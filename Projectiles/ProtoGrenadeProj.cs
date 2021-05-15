using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{

    public class ProtoGrenadeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Proto Grenade");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;


           
            projectile.friendly = true;

            projectile.aiStyle = 2;

            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 200;

        }

        int shrapnel = 0;
        public override void AI()
        {
            shrapnel++;
            if (shrapnel == 25)
            {
                if (Main.rand.Next(10) == 0)
                {
                    int numberProjectiles = 4 + Main.rand.Next(2); //This defines how many projectiles to shot.
                    for (int i = 0; i < numberProjectiles; i++)
                    {

                        float speedX = Main.rand.NextFloat(-6f, 6f);
                        float speedY = Main.rand.NextFloat(-6f, 6f);

                        Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("ProtoGrenadeProj2"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
                    }
                    projectile.Kill();
                }
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 60;
                projectile.height = 60;
                projectile.Center = projectile.position;
                

                projectile.knockBack = 3f;
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                
                
            }
            else
            {
                
                if (Main.rand.NextBool())
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    
                    dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                   
                }
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);



            for (int i = 0; i < 30; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            for (int i = 0; i < 15; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 20; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }

    }
    //_____________________________________________________________________________________________________________________________________________
    public class ProtoGrenadeProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpnel");
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
            if (Main.rand.NextBool())
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;

               

            }
            projectile.rotation += (float)projectile.direction * -0.2f;
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
                Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 5; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 1);
                }

            }
        }
    }
}