using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
    
    public class DerplingEnemyShellProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Shell Shard");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }
        public override void SetDefaults()
        {

            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 3;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
           
            //projectile.CloneDefaults(106);
            //aiType = 106;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
        }

        public override void AI()
        {
          
            projectile.rotation += (float)projectile.direction * -0.6f;


        }
        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }


            }

            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 3);

            return false;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {


            for (int i = 0; i < 5; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
            }


        }

        public override void Kill(int timeLeft)
        {
            

                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 89);

                for (int i = 0; i < 5; i++)
                {

               
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
                }

            
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.oldRot[k], drawOrigin, projectile.scale * 0.9f, SpriteEffects.None, 0f);

            }
            return true;

        }

    }
   
}