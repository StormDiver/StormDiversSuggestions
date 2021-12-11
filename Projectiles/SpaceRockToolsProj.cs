using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Projectiles
{
    
    public class SpaceRockDrillSawProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid DrillSaw");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
        
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;
            
            drawOffsetX = 9;
            drawOriginOffsetY = 0;
       
        }

        public override void AI()
        {
           
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
     
            AnimateProjectile();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

         
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 2) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 3; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
   
    public class SpaceRockJackhammerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Jackhammer");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
    
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;

            drawOffsetX = 9;
            drawOriginOffsetY = 0;

        }

        public override void AI()
        {
           
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;



            AnimateProjectile();
        }



        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 3; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
