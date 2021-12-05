using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles       
{
 
    public class DerpWaveProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Shockwave");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 120;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            //projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 40;
            projectile.extraUpdates = 1;
            projectile.knockBack = 8f;
            //projectile.usesLocalNPCImmunity = true;
            //projectile.usesIDStaticNPCImmunity = true;
            
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
        }
        float airknock = 13;
        public override void AI()
        {
            projectile.damage = (projectile.damage * 100) / 101;
            airknock -= 0.14f;

            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {


                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 68, 0f, 0f, 100, default, 1.5f);

                    //Main.dust[dustIndex].scale = 0.5f + (float)Main.rand.Next(5) * 0.1f;
                    //Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.friendly && target.lifeMax > 5 && !target.boss  && target.knockBackResist != 0f)
            {
                if (target.velocity.Y == 0)
                {
                    target.velocity.Y = -airknock - (target.knockBackResist * 2);
                    target.velocity.X = 4f * projectile.direction;
                }
                else
                {
                    projectile.knockBack = 20;
                    target.velocity.Y = (-airknock * 0.5f) - (target.knockBackResist * 2);
                    target.velocity.X = 7f * projectile.direction;

                }
                target.AddBuff(mod.BuffType("DerpDebuff"), 45);

                /*if (airknock > 0)
                {
                    airknock--;
                }*/
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //projectile.Kill();
            return false;
        }
    }
}