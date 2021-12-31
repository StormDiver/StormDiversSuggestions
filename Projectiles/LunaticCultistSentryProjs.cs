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
    
    public class LunaticExpertSentryProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Sentry");
            Main.projFrames[projectile.type] = 8;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 46;
            //projectile.light = 1f;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.alpha = 50;
            projectile.timeLeft = 99999999;
            projectile.tileCollide = false;
            //drawOffsetX = 2;
            //drawOriginOffsetY = 2;
            projectile.ignoreWater = true;

        }
        public override bool CanDamage()
        {

            return false;
        }
        int shoottime = 0;
        int summontime = 0;
        bool directionright;
        bool animateidle = true;
        bool animateshoot;
        NPC target;
        public override void AI()
        {
            summontime ++;
            if (summontime <3)
            {
                Main.PlaySound(SoundID.NPCHit, (int)projectile.Center.X, (int)projectile.Center.Y, 55, 0.5f, 0.5f);

                for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }
            }
            Player player = Main.player[projectile.owner];
            //Sets location and direction when spawned
            if (summontime <= 1)
            {
                if (projectile.position.X < player.position.X)
                {
                    directionright = false;
                  
                }
                else
                {
                    directionright = true;
                    
                }

            }
            if (directionright)
            {              
                projectile.position.X = player.Center.X - 80 - projectile.width / 2;
                projectile.position.Y = player.Center.Y - 40 - projectile.height / 2;

            }
            else
            {
                projectile.position.X = player.Center.X + 80 - projectile.width / 2;
                projectile.position.Y = player.Center.Y - 40 - projectile.height / 2;

            }


            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.Bottom.Y - 15), projectile.width, 10, 173, 0, 5, 130, default, 1.5f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 1f;
            }
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

                if (player.direction == 1)
                {
                    projectile.spriteDirection = 1;

                }
                else
                {
                    projectile.spriteDirection = -1;

                }

                if (distance < 500f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy && Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                {

                    distance = 1.6f / distance;

                    //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                    shootToX *= distance * 6f;
                    shootToY *= distance * 6f;

                    int damage = (int)(80 * player.minionDamage);
                    if (shoottime > 30)
                    {

                        for (int j = 0; j < 25; j++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                        {
                            int dust = Dust.NewDust(new Vector2(projectile.Center.X - 10, projectile.Center.Y - 10), 20, 20, 173, projectile.velocity.X, projectile.velocity.Y, 100, default, 1.5f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].velocity *= 2f;
                        }


                        Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(8));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("LunaticExpertSentryProj2"), damage, projectile.knockBack, Main.myPlayer, 0f, 0f);

                        Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 77, 0.5f, 0.5f);

                        shoottime = 0;
                        animateidle = false;
                        projectile.frame = 4;

                        animateshoot = true;
                    }


                }

              
            }
            
                AnimateProjectile();
            
            //projectile.ai[0] += 1f;
            if (player.GetModPlayer<StormPlayer>().lunaticHood == false || player.dead)

            {
                
                projectile.Kill();
                return;
            }
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.NPCKilled, (int)projectile.Center.X, (int)projectile.Center.Y, 59, 0.5f, 0.5f);

            for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2.5f;
            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            if (animateidle)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6) 
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;

                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            if (animateshoot)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6) 
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;

                }
                if (projectile.frame >= 8)
                {
                    projectile.frame = 0;
                    animateidle = true;
                    animateshoot = false;
                }
            }
        }


        /*public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }*/
    }


    //____________________________________________________________
    public class LunaticExpertSentryProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Shadow Fireball");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;
            //projectile.minion = true;
            projectile.timeLeft = 120;
            //projectile.light = 0.5f;
            projectile.scale =1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 0;
            drawOffsetX = 0;
            //drawOriginOffsetY = -9;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

            
        }
        int dusttime = 0;
        int rotate;
        Vector2 newMove;
        public override void AI()
        {

            rotate += 3;
            projectile.rotation = rotate * 0.1f;
            dusttime++;
            if (dusttime > 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X * (float)i;
                    float Y = projectile.Center.Y * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 173, 0, 0, 100, default, 2f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;

                }
            }

            if (Main.rand.Next (3)== 0)
            {
                
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, projectile.velocity.X, projectile.velocity.Y, 100, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
               
            }

            if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
            Player player = Main.player[projectile.owner];

            Vector2 move = Vector2.Zero;
                float distance = 300f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
                    {
                        if (Collision.CanHit(projectile.Center, 0, 0, Main.npc[k].Center, 0, 0))
                        {
                        if (player.HasMinionAttackTargetNPC)
                        {

                            newMove = Main.npc[player.MinionAttackTargetNPC].Center - projectile.Center;
                        }
                        else
                        {
                            newMove = Main.npc[k].Center - projectile.Center;
                        }
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
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.Center.X, (int)projectile.Center.Y, 6, .3f, -0f);

                for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 173, 0, 0, 120, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    

                    Main.dust[dust].velocity *= 1.5f;
                }

            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
       
        public override Color? GetAlpha(Color lightColor)
        {



            Color color = Color.White;
            color.A = 150;
            return color;



        }

    }
    
}
