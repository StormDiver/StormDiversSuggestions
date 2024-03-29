using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles       
{
   
    public class StompBootProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shockwave");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = false;
            //projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 40;
            projectile.extraUpdates = 1;
            projectile.knockBack = 8f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            projectile.damage = (projectile.damage * 100) / 101;
            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {

                    
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.Bottom.Y - 10), projectile.width, 12, 31, 0f, 0f, 100, default, 100f);
                    
                    Main.dust[dustIndex].scale = 0.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 203);
                 
                    dust2.noGravity = true;


                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }
        
       
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
    public class StompBootProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stompwave");
        }
        public override void SetDefaults()
        {

            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = false;
            //projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.extraUpdates = 1;
            //projectile.knockBack = 2f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
        }

        public override void AI()
        {
           
        }



        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
    
}