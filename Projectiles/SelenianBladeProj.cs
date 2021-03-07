using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Buffs;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Projectiles
{


    public class SelenianBladeProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Blade");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
        }
        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.scale = 1f;
            projectile.CloneDefaults(106);
            aiType = 106;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.penetrate = -1;
        }

        bool stillspin;
        int stilltime;
        public override void AI()
        {


            projectile.width = 36;
            projectile.height = 36;

            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);  //this is the dust that this projectile will spawn
            Main.dust[dust].velocity /= 1f;
            Main.dust[dust].scale = 1f;
            Main.dust[dust].noGravity = true;
            projectile.penetrate = -1;
            if (stillspin)//while active projectile does not move
            {
                projectile.velocity.Y *= 0f;
                projectile.velocity.X *= 0f;
                stilltime++; //timer counts up while not moving
            }
            if (stilltime >= 45) //once this time is reached it cannot stay still again
            {
                stillspin = false;
            }

            
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


            //Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 2);
            Player player = Main.player[projectile.owner];

            target.AddBuff(BuffID.Daybreak, 300);
            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 6);
                dust.scale = 2f;
                dust.noGravity = true;

            }
            if (stilltime < 45) //So the projectile doesn't stay still again
            {
                stillspin = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            //Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 2);
            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                dust.scale = 2f;
                dust.noGravity = true;

            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 27);



            }



        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            Player player = Main.player[projectile.owner];

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * 0.7f; k++) //Distance between afterimages
            {
                Vector2 drawPos = new Vector2(0, 0) + projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);

                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length) * 0.5f; //Opactiy
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.oldRot[k], drawOrigin, (float)(projectile.scale * 0.9f), SpriteEffects.None, 0f);

            }
            return false;

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 75;
            return color;

        }
    }
    
}