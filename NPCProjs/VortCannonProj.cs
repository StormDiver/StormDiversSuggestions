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
            
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            
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
                Main.dust[j].velocity *= 0.3f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 0.8f;
            }
            if (projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 100;
                projectile.height = 100;
                projectile.Center = projectile.position;


                projectile.knockBack = 6f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
         
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
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
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74);
            
            for (int i = 0; i < 60; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 229, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
                dust.fadeIn = 1f;

            }

        }

      
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}
