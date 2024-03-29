using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Projectiles
{
    public class TurtleSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 28;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1f;
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

        // It appears that for this AI, only the ai0 field is used!
        public override void AI()
        {
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            
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
                    MovementFactor += 1f;
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
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 0, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

        }
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
            Player player = Main.player[projectile.owner];
            
                player.AddBuff(mod.BuffType("TurtleBuff"), 90);
            
            
           
        }

    }
    //________________________________________________________________________________________________________________
    public class TurtleShellProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Shell");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;

        }
        public override void SetDefaults()
        {

            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            
            //projectile.CloneDefaults(106);
            //aiType = 106;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = -1;
            drawOriginOffsetY = 4;
        }

        public override void AI()
        {
            /*Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 0, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.noLight = true;*/

            projectile.rotation += (float)projectile.direction * -0.6f;


            drawOffsetX = -1;
            drawOriginOffsetY = 4;
            projectile.width = 30;
            projectile.height = 30;
        }
        int reflect = 4;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.75f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.75f;
                }


            }

            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 3);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0);
                dust.noGravity = true;
            }

            Player player = Main.player[projectile.owner];

            projectile.damage = (projectile.damage * 9) / 10;


            player.AddBuff(mod.BuffType("TurtleBuff"), 90);
            
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 89);

                for (int i = 0; i < 25; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-20, -20), Main.rand.NextFloat(20, 20));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0);
                }

            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.oldRot[k], drawOrigin, projectile.scale * 0.9f, SpriteEffects.None, 0f);

            }
            return true;

        }

    }
    //________________________________________________________________________________________________________________

    public class TurtleYoyoProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Yoyo");
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;
        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 600;

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
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 0, 0f, 0f, 0, new Color(255, 255, 255), 1f);

            dust.noGravity = true;
            dust.noLight = true;
            shoottime++;
            if (shoottime >= 40)
            {


                for (int i = 0; i < 3; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 7);

                    Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(360));

                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("TurtleYoyoProj2"), (int)(projectile.damage * 1.25f), 0f, projectile.owner, 0f, 0f);
                    shoottime = 0;
                }
            }
            
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            Player player = Main.player[projectile.owner];
            
                player.AddBuff(mod.BuffType("TurtleBuff"), 90);
            
        }

    }
    //________________________________________________________________________________________________________________

    public class TurtleYoyoProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turtle Yoyo");

        }
        public override void SetDefaults()
        {

            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.timeLeft = 40;

            projectile.scale = 1f;
            projectile.aiStyle = -1;

            // drawOffsetX = -3;
            // drawOriginOffsetY = 1;
        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 0, 0f, 0f, 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.noLight = true;

            projectile.rotation += 2f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {


                for (int i = 0; i < 7; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 0);

                    dust.noGravity = true;

                }

            }
        }



    }
}