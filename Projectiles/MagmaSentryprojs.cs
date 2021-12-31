using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    
   
    //______________________________________________________________________________________________________
    public class MagmaSentryProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Orb Sentry");
            Main.projFrames[projectile.type] = 7;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

        }
        public override void SetDefaults()
        {
      
            projectile.width = 20;
            projectile.height = 70;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -5;
            
            //projectile.aiStyle = 1;
        }
        public override bool CanDamage()
        {

            return false;
        }
        int summontime;
        int shoottime = 0;
        bool animate = false;
        NPC target;
        public override void AI()
        {

            summontime++;
            if (summontime <= 3)
                {
                for (int i = 0; i < 50; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X - 15, projectile.position.Y), 30, projectile.height, 6, 0f, 0f, 0, default, 1f);

                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.4f;
                    Main.dust[dustIndex].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }
            }
            projectile.rotation = 0;
           
            Main.player[projectile.owner].UpdateMaxTurrets();
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            //if (projectile.ai[0] > 20f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X - 10, projectile.Top.Y), 20, 20, 6, 0, 0, 130, default, 1.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                }
            }

            //else
            {
                //projectile.ai[0] += 1f;
            }
            shoottime++;
            //Getting the npc to fire at
            Player player = Main.player[projectile.owner];

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

                if (distance < 600f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)
                {

                    if (Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        target.TargetClosest(true);

                        
                        if (shoottime > 90)
                        {
                            animate = true;

                            //Dividing the factor of 2f which is the desired velocity by distance
                            distance = 1.6f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            shootToX *= distance * 5f;
                            shootToY *= distance * 5f;

                            for (int j = 0; j < 30; j++)
                            {
                                int dust = Dust.NewDust(new Vector2(projectile.Center.X - 10, projectile.Top.Y), 20, 20, 6, 0, -2, 130, default, 1f);

                                //Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                                Main.dust[dust].velocity *= 2f;
                            }

                            Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(0));

                            Projectile.NewProjectile(projectile.Center.X, projectile.Top.Y + 14, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MagmaSentryProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);

                            


                            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 45, 1, 0.5f);
                            shoottime = 0;
                        }
                    }

                }
            }
            projectile.ai[0] += 1f;


            if (animate)
            {
                AnimateProjectile();
            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            
                projectile.frameCounter++;
                if (projectile.frameCounter >= 3)
                {
                    projectile.frame++;
                    //projectile.frame %= 6; // Will reset to the first frame if you've gone through them all.
                    projectile.frameCounter = 0;
                    
                }
                if (projectile.frame == 7)
                {
                    
                    projectile.frame = 0;
                    animate = false;
                }
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
       
        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 50; i++)
            {

                var dust2 = Dust.NewDustDirect(new Vector2(projectile.Center.X - 15, projectile.position.Y), 30, projectile.height, 6);
                dust2.noGravity = true;
            }
        }

    }
    //_____________________________________________________________________________________________________
    public class MagmaSentryProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Fire Orb");
            Main.projFrames[projectile.type] = 4;

        }
        public override void SetDefaults()
        {

            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 240;
            projectile.aiStyle = 0;
            //aiType = ProjectileID.Meteor1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.alpha = 100;
        }

        public override void AI()
        {
            if (Main.rand.Next(1) == 0)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 1.1f, projectile.velocity.Y * 1.1f);
                dust.noGravity = true;
                dust.scale = 2f;
            }

        

            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 5; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            projectile.damage = (projectile.damage * 9) / 10;
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);

        }
        int reflect = 3;
        public override bool OnTileCollide(Vector2 oldVelocity)

        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * 1f;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * 1f;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

               
                for (int i = 0; i < 25; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0f, 0f, 0, default, 2f);
                   
                    Main.dust[dustIndex].noGravity = true;
                }

            }
        }
       
    }

}
