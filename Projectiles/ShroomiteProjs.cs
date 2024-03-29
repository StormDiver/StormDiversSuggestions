﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class ShroomBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Bullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 3;
            
            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

        }
        int reflect = 4;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
        int dusttime;
        public override void AI()
        {

             dusttime++;
           
            if (dusttime > 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                  

                    int dust = Dust.NewDust(new Vector2(X, Y), 0, 0, 206, 0, 0, 100, default, 1f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;


                }
            }

           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 25; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 206, default, 1.2f);
            }
            projectile.damage = (projectile.damage * 9) / 10;
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }

       

    }
    //______________________________________________________________________________________
    public class ShroomArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Arrow");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 2;
            projectile.arrow = true;
            projectile.tileCollide = true;

            projectile.ranged = true;

            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            //Creates no immunity frames
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;

            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        int spwmushroom = 8;
        
        public override void AI()
        {

            spwmushroom--;
            if (Main.rand.Next(12) == 0)
            {
                
                
                int speedX = 0;
                int speedY = 0;

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX, speedY, mod.ProjectileType("ShroomMush"), (int)(projectile.damage * 1.25), 0f, projectile.owner, 0f, 0f);
                spwmushroom = 8;
            }
           /* trail++;
            if (trail > 2)
            {
                Dust dust;

                Vector2 position = projectile.Center;
                dust = Terraria.Dust.NewDustPerfect(position, 206, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;
            }*/
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 130, default, 1.2f);
            }
            projectile.damage = (projectile.damage * 9) / 10;

        }

        public override void Kill(int timeLeft)
        {

            int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("ShroomArrow")) : 0;
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
           
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomArrowProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
    }
    //______________________________________________________________________________________________
    public class ShroomGrenProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Grenade");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;


            projectile.light = 0.1f;
            projectile.friendly = true;

            projectile.CloneDefaults(133);
            aiType = 133;

            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 450;

        }
        

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

           
             
                //Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.5f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.5f;
                }
            
           // Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 56);
            return false;
        }
        int timeleft = 240;
        public override void AI()
        {
            timeleft--;
            if (timeleft <= 0)
            {
                projectile.Kill();
            }
            if ((projectile.velocity.X >= 0.5 || projectile.velocity.X <= -0.5) || (projectile.velocity.Y >= 0.5 || projectile.velocity.Y <= -0.5))
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 206, 0f, 0f, 100, default, 1.5f);
                //Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                // Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);


            for (int i = 0; i < 25; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 31);
                dust.noGravity = true;
                dust.scale = 1.5f;
                dust.velocity *= 4f;
                dust.fadeIn = 1f;

            }
            for (int i = 0; i < 25; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 206);
                dust.noGravity = true;

                dust.scale = 2f;
                dust.velocity *= 4f;
                dust.fadeIn = 1f;

            }
            if (projectile.owner == Main.myPlayer)
            {
                int numberProjectiles = 8 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("ShroomMush"), (int)(projectile.damage * 0.4f), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomGrenProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //______________________________________________________________________________________________
    public class ShroomRocketProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Rocket");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;


            projectile.light = 0.2f;
            projectile.friendly = true;

            // projectile.CloneDefaults(134);
            // aiType = 134;
            projectile.aiStyle = 0;
            projectile.extraUpdates = 1;
            //aiType = ProjectileID.Bullet;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;
            
            projectile.timeLeft = 300;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return false;
        }
        int timeleft = 240;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            timeleft--;
            if (timeleft <= 0)
            {
                projectile.Kill();
            }
            /*for (int i = 0; i < 5; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 0, 0, 206);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0.1f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 1.5f;
            }*/
            for (int i = 0; i < 2; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X - 5, projectile.Center.Y - 5), 10, 10, 206, 0f, 0f, 100, default, 1.5f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 0.5f;

                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;

            }
            int dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex2].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex2].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex2].noGravity = true;
            

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item14, projectile.position);



            for (int i = 0; i < 25; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 31);
                dust.noGravity = true;
                dust.scale = 1.5f;
                dust.velocity *= 4f;
                dust.fadeIn = 1f;

            }
            for (int i = 0; i < 25; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 206);
                dust.noGravity = true;

                dust.scale = 2f;
                dust.velocity *= 4f;
                dust.fadeIn = 1f;

            }
            
            if (projectile.owner == Main.myPlayer)
            {
                int numberProjectiles = 8 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("ShroomMush"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomRocketProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //______________________________________________________________________________________________
    public class ShroomMush : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spinning Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.CloneDefaults(131);
            aiType = 131;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.melee = false;
            projectile.timeLeft = 50;
            projectile.tileCollide = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 50;
            return color;

        }

    }
    //____________________________________________________________________________________________________________________________________________
    public class ShroomSetRocketProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Set Rocket");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;

            projectile.aiStyle = 0;
            projectile.light = 0.1f;

            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = -1;


            projectile.tileCollide = true;


            projectile.ranged = true;
            projectile.extraUpdates = 1;
            //aiType = ProjectileID.Bullet;


        }


        // int dusttime = 10;
        public override void AI()
        {


            /*  Dust dust;

              Vector2 position = projectile.Center;
              dust = Terraria.Dust.NewDustPerfect(position, 206, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
              dust.noGravity = true;*/

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 206);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0.1f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 1f;
            }
            
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 175;
                projectile.height = 175;
                projectile.Center = projectile.position;


                projectile.knockBack = 3f;

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
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);

            projectile.alpha = 255;
            for (int i = 0; i < 50; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 31);
                dust.noGravity = true;
                dust.scale = 2.5f;
                dust.velocity *= 4f;
                dust.fadeIn = 1f;

            }
            for (int i = 0; i < 50; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 206);
                dust.noGravity = true;

                dust.scale = 3f;
                dust.velocity *= 4f;
                dust.fadeIn = 1.5f;

            }
            for (int i = 0; i < 80; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 206, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
            }

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 16;
            projectile.height = 16;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

        }
        public override Color? GetAlpha(Color lightColor)
        {



            return Color.White;

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }


    }
    //____________________________________________________________________________________________________________________________________________
    public class ShroomBowArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Glowing arrow");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;


            //projectile.light = 0.6f;
            projectile.friendly = true;

             //projectile.CloneDefaults(225);
            //aiType = 225;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;
            projectile.penetrate = 2;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.timeLeft = 300;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 1.3f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 1.3f;
                }
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 56);
            return false;
        }


        public override void AI()
        {
            /*for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile

                //Get the shoot trajectory from the projectile and target
                float shootToX = target.Center.X - projectile.Center.X;
                float shootToY = target.Center.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the live targeted npc and the projectile is less than 480 pixels
                if (distance < 300f && target.active)
                {

                    distance = 0.5f / distance;

                    //Multiply the distance by a multiplier proj faster
                    shootToX *= distance * 12;
                    shootToY *= distance * 12;

                    //Set the velocities to the shoot values
                    projectile.velocity.X = shootToX;
                    projectile.velocity.Y = shootToY;
                }

            }*/
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;


        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
           
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }
       
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }

    }

}
