using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class FrostBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostBullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;

            projectile.aiStyle = 1;
            projectile.light = 0.4f;
            
            projectile.friendly = true;
            projectile.timeLeft = 180;
            projectile.penetrate = 2;

            //projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            projectile.tileCollide = false;
            projectile.ranged = true;
            
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = true;

        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
           
            {
                float speedX = projectile.velocity.X;
                float speedY = projectile.velocity.Y;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X * 10f, perturbedSpeed.Y * 10f, mod.ProjectileType("FrostBulletProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            projectile.Kill();
            return false;
        }
        // int dusttime = 10;
        public override void AI()
        {
            
            {
                //Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }

        public override void Kill(int timeLeft)
        {

            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }

       

    }

    //_____________________________________________________________________________________________________________________________________________________
    public class FrostBulletProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostBullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;

            projectile.aiStyle = 1;
            projectile.light = 0.4f;

            projectile.friendly = true;
            projectile.timeLeft = 28;
            projectile.penetrate = 2;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;

            projectile.tileCollide = false;

            projectile.ranged = true;

            aiType = ProjectileID.Bullet;


        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            return false;
        }
        // int dusttime = 10;
        public override void AI()
        {

            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }

        public override void Kill(int timeLeft)
        {

            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }



    }

}
