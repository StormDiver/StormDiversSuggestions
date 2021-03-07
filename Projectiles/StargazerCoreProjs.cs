using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    
    
   
    //______________________________________________________________________________________________________
    public class StargazerCoreProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stargazer Sentry");
        }
        public override void SetDefaults()
        {
       
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.sentry = true;
            projectile.penetrate = 1;
            projectile.timeLeft = Projectile.SentryLifeTime;
            projectile.light = 0.6f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            
        }
        public override bool CanDamage()
        {

            return false;
        }
        
        int shoottime = 0;
        int firerate = 0;
        int stopfire = 0;
        int rotate;
        int opacity = 255;



        public override void AI()
        {
            if (opacity > 150)
            {
                opacity -= 10;
                for (int i = 0; i < 20; i++)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);

                    Main.dust[dust].velocity *= 0.5f;
                }
            }
            projectile.alpha = opacity;
            rotate += 1;
            projectile.rotation = rotate * 0.1f;
            //projectile.rotation += (float)projectile.direction * -0.1f;

            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            Main.player[projectile.owner].UpdateMaxTurrets();


            {
                if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, 0, 10, 130, default, 1f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                }
            }

           
        
        shoottime++;
            for (int i = 0; i < 200; i++)
            {

                NPC target = Main.npc[i];
                //target.TargetClosest(true);

                //Getting the shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                //bool lineOfSight = Collision.CanHitLine(projectile.Center, 1, 1, target.Center, 1, 1);
                //If the distance between the projectile and the live target is active

                if (distance < 750f && !target.friendly && target.active && !target.dontTakeDamage && target.lifeMax > 5 && target.type != NPCID.TargetDummy)
                {

                    if (Collision.CanHit(projectile.Center, 0, 0, target.Center, 0, 0))
                    {
                        target.TargetClosest(true);

                        if (shoottime > 90)
                        {

                            firerate++;
                            stopfire++;
                            //Dividing the factor of 2f which is the desired velocity by distance
                            distance = 1.6f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            shootToX *= distance * 15f;
                            shootToY *= distance * 15f;

                            
                            if (firerate >= 5)
                            {
                                Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(0));

                                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("StargazerCoreProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);

                                for (int j = 0; j < 20; j++)     //this defines how many dust to spawn
                                {
                                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);

                                    Main.dust[dust].velocity *= 0.5f;
                                }
                                firerate = 0;
                            }
                            //Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 60);
                            if (stopfire >= 25)
                            {
                                shoottime = 0;
                                stopfire = 0;
                                firerate = 0;

                            }
                        }
                    }
                }
               
            }
           



        }
       


      
        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 50; i++)
            {

          
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 111);
                dust2.noGravity = true;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (opacity <= 150)
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
    //_____________________________________________________________________________________________________
    public class StargazerCoreProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stargazer Laser");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
        }
        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            //projectile.sentry = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 180;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            projectile.light = 0.6f;

        }
        int visible;
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            visible++;
            
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, 0, 0, 130, default, 1.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                }
            
           
            if (visible <= 3)
            {
                projectile.alpha = 255;
            }
           
            return;
        }

        

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage -= (projectile.damage / 10);
            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);

                for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0, 0, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }

            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            if (visible >= 3)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

                }
            }
            return true;

        }
        public override Color? GetAlpha(Color lightColor)
        {


            if (visible > 3)
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

}
