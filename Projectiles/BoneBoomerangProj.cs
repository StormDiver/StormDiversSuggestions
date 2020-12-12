using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Projectiles
{

    
    public class BoneBoomerangProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Boomerang");
        }
        public override void SetDefaults()
        {

            projectile.friendly = true;

            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            projectile.scale = 1f;
            projectile.CloneDefaults(52);
            aiType = 52;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -4;
            drawOriginOffsetY = -4;
        }


        public override void AI()
        {
            

            projectile.width = 24;
            projectile.height = 24;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

           
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 2);



        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 2);

            return true;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);



            }



        }
    }
    

}