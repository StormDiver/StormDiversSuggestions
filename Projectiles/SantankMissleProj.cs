using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{

    public class SantankMissleProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ho-Ho-Homing missile");
            Main.projFrames[projectile.type] = 4;

        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;


           
            projectile.friendly = true;

            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 180;

        }
        int timer;
        public override void AI()
        {
            var player = Main.player[projectile.owner];

            /*if (projectile.position.Y > (player.position.Y - 250) && projectile.position.Y < player.position.Y)
            {
                projectile.tileCollide = false;
            }
            else
            {
                projectile.tileCollide = true;

            }*/
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            timer++;
            if (timer > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 6, 0, 0, 100, default, 1f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                }
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 160;
                projectile.height = 160;
                projectile.Center = projectile.position;
                

                projectile.knockBack = 3f;
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                
                
            }
            if (timer > 45)
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

            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (timer > 45)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 15f)
                {
                    vector *= 15f / magnitude;
                }
            }
        }
        public override bool CanDamage()
        {
            if (timer < 45)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (timer < 45)
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }
            }
            if (projectile.timeLeft > 3 && timer >= 45)
            {
                projectile.timeLeft = 3;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);



            for (int i = 0; i < 30; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 4f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            for (int i = 0; i < 50; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
                dust.velocity *= 3;


            }
            for (int i = 0; i < 50; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }

    }
    
}