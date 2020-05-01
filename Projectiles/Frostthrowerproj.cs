using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class Frostthrowerproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost ");
        }
        public override void SetDefaults()
        {
            
            projectile.width = 12;  
            projectile.height = 12; 
            projectile.friendly = true;  
            projectile.ignoreWater = true; 
            projectile.ranged = true;  
            projectile.penetrate = -1; 
            projectile.timeLeft = 125;   
            projectile.extraUpdates = 3;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default, 3f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f); //this defines the flames dust and color parcticles, like when they fall thru ground, change DustID to wat dust you want from Terraria
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
            target.AddBuff(BuffID.Frostburn, 300);   //this make so when the projectile/flame hit a npc, gives it the buff  onfire , 80 = 3 seconds
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}