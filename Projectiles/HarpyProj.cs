using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class HarpyProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Feather");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0f;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 90;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
          
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;



            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 30);
            if (Main.rand.Next(2) == 0) // the chance
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 202, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;

            }



        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
            /*if (Main.rand.Next(2) == 0) // the chance
            {
                target.AddBuff(BuffID.Poisoned, 240);
            }*/
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

         
                return true;
            
            
        }

        public override void Kill(int timeLeft)
        {


            //Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(10, 10), Main.rand.NextFloat(-10, -10));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 202);
            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 11);

        }



    }
    //___________________________________________________________________________________________
    public class HarpyProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Harpy Feather");
           
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0f;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.magic = true;
            projectile.timeLeft = 120;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = -10;
        }
        
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.3f;

            if (Main.rand.Next(2) == 0) // the chance
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 202, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
                
            
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 202);
                
            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 11);

        }


        public override void Kill(int timeLeft)
        {



            //Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 202);
            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 11);
        }
       
    }
    //_______________________________________________
    public class HarpyArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 7;
            projectile.height = 7;

            projectile.aiStyle = 0;
           
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 1;
            projectile.arrow = true;
            projectile.tileCollide = true;
            projectile.knockBack = 8f;
            projectile.ranged = true;

            projectile.arrow = true;
            //Creates no immunity frames
            

            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            /* int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 0.7f);
             Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
             Main.dust[dustIndex].noGravity = true;*/
        }




        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 202);
            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 11);
        }

    }
    //___________________________________________________________________________
    public class HarpyYoyoProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Yoyo");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 5f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 165f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 360;

            projectile.scale = 1f;
            projectile.aiStyle = 99;

            // drawOffsetX = -3;
            // drawOriginOffsetY = 1;
        }
        //int shoottime = 0;
        public override void AI()
        {
            if (Main.rand.Next(2) == 0) // the chance
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 202, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;

            }
            /*shoottime++;
            if (shoottime >= 40)
            {


                for (int i = 0; i < 3; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 7);

                    Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(360));

                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("TurtleYoyoProj2"), (int)(projectile.damage * 1.25f), 0f, projectile.owner, 0f, 0f);
                    shoottime = 0;
                }
            }*/

        }


    }
}