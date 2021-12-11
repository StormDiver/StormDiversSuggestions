using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Projectiles
{
    
    public class SantankDrillProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santank Drill");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            //projectile.CloneDefaults(509);
            // aiType = 509;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;
            
            drawOffsetX = 7;
            drawOriginOffsetY = 0;

            
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 0.35f, projectile.velocity.Y * 0.3f, 100, default, 1.9f);
            Main.dust[dust].noGravity = true;

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
                projectile.frame %= 2; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }


    }
    public class SantankSawProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santank Chainsaw");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            //projectile.CloneDefaults(509);
            // aiType = 509;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;

            drawOffsetX = 6;
            drawOriginOffsetY = 0;


        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 1.9f);
            Main.dust[dust].noGravity = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;   
            AnimateProjectile();
        }

       

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 2) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 2; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }


    }
    public class SantankJackhamProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santank Jackhammer");
            Main.projFrames[projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            //projectile.CloneDefaults(509);
            // aiType = 509;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true; //so you can't hit enemies through walls
            projectile.melee = true;

            drawOffsetX = 5;
            drawOriginOffsetY = 0;


        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 127, projectile.velocity.X * 0.35f, projectile.velocity.Y * 0.3f, 100, default, 1.9f);
            Main.dust[dust].noGravity = true;

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


    }
}
