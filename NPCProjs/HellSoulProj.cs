using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
   
    public class HellSoulProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Soul");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;

            projectile.light = 0.4f;

            projectile.friendly = false;
            projectile.hostile = true;

            projectile.penetrate = 1;


            projectile.tileCollide = false;
            projectile.scale = 1.1f;

            projectile.alpha = 150;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

            projectile.timeLeft = 600;
            //aiType = ProjectileID.LostSoulHostile;
            projectile.aiStyle = -1;
            // projectile.CloneDefaults(452);
            //aiType = 452;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }


        readonly int homerandom = Main.rand.Next(180, 300);
        int hometime;
        public override void AI()
        {
            var dust3 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0);
            dust3.noGravity = true;
            hometime++;


            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            if (hometime <= homerandom)
            {
                projectile.velocity.X *= 0.98f;
                projectile.velocity.Y *= 0.98f;
            }

            if (hometime == homerandom)
            {
                for (int i = 0; i < 20; i++)
                {

                    int dust2 = Dust.NewDust(projectile.Center - projectile.velocity, projectile.width, projectile.height, 5, 0f, 0f, 50, default, 1f);
                    Main.dust[dust2].noGravity = true;

                }
            }
            if (hometime >= homerandom && hometime <= homerandom + 30)
            {
                for (int i = 0; i < 200; i++)
                {
                    Player target = Main.player[i];
                    //If the npc is hostile

                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.Center.X - projectile.Center.X;
                    float shootToY = target.Center.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 2000f && target.active)
                    {

                        distance = 0.5f / distance;

                        //Multiply the distance by a multiplier proj faster
                        shootToX *= distance * 7.5f;
                        shootToY *= distance * 7.5f;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }

                }
                

            }

        }
     
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 150);

            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 20; i++)
            {

                int dust2 = Dust.NewDust(projectile.Center - projectile.velocity, projectile.width, projectile.height, 5, 0f, 0f, 50, default, 1f);

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
        /*public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }*/
       
    }
}
