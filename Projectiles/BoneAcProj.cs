using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    
    public class BoneAcProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Proj");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.CloneDefaults(131);
            aiType = 131;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.ranged = true;
            projectile.melee = false;
            projectile.timeLeft = 100;
            projectile.tileCollide = false;

            drawOffsetX = 2;
            drawOriginOffsetY = 2;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }
       

    }
   

}
