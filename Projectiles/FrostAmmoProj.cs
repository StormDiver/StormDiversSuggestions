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
            DisplayName.SetDefault("Frost Bullet");
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

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            projectile.tileCollide = false;
            projectile.ranged = true;
            
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
           
            {
                float speedX = projectile.velocity.X;
                float speedY = projectile.velocity.Y;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(16));
                
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
            DisplayName.SetDefault("Frost Bullet");
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

    //_____________________________________________________________________________________________________________________________________________________

    public class FrostArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 1;
            projectile.arrow = true;
            projectile.tileCollide = true;

            projectile.ranged = true;

            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            //Creates no immunity frames
           

            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }
       
        public override void AI()
        {
           
               /* int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 0.7f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;*/
        }
        
       
       

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);

            for (int i = 0; i < 10; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 0.7f)];
                dust.noGravity = true;

            }

            int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-3f, 3f);
                float speedY = Main.rand.NextFloat(-3f, 3f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, ProjectileID.CrystalShard, (int)(projectile.damage * 0.3), 0f, projectile.owner, 0f, 0f);
            }

        }
       
    }

}
