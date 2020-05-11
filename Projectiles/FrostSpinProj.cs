using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles     //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class FrostSpinProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostSpinner");
        }
        public override void SetDefaults()
        {
           
            projectile.width = 150;     
            projectile.height = 150;      
            projectile.friendly = true;    
            projectile.penetrate = -1;    
            projectile.tileCollide = false; 
            projectile.ignoreWater = true;       
            projectile.melee = true;
            projectile.ownerHitCheck = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(BuffID.Frostburn, 900);

            }
        }
       // float hitbox = 150;
       // bool hitboxup;
       // bool hitboxdown;
        public override void AI()
        {
           
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)
            {
                Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 7);    
                projectile.soundDelay = 45;    
            }
           
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            Lighting.AddLight(projectile.Center, 0f, 0.5f, 0.5f);     
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;  
            projectile.spriteDirection = player.direction;
            projectile.rotation += 0.3f * player.direction; 
           /* if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }*/ 
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;


            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

           /* if (hitbox == 160)
            {
                hitboxup = false;
                hitboxdown = true;
            }
            if (hitbox == 150)
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
            return false;
        }
    }
}