using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class BeetleSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.3f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 6;
        }


        public float MovementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        int shoottime = 0;
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
                    MovementFactor = 4f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 2) // Somewhere along the item animation, make sure the spear moves back
                {
                    MovementFactor -= 1.4f;
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
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 186, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

            shoottime++;
            Player player = Main.player[projectile.owner];
            bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, player.position, player.width, player.height);
            if (shoottime == 10 && lineOfSight)
            {


                Main.PlaySound(29, (int)projectile.Center.X, (int)projectile.Center.Y, 50);

                Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(360));

                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleProj"), (int)(projectile.damage * 0.75f), 0f, projectile.owner, 0f, 0f);

                
            }

        }
       
        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
            Player player = Main.player[projectile.owner];
           
                player.AddBuff(mod.BuffType("TurtleBuff"), 120);

            
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("TurtleDebuff"), 300);
            }
        }*/

    }
    //________________________________________________________________________________________________________________
    public class BeetleYoyoProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Yoyo");
            //ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 15f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = -1;

            projectile.scale = 1f;
            projectile.aiStyle = 99;

            // drawOffsetX = -3;
            // drawOriginOffsetY = 1;
        }
        int shoottime = 0;
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 186, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

            shoottime++;
            if (shoottime >= 20)
            {

                Main.PlaySound(29, (int)projectile.Center.X, (int)projectile.Center.Y, 50);

                Vector2 perturbedSpeed = new Vector2(0, -2).RotatedByRandom(MathHelper.ToRadians(360));

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleProj"), (int)(projectile.damage * 0.75f), 0f, projectile.owner, 0f, 0f);



                shoottime = 0;
            }
        }
       
    }
    //________________________________________________________________________________________________________________
    public class BeetleShellProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Shell");
        }
        public override void SetDefaults()
        {

            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.melee = true;
            projectile.timeLeft = 400;
            projectile.aiStyle = 14;
            projectile.scale = 1f;
            
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 2;
        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 186, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.noLight = true;

            projectile.rotation += (float)projectile.direction * -0.6f;

            drawOffsetX = 0;
            drawOriginOffsetY = 2;
            projectile.width = 26;
            projectile.height = 26;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 7);


            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 186);
                dust.noGravity = true;
            }
            if (Main.rand.Next(5) == 0)
            {
                Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(360));

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleProj"), (int)(projectile.damage * 0.75f), 0f, projectile.owner, 0f, 0f);
                Main.PlaySound(29, (int)projectile.Center.X, (int)projectile.Center.Y, 50);

            }
        }
        int reflect = 4;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);


            if (Main.rand.Next(5) == 0)
            {
                Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(360));

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleProj"), (int)(projectile.damage * 0.75f), 0f, projectile.owner, 0f, 0f);
                Main.PlaySound(29, (int)projectile.Center.X, (int)projectile.Center.Y, 50);

            }
            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.7f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.7f;
                }


            }
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 186);
                dust.noGravity = true;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {


                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-20, -20), Main.rand.NextFloat(20, 20));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 186);
                    dust.noGravity = true;
                }

            }
        }

    }

    //________________________________________________________________________________________________________________
    public class BeetleProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 300;

            projectile.scale = 1f;
            projectile.CloneDefaults(189);
            aiType = 189;

            drawOffsetX = -9;
            drawOriginOffsetY = -9;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            AnimateProjectile();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X * 0.6f;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y * 0.6f;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("BeetleDebuff"), 480);
                //Main.PlaySound(29, (int)projectile.Center.X, (int)projectile.Center.Y, 50);
            }
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {


                for (int i = 0; i < 7; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 186);

                    dust.noGravity = true;

                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 5; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }


    }
   


}