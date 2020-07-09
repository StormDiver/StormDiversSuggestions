using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class AridArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 600;
           
            projectile.tileCollide = true;
            projectile.penetrate = 1; 
            projectile.ranged = true;
            projectile.extraUpdates = 1;
            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            
        }
        int dropdust = 10;
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
            }
            dropdust--;
            if ((projectile.velocity.X >= 3 || projectile.velocity.X <= -3))
                if (Main.rand.Next(15) == 0)
                {
                int speedX = 0;
                int speedY = 3;

                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("DesertArrowDust"), (int)(projectile.damage * 0.7), 0f, projectile.owner, 0f, 0f);
                dropdust = 10;
            }

        }
        // int reflect = 5;


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }

        public override void Kill(int timeLeft)
        {
            
             
             Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 55);
            }

        }
    }
    //________________________________________________________________________________________
    public class DesertArrowDust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Arrow Dust");

        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.light = 0.1f;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.ranged = true;
            // projectile.aiStyle = 1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 180;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 0f)  //this defines where the flames starts
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
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }


    }
    //________________________________________________________________________________________
    public class DesertSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.3f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }


        public float MovementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        // It appears that for this AI, only the ai0 field is used!
        public override void AI()
        {
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            Player projOwner = Main.player[projectile.owner];
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (MovementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    MovementFactor = 2f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 2) // Somewhere along the item animation, make sure the spear moves back
                {
                    MovementFactor -= 1f;
                }
                else // Otherwise, increase the movement factor
                {
                    MovementFactor += 1.4f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * MovementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            // These dusts are added later, for the 'ExampleMod' effect
            if (Main.rand.NextBool(3))
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 138, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }
    }
    //________________________________________________________________________________________
    public class DesertSpearTipProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Spear Dust");

        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.light = 0.1f;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.melee = true;
            // projectile.aiStyle = 1;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 80;
            projectile.penetrate = 2;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 30f)  //this defines where the flames starts
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
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }


    }
    //________________________________________________________________________________________
   
    public class DesertSpellProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Burning Sand");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 0f)  //this defines where the flames starts
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
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
    //______________________________________________________________________________________________________
    public class DesertJarProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Jar Dust");

        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;

            projectile.friendly = true;
           
            projectile.timeLeft = 100;
            projectile.penetrate = -1;


            projectile.tileCollide = true;
            projectile.scale = 1f;



            projectile.aiStyle = 14;
            


        }

        public override void AI()
        { 
            projectile.velocity.X = 0;
            projectile.velocity.Y = 0;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 138, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 130, default, 1.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                   // int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 55, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);
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
            target.AddBuff(mod.BuffType("AridSandDebuff"), 120);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 180);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            return false;
        }
        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.Center, projectile.velocity, projectile.width, projectile.height);
            

        }

    }
    //______________________________________________________________________________________________________
    public class DesertStaffProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Blast");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 140;
            projectile.extraUpdates = 3;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.scale = 2f;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 20f)  //this defines where the flames starts
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
            target.AddBuff(mod.BuffType("AridSandDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("AridSandDebuff"), 600);
        }
        public override void Kill(int timeLeft)
        {
            float numberProjectiles = 4 + Main.rand.Next(2);
            float rotation = MathHelper.ToRadians(180);
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                float speedX = projectile.velocity.X * 0.6f;
                float speedY = projectile.velocity.Y * 0.6f;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles)));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DesertSpellProj"), (int)(projectile.damage * 0.5f), projectile.knockBack, Main.myPlayer, 0f, 0f);
            }

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 45);


           

        }

    }
    
}
