using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
 
    //___________________________________________________________________________________________
    public class SwordLightProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Essence");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0.3f;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            //drawOffsetX = 2;
            //drawOriginOffsetY = -10;
        }
        int dusttime;
        public override void AI()
        {
            dusttime++;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);
            projectile.spriteDirection = projectile.direction;
            /*Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            dust = Terraria.Dust.NewDustPerfect(projectile.Center, 43, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 2f);
            dust.noGravity = true;
            dust.fadeIn = 0.5f;*/
            if (dusttime >= 3)
            {
                for (int i = 0; i < 5; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 5f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 5f * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 66, 0, 0, 100, default, 1f);
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
            float distance = 250f;
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
            if (magnitude > 15f)
            {
                vector *= 15f / magnitude;
            }

        }
    
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 66, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 130, default, 1f);
                dust.noGravity = true;

                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 63, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 130, default, 1f);

            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            return true;
            
        }
        
  

        public override void Kill(int timeLeft)
        {



            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 7, 0.5f);
            for (int i = 0; i < 25; i++)
            {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 66, 0, 0, 130, default, 1f);
                dust.noGravity = true;
            }

        }
        

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
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
    //___________________________________________________________________________________________
    public class SwordDarkProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Essence");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.light = 0f;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 90;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            //drawOffsetX = 2;
            //drawOriginOffsetY = -10;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);
            projectile.spriteDirection = projectile.direction;
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 109, projectile.velocity.X * -0.2f, projectile.velocity.Y * -0.2f, 0, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
            Main.dust[dust].noGravity = true; //this make so the dust has no gravity
           


            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 120;
                projectile.height = 120;
                projectile.Center = projectile.position;


                projectile.knockBack = 6;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("DarkShardDebuff"), 300);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
            return false;

        }



        public override void Kill(int timeLeft)
        {


            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 1.5f, -0.5f);

            for (int i = 0; i < 60; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 54, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 60; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 109, 0f, 0f, 0, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
            for (int i = 0; i < 60; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 0, 0, 109, 0f, 0f, 0, default, 2f);
                //Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                //Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 3;

            }



        }


        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft > 3)
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
    }
}