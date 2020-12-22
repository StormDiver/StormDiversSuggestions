using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    public class WebProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Web");

        }
        public override void SetDefaults()
        {

            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.magic = true;
            projectile.timeLeft = 600;
            projectile.aiStyle = 14;
            //aiType = ProjectileID.WoodenArrowFriendly;
            projectile.ignoreWater = true;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        int rotate;
        bool stick;
        public override void AI()
        {
            if (!stick)
            {
                rotate += 1;
                projectile.rotation = rotate * 0.2f;
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;

                }
            }
            
            
            /* Dust dust2;
             // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
             Vector2 position2 = projectile.Center;
             dust2 = Terraria.Dust.NewDustPerfect(position2, 45, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
             dust2.noGravity = true;*/
             if (stick)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //stick = true;
            projectile.damage -= 2;

        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            //target.AddBuff(BuffID.Wet, 300);
            //stick = true;
        }

        

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            if (!stick)
            {
                projectile.penetrate = 5;
                for (int i = 0; i < 5; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);
                    Main.PlaySound(4, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 0.5f, 0.2f);


                }
            }
            stick = true;
            
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(4, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 0.5f, 0.2f);
                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);
                   
                   

                }

            }

        }
        
    }
   
}
