using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Projectiles
{
   
    public class QuackProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Duck");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.magic = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            
        }
    
        int speedup = 0;
        public override void AI()
        {
            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;



            speedup++;
            if (speedup <= 50)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;
                
               
            }

          
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }


        public override void Kill(int timeLeft)
        {

            Main.PlaySound(30, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }

        }
       

    }
    
   
}
