using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class PredictorBrainProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Brain Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.light = 0.6f;
            projectile.friendly = true;
            
            projectile.magic = true;
            projectile.timeLeft = 300;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 2;
            drawOriginOffsetY = -10;
        }
        int charge = 0;
        public override bool CanDamage()
        {

            return false;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.9f;
            projectile.velocity.Y *= 0.9f;

            /*projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);*/
            projectile.spriteDirection = projectile.direction;

            charge++;
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
            Main.dust[dust].noGravity = true; //this make so the dust has no gravity
            Main.dust[dust].velocity *= -0.3f;
            int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
            Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
            Main.dust[dust2].velocity *= -0.3f;

            if (charge == 50)
            {
               
               
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
                for (int i = 0; i < 10; i++)
                {

                    
                    var dust3 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                    var dust4 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);

                }
                //for (int i = 0; i < 10; i++)
                {
                    //target = Main.MouseWorld;
                    //target.TargetClosest(true);
                    float shootToX = Main.MouseWorld.X - projectile.Center.X;
                    float shootToY = Main.MouseWorld.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    bool lineOfSight = Collision.CanHitLine(Main.MouseWorld, 0, 0, projectile.position, projectile.width, projectile.height);
                    

                        distance = 3f / distance;
                        shootToX *= distance * 7;
                        shootToY *= distance * 7;
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("PredictorBrainProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);

                        projectile.Kill();
                    
                }
                    
                    
                

            }
            
           
        }
    

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27);
                dust.noGravity = true;
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {

/*
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }*/

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
    //___________________________________________________________________________________________
    public class PredictorBrainProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Brain Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.light = 0.3f;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.magic = true;
            projectile.timeLeft = 200;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 2;
            drawOriginOffsetY = -10;
        }
        
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            //Dust.NewDust(projectile.Center + projectile.velocity, projectile.width, projectile.height, 175);
            projectile.spriteDirection = projectile.direction;
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
            Main.dust[dust].noGravity = true; //this make so the dust has no gravity
            Main.dust[dust].velocity *= -0.3f;
            int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
            Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
            Main.dust[dust2].velocity *= -0.3f;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 72, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 130, default, 0.5f);

            }
            target.AddBuff(mod.BuffType("NebulaDebuff"), 180);

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            return true;
            
        }
        
  

        public override void Kill(int timeLeft)
        {



            //Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int i = 0; i < 10; i++)
            {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 72, 0, 0, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27, 0, 0, 130, default, 0.5f);
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