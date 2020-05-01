using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class BuffShroomProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShroomiteEnhancedProj");
           
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 1;

            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            

        }
        
       
       // int dusttime = 10;
        public override void AI()
        {
           
           
            Dust dust;
           
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 187, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

        
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }

       

    }
    public class BuffSpectreProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SpectreBuffbolt");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.light = 1f;
            projectile.friendly = true;
            projectile.penetrate = 8;
            projectile.magic = false;
            projectile.timeLeft = 200;
            aiType = ProjectileID.Bullet;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }


        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;

            AnimateProjectile();

            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 66);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0f;
                Main.dust[j].noGravity = true;

            }


            projectile.velocity.X *= 1.05f;
            projectile.velocity.Y *= 1.05f;




        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 60);
            }
        }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 15);
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
    }
}
