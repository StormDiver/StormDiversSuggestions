using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class TungstenBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TungstenBullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;

            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;

            drawOffsetX = 2;
            drawOriginOffsetY = -0;
        }
      
       
       
        public override void AI()
        {
           
           

            /*
                if (Main.rand.Next(75) == 0)
                {

                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 1.25), 0f, projectile.owner, 0f, 0f);
                }
            */
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

        

    }
    public class IronShotProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("IronBullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;

            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;


            projectile.tileCollide = true;


            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.WoodenArrowFriendly;
            drawOffsetX = 2;
            drawOriginOffsetY = -0;

        }



        public override void AI()
        {


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);

        }



    }
    public class LeadShotProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LeadBullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;

            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;


            projectile.tileCollide = true;


            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.WoodenArrowFriendly;

            drawOffsetX = 2;
            drawOriginOffsetY = -0;
        }



        public override void AI()
        {



            /*
                if (Main.rand.Next(75) == 0)
                {

                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 1.25), 0f, projectile.owner, 0f, 0f);
                }
            */
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);

        }



    }

}
