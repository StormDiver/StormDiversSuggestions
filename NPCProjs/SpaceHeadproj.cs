using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
    public class SpaceHeadProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Rock");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.light = 0.6f;
            projectile.friendly = false;
            projectile.hostile = true;
            
            projectile.magic = true;
            projectile.timeLeft = 300;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
        }
        int charge = 0;
        public override bool CanDamage()
        {

            return false;
        }
        int rotate;
        public override void AI()
        {
            projectile.velocity.X *= 0.9f;
            projectile.velocity.Y *= 0.9f;
            rotate += 1;
            projectile.rotation = rotate * 0.1f;
  


            charge++;
            if (Main.rand.Next(7) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                dust2.noGravity = true;
                dust2.scale = 1.5f;
                dust2.velocity *= 2;

            }
            if (Main.rand.Next(3) == 0)
            {
    
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 0, default, 0.5f);
            }

            if (charge == 60)
            {
               
               
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 20);
                for (int i = 0; i < 10; i++)
                {

                    
                    var dust3 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                    var dust4 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);

                }
                for (int i = 0; i < 1; i++)
                {
                    Player player = Main.player[i];
                    if (Main.netMode != 1)
                    {

                        //target = Main.MouseWorld;
                        //target.TargetClosest(true);
                        float shootToX = player.position.X - projectile.Center.X;
                        float shootToY = player.position.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));



                        distance = 3f / distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("SpaceHeadProj2"), projectile.damage, projectile.knockBack);

                        projectile.Kill();
                    }

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
        
    }
    //___________________________________________________________________________________________
    public class SpaceHeadProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Rock Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.light = 0.3f;
            projectile.friendly = false;
            projectile.hostile = true;
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
        int rotate;
        public override void AI()
        {
            rotate += 1;
            projectile.rotation = rotate * 0.1f;
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                

            }

        }
        
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1f);
            }
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

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1f);
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