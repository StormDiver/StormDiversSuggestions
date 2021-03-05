using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class SilverKniveProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Throwing Knive");

        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            projectile.aiStyle = 2;


            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 3;

            projectile.tileCollide = true;


            projectile.thrown = true;


            drawOffsetX = 0;
            drawOriginOffsetY = -0;

            projectile.light = 0.2f;
        }


        int spinspeed = 0;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (spin)
            {

                spinspeed++;
                projectile.rotation = (0.4f * spinspeed) * projectile.direction;
               
                drawOriginOffsetY = -8;
      
                
            }

        }
        int reflect = 2;
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
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }
                spin = true;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9 / 10);
        }


        public override void Kill(int timeLeft)
        {
            int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("SilverKnive")) : 0;

            Main.PlaySound(0, (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 5; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 30);
            }
        }



    }
    public class TungstenKniveProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Throwing Knive");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            projectile.aiStyle = 2;
            
            
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 3;
            
            projectile.tileCollide = true;
            
        
            projectile.thrown = true;
           

            drawOffsetX = 0;
            drawOriginOffsetY = -0;

            projectile.light = 0.2f;
        }



        int spinspeed = 0;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (spin)
            {

                spinspeed++;
                projectile.rotation = (0.4f * spinspeed) * projectile.direction;

                drawOriginOffsetY = -8;


            }

        }
        int reflect = 2;
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
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }
                spin = true;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9 / 10);
        }
        

        public override void Kill(int timeLeft)
        {
            int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("TungstenBullet")) : 0;

            Main.PlaySound(0, (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 5; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 30);
            }
        }



    }
   
}
