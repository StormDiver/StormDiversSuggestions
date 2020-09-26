using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class SpectreGlobeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Sky Orb");
            Main.projFrames[projectile.type] = 4;
        }
        int ignoretile = 0;
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 9;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 1;                  
            projectile.magic = true;
            projectile.timeLeft = 200;
            projectile.CloneDefaults(297);
            projectile.light = 0.6f;
            aiType = 297;

        }
        int timeleft2 = 300;
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 175, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            projectile.spriteDirection = projectile.direction;
            AnimateProjectile();
            ignoretile++;
            if (ignoretile >= 10)
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;
            }
            timeleft2--;
            if (timeleft2 <= 0)
            {
                projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {
            
                
                
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);
            for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
                }
            
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
    }
    //_______________________________________________________________________________________________
    public class SpectreGunProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Skull");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.light = 0.6f;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.magic = true;
            projectile.timeLeft = 240;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            
        }

        int speedup = 0;
        public override void AI()
        {
            if (speedup < 1)
            {
                projectile.damage = 80;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);
            projectile.spriteDirection = projectile.direction;

            AnimateProjectile();
           
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 66);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0f;
                Main.dust[j].noGravity = true;

            }
            speedup++;
            if (speedup <= 80)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;
                projectile.damage += 1;
               
            }

          
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            }
        }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    //_______________________________________________________________________________________________
    public class SpectreGunProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SpectreGunbolt");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.light = 0.6f;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.magic = true;
            projectile.timeLeft = 200;
            aiType = ProjectileID.Bullet;
            projectile.aiStyle = 1;
            projectile.scale = 0.75f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }
        
        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;

            AnimateProjectile();
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 66);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0f;
                Main.dust[j].noGravity = true;

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            }
        }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
    }
    //_______________________________________________________________________________________________

    public class SpectreStaffSpinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orb");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;

            projectile.friendly = true;

            projectile.magic = true;
            //projectile.timeLeft = 750;
            
            
            projectile.CloneDefaults(297);
            aiType = 297;

        }
        int distime = 0;
        
        public override void AI()
        {
            if (distime <= 1)
            {
                projectile.timeLeft = 3100;
            }
            if (distime <= 500)
            {
                distime++;
            }
            
            int distanceproj = (distime / 2) + 10;
            

            //Making player variable "p" set as the projectile's owner
            Player p = Main.player[projectile.owner];

            //Factors for calculations

            double deg = (double)projectile.ai[1] * 5f ; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = distanceproj; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            var player = Main.player[projectile.owner];
            if (player.dead)
            {
                projectile.Kill();
                return;
            }
            AnimateProjectile();
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 204);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 2.5f;

            }
            
            projectile.tileCollide = false;
            projectile.penetrate = 20;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.1f;
        }

        public override void Kill(int timeLeft)
        {



            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }


    }
    //_______________________________________________________________________________________________
    public class SpectreStaffSpinProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orb");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 46;
            projectile.height = 46;

            projectile.friendly = true;

            projectile.magic = true;
            //projectile.timeLeft = 750;

            
            projectile.CloneDefaults(297);
            aiType = 297;
        }
        int distime = 0;
       
        public override void AI()
        {
            if (distime <= 1)
            {
                projectile.timeLeft = 3100;
            }
            if (distime <= 500)
            {
                distime++;
            }
            
            int distanceproj = (distime / 2) + 10;
            //Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 175);

            //Making player variable "p" set as the projectile's owner
            Player p = Main.player[projectile.owner];

            //Factors for calculations

            double deg = (double)projectile.ai[1] * -5f; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = distanceproj; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            var player = Main.player[projectile.owner];
            if (player.dead)
            {
                projectile.Kill();
                return;
            }
            AnimateProjectile();
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 204);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 2.5f;

            }
            
            projectile.tileCollide = false;
            projectile.penetrate = 20;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.1f;
        }

        public override void Kill(int timeLeft)
        {



            
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

    }
    
    //_______________________________________________________________________________________________
    public class SpectreDaggerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Dagger");
           
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.light = 0.6f;
            projectile.friendly = true;
            
            projectile.magic = true;
            projectile.timeLeft = 200;
            projectile.CloneDefaults(48);
            aiType = 48;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = -1;
            drawOriginOffsetY = -6;
        }

        public override void AI()
        {
            projectile.magic = true;


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 66, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.scale = 0.8f;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.penetrate = 10;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }

            projectile.velocity.X = projectile.velocity.X * 1.1f;

            projectile.velocity.Y = -4f;
        }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }
           
        }

       /* public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }*/
    }
    //_______________________________________________________________________________________________
    
}
