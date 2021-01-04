using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    
   
    //______________________________________________________________________________________________________
    public class DesertStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Sentry");
            Main.projFrames[projectile.type] = 8;
        }
        public override void SetDefaults()
        {
       
            projectile.width = 50;
            projectile.height = 50;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            
        }
        public override bool CanDamage()
        {

            return false;
        }
        int opacity = 255;
        int shoottime = 0;
        bool animate = false;
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

            //if (projectile.ai[0] > 20f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, 0, 10, 130, default, 1f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                }
            }

            //else
            {
                //projectile.ai[0] += 1f;
            }
            shoottime++;
            //Getting the npc to fire at
            for (int i = 0; i < 200; i++)
            {

                NPC target = Main.npc[i];

                //Getting the shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                //bool lineOfSight = Collision.CanHitLine(projectile.Center, 1, 1, target.Center, 1, 1);
                //If the distance between the projectile and the live target is active

                if (distance < 200f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)
                {

                    if (Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        if (shoottime > 80)
                        {
                            AnimateProjectile();


                            float numberProjectiles = 12;
                            float rotation = MathHelper.ToRadians(180);
                            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                            for (int j = 0; j < numberProjectiles; j++)
                            {
                                float speedX = 0f;
                                float speedY = 3.5f;
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, j / (numberProjectiles)));
                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DesertStaffProj2"), (int)(projectile.damage * 1f), projectile.knockBack, Main.myPlayer, 0f, 0f);
                            }

                            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
                            animate = true;
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
                if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
                {
                    projectile.frame++;
                    //projectile.frame %= 6; // Will reset to the first frame if you've gone through them all.
                    projectile.frameCounter = 0;
                    
                }
                if (projectile.frame == 8)
                {
                    
                    projectile.frame = 0;
                    animate = false;
                }
            
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 50; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust2.noGravity = true;
            }
        }

    }
    //_____________________________________________________________________________________________________
    public class DesertStaffProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Sand");
        }
        public override void SetDefaults()
        {

            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 60;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 5f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X - 10, projectile.Center.Y - 10), 20, 20, 138, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.Center.X - 5, projectile.Center.Y - 5), 10, 10, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 180);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 180);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }

}
