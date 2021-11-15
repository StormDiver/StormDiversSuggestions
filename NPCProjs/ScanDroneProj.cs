using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs
{
    public class ScanDroneProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ScanDrone Bolt");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            
            projectile.light = 0.4f;
            
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 4;

            
            projectile.tileCollide = false;
            projectile.scale = 1.2f;

            
            projectile.extraUpdates = 1;
            projectile.aiStyle = -1;
            //aiType = ProjectileID.VortexBeaterRocket;
            

        }
        
       
        
        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 229);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 0.8f;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            AnimateProjectile();
           
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("ScanDroneDebuff"), 480);
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.Center);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 206);
            }

        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 5; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}
