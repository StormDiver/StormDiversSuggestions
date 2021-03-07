using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Projectiles
{
   
    public class SpectreHoseProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Skull");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.light = 0.6f;
            projectile.friendly = true;
            projectile.penetrate = 11;
            projectile.magic = true;
            projectile.timeLeft = 240;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 0.8f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = -2;
            drawOriginOffsetY = 0;
            
        }
    
        int speedup = 0;
        public override void AI()
        {
            
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);

            AnimateProjectile();
           
            for (int i = 0; i < 10; i++)
            {
                float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
               

                int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 66, 0, 0, 100, default, 1f);
                Main.dust[dust].position.X = X;
                Main.dust[dust].position.Y = Y;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
            }
            speedup++;
            if (speedup <= 50)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;
                projectile.damage += 2;
               
            }

          
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }
        }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
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
    
    //_______________________________________________________________________________________________

    public class SpectreStaffSpinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orb");
            //Main.projFrames[projectile.type] = 4;

            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;

            projectile.friendly = true;

            projectile.magic = true;
            projectile.timeLeft = 3600;
            projectile.ignoreWater = true;

            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 5;
            projectile.light = 0.1f;


            //projectile.CloneDefaults(297);
            //aiType = 297;

        }
        int distime = 0;
        readonly int orbit = Main.rand.Next(1, 5); //The intial random value selected
        int orbittime = 0;
        int direction;
        int speed;
        bool lineOfSight;
        public override void AI()
        {
            //picks a random direction and distance
            if (orbit == 1)
            {
                orbittime = 60; //max distance, disttime counts up to this and when it reaches it it stops increasing
                speed = 8; //speed
                direction = 10; // orbit direciton and speed
            }
            else if (orbit == 2)
            {
                orbittime = 140;
                speed = 7;
                direction = 10;
            }
            if (orbit == 3)
            {
                orbittime = 100;
                speed = -8;
                direction = -10;
            }
            else if (orbit == 4)
            {
                orbittime = 180;
                speed = -7;
                direction = -10;
            }


            if (distime <= orbittime) //Disttime will count up making the orb orbit further out until it reaches the orbittime value
            {
                distime++;
            }
            if (distime == orbittime - 1)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 30);

                for (int i = 0; i < 20; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 185);
                    dust2.noGravity = true;

                }
            }

            int distanceproj = (distime) + direction; //The direction it spins


            //Making player variable "p" set as the projectile's owner
            Player p = Main.player[projectile.owner];

            //Factors for calculations

            double deg = (double)projectile.ai[1] * speed; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = distanceproj; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            var player = Main.player[projectile.owner];
            if (player.dead)
            {
                projectile.Kill();
                return;
            }
            //AnimateProjectile();

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 185, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;


            lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, player.position, player.width, player.height);


            if (player.controlUseTile && lineOfSight && distime >= orbittime) //will fire projectile once it reaches maximum orbit and has a line of sight with the player
            {


                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 30);
               
                //for (int i = 0; i < 10; i++)
                {
                    //target = Main.MouseWorld;
                    //target.TargetClosest(true);
                    float shootToX = Main.MouseWorld.X - projectile.Center.X;
                    float shootToY = Main.MouseWorld.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    bool lineOfSight = Collision.CanHitLine(Main.MouseWorld, 0, 0, projectile.position, projectile.width, projectile.height);


                    distance = 3f / distance;
                    shootToX *= distance * 8;
                    shootToY *= distance * 8;
                    int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("SpectreStaffSpinProj2"), (int)(projectile.damage * 1.5f), projectile.knockBack + 2, Main.myPlayer, 0f, 0f);

                    projectile.Kill();
                }

        }
    }
        
        public override bool CanDamage()
        {
            if (!lineOfSight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Kill(int timeLeft)
        {



            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }

        }
        /*public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }*/
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
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
    }
    //_______________________________________________________________________________________________
    public class SpectreStaffSpinProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orb");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults() 
        {
            projectile.width = 18;
            projectile.height = 18;

            projectile.friendly = true;

            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.aiStyle = 0;
            projectile.tileCollide = true;
            projectile.penetrate = 4;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.1f;
            //projectile.CloneDefaults(297);
            // aiType = 297;
        }
        bool lineOfSight;
       
        public override void AI()
        {

            var player = Main.player[projectile.owner];


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 185, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

              lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, player.position, player.width, player.height);

         

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(10, 10), Main.rand.NextFloat(-10, -10));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 185);
                dust.noGravity = true;
                dust.scale = 0.7f;
            }
        }
        public override void Kill(int timeLeft)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 185);
                dust.noGravity = true;
                dust.scale = 0.7f;
            }

        }
        
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
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

    }
    
    //_______________________________________________________________________________________________
    public class SpectreDaggerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Dagger");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0.4f;
            projectile.friendly = true;
            
            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.penetrate = 5;
            
        }
        int releasetime = 0;
        public override void AI()
        {
            releasetime++;
            projectile.magic = true;

            var player = Main.player[projectile.owner];

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 15, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.scale = 1f;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1000f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                //if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
                if (player.controlUseItem && player.HeldItem.type == mod.ItemType("SpectreDagger") && !player.dead)
                {
                    if (Collision.CanHit(projectile.Center, 0, 0, Main.MouseWorld, 0, 0))
                    {
                        

                        projectile.timeLeft = 120;
                        Vector2 newMove = Main.MouseWorld - projectile.Center;
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
            if (player.releaseUseItem && releasetime >= 10 || player.HeldItem.type != mod.ItemType("SpectreDagger"))
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("SpectreDaggerProj2"), projectile.damage, 0f, projectile.owner, 0f, 0f);

                projectile.Kill();
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 10.2f;
                AdjustMagnitude(ref projectile.velocity);
            }
            

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 16f)
            {
                vector *= 16f / magnitude;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }

            //projectile.damage += 12;
        }


        public override void Kill(int timeLeft)
        {



            //Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 5; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(5, 5), Main.rand.NextFloat(-5, -5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }
           
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * .75f; k++)
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
        /* public void AnimateProjectile() // Call this every frame, for example in the AI method.
         {
             projectile.frameCounter++;
             if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
             {
                 projectile.frame++;
                 projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                 projectile.frameCounter = 0;
             }
         }*/
    }
    //_______________________________________________________________________________________________
    //_______________________________________________________________________________________________
    public class SpectreDaggerProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Dagger");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0.4f;
            projectile.friendly = true;

            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.penetrate = 2;

        }

        public override void AI()
        {
            projectile.magic = true;

            var player = Main.player[projectile.owner];

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 15, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.scale = 1f;

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            

        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }

            //projectile.damage += 12;
        }


        public override void Kill(int timeLeft)
        {



            //Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 5; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(5, 5), Main.rand.NextFloat(-5, -5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * .75f; k++)
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
