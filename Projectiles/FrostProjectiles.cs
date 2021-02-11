using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Basefiles;



namespace StormDiversSuggestions.Projectiles
{

    public class FrostGrenadeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Grenade");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;


            projectile.light = 0.1f;
            projectile.friendly = true;

            projectile.aiStyle = 2;

            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 200;

        }
       
       
        public override void AI()
        {

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 100;
                projectile.height = 100;
                projectile.Center = projectile.position;

                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                projectile.knockBack = 3f;
                
            }
            else
            {
                
                if (Main.rand.NextBool())
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    
                    dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                   
                }
            }
            }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            

            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
            var player = Main.player[projectile.owner];
            if (Main.rand.Next(1) == 0) // the chance
            {
               
                    target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);

                

            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);



            for (int i = 0; i < 60; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            for (int i = 0; i < 30; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }

        }

    }
    //___________________________________________________________________________________________________________________________________
    public class FrostSpinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Spinner");
        }
        public override void SetDefaults()
        {

            projectile.width = 150;
            projectile.height = 150;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.ownerHitCheck = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            var player = Main.player[projectile.owner];
            if (Main.rand.Next(1) == 0) // the chance
            {
                
                    target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);

                

            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);
        }
        // float hitbox = 150;
        // bool hitboxup;
        // bool hitboxdown;
        public override void AI()
        {

            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)
            {
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 7);
                projectile.soundDelay = 45;
            }

            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            Lighting.AddLight(projectile.Center, 0f, 0.5f, 0.5f);
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;
            projectile.spriteDirection = player.direction;
            projectile.rotation += 0.2f * player.direction;
            /* if (projectile.rotation > MathHelper.TwoPi)
             {
                 projectile.rotation -= MathHelper.TwoPi;
             }
             else if (projectile.rotation < 0)
             {
                 projectile.rotation += MathHelper.TwoPi;
             }*/
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;


            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

            /* if (hitbox == 160)
             {
                 hitboxup = false;
                 hitboxdown = true;
             }
             if (hitbox == 150)
             {
                 hitboxup = true;
                 hitboxdown = false;
             }
             if (hitboxup == true)
             {
                 for (int i = 0; i < 10; i++)
                 {
                     hitbox++;
                 }
             }
             if (hitboxdown == true)
             {
                 hitbox--;
             }
             projectile.width = (int)hitbox;
             projectile.height = (int)hitbox;*/
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
    //___________________________________________________________________________________________________________________________________
    public class FrostStarProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Frizbee");
        }
        public override void SetDefaults()
        {

            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.scale = 1f;
           projectile.CloneDefaults(272);
           aiType = 272;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -6;
            drawOriginOffsetY = -6;
        }

        
        public override void AI()
        {
            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 0.7f);
            Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].noGravity = true;


            projectile.rotation += (float)projectile.direction * -0.6f;


            projectile.tileCollide = true;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            for (int i = 0; i < 10; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 0.7f)];


            }
            {
                var player = Main.player[projectile.owner];
                if (Main.rand.Next(1) == 0) // the chance
                {
                   
                        target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);

                    

                }
            }
            for (int i = 0; i < 3; i++)
            {

                float speedX = Main.rand.NextFloat(-5f, 5f);
                float speedY = Main.rand.NextFloat(-5f, 5f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, ProjectileID.CrystalShard, (int)(projectile.damage * 0.33f), 0f, projectile.owner, 0f, 0f);
            }
            projectile.Kill();

        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            
                {
                    target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);

                }
        
            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            for (int i = 0; i < 10; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 0.7f)];


            }
            for (int i = 0; i < 3; i++)
            {

                float speedX = Main.rand.NextFloat(-3f, 3f);
                float speedY = Main.rand.NextFloat(-3f, 3f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, ProjectileID.CrystalShard, (int)(projectile.damage * 0.3), 0f, projectile.owner, 0f, 0f);
            }
            projectile.Kill();
            return false;
        }
       
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);

               

            }



        }
    }
    //___________________________________________________________________________________________________________________________________
    public class Frostthrowerproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 125;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default, 3f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            var player = Main.player[projectile.owner];
            if (Main.rand.Next(1) == 0) // the chance
            {
                
                    target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);

                

            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
    //___________________________________________________________________________________________________________________________________
    public class FrostAccessProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Fragment");
        }
        public override void SetDefaults()
        {

            projectile.width = 9;
            projectile.height = 9;
            projectile.friendly = true;
            projectile.penetrate = 2;
           
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -2;
            drawOriginOffsetY = -2;
        }

        public override void AI()
        {
            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 0.7f);
            Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].noGravity = true;


            projectile.rotation += (float)projectile.direction * -0.2f;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 180);

            
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 180);
        }


        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);

                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 187);
                }

            }
        }
    }
    //___________________________________________________________________________________________________________________________________
    //___________________________________________________________________________________________________________________________________
    //___________________________________________________________________________________________________________________________________

}