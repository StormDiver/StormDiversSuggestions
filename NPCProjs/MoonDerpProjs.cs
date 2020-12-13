using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
    public class MoonDerpBoltProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

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
            projectile.scale = 1.1f;

            
            projectile.extraUpdates = 1;
            
           
            projectile.timeLeft = 600;
            //aiType = ProjectileID.LostSoulHostile;
            projectile.aiStyle = -1;
            // projectile.CloneDefaults(452);
            //aiType = 452;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        
       
        
        
        public override void AI()
        {
            
          
            
          
          

            for (int i = 0; i < 10; i++)
            {
                float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;


                int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 229, 0, 0, 100, default, 1f);
                Main.dust[dust].position.X = X;
                Main.dust[dust].position.Y = Y;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;

            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
         
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            //projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 55);
            for (int i = 0; i < 15; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 229, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
               
                
            }

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
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
        }

    }
    //_________________________________________________________________
    public class MoonDerpEyeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling Eye");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

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
            projectile.scale = 1.1f;


            projectile.extraUpdates = 1;


            projectile.timeLeft = 600;
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



            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 229, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.fadeIn = 1f;


            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (hometime >= 120)
            {
                for (int i = 0; i < 200; i++)
                {
                    Player target = Main.player[i];
                    //If the npc is hostile

                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.Center.X - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 1200f && target.active && hometime >= 120)
                    {

                        distance = 0.5f / distance;

                        //Multiply the distance by a multiplier proj faster
                        shootToX *= distance * 10;
                        shootToY *= distance * 0;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                    if (projectile.Center.Y >= target.Center.Y)
                    {
                        projectile.velocity.Y = 4;
                    }
                    if (projectile.Center.Y < target.Center.Y)
                    {
                        projectile.velocity.Y = 3;
                    }
                }
                
            }

        }
       /* private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 4f)
            {
                vector *= 4f / magnitude;
            }
        }*/
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 43);
            for (int i = 0; i < 40; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                int dust2 = Dust.NewDust(projectile.Center - projectile.velocity, projectile.width, projectile.height, 229, 0f, 0f, 200, default, 1.2f);
                Main.dust[dust2].velocity *= -5f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].fadeIn = 1f;

            }

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
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
        }

    }
}
