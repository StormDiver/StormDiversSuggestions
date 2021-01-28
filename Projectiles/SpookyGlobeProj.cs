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
    public class SpookyGlobeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Sky Orb");
            
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            
            projectile.friendly = true;
            projectile.penetrate = 1;                  
            projectile.magic = true;
            projectile.timeLeft = 200;
            projectile.aiStyle = 0;
            projectile.light = 0.5f;
           
        
        }
        int timeleft2 = 300;
        public override void AI()
        {
            var player = Main.player[projectile.owner];
           
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 6, 0f, 0f, 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;


            for (int i = 0; i < 10; i++)
            {
                float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;


                int dust2 = Dust.NewDust(new Vector2(X, Y), 0, 0, 127, 0, 0, 100, default, 1f);
                Main.dust[dust2].position.X = X;
                Main.dust[dust2].position.Y = Y;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0f;
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
        
           
            if (projectile.position.Y > player.position.Y)
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;

            }
            timeleft2--;
            if (timeleft2 <= 0)
            {
                projectile.Kill();
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
                projectile.velocity = (10 * projectile.velocity + move) / 10f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 10f)
            {
                vector *= 10f / magnitude;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);


            projectile.Kill();

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            return true;
        }
        public override void Kill(int timeLeft)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);

                dust.noGravity = true;

            }




        }
        
    }
    
    
}
