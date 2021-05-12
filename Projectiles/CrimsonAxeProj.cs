using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class CrimsonAxeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Axe");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.light = 0.6f;
            projectile.friendly = true;
            projectile.penetrate = 5;

            projectile.magic = true;
            projectile.timeLeft = 300;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -10;
        }
        int speedup = 0;
        public override void AI()
        {
            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;

            speedup++;
            if (speedup < 60)
            {
                projectile.rotation = (0.4f * speedup);
            }
            if (speedup == 60)
            {


                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 34);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87);
                    dust2.noGravity = true;
                }

                float numberProjectiles = 4 + Main.rand.Next(2);
                float rotation = MathHelper.ToRadians(5);
                //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    float speedX = projectile.velocity.X * 10f;
                    float speedY = projectile.velocity.Y * 10f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X * 2f, perturbedSpeed.Y * 2f, mod.ProjectileType("CrimsonAxeProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                }
                projectile.Kill();

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87);
                dust.noGravity = true;
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 60);
            }
            projectile.damage = (projectile.damage * 8) / 10;

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);
            return true;
        }

        public override void Kill(int timeLeft)
        {



            
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87);
                dust.noGravity = true;
            }

        }
        

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        
    }
    //___________________________________________________________________________________________
    public class CrimsonAxeProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Axe");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.light = 0.3f;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 200;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            drawOffsetX = 0;
            drawOriginOffsetY = -10;
        }
        
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);
            //projectile.spriteDirection = projectile.direction;

           
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87);
                dust.noGravity = true;
                
            }

           
            if (Main.rand.Next(2) == 0) // the chance
            {
                target.AddBuff(BuffID.Ichor, 600);

            }

        
    }


        public override void Kill(int timeLeft)
        {



            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 87);
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
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
    }
}