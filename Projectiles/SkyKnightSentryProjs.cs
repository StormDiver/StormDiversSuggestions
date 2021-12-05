using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Projectiles
{
    
    public class SkyKnightSentryProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Warrior Sentry");
            Main.projFrames[projectile.type] = 3;
            //ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 32;
            //projectile.light = 1f;
            projectile.friendly = true;
            projectile.penetrate = -1;

            projectile.timeLeft = 99999999;
            projectile.tileCollide = true;
            //drawOffsetX = 2;
            //drawOriginOffsetY = 2;

        }
        public override bool CanDamage()
        {

            return false;
        }
        int shoottime = 0;
        int summontime = 0;
        bool scaleup;
        bool animate;
        public override void AI()
        {
            summontime ++;
            if (summontime <3)
            {
                Main.PlaySound(SoundID.Item, projectile.Center, 9);

                for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 162, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }
            }
            Player player = Main.player[projectile.owner];

            projectile.position.X = player.Center.X  - projectile.width / 2;
            projectile.position.Y = player.Center.Y - 75 - projectile.height / 2;



            projectile.alpha = (int)0.5f;

        
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 162, 0, 5, 130, default, 1.5f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1f;
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


                if (distance < 500f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy && Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                {

                    distance = 1.6f / distance;

                    //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                    shootToX *= distance * 7f;
                    shootToY *= distance * 7f;


                    if (shoottime > 60)
                    {

                        Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(8));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SkyKnightSentryProj2"), 40, projectile.knockBack, Main.myPlayer, 0f, 0f);

                        Main.PlaySound(SoundID.Item, projectile.Center, 9);

                        shoottime = 0;
                        animate = true;
                    }


                }

            }
            if (animate)
            {
                AnimateProjectile();
            }
            //projectile.ai[0] += 1f;
            if (player.GetModPlayer<StormPlayer>().skyKnightSet == false || player.dead)

            {
                
                projectile.Kill();
                return;
            }
            //To make the sentry pulse
            if (scaleup)
            {
                projectile.scale += 0.01f;
            }
            else
            {
                projectile.scale -= 0.01f;
            }
            if (projectile.scale >= 1.15f)
            {
                scaleup = false;
            }
            if (projectile.scale <= 0.85f)
            {
                scaleup = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);

            for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 162, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2.5f;
            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frameCounter = 0;

            }
            if (projectile.frame >= 3)
            {
                projectile.frame = 0;
                animate = false;
            }
        }



        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }


    //____________________________________________________________
    public class SkyKnightSentryProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Warrior Star");
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 1;
            //projectile.minion = true;
            projectile.timeLeft = 120;
            //projectile.light = 0.5f;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 0;
            drawOffsetX = 0;
            //drawOriginOffsetY = -9;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

            
        }
        int dusttime = 0;
        int rotate;

        public override void AI()
        {

            rotate += 2;
            projectile.rotation = rotate * 0.1f;
            dusttime++;
            if (dusttime > 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X * (float)i;
                    float Y = projectile.Center.Y * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 162, 0, 0, 100, default, 1.5f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;

                }
            }

            if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 100f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
                    {
                        if (Collision.CanHit(projectile.Center, 0, 0, Main.npc[k].Center, 0, 0))
                        {
                            Vector2 newMove = Main.npc[k].Center - projectile.Center;
                            float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                            if (distanceTo < distance)
                            {
                                move = newMove;
                                distance = distanceTo;
                                target = true;
                            }
                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (10 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
            }
        
        private void AdjustMagnitude(ref Vector2 vector)
        {
            
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 14f)
                {
                    vector *= 14f / magnitude;
                }
            
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
          projectile.Kill();

            
        }
        
      
        
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);

                for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 162, 0, 0, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    

                    Main.dust[dust].velocity *= 1.5f;
                }

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
