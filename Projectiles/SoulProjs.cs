using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    public class SoulFrightProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Projectile of Fright");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.magic = true;
            projectile.timeLeft = 30;
            projectile.light = 0.5f;
            
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.scale = 1.5f;
            drawOffsetX = -0;
            drawOriginOffsetY = -0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

        }
       
       
        public override void AI()
        {
           
            AnimateProjectile();

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 259);
                dust.velocity *= 0.5f;
                dust.noGravity = true;
            }

            if (projectile.timeLeft >= 30)
            {

                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 259);
                    dust.velocity *= 2;
                    dust.noGravity = true;

                }
            }
            var player = Main.player[projectile.owner];

            

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (projectile.timeLeft >= 35)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 60f)
                {
                    vector *= 60f / magnitude;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 259, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                dust.scale = 1.5f;
                dust.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {


            for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 259);
                    dust.velocity *= 2;
                    dust.noGravity = true;

                }

            
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
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
    //______________________________
    public class SoulSightProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Projectile of Sight");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.magic = true;
            projectile.timeLeft = 30;
            projectile.light = 0.5f;
           
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.scale = 1.5f;
            drawOffsetX = -0;
            drawOriginOffsetY = -0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

        }


        public override void AI()
        {

            AnimateProjectile();

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
          
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 110);
                dust.velocity *= 0.5f;
                dust.noGravity = true;
            }

            if (projectile.timeLeft >= 30)
            {

                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 110);
                    dust.velocity *= 2;
                    dust.noGravity = true;

                }
            }
            var player = Main.player[projectile.owner];

          

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (projectile.timeLeft >= 35)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 60f)
                {
                    vector *= 60f / magnitude;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 110, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f);
                dust.scale = 0.75f;
            }
        }

        public override void Kill(int timeLeft)
        {


            for (int i = 0; i < 15; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 110);
                dust.velocity *= 2;
                dust.noGravity = true;

            }


        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
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
    //_____________________
    public class SoulMightProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Projectile of Might");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.magic = true;
            projectile.timeLeft = 30;
            projectile.light = 0.5f;
            projectile.tileCollide = false;
            projectile.aiStyle = 0;
            projectile.scale = 1.5f;
            drawOffsetX = -0;
            drawOriginOffsetY = -0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }


        public override void AI()
        {

            AnimateProjectile();

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
           
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56);
                dust.velocity *= 0.5f;
                dust.noGravity = true;
            }
            if (projectile.timeLeft >= 30)
            {

                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56);
                    dust.velocity *= 2;
                    dust.noGravity = true;

                }
            }

            var player = Main.player[projectile.owner];

           

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (projectile.timeLeft >= 35)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 60f)
                {
                    vector *= 60f / magnitude;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);

            }

        }

        public override void Kill(int timeLeft)
        {


            for (int i = 0; i < 15; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 56);
                dust.velocity *= 2;
                dust.noGravity = true;

            }


        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
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