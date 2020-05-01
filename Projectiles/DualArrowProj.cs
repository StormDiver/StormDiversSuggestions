using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class DualArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DualArrow");
           
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.light = 1f;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 2000;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.arrow = true;
           
            drawOffsetX = -2;
            drawOriginOffsetY = -0;
        }
        int split = 0;
        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;
            
            split++;
            
            if (split == 40)
            {
                if (Main.rand.Next(3) == 0)
                {

                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 5);
                    for (int i = 0; i < 10; i++)
                    {

                        Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                        var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 129);
                        dust2.noGravity = true;
                    }

                   
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                   
                    for (int i = 0; i < 2; i++)
                    {
                        float speedX = projectile.velocity.X;
                        float speedY = projectile.velocity.Y;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.WoodenArrowFriendly, projectile.damage, projectile.knockBack, Main.myPlayer);
                    }
                    projectile.Kill();

                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            
        }

       

        public override void Kill(int timeLeft)
        {



            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 129);
                dust2.noGravity = true;
            }
        }
       
    }
   
}