using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
    public class HellMiniBossProj1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellSoul Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            Main.projFrames[projectile.type] = 4;

        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;

            
            projectile.light = 0.4f;
            
            projectile.friendly = false;
            projectile.hostile = true;
            
            projectile.penetrate = 1;
            
            
            projectile.tileCollide = true;
            projectile.scale = 1f;


            projectile.extraUpdates = 0;
            
           
            projectile.timeLeft = 180;
            //aiType = ProjectileID.LostSoulHostile;
            projectile.aiStyle = 0;
            // projectile.CloneDefaults(452);
            //aiType = 452;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }

        int speedup;
        public override void AI()
        {


            speedup++;
            if (speedup <= 20)
            {
                projectile.velocity.X *= 1.06f;
                projectile.velocity.Y *= 1.06f;

            }



            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 0.8f;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            AnimateProjectile();


        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            for (int i = 0; i < 15; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 173, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 130, default, 1.2f);
                dust.noGravity = true;
            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 300);

        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                dust.scale = 2;
                dust.velocity *= 2;
            }

        }
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }*/
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
        }

    }
    //_________________________________________________________________
    public class HellMiniBossProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellSoul Giant Flame");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            Main.projFrames[projectile.type] = 4;

        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;


            projectile.light = 0.4f;

            projectile.friendly = false;
            projectile.hostile = true;

            projectile.penetrate = 1;


            projectile.scale = 1.25f;


            projectile.extraUpdates = 1;
            projectile.tileCollide = false;

            projectile.timeLeft = 300;
            //aiType = ProjectileID.LostSoulHostile;
            projectile.aiStyle = -1;
            // projectile.CloneDefaults(452);
            //aiType = 452;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }



        int hometime;
        public override void AI()
        {


            hometime++;

            projectile.rotation = projectile.velocity.X / 20;

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.fadeIn = 1f;


            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
           
            if (hometime >= 30 && hometime <= 180)
            {

                for (int i = 0; i < 100; i++)
                {
                    Player target = Main.player[i];
                    //If the npc is hostile

                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.Center.X - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 750f && target.active)
                    {

                        distance = 0.5f / distance;

                        //Multiply the distance by a multiplier proj faster
                        shootToX *= distance * 7;
                        shootToY *= distance * 6;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    
                        
                  

                }
                
            }

            AnimateProjectile();


        }
        /* private void AdjustMagnitude(ref Vector2 vector)
         {
             float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
             if (magnitude > 4f)
             {
                 vector *= 4f / magnitude;
             }
         }*/
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 300);

            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                dust.scale = 2;
                dust.velocity *= 2;
            }

        }
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, projectile.frame, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }*/
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
        }

    }
}
