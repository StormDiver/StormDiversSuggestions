using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.NPCProjs
{

    public class SandCoreProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Sand");
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.extraUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.Center.X - 5, projectile.Center.Y - 5), 10, 10, 10, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.Center.X - 5, projectile.Center.Y - 5), 10, 10, 54, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                    Main.dust[dust2].velocity *= 0.5f;

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
   
            target.AddBuff(mod.BuffType("AridSandDebuff"), 180);
        }
      

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }

}
