using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
   
    public class GladiatorStaffProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gladiator Staff Beam");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }
        public override void SetDefaults()
        {

            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.magic = true;
            projectile.timeLeft = 120;
            projectile.aiStyle = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

       
        public override void AI()
        {

     
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.height, projectile.width, 57, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;



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
    //___________________________________
    public class GladiatorStaffProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gladiator Energy Orb");
           

        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.magic = true;
            projectile.timeLeft = 60;
            projectile.aiStyle = 14;
            
            
        }

        public override void AI()
        {
          

            for (int i = 0; i < 10; i++)
            {
                float X = projectile.Center.X - projectile.velocity.X / 5f * (float)i;
                float Y = projectile.Center.Y - projectile.velocity.Y / 5f * (float)i;


                int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 57, 0, 0, 100, default, 1f);
                Main.dust[dust].position.X = X;
                Main.dust[dust].position.Y = Y;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].scale *= 1f;
            }
            Dust dust2;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position2 = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position2, 57, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1.5f);
            dust2.noGravity = true;
            dust2.noLight = true;


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
        
    }

}
