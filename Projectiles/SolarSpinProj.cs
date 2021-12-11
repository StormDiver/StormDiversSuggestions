using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles     //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SolarSpinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Spinner");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
           
            projectile.width = 260;     
            projectile.height = 260;      
            projectile.friendly = true;    
            projectile.penetrate = -1;    
            projectile.tileCollide = false; 
            projectile.ignoreWater = true;       
            projectile.melee = true;
            //projectile.scale = 1.2f;
            

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(BuffID.Daybreak, 600);

            }

            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 6);
                dust.scale = 2f;
                dust.noGravity = true;
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 74);
            }

        }
        // float hitbox = 300;
        //bool hitboxup;
        //bool hitboxdown;

        public override void AI()
        {

            
            //-------------------------------------------------------------Sound-------------------------------------------------------
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 7);    
                projectile.soundDelay = 25;    
            }
            //-----------------------------------------------How the projectile works---------------------------------------------------------------------
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            Lighting.AddLight(projectile.Center, 1f, 0.5f, 0f);     //this is the projectile light color R, G, B (Red, Green, Blue)
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;
            
            projectile.spriteDirection = player.direction;
            
            projectile.rotation += 0.2f * player.direction; //this is the projectile rotation/spinning speed
           
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;

            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 7;
           /* if (hitbox == 300)
            {
                hitboxup = false;
                hitboxdown = true;
            }
            if (hitbox == 270)
            {
                hitboxup = true;
                hitboxdown = false;
            }
            if (hitboxup == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    hitbox++;
                }
            }
            if (hitboxdown == true)
            {
                hitbox--;
            }
            projectile.width = (int)hitbox;
            projectile.height = (int)hitbox;*/
        }
    
         public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
         {
             Texture2D texture = Main.projectileTexture[projectile.type];
             spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
             Player player = Main.player[projectile.owner];

             Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
             for (int k = 0; k < projectile.oldPos.Length * 0.7f; k++) //Distance between afterimages
             {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    
                 Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length) * 0.5f; //Opactiy
                 spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.oldRot[k], drawOrigin, (float)(projectile.scale * 0.9f), SpriteEffects.None, 0f);

             }
             return false;

         }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            
            
        }

        public override Color? GetAlpha(Color lightColor)
        {



                Color color = Color.White;
                color.A = 75;
                return color;

           

        }
    }
    public class SelenianReflect : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        
    
        bool reflected;
        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];

            //var projreflect = Main.projectile[mod.ProjectileType("SelenianBladeProj")];

            //if (Main.LocalPlayer.HasBuff(BuffType<SelenianBuff>()))
            if (player.itemAnimation > 1 && Main.mouseLeft && player.HeldItem.type == mod.ItemType("SolarSpin"))
            {

                if (projectile.hostile)
                {
                    if (
                        projectile.aiStyle == 0 ||
                        projectile.aiStyle == 1 ||
                        projectile.aiStyle == 2


                        )
                    {
                        //Player player = Main.player[npc.target];

                        float distanceX = player.Center.X - projectile.Center.X;
                        float distanceY = player.Center.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));


                        if (distance <= 100 && !reflected)
                        {

                            int choice = Main.rand.Next(2);
                            if (choice == 0)
                            {
                                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 56);
                                //projectile.Kill();
                                projectile.velocity.X *= -1f;


                                projectile.velocity.Y *= -1f;

                                projectile.friendly = true;
                                projectile.hostile = false;

                                projectile.damage *= 4;
                                reflected = true;
                            }
                            else
                            {
                                reflected = true;
                            }


                        }
                    }
                }

                
            }
        }
    }
}