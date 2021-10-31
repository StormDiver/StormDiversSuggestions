using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Projectiles
{

    public class BloodDropProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Drop");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            //projectile.magic = true;
            projectile.aiStyle = 2;
            //projectile.CloneDefaults(48);
            //aiType = 48;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            projectile.knockBack = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        bool bloodspray = true;
        public override void AI()
        {


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center;
                dust = Terraria.Dust.NewDustPerfect(position, 115, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
                if (bloodspray)
                {
                    dust.noGravity = true;
                }

            }

            if (!bloodspray)
            {
                projectile.velocity.X = 0;
                //projectile.velocity.Y = 0;
            }
            return;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (bloodspray)
            {
                Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 13);
            }
            bloodspray = false;

            //projectile.timeLeft = 100;
            return false;
        }
    }
    //------------------------------------------
    public class BloodSwordProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Trial");
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            //projectile.magic = true;

            projectile.penetrate = 3;
            projectile.timeLeft = 50;
            projectile.knockBack = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        //bool bloodspray = true;
        public override void AI()
        {


            if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];


            }


            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 13);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 13);

            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];

            }
        }
    }
    //______________________________________________________________________________________________________________________
    public class BloodSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1f;
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
                    MovementFactor = 1.5f; // Make sure the spear moves forward when initially thrown out
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
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 5, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 1, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

        }

    
    }
   
    //_______________________________________________
    public class BloodOrbitProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Orb");
        }
        public override void SetDefaults()
        {

            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
  
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 90;
           
        }
        public override bool CanDamage()
        {
            return false;
        }
        public override void AI()
        {

            projectile.rotation += (float)projectile.direction * -0.3f;

            if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.Center;
                dust = Terraria.Dust.NewDustPerfect(position, 5, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);


            }
            Player p = Main.player[projectile.owner];

            //Factors for calculations
            double deg = (double)projectile.ai[1] * -4.1f; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 100; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            var player = Main.player[projectile.owner];
            if (player.GetModPlayer<StormPlayer>().BloodOrb == false || player.dead)
            {
                projectile.Kill();
            }



        }
    }
    //_________________________________________
    public class BloodYoyoProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Attack Yoyo");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 5f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 200f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }
        public override void SetDefaults()
        {

            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 360;

            projectile.scale = 1f;
            projectile.aiStyle = 99;

            // drawOffsetX = -3;
            // drawOriginOffsetY = 1;
        }
        int shoottime = 0;
        public override void AI()
        {
            if (Main.rand.Next(2) == 0) // the chance
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = false;

            }
            shoottime++;
            if (shoottime >= 8)
            {
                

               
                    
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("BloodYoyoProj2"), (int)(projectile.damage * .4f), 0f, projectile.owner, 0f, 0f);
                    shoottime = 0;
                
            }

        }


    }
    //____________________________________________________________________________________________
    public class BloodYoyoProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Yoyo trail");
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            //projectile.magic = true;

            projectile.penetrate = 1;
            projectile.timeLeft = 20;
            projectile.knockBack = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        //bool bloodspray = true;
        public override void AI()
        {


            if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
            }


            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];


            }


            return;
        }

      
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 13);

            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];

            }
        }
    }
}