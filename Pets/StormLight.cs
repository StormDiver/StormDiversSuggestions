using StormDiversSuggestions.Basefiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Pets
{

    public class StormLightItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Helmet");
            Tooltip.SetDefault("Summons something unthinkable");
    
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish);
            item.width = 24;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            
            item.shoot = ProjectileType<StormLightProj>();
            item.buffType = BuffType<StormLightBuff>();
            item.rare = ItemRarityID.Red;

        }



        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.VortexRifleman)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormLightItem"));
                       
                    }
                }
            }
        }
    }

    public class StormLightBuff : ModBuff
    {
        public override void SetDefaults()
        {
            
            DisplayName.SetDefault("Baby Storm Diver");
            Description.SetDefault("It's not cute, it's not!!!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<StormPlayer>().stormHelmet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<StormLightProj>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<StormLightProj>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
    public class StormLightProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Storm Diver");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.DD2PetGato);
            aiType = ProjectileID.DD2PetGato;
            projectile.width = 34;
           projectile.height = 40;
            projectile.scale = 1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.petFlagDD2Gato = false; 
            return true;
        }
        
        public override void AI()
        {
            //Lighting.AddLight(projectile.Center, (255 - projectile.alpha) * 0f / 255f, (255 - projectile.alpha) * 0.9f / 255f, (255 - projectile.alpha) * 0.9f / 255f);
            Player player = Main.player[projectile.owner];
            StormPlayer modPlayer = player.GetModPlayer<StormPlayer>();
            if (player.dead)
            {
                modPlayer.stormHelmet = false;
            }
            if (modPlayer.stormHelmet)
            {
                projectile.timeLeft = 2;
            }
            if (projectile.velocity.X >= 8 || projectile.velocity.X <= -8 || projectile.velocity.Y <= -5)
            {
                /* Dust dust;
                 // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                 Vector2 position = projectile.Center;
                 dust = Terraria.Dust.NewDustPerfect(position, 111, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
                 dust.noGravity = true;*/
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = (new Vector2(projectile.Center.X - 3, projectile.Center.Y - 3));
                dust = Terraria.Dust.NewDustDirect(position, 6, 6, 206, projectile.velocity.X * -0.3f, 3, 0, new Color(255, 255, 255), 1f);
                
                
                
            }
            //AnimateProjectile();

        }
         /*public void AnimateProjectile() // Call this every frame, for example in the AI method.
         {
             projectile.frameCounter++;
             if (projectile.frameCounter >= 8) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
             {
                 projectile.frame++;
                 projectile.frame %= 7; // Will reset to the first frame if you've gone through them all.
                 projectile.frameCounter = 0;
             }
         }*/

        /**public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)//Doesn't work >:(
        {
            Texture2D texture = mod.GetTexture("Pets/StormLightProj_Glowmask");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, projectile.frame * (Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height)
           , Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 100);
           

        }*/
       
         public override Color? GetAlpha(Color lightColor)
         {
             return Color.White;
         }
    }
}

