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
            DisplayName.SetDefault("Bouncy Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            projectile.aiStyle = 1;
            
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
            projectile.damage = (projectile.damage * 9) / 10;

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X *0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y *0.8f;
                }
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 56);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            projectile.damage = (projectile.damage * 8) / 10;

            projectile.velocity.X = projectile.velocity.X * -0.6f;

            projectile.velocity.Y = projectile.velocity.Y * -0.6f;
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 56);
        }
       
        public override void Kill(int timeLeft)
        {
            
             int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("BouncyArrow")) : 0;
             Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
             Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 3; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 100, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }

        }
    }
}
