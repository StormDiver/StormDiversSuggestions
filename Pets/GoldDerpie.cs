using StormDiversSuggestions.Basefiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace StormDiversSuggestions.Pets
{

    public class DerplingVine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Vine");
            Tooltip.SetDefault("Seems to be infused with some strange energy");
            
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.width = 16;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 7, 50, 0);
           
            
            item.shoot = ProjectileType<GoldDerpie>();
            item.buffType = BuffType<GoldDerpieBuff>();
            item.rare = ItemRarityID.Yellow;
        }



        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }

    public class GoldDerpieBuff : ModBuff
    {
        public override void SetDefaults()
        {
            
            DisplayName.SetDefault("Golden Derpie");
            Description.SetDefault("So shiny and bouncy!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<StormPlayer>().goldDerpie = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<GoldDerpie>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<GoldDerpie>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
    public class GoldDerpie : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Derpie");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.EyeSpring);
            aiType = ProjectileID.EyeSpring;
            projectile.width = 34;
           projectile.height = 24;
            drawOffsetX = -0;
            drawOriginOffsetY = -8;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.eyeSpring = false; 
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            StormPlayer modPlayer = player.GetModPlayer<StormPlayer>();
            if (player.dead)
            {
                modPlayer.goldDerpie = false;
            }
            if (modPlayer.goldDerpie)
            {
                projectile.timeLeft = 2;
            }
           /* if (dustime >= 5 && !projectile.tileCollide)
                
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 19);
                Main.dust[dust].velocity *= -1f;
                dustime = 0;
            }*/
           if (Main.rand.Next(15) == 0)
            {
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 124);

                    dust.scale = 0.5f;
                    dust.velocity *= 0;

                }
            }

        }
    }
}

