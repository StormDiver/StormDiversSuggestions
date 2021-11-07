using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class NebulaFlame : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Flame");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            
            projectile.penetrate = -1;
            projectile.timeLeft = 150;
            projectile.extraUpdates = 3;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 0.1f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 130, default, 2f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= -0.3f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= -1f;
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
                target.AddBuff(mod.BuffType("NebulaDebuff"), 300);
            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}