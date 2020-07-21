using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs
{
    public class SolarDerpProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Fireball");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 600;
            projectile.penetrate = 4;

            
            projectile.tileCollide = true;
            projectile.scale = 1f;

          

            projectile.aiStyle = 14;
            aiType = ProjectileID.Meteor1;


        }
        
       
        
        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.6f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 153, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }
            Dust dust2;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position2 = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position2, 174, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust2.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;

            AnimateProjectile();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            
            
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                //target.AddBuff(mod.BuffType("ScanDroneDebuff"), 480);
                target.AddBuff(BuffID.OnFire, 300, false);
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            //Main.PlaySound(SoundID.Item10, projectile.Center);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(4, 4), Main.rand.NextFloat(-4, -4));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 244);
                //Main.PlaySound(3, (int)projectile.Center.X, (int)projectile.Center.Y, 3);
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

    }
}
