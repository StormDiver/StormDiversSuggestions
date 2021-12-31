using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{

    //______________________________________________________________________________________________________
    public class MeteorSentryProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Sentry");
            Main.projFrames[projectile.type] = 6;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }
        public override void SetDefaults()
        {

            projectile.width = 58;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.light = 0.4f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.aiStyle = -1;
            projectile.tileCollide = false;
        }
        public override bool CanDamage()
        {

            return false;
        }
        int opacity = 255;
        int shoottime = 0;
        int spawntime;
        bool floatup = true;
        int floattime;
        public override void AI()
        {
            if (opacity > 0)
            {
                opacity -= 10;
            }
            projectile.alpha = opacity;
            Main.player[projectile.owner].UpdateMaxTurrets();
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            {
                if (Main.rand.Next(10) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X + 19 , projectile.Bottom.Y - 10), 20, 4, 6, 0, 30, 0, default, 1f);

                    //Main.dust[dust].noGravity = true; //this make so the dust has no gravity


                }
            }

            spawntime++;
            shoottime++;
            if (spawntime <= 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0f, 0f, 0, default, 1f);

                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.4f;
                    Main.dust[dustIndex].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }
            }
            //Getting the npc to fire at
            if (spawntime >= 30)
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    target.TargetClosest(true);

                    float distanceX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float distanceY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;

                    if (((distanceX >= -75f && distanceX <= 75f) && (distanceY >= 0f && distanceY <= 750f)) && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy && Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        /*if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
                        {
                            int dust2 = Dust.NewDust(new Vector2(projectile.position.X + 19, projectile.Bottom.Y - 10), 20, 4, 0, 0, 3, 0, default, 1f);
                        }*/

                        if (Main.rand.Next(3) == 0)
                        {
                            Dust dust;
                            dust = Terraria.Dust.NewDustPerfect(new Vector2(projectile.Center.X, projectile.Bottom.Y - 5), 112, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
                            dust.fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;

                            dust.noGravity = true;
                            dust.scale = 0.1f + (float)Main.rand.Next(5) * 0.4f;
                        }

                        float xpos = (Main.rand.NextFloat(-10, 10));

                        if (shoottime > 15)
                        {

                            Projectile.NewProjectile(projectile.Center.X + xpos, projectile.Bottom.Y - 10, xpos / 15, 8, mod.ProjectileType("MeteorSentryProj2"), (int)(projectile.damage * 1f), projectile.knockBack, Main.myPlayer, 0f, 0f);

                            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 12);

                            shoottime = 0;
                        }

                       
                    }

                  

                }
            }

            projectile.ai[0] += 1f;

            //Animation
            { 
                projectile.frameCounter++;
                if (projectile.frameCounter >= 5)
                {
                    projectile.frame++;

                    projectile.frameCounter = 0;

                }
                if (projectile.frame >= 6) //Once all the frames are exhausted it resets back to frame zero
                {
                    projectile.frame = 0;

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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 113, 1, -0.5f);

            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 65, 0f, 0f, 0, default, 1f);

                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.4f;
                Main.dust[dustIndex].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            //return Color.White;
            return null;
        }
    }
    //___________________________________________________________________
    public class MeteorSentryProj2: ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Sentry laser");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;


        }
        int dusttime;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;


            dusttime++;
            if (dusttime >= 5)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 62, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 5; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                dust.scale = 0.5f;
                dust.velocity *= 0.5f;

            }
            projectile.damage = projectile.damage / 10 * 9;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 5; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    dust.scale = 0.5f;
                    dust.velocity *= 0.5f;

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
