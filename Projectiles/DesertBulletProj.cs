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
            DisplayName.SetDefault("DesertBullet");
          
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
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

                    float numberProjectiles = 2 + Main.rand.Next(2);
                    float rotation = MathHelper.ToRadians(5);
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        float speedX = projectile.velocity.X;
                        float speedY = projectile.velocity.Y;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X * 10f, perturbedSpeed.Y * 10f, mod.ProjectileType("DesertBulletProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
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

    }
    //___________________________________________________________________________________________
    public class DesertBulletProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DesertBullet");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
           
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
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

    }
}