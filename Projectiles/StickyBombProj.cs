using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{

    public class StickyBombProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Bomb");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;


           
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.aiStyle = 2;

            projectile.penetrate = 5;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 3600;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -1;
            drawOriginOffsetY = -1;
        }
        bool stick; //wheter bomb has hit a tile
        bool boomed; //when it is exploding
        int boomtime = 0; //How long until you can actually detonate
        bool unstick; //Bool for if you unstick the bombs
        
        public override bool CanDamage()
        {
            if (unstick)
            {
                return true;
            }
            if (!boomed)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        
        public override void AI()
        {
            boomtime++;
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                boomed = true;

                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 200;
                projectile.height = 200;
                projectile.Center = projectile.position;


                projectile.knockBack = 3f;
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                //projectile.hostile = true;


            }
            else
            {

                if (!stick)
                {
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;

                    dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;

                }
            }

            if (stick && !unstick)
            {
                projectile.velocity.X = 0;
                projectile.velocity.Y = 0;
                projectile.knockBack = 0;

            }
            var player = Main.player[projectile.owner];

            if ((player.controlUseTile && !player.controlDown && player.HeldItem.type == mod.ItemType("StickyLauncher") && boomtime > 30) || player.dead) //will go BOOM
            {
                if (projectile.timeLeft > 3)
                {
                    projectile.timeLeft = 3;
                }
            }
            if ((player.controlUseTile && player.controlDown && !unstick && stick)) //will go BOOM
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 108);
                projectile.velocity.Y = -2;
                unstick = true;
            }

        }
            
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            damage /= 4;
            target.velocity.Y = -15;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!unstick)
            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            }
            if (!stick)
            {
                projectile.penetrate = -1;
                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 31);


                }
                Main.PlaySound(SoundID.NPCHit, (int)projectile.Center.X, (int)projectile.Center.Y, 1, 0.5f, 0.2f);

            }
            stick = true;
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (unstick)
            {
                if (projectile.timeLeft > 3)
                {
                    projectile.timeLeft = 3;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);



            for (int i = 0; i < 50; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.Center.X- 10, projectile.Center.Y - 10), 20, 20, 6, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].noGravity = false;
                Main.dust[dustIndex].velocity *= 4f;
                int dustIndex2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - 10), projectile.width, projectile.height, 6, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex2].noGravity = true;
                Main.dust[dustIndex2].velocity *= 2;

            }
            for (int i = 0; i < 40; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 3f;
                dust.velocity *= 5;

            }
            for (int i = 0; i < 50; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                Main.dust[dustIndex].scale = 0.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }

    }
   
}