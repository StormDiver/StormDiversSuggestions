using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    
   
    //______________________________________________________________________________________________________
    public class JungleSentryProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Sentry");
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
      
            projectile.width = 15;
            projectile.height = 66;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -20;
            //projectile.aiStyle = 1;
        }
        public override bool CanDamage()
        {

            return false;
        }
        int summontime;
        int shoottime = 0;
        bool animate = false;
        public override void AI()
        {

            summontime++;
            if (summontime <= 3)
                {
                for (int i = 0; i < 50; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X - 20, projectile.position.Y), 52, projectile.height, 40, 0f, 0f, 0, default, 1f);

                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.4f;
                    Main.dust[dustIndex].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }
            }
            projectile.rotation = 0;
            //projectile.velocity.Y = 5;
           
            //projectile.rotation += (float)projectile.direction * -0.1f;
            Main.player[projectile.owner].UpdateMaxTurrets();
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            //if (projectile.ai[0] > 20f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X - 20, projectile.position.Y), 52, projectile.height, 40, 0, 0, 130, default, 1f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X - 20, projectile.position.Y), 52, projectile.height, 78, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
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

                if (distance < 300f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)
                {

                    if (Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        if (shoottime > 100)
                        {
                            animate = true;

                        }
                        if (shoottime > 120)
                        {
                            for (int j = 0; j < 50; j++)
                            {
                                int dust = Dust.NewDust(new Vector2(projectile.position.X - 20, projectile.position.Y), 52, projectile.height, 40, 0, -2, 130, default, 1f);

                                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                                Main.dust[dust].velocity *= 0.5f;
                            }
                            float numberProjectiles = 6;
                            float rotation = MathHelper.ToRadians(40);
                            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                            for (int j = 0; j < numberProjectiles; j++)
                            {
                                float speedX = 0f;
                                float speedY = -6f;
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, j / (numberProjectiles) + 0.08f));
                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("JungleSentryProj2"), (int)(projectile.damage * 1f), projectile.knockBack, Main.myPlayer, 0f, 0f);
                            }

                            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 65);
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
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    //projectile.frame %= 6; // Will reset to the first frame if you've gone through them all.
                    projectile.frameCounter = 0;
                    
                }
                if (projectile.frame == 6)
                {
                    
                    projectile.frame = 0;
                    animate = false;
                }
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            //target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 50; i++)
            {

                var dust2 = Dust.NewDustDirect(new Vector2(projectile.position.X - 20, projectile.position.Y), 52, projectile.height, 40);
                dust2.noGravity = true;
            }
        }

    }
    //_____________________________________________________________________________________________________
    public class JungleSentryProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Thorn ball");
        }
        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 240;
            projectile.aiStyle = 14;
            //aiType = ProjectileID.Meteor1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 40);
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
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
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.Grass, projectile.position);

                for (int i = 0; i < 20; i++)
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 40);

                }
                for (int i = 0; i < 25; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 78, 0f, 0f, 0, default, 1f);
                   
                    Main.dust[dustIndex].noGravity = true;
                }

            }
        }
       
    }

}
