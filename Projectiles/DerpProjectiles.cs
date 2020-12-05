using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Projectiles
{
    public class DerpMeleeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Head");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 24;
           
            projectile.friendly = true;
            
            projectile.tileCollide = true;
            projectile.melee = true;
           projectile.aiStyle = 1;
            //projectile.CloneDefaults(48);
            //aiType = 48;
            projectile.timeLeft = 180;
            drawOffsetX = -3;
            drawOriginOffsetY = 0;
            projectile.scale = 0.7f;
        }
        
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 33, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;


            /*
            int dust = Dust.NewDustPerfect(projectile.position - projectile.velocity, projectile.width, projectile.height, 48, 0f, 0f, 200, default, 1.5f);
                Main.dust[dust].velocity *= -1f;
                Main.dust[dust].noGravity = true;
               */

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.penetrate = 1;
            projectile.melee = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            
           
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                //Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 22);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 253);
                }
            }
        }
    }
    //__________________________________________________________________________________________________________________
    public class DerpRangedProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Head");

        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.melee = true;
            // projectile.aiStyle = 1;
            projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
            aiType = ProjectileID.ChlorophyteBullet;
            projectile.timeLeft = 180;
            drawOffsetX = -7;
            drawOriginOffsetY = 0;
        }
        
        public override void AI()
        {

            /*
                int dust = Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, 48, 0f, 0f, 200, default, 1.5f);
                Main.dust[dust].velocity *= -1f;
                Main.dust[dust].noGravity = true;
*/
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 33, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 2f);
            dust.noGravity = true;


            /*
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.Center.X - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 300f && target.active)
                    {

                        //Divide the factor, 3f, which is the desired velocity
                        distance = 4f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 2;
                        shootToY *= distance * 2;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }

            } */
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 22);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 253);
                }
            }
        }
    }
    //__________________________________________________________________________________________________________________
    public class DerpMagicProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Head");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 24;
           
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.magic = true;

            projectile.aiStyle = 0;
            projectile.timeLeft = 60;
            projectile.scale = 0.7f;

        }

        


        public override void AI()
        {


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 33, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            
            
                /*if (Main.rand.Next(10) == 0)
                {
                    float speedX = 0f;
                    float speedY = -4f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(90));
                    float scale = 1f - (Main.rand.NextFloat() * .5f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DerpMagicProj2"), (int)(projectile.damage * 0.6f), 0f, projectile.owner, 0f, 0f);
                    
                
            }*/
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


           
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 22);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 253);
            }
            int numberProjectiles = 3 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                // Calculate new speeds for other projectiles.
                // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                float speedX = Main.rand.NextFloat(-7f, 7f);
                float speedY = Main.rand.NextFloat(-7f, 7f);

                Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("DerpMagicProj2"), (int)(projectile.damage * 0.75), 0f, projectile.owner, 0f, 0f);
            }
        }

    }
    //__________________________________________________________________________________________________________________
    public class DerpMagicProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpie Head");

        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 18;
           
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.magic = true;
            //projectile.extraUpdates = 1;
            //projectile.CloneDefaults(297);
            projectile.aiStyle = 2;
            //aiType = 297;
            //projectile.timeLeft = 240;
            projectile.timeLeft = 360;
        }
       
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 33, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 0.5f);
            dust.noGravity = true;



        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


           
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }
        public override void Kill(int timeLeft)
        {


            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            //Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 22);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 253);
                dust.scale = 0.5f;
            }

        }
    }
}
