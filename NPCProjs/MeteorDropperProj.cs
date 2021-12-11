using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCProjs
{
    public class MeteorDropperProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Fragment");
            Main.projFrames[projectile.type] = 4;

        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.light = 0.3f;
            projectile.friendly = false;
            projectile.hostile = true;
            
            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
        }
       
        public override void AI()
        {
          
  


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                dust2.noGravity = true;
                dust2.scale = 1.5f;
                dust2.velocity *= 2;

            }
          

          

            AnimateProjectile();

        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);
         }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                dust.noGravity = true;
                dust.scale = 1.5f;
            }
            return true;
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 6) 
            {
                projectile.frame++;
                projectile.frame %= 4; 
                projectile.frameCounter = 0;
            }
        }
        public override void Kill(int timeLeft)
        {

/*
            Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6);

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 15);
            }*/

        }
        

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        
    }
    
}