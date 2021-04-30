using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.NPCProjs
{
    public class GladiatorMiniBossProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Warrior Sword");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }
        public override void SetDefaults()
        {

            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = false;
            projectile.penetrate = 2;
            projectile.timeLeft = 120;
            projectile.aiStyle = 0;
            projectile.tileCollide = false;
            projectile.hostile = true;
        }

        int speedup = 0;
        public override void AI()
        {
            if (speedup == 1)
            {
                for (int i = 0; i < 10; i++)
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 57);
                    dust2.noGravity = true;
                    dust2.velocity *= 3;

                }
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.height, projectile.width, 57, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;

            speedup++;
            if (speedup <= 80)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {

        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 57);
                dust.noGravity = true;
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
            return Color.White;
        }
    }

}
