using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs
{
    public class MushroomMiniBossProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouncing Mushroom");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 240;
            projectile.penetrate = -1;

            
            projectile.tileCollide = true;
            projectile.scale = 1f;

          

            projectile.aiStyle = 14;
           // aiType = ProjectileID.Meteor1;


        }
        
       
        
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * 0.1f;

            if (Main.rand.Next(3) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 113, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
            AnimateProjectile();
        }
        int reflect = 4;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            reflect--;



            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * 0.4f;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * 0.4f;
            }

            if (reflect == 0)
            {
                projectile.Kill();
            }
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, projectile.height, 113);
                dust.velocity *= 0.5f;

            }

        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

            for (int i = 0; i < 20; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 113);
                dust.velocity *= 0.2f;
            }

        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 2; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 50;
            return color;

        }
    }
}
