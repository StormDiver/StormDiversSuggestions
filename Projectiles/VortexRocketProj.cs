using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
   
    public class VortexRocketProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Rocket");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;


            projectile.light = 0.6f;
            projectile.friendly = true;

            //projectile.CloneDefaults(616);
            //aiType = 616;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 300;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;


            projectile.extraUpdates = 1;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }


        int dusttime;
        public override void AI()
        {
            dusttime++;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (dusttime > 1)
            {
                for (int i = 0; i < 15; i++)
                {
                    float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                    float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                    int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 229);
                    //Main.dust[num165].alpha = alpha;
                    Main.dust[j].position.X = x2;
                    Main.dust[j].position.Y = y2;
                    Main.dust[j].velocity *= 0.1f;
                    Main.dust[j].noGravity = true;
                    Main.dust[j].scale = 1f;
                }
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 150;
                projectile.height = 150;
                projectile.Center = projectile.position;


                projectile.knockBack = 6f;

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
            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);

            projectile.alpha = 255;

            for (int i = 0; i < 50; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 80; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 229, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
                dust.fadeIn = 1f;

            }

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 16;
            projectile.height = 16;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {

            if (projectile.timeLeft > 3)
            {
                Texture2D texture = mod.GetTexture("Projectiles/VortexRocketProj_Glow");

                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            if (projectile.timeLeft > 3)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

                }
            }
            return true;

        }
    }

    //________________________________________________________________________________________________________________________________________________________________________________________________________________
    public class VortexRocketProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Rocket");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;


            projectile.light = 0.6f;
            projectile.friendly = true;

            //projectile.CloneDefaults(616);
            //aiType = 616;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 300;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;


            projectile.extraUpdates = 1;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }


        int dusttime;
        public override void AI()
        {
            dusttime++;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (dusttime > 2)
            {
                for (int i = 0; i < 25; i++)
                {
                    float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                    float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                    int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 229);
                    //Main.dust[num165].alpha = alpha;
                    Main.dust[j].position.X = x2;
                    Main.dust[j].position.Y = y2;
                    Main.dust[j].velocity *= 0.1f;
                    Main.dust[j].noGravity = true;
                    Main.dust[j].scale = 1f;
                }
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 200;
                projectile.height = 200;
                projectile.Center = projectile.position;


                projectile.knockBack = 6f;

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
            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);
            
            projectile.alpha = 255;

            for (int i = 0; i < 60; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 120; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 229, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
                dust.fadeIn = 2f;

            }

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 16;
            projectile.height = 16;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {

            if (projectile.timeLeft > 3)
            {
                Texture2D texture = mod.GetTexture("Projectiles/VortexRocketProj_Glow");

                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            if (projectile.timeLeft > 3)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

                }
            }
            return true;

        }
    }

}
