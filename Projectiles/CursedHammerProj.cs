using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class CursedHammerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Hammer");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.light = 0.6f;
            projectile.friendly = true;
           
            projectile.magic = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = -3;
            drawOriginOffsetY = -10;
        }
        int speedup = 0;
        int shoottime = 0;
        public override void AI()
        {
            
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;

            AnimateProjectile();
            speedup++;
            shoottime++;
            if (speedup < 60)
            {
                projectile.rotation = (0.4f * speedup);
                projectile.penetrate = -1;
            }
            if (speedup == 60)
            {


                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);

                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                    dust2.noGravity = true;
                }
               
                
                {

                    projectile.velocity.X *= 12f;
                    projectile.velocity.Y *= 12f;
                }
            }

                if (speedup >= 60)
                {


                    projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
                   

                if (shoottime >= 18)
                {
                    float speedX = 0f;
                    float speedY = -4f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(90));
                    float scale = 1f - (Main.rand.NextFloat() * .5f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("CursedHammerProj2"), (int)(projectile.damage * 0.7f), 0f, projectile.owner, 0f, 0f);

                    for (int i = 0; i < 10; i++)
                    {

                        Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                        var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                        dust2.noGravity = true;
                    }
                    shoottime = 0;
                }

            }
            if (speedup == 60)
            {
                projectile.penetrate = 2;
            }



        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                dust.noGravity = true;
                //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74);
            }

           
            {
                target.AddBuff(BuffID.CursedInferno, 600);

            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            
            return true;
        }

        public override void Kill(int timeLeft)
        {


            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                dust.noGravity = true;
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 2; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/CursedHammerProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //___________________________________________________________________________________________
    public class CursedHammerProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Hammer");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.light = 0.6f;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.magic = true;
            projectile.timeLeft = 200;
            //aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;
            projectile.scale = 0.8f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = -6;
            drawOriginOffsetY = -15;
        }
        int spin = 0;
        public override void AI()
        {
            spin++;
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;
            projectile.rotation = (0.3f * spin);
            AnimateProjectile();
           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
               dust.noGravity = true;
                
            }

           
            
                target.AddBuff(BuffID.CursedInferno, 400);

            

        
        }


        public override void Kill(int timeLeft)
        {


            
           Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
               dust.noGravity = true;
            }

        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 10) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 2; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/CursedHammerProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
}