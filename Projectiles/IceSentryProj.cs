using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    
   
    //______________________________________________________________________________________________________
    public class IceSentryProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Sentry");
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

        }
        public override void SetDefaults()
        {
      
            projectile.width = 34;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.tileCollide = false;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            
        }
        public override bool CanDamage()
        {

            return false;
        }
        int opacity = 255;
        int shoottime = 0;
        bool animate1 = false; //For making the core open up
        bool animate2 = false; //This bool is used to indicate that the core is open
        bool animate3 = false; //For closing the core
        bool floatup = true;
        int floattime;
        NPC target;
        public override void AI()
        {
            if (opacity > 0)
            {
                opacity -= 10;
            }
            projectile.alpha = opacity;
            //projectile.rotation += (float)projectile.direction * -0.1f;
            Main.player[projectile.owner].UpdateMaxTurrets();
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0, 10, 130, default, 1f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity

                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);
            }
            

            Player player = Main.player[projectile.owner];
            shoottime++;
            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {

                if (player.HasMinionAttackTargetNPC)
                {
                    target = Main.npc[player.MinionAttackTargetNPC];
                }
                else
                {
                    target = Main.npc[i];

                }

                //Getting the shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                //bool lineOfSight = Collision.CanHitLine(projectile.Center, 1, 1, target.Center, 1, 1);
                //If the distance between the projectile and the live target is active

                if (distance < 500f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy && Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                {

                        distance = 1.6f / distance;

                        //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                        shootToX *= distance * 4f;
                        shootToY *= distance * 4f;

                        
                        if (shoottime > 12)
                        {

                            Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(8));
                            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("IceSentryProj2"), (int)(projectile.damage * 1f), projectile.knockBack, Main.myPlayer, 0f, 0f);

                            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 20);

                            shoottime = 0;
                        }

                    if (!animate2)//If the core isn't already open it'll activate the opening bool
                    {
                        animate1 = true;
                    }
                }
                else
                {
                    if (animate2) //If there are no nearby enemies and the core is open, it'll then activate the closing bool
                    {
                        animate3 = true; //Activates the closing bool
                        animate2 = false; //removes itself as the core is no longer open
                    }
                }
            }
            projectile.ai[0] += 1f;


            if (animate1)//For opening the core
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 3) 
                {
                    projectile.frame++;
                  
                    projectile.frameCounter = 0;

                }
                if (projectile.frame == 6) //Once it reaches this frame it stops counting up and activates the bool to say the core is open
                {
                    projectile.frameCounter = 0;
                    projectile.frame = 6;
                    animate1 = false; //The bool then makes itself false to stop the count
                    animate2 = true; //While this is true it'll stop this bool from being reactivated
                }
            }
           
            if (animate3) //This is the bool for closing the core
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 3) 
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;

                }
                if (projectile.frame == 8) //Once all the frames are exhausted it resets back to frame zero
                {
                    projectile.frame = 0;
                    animate3 = false; //The bool then makes itself false to stop the count
                }
            }


            if (floatup) //Floating upwards
            {
                floattime++;
                if (floattime <= 30)
                {
                    projectile.velocity.Y -= 0.01f;

                }
                else
                {
                    projectile.velocity.Y += 0.01f;

                }
                if (floattime >= 60) //Halfway through it slows down
                {
                    floatup = false;
                    floattime = 0;
                }
            }
            if (!floatup) //Floating downwards
            {
                floattime++;

                if (floattime <= 30)
                {
                    projectile.velocity.Y += 0.01f;
                }
                else
                {
                    projectile.velocity.Y -= 0.01f;

                }
                if (floattime >= 60) //Halfway through it slows down
                {
                    floatup = true;
                    floattime = 0;
                }
            }
        }
        


        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 50; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 187);
                dust2.noGravity = true;
            }
        }

    }
    //_____________________________________________________________________________________________________
    public class IceSentryProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Stream");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 75;
            projectile.extraUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
           
            
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default, 2f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
                }
            
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;

            target.AddBuff(mod.BuffType("UltraFrostDebuff"), 180);

        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("UltraFrostDebuff"), 180);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }

}
