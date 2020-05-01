using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class BouncyArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BouncyArrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.2f;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            
            
            projectile.tileCollide = true;
            projectile.penetrate = 5; 
            projectile.ranged = true;
            
            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        public override void AI()
        {
            

        }
        int reflect = 5;
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X *0.6f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y *0.6f;
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 56);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


            projectile.velocity.X = projectile.velocity.X * -0.6f;

            projectile.velocity.Y = projectile.velocity.Y * -0.6f;
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 56);
        }
       
        public override void Kill(int timeLeft)
        {
            
             int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("BouncyArrow")) : 0;
             Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
             Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 72);
            }

        }
    }
}
