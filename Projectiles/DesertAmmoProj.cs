using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class DesertBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Bullet");
          
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            aiType = ProjectileID.Bullet;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.extraUpdates = 1;
            projectile.light = 0.3f;
        }
        int split = 0;
        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;


            split++;

            if (split == 18)
            {

                if (Main.rand.Next(2) == 0)
                {

                    for (int i = 0; i < 10; i++)
                    {

                        Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                        var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                        dust2.noGravity = true;
                    }

                    float numberProjectiles = 2;
                    float rotation = MathHelper.ToRadians(4);
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        float speedX = projectile.velocity.X;
                        float speedY = projectile.velocity.Y;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) ;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DesertBulletProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                    projectile.Kill();

                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust2.noGravity = true;
            }
            return true;
        }
        public override void Kill(int timeLeft)
        {


            Main.PlaySound(SoundID.Item10, projectile.position);

        }
        public override Color? GetAlpha(Color lightColor)
        {



            return Color.White;

        }

    }
    //___________________________________________________________________________________________
    public class DesertBulletProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Bullet");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
           
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 200;
            aiType = ProjectileID.Bullet;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.extraUpdates = 1;
            projectile.light = 0.3f;
        }

        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;



        }
      

     

        public override void Kill(int timeLeft)
        {


            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust2.noGravity = true;
            }

        }
        public override Color? GetAlpha(Color lightColor)
        {



            return Color.White;

        }

    }
    //____________________________________________________________________________
    public class DesertArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 2;
            projectile.arrow = true;
            projectile.tileCollide = true;

            projectile.ranged = true;

            projectile.arrow = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }
        int spinspeed = 0;
        

        int reflect = 3;
        bool spin = false;
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
                    projectile.velocity.X = -oldVelocity.X * 1.1f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 1.1f;
                }
                spin = true;
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }

        public override void AI()
        {


            if (spin)
            {
               
                spinspeed++;
                projectile.rotation = (0.4f * spinspeed) * projectile.direction;
                projectile.penetrate = -1;
             
                drawOriginOffsetY = -16;
              


                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, 0f, 0f, 100, default, 0.7f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }



        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust2.noGravity = true;
            }
        }

    }
    
}