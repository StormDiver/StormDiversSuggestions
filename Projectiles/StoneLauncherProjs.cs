using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class StoneProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Boulder");
        }
        public override void SetDefaults()
        {

            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14; 
            aiType = ProjectileID.WoodenArrowFriendly;
           
        }

        public override void AI()
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }


        }




        public override bool OnTileCollide(Vector2 oldVelocity)
            
        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
                }

            }
            {
                
                for (int i = 0; i < 2; i++)
                {

                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.3f, .5f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.3f, .5f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneFragProj"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
    }
    //________________________________________________________________________
    public class StoneHardProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hard Stone Boulder");
        }
        public override void SetDefaults()
        {

            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.scale = 0.75f;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;
        }

        public override void AI()
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 255, 255), 1.2f)];
                dust.noGravity = true;
            }

            projectile.width = 28;
            projectile.height = 28;
        }




        int reflect = 2;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.7f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.7f;
                }
            }
            if (reflect >= 1)
            {
                int numberProjectiles = 4 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {

                    float speedX = Main.rand.NextFloat(-5f, 5f);
                    float speedY = Main.rand.NextFloat(-5f, 5f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneFragProj"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
                }
            }
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BoulderDebuff"), 480);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("BoulderDebuff"), 800);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
            }
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
                }

            }

            int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-5f, 5f);
                float speedY = Main.rand.NextFloat(-5f, 5f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneFragProj"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
            }

        }
    }
    //_____________________________________________________________________________________________________
    public class StoneSuperProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Stone Boulder");
        }
        public override void SetDefaults()
        {
            projectile.light = 0.8f;
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.scale = 0.75f;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 180;
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;

        }
       
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 174, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1.5f);
            dust.noGravity = true;
           

            projectile.rotation += (float)projectile.direction * 0.2f;

            projectile.width = 28;
            projectile.height = 28;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBoulderDebuff"), 600);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 55);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperBoulderDebuff"), 800);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 55);
            }
        }

        int reflect = 2;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.9f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.9f;
                }
            }
            if (reflect >= 1)
            {
                int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {

                    float speedX = Main.rand.NextFloat(-7f, 7f);
                    float speedY = Main.rand.NextFloat(-7f, 7f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneFragSuperProj"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
                }
            }
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 55);
                }

            }

            int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-7f, 7f);
                float speedY = Main.rand.NextFloat(-7f, 7f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneFragSuperProj"), (int)(projectile.damage * 0.4), 0f, projectile.owner, 0f, 0f);
            }


        }
    }
    //______________________________________________________________________________________
    public class StoneFragProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Fragment");
        }
        public override void SetDefaults()
        {

            projectile.width = 9;
            projectile.height = 9;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -2;
            drawOriginOffsetY = -2;
        }
        
        public override void AI()
        {
            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 255, 255), 0.8f)];
                dust.noGravity = true;
            }
            projectile.rotation += (float)projectile.direction * 0.2f;
        }




        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(21, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 5; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
                }

            }
        }
    }
    //_________________________________________________________________________________________________
    public class StoneFragSuperProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Fragment");
        }
        public override void SetDefaults()
        {
            projectile.light = 0.2f;
            projectile.width = 9;
            projectile.height = 9;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 180;
            drawOffsetX = -3;
            drawOriginOffsetY = -3;
        }
        
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 174, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * 0.2f;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBoulderDebuff"), 180);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("SuperBoulderDebuff"), 400);
        }


        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(21, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 3; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 55);
                }

            }
        }
    }
}
