using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Basefiles
{
    
    public class ProjectileModfier : GlobalProjectile
    {
        /*public override bool InstancePerEntity => true;
        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            var player = Main.player[projectile.owner];
            if (player.GetModPlayer<StormPlayer>().primeSpin == true)

            {
                if (projectile.hostile)
                {
                    
                    projectile.velocity.X *= -1f;


                    projectile.velocity.Y *= -1f;
                    
                    projectile.friendly = true;

                    projectile.damage *= 4;
                    
                }
            }
        }
        */


        /* public override void AI(Projectile projectile)
         {
             var player = Main.player[projectile.owner];


             if (player.GetModPlayer<StormPlayer>().primeSpin == true)

             {

                 if (projectile.hostile)
                 {
                     if (projectile.type != ProjectileID.PhantasmalDeathray &&
                         projectile.type != ProjectileID.SaucerDeathray &&
                         projectile.type != ProjectileID.CultistRitual &&
                         projectile.type != ProjectileID.CultistBossIceMist &&
                         projectile.type != ProjectileID.CultistBossLightningOrb &&
                         projectile.type != ProjectileID.VortexVortexPortal &&
                         projectile.type != ProjectileID.VortexVortexLightning &&
                         projectile.type != ProjectileID.Sharknado &&
                         projectile.type != ProjectileID.SharknadoBolt &&
                         projectile.type != ProjectileID.Cthulunado

                         )
                     {
                         //Player player = Main.player[npc.target];

                         float distanceX = player.Center.X - projectile.Center.X;
                         float distanceY = player.Center.Y - projectile.Center.Y;
                         float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

                         { }
                         if (distance >= 150 && distance <= 160 && Main.rand.Next(5) == 0)
                         {

                             {
                                 Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 4);
                                 projectile.Kill();
                             }
                         }
                     }
                     }
                       Dust dust;
                     // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                     Vector2 position = projectile.position;
                     dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 59, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                     dust.noGravity = true;

             }*/

        /* if (projectile.ranged)
         {

             rangedincrease++;
             if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
             {

 Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 59, 0f, 0f, 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

            
                 dust.scale = 1.2f;
                 if (rangedincrease == 1)
                 {
                     if (projectile.penetrate >= 1)
                     {
                         projectile.penetrate = (projectile.penetrate + 1);
                     }
                     projectile.knockBack *= 2f;
                     projectile.usesLocalNPCImmunity = true;
                     projectile.localNPCHitCooldown = 10;
                     projectile.extraUpdates += (int)1.5f;
                 }
             }
         }*/


    }
    /* public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockBack, bool crit)
     {
         if (projectile.melee)
         {
             if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()))
             {
                 if (Main.rand.Next(5) == 0)
                 {
                     target.AddBuff(mod.BuffType("BeetleDebuff"), 300);
                 }

             }
         }
         if (projectile.ranged)
         {
             if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
             {

             }

         }

         if (projectile.magic)
         {
             if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
             {

             }
         }
     }
     public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
     {
         if (projectile.magic)
         {

         }
         return true;
     }*/
}
    

        
    

