using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Projectiles
{

    public class CelestialShieldProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Guardian");
            Main.projFrames[projectile.type] = 4;

        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;

            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.knockBack = 0;
            projectile.ignoreWater = true;
            projectile.timeLeft = 9999999;
            projectile.tileCollide = false;
            projectile.MaxUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        int rotatespeed;
        int particle;
        public override void AI()
        {
            Player p = Main.player[projectile.owner];


             if(p.HasBuff(mod.BuffType("CelestialBuff")))
            {
                rotatespeed = 10;
            }
             else
            {
                rotatespeed = 2;
            }
            projectile.rotation += (float)projectile.direction * -0.2f;
            //Making player variable "p" set as the projectile's owner

            //Factors for calculations
            double deg = (double)projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 50; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += -rotatespeed;
            var player = Main.player[projectile.owner];

            if (Main.rand.Next(2) == 0)
            {
                int choice = Main.rand.Next(4);
                if (choice == 0)
                {
                    particle = 244;
                }
                else if (choice == 1)
                {
                    particle = 110;
                }
                else if (choice == 2)
                {
                    particle = 111; ;
                }
                else if (choice == 3)
                {
                    particle = 112;
                }
                var dust = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, particle);
                dust.noGravity = true;
              

            }
            if (player.GetModPlayer<StormPlayer>().lunarBarrier == false || player.dead)

            {
                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 110);
                    var dust2 = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111);
                    dust2.noGravity = true;

                    var dust3 = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 112);
                    dust3.noGravity = true;

                    var dust4 = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 244);
                    dust4.noGravity = true;

                }
                projectile.Kill();
                return;
            }
            
            AnimateProjectile();
        
        }
        public override bool CanDamage()
        {
           
                return false;
           
        }
    
      
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                //Main.PlaySound(SoundID.Item14, projectile.position);



            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 5 frames
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
    
}
