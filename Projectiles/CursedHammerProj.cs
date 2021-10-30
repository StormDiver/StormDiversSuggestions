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
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
          
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

            speedup++;
            shoottime++;
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
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                    dust2.noGravity = true;
                }
               
                
                    projectile.velocity.X *= 12f;
                    projectile.velocity.Y *= 12f;
                
                projectile.penetrate = 2;
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 10;
            }

            if (speedup >= 60)
            {


                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;


                if (shoottime >= 17)
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
           



        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                dust.noGravity = true;
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);
            }

           
            {
                target.AddBuff(BuffID.CursedInferno, 600);

            }
            if (speedup < 60)
            {
                projectile.damage = (projectile.damage * 8) / 10;
            }
            else
            {
                projectile.damage = (projectile.damage * 9) / 10;

            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            
            return true;
        }

        public override void Kill(int timeLeft)
        {


            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 30; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
                dust.noGravity = true;
            }

        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            if (speedup > 60)
            {
                Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

                }
            }
            return true;
   

        }
    }
    //___________________________________________________________________________________________
    public class CursedHammerProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Hammer");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.light = 0.3f;
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


            projectile.damage = (projectile.damage * 9) / 10;


        }


        public override void Kill(int timeLeft)
        {


            
           Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            for (int i = 0; i < 20; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 107);
               dust.noGravity = true;
            }

        }
        

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            
            return true;

        }
    }
}