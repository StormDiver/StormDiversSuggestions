using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Basefiles;



namespace StormDiversSuggestions.NPCProjs
{

    
    public class IceCoreProj: ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Spike");
        }
        public override void SetDefaults()
        {

            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = 2;
           
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            //drawOffsetX = -2;
            //drawOriginOffsetY = -2;
        }
        bool dustspawn = false;
        public override void AI()
        {
            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0f, 0f, 100, default, 0.7f);
            Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
            Main.dust[dustIndex].noGravity = true;

            
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (!dustspawn)
            {
                for (int i = 0; i < 15; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                    dust.velocity *= 2;
                }
                dustspawn = true;
            }
        }

       
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperFrostBurn"), 180);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
           
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 27);

                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                }

            
        }
    }
    //___________________________________________________________________________________________________________________________________
    //___________________________________________________________________________________________________________________________________
    //___________________________________________________________________________________________________________________________________

}