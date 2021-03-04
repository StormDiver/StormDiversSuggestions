using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
   
    public class FlamingSeed : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Seed");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.scale = 0.8f;
        }
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.5f;

            if (Main.rand.Next(2) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 127, 0f, 0f, 0, new Color(255, 255, 255), 1.5f);
                dust.noGravity = true;

            }
     

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
            projectile.damage = (projectile.damage * 9 / 10);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 10, 1, 0.4f);
                for (int i = 0; i < 5; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 127);
                    dust.scale = 0.7f;
                }

            }
           
        }
        
    }
}
