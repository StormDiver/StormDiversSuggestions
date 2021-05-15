using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Pets;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items.Minions
{
    public class SpaceRockMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Asteroid Minion");
            Description.SetDefault("A mini Asteroid will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ProjectileType<SpaceRockMinionProj>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    public class SpaceRockMinion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Staff");
            Tooltip.SetDefault("Summons a mini Asteroid to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 46;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 25;
            item.useAnimation = 25;
            item.autoReuse = true;
            // item.UseSound = SoundID.Item43;

            item.damage = 45;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item43;

            
            item.mana = 10;

            item.noMelee = true; 
            item.summon = true;

            item.UseSound = SoundID.Item45;

            item.buffType = BuffType<SpaceRockMinionBuff>();
            item.shoot = mod.ProjectileType("SpaceRockMinionProj");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 8);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            player.AddBuff(item.buffType, 2);

            position = Main.MouseWorld;

            return true;



        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }

    //CCOPY Spazmini MINION AI
    public class SpaceRockMinionProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Minion");
            // Sets the amount of frames this minion has on its spritesheet
            Main.projFrames[projectile.type] = 4;
            // This is necessary for right-click targeting
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

            // These below are needed for a minion
            // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;
            // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            // Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
            ProjectileID.Sets.Homing[projectile.type] = false;

            
        }

        public sealed override void SetDefaults()
        {
            // Only controls if it deals damage to enemies on contact (more on that later)
            projectile.friendly = true;
            // Only determines the damage type
            projectile.minion = true;
            // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            projectile.minionSlots = 1f;
            // Needed so the minion doesn't despawn on collision with enemies or tiles
            projectile.penetrate = -1;

            projectile.CloneDefaults(388);
            aiType = 388;
        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        int dustspeed;
        int projspeed;
        public override void AI()
        {
            projspeed++;
            
            projectile.minionSlots = 1f;
            Player player = Main.player[projectile.owner];
            // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType<SpaceRockMinionBuff>());
            }
            if (player.HasBuff(BuffType<SpaceRockMinionBuff>()))
            {
                projectile.timeLeft = 2;
            }
            projectile.width = 38;
            projectile.height = 22;
            projectile.Opacity = 1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

          
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;

           
            if (projectile.velocity.X > 6 || projectile.velocity.X < -6 || projectile.velocity.Y > 6 || projectile.velocity.Y < -6)
            {
                dustspeed = 1;
            }
            else
            {
                dustspeed = 5;
            }
            if (Main.rand.Next(dustspeed) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                dust2.noGravity = true;
                dust2.scale = 1.5f;
                dust2.velocity *= 1;

            }
     
            int frameSpeed = 20;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            //projectile.velocity.X *= 0.5f;
            //projectile.velocity.Y *= 0.5f;
            for (int i = 0; i < 20; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1.5f);
                dust.noGravity = true;
            }
            if (projspeed >= 90)
            {
                Projectile.NewProjectile(target.Right.X + 200, target.Center.Y, -15, 0f, mod.ProjectileType("SpaceRockMinionProj2"), projectile.damage, 0, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(target.Left.X - 200, target.Center.Y, 15, 0f, mod.ProjectileType("SpaceRockMinionProj2"), projectile.damage, 0, Main.myPlayer, 0f, 0f);

                projspeed = 0;
            }
        }


    }
    //__________________________________________________________________________________________________________________________________________________
    public class SpaceRockMinionProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Minion Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 14;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.light = 0.4f;
            projectile.scale = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -6;
            projectile.tileCollide = false;
        }
        int rotate;
        public override void AI()
        {
            var player = Main.player[projectile.owner];

            if (projectile.position.Y > (player.position.Y - 200))
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;

            }
            rotate += 2;
            projectile.rotation = rotate * 0.1f;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {


                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= -0.3f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust2].velocity *= -0.3f;

                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }

        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
           
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 1f);
           

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * 0.5f; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
    }
}