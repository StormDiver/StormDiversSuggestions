using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
  
    //______________________________________________________________________________________________________
    public class AncientStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sand Explosion");
            
            
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            projectile.magic = true;
            projectile.friendly = true;
           
            projectile.timeLeft = 40;
            projectile.penetrate = -1;


            projectile.tileCollide = true;
            projectile.scale = 1f;
            projectile.knockBack = 0;


            projectile.aiStyle = -1;
            //projectile.usesIDStaticNPCImmunity = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;


        }

        public override void AI()
        { 
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

           
                if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
                }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft == 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
               
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 150;
                projectile.height = 150;
                projectile.Center = projectile.position;

               

                projectile.knockBack = 6f;

            }
        }
        public override bool CanDamage()
        {
            if (projectile.timeLeft > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            //target.AddBuff(mod.BuffType("AridSandDebuff"), 180);
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            return false;
        }
        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);

            for (int i = 0; i < 50; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 138);
                dust.noGravity = true;
                dust.scale = 2f;
                dust.velocity *= 3.5f;
                dust.fadeIn = 1f;

            }
            for (int i = 0; i < 50; i++)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 55, 0f, 0f, 0, default, 1f)];
                dust.noGravity = true;
                dust.scale = 1f;


            }
          

        }

    }
    //_______________________________________
    public class AncientKnivesProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Throwing Knife");

        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;

            projectile.aiStyle = 0;


            projectile.friendly = true;
            projectile.timeLeft = 35;
            projectile.penetrate = 1;

            projectile.tileCollide = true;


            projectile.melee = true;
            projectile.light = 0.1f;

            drawOffsetX = 0;
            drawOriginOffsetY = -0;

            projectile.light = 0.2f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }


        int spinspeed = 0;

        public override void AI()
        {

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (projectile.timeLeft == 32)
            {
                projectile.penetrate = 3;

            }
            if (projectile.timeLeft <= 15)
            {

                spinspeed++;
                projectile.rotation = (0.4f * spinspeed) * projectile.direction;

                drawOriginOffsetY = -8;

                projectile.alpha += 17;
                projectile.light -= 0.01f;
            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 5; i++)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust.scale = 0.5f;
            }
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);

            projectile.damage = (projectile.damage * 9 / 10);
            for (int i = 0; i < 5; i++)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust.scale = 0.5f;
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
           
        {
            target.AddBuff(BuffID.OnFire, 180);

            for (int i = 0; i < 5; i++)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 138);
                dust.scale = 0.5f;
            }
        }


        public override void Kill(int timeLeft)
        {
            
            
        }



    }
    //___________________________________________________________________________
    public class AncientFlameProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Sand Stream");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 150;
            projectile.extraUpdates = 2;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
          
            if (projectile.ai[0] > 13f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
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
            projectile.damage = (projectile.damage * 9) / 10;
            

                target.AddBuff(BuffID.OnFire, 180);



            
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
           
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(BuffID.OnFire, 180);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}
