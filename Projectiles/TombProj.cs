using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    public class TombProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TombStone");

        }
        public override void SetDefaults()
        {

            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 2;
            //aiType = ProjectileID.WoodenArrowFriendly;
            projectile.ignoreWater = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -2;
        }
        int rotate;
        public override void AI()
        {
            rotate += 1;
            projectile.rotation = rotate * 0.2f;

            if (Main.rand.Next(3) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;

            }
            if (Main.rand.Next(3) == 0)
            {
                Dust dust2;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust2 = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 2, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust2.noGravity = true;

            }
            /* Dust dust2;
             // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
             Vector2 position2 = projectile.Center;
             dust2 = Terraria.Dust.NewDustPerfect(position2, 45, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
             dust2.noGravity = true;*/


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(BuffID.Wet, 300);
            
            
                Projectile.NewProjectile(target.Center.X - 11, target.Top.Y - 15, 0, -3, mod.ProjectileType("GhostProj"), (int)(projectile.damage * 0.6f), 1f, projectile.owner, 0f, 0f);
            for (int i = 0; i < 15; i++)
            {


                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 31);

                dust.noGravity = true;

            }

        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            //target.AddBuff(BuffID.Wet, 300);
        }

        int reflect = 4;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            projectile.damage = (projectile.damage * 9) / 10;
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.9f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.9f;
                }
            }
            if (reflect >= 1)
            {
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62, 0.5f, 1.5f);
            }
            for (int i = 0; i < 5; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 1);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 2);

            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 1);
                    dust.scale = 0.8f;
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 2);
                    dust2.scale = 0.8f;

                }

            }

        }
        
    }
    //___________________________
    public class GhostProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Ghost");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 300;

            projectile.scale = 1f;
            projectile.CloneDefaults(189);
            aiType = 189;

            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            projectile.width = 22;
            projectile.height = 22;

            AnimateProjectile();

            //for (int i = 0; i < 7; i++)
           /* {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);

                dust.noGravity = true;

            }*/
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * 0.6f;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * 0.6f;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           
            Main.PlaySound(4, (int)projectile.Center.X, (int)projectile.Center.Y, 6, 0.5f, 1);
            
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {


                for (int i = 0; i < 7; i++)
                {

                    
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);

                    dust.noGravity = true;

                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
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
