﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    
    public class StardustSentryProj : ModProjectile
    {
       
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Sentry");
            Main.projFrames[projectile.type] = 4;
            //ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 36;
            //projectile.light = 1f;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;

            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.tileCollide = true;
            //drawOffsetX = 2;
            //drawOriginOffsetY = 2;
            projectile.sentry = true;
            
        }
        public override bool CanDamage()
        {
        
            return false;
        }
        int shoottime = 0;
        //int supershot = 0;
        int opacity = 0;
        bool floatup = true;
        int floattime;
        NPC target;

        public override void AI()
        {
            projectile.alpha = (int)0.5f;
            opacity++;
            
            Main.player[projectile.owner].UpdateMaxTurrets();
            AnimateProjectile();
            // projectile.TurretShouldPersist();
            if (opacity < 30)
            {
                projectile.Opacity = 0;
                Dust dust;

                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 135, 0f, 0f, 0, new Color(255, 255, 255), 2f)];
                dust.noGravity = true;
            }
             
            if (opacity == 30)
            {
                for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X * 1, projectile.velocity.Y * 1, 120, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }
                Main.PlaySound(SoundID.NPCHit, (int)projectile.Center.X, (int)projectile.Center.Y, 5);
            }
            if (opacity >= 30)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, 0, 5, 130, default, 1f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 0.5f;
            }
            shoottime++;
            Player player = Main.player[projectile.owner];

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
                

                if (distance < 700 && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)  
                {
                   
                    if (Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        target.TargetClosest(true);
                        if (shoottime > 40)
                        {
                            //supershot++;


                            //Dividing the factor of 2f which is the desired velocity by distance
                            //distance = 1.6f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            //shootToX *= distance * 3.5f;
                            //shootToY *= distance * 3.5f;

                            
                            for (int j = 0; j < 3; j++)
                            {


                                float speedX = 0f;
                                float speedY = -4.5f;
                                
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(60));
                                
                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("StardustSentryProj2"), projectile.damage, 1f, Main.myPlayer, 0f, 0f);
                                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Top.Y, 8);

                                shoottime = 0;
                            }
                                for (int k = 0; k < 25; k++)
                            {
                                Dust dust2;


                                dust2 = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 4f, 0, new Color(255, 255, 255), 2f)];
                                dust2.noGravity = true;
                                dust2.velocity *= 2;
                            }
                        }
                    }
                    /*if (supershot > 4)
                    {
                        target.TargetClosest(true);
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX * 3, shootToY * 3, mod.ProjectileType("StardustSentryProj3"), (int) (projectile.damage * 2f), (int)(projectile.knockBack * 2), Main.myPlayer, 0f, 0f); //Spawning a projectile mod.ProjectileType("FlamethrowerProj") is an example of how to spawn a modded projectile. if you want to shot a terraria prjectile add instead ProjectileID.Nameofterrariaprojectile
                        Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 60);
                        supershot = 0;

                    }*/
                }
            }
            //projectile.ai[0] += 1f;

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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);    

            for (int i = 0; i < 50; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default, 2f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
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
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
      
  
         /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
         {
            if (opacity > 30)
            {
                Texture2D texture = mod.GetTexture("Projectiles/StardustSentryProj");

                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, texture.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame), projectile.GetAlpha(Color.White), projectile.rotation, projectile.Size / 2f, projectile.scale, projectile.spriteDirection == 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                
            }

         }*/
       public override Color? GetAlpha(Color lightColor)
        {

            
            if (opacity > 30)
            {
                
                Color color = Color.White;
                color.A = 150;
                return color;

            }
            else
            {
                return null;
            }
            
        }
    }

    //____________________________________________________________
    public class StardustSentryProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Flow Invader");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 1;
            //projectile.minion = true;
            projectile.timeLeft = 300;
            //projectile.light = 0.5f;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 0;
            drawOffsetX = -5;
            //drawOriginOffsetY = -9;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

            projectile.Opacity = 0;
        }
        int dusttime = 0;
        int hometime = 0;
        Vector2 newMove;

        public override void AI()
        {
           

            dusttime++;
            if (dusttime >= 5)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 120, default, 0.8f);   //this make so when this projectile is active has dust around , change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.5f;
                dusttime = 0;
            }
            
            AnimateProjectile();
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Player player = Main.player[projectile.owner];

            hometime++;
           if (hometime > 6)
            {
                projectile.alpha = (int)0.5f;
            }
            if (hometime > 30)
            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 750f;
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
                    projectile.velocity = (10 * projectile.velocity + move) / 10f;
                    AdjustMagnitude(ref projectile.velocity);
                }
            }
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (hometime > 30)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 12f)
                {
                    vector *= 12f / magnitude;
                }
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
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width * 2, projectile.height * 2, 135, projectile.velocity.X, projectile.velocity.Y, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2f;

                    //Main.dust[dust].velocity *= 2.5f;
                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {


            if (hometime > 6)
            {

                Color color = Color.White;
                color.A = 150;
                return color;

            }
            else
            {
                return null;
            }

        }

    }
    //____________________________________________________________
    public class StardustSentryProj3 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fast Golden Flow Invader");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 19;
            projectile.height = 19;
            projectile.friendly = true;
            projectile.penetrate = 5;
           // projectile.minion = true;
            projectile.timeLeft = 180;
            projectile.light = 0.2f;
            projectile.scale = 1f;
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.ignoreWater = true;
            drawOffsetX = -10;
            //drawOriginOffsetY = -9;
            //projectile.CloneDefaults(625);
            //aiType = 338;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.Opacity = 1f;
        }
        int dusttime = 0;
        public override void AI()
        {

            projectile.alpha = (int)0.5f;
            

            dusttime++;
            if (dusttime >= 2)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 120, default, 0.8f);   //this make so when this projectile is active has dust around , change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.5f;
                dusttime = 0;
            }

            AnimateProjectile();
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

           

        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            projectile.damage -= (projectile.damage / 20);

            Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);
            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                //Main.dust[dust].velocity *= 2.5f;
            }


        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);
                for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width * 2, projectile.height * 2, 135, projectile.velocity.X, projectile.velocity.Y, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
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
