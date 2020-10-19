using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using StormDiversSuggestions;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.VanillaChanges
{
    

    public class FixedProjectiles : GlobalProjectile
    {
        


        public override void SetDefaults(Projectile projectile)
        {
            if (GetInstance<Configurations>().EnableFixedProjs)
            

            
            if(projectile.type == ProjectileID.MeteorShot)
            {
               
            }
            if (projectile.type == ProjectileID.ChlorophyteArrow)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = 10;
            }
            if (projectile.type == ProjectileID.MoonlordArrow)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = -1;
            }
            if (projectile.type == ProjectileID.JestersArrow)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = -1;
            }
            if (projectile.type == ProjectileID.UnholyArrow)
            {
                projectile.usesLocalNPCImmunity = true;
                projectile.localNPCHitCooldown = -1;
            }
        }

        

       
      
    }
}
