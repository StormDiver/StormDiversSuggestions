using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs
{
    public class VortCannonProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortexian Rocket");
            
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;

            
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
                float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 229);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0.5f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 0.8f;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
            AnimateProjectile();
          /*
            for (int i = 0; i < 200; i++)
            {
                Player target = Main.player[i];
                //If the npc is hostile
                
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.Center.X - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                
                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 600f && target.active && hometime >= 120)
                    {
                        
                        distance = 0.5f / distance;

                        //Multiply the distance by a multiplier proj faster
                        shootToX *= distance * 6;
                        shootToY *= distance * 6;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                
            }*/
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 40; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                int dust2 = Dust.NewDust(projectile.Center - projectile.velocity, projectile.width, projectile.height, 229, 0f, 0f, 200, default, 0.8f);
                Main.dust[dust2].velocity *= -5f;
                Main.dust[dust2].noGravity = true;
            }

        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 5; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

    }
}
