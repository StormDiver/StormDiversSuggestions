using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.NPCProjs
{
    public class GraniteMiniBossProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Bolt");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
    
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 180;
            projectile.penetrate = -1;
               
            projectile.tileCollide = true;
        
            projectile.ranged = true;
            
            aiType = ProjectileID.Bullet;
          

        }
       
        
        int dusttime;
        public override void AI()
        {

             dusttime++;
           
            if (dusttime > 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 2f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 2f * (float)i;
                 

                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 70, 0, 0, 100, default, 1.5f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;

                }
            }
            Dust dust2;
            Vector2 position2 = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position2, 65, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1.5f);
            dust2.noGravity = true;
            dust2.noLight = true;

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
        
            for (int i = 0; i < 15; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 130, default, 1.2f);
                dust.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70);
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
            for (int k = 0; k < projectile.oldPos.Length * 0.5f; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
    
    }
    
}
