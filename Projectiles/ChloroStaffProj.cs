using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class ChloroStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Stream");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            projectile.extraUpdates = 1;
            projectile.scale = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }
        public override bool CanDamage()
        {

            return true;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            
            if (projectile.ai[0] > 9f)  //this defines where the flames starts
            {
                if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
                {
                    
                    
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 44, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= -0.3f;
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 44);
                    dust2.noGravity = true;
                    
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {


            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);
            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 44);
                dust.noGravity = true;
                dust.velocity *= 3;
            }

        }
    }
    
}