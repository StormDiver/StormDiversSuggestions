using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
 

    public class MeteorArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 1;
            projectile.arrow = true;
            projectile.tileCollide = true;

            projectile.ranged = true;

            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            //Creates no immunity frames
           

            drawOffsetX =0;
            drawOriginOffsetY = 0;
        }
        int hometime;
        public override void AI()
        {
            var player = Main.player[projectile.owner];

            if (projectile.position.Y < (player.position.Y - 200) && player.HeldItem.type == mod.ItemType("MeteorBow"))
            {
                projectile.tileCollide = false;
            }
            else
            {
                projectile.tileCollide = true;

            }

            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 0.7f);
             Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
             Main.dust[dustIndex].noGravity = true;
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 100f;
            bool target = false;
            if (hometime <= 15)
            {
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
            }
            if (target && hometime <=15)
            {
                hometime++;
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 10.5f;
                AdjustMagnitude(ref projectile.velocity);
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 9f)
                {
                    vector *= 9f / magnitude;
                }
            
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);

            for (int i = 0; i < 10; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 6, 0f, 0f, 0, new Color(255, 255, 255), 0.7f)];
                
            }
        }     
    }
}
