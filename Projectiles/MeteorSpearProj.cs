using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{

   
    public class MeteorSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Spear");

        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }


        public float MovementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        int shoottime = 0;
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
                    MovementFactor = 1.6f; // Make sure the spear moves forward when initially thrown out
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

            if (Main.rand.NextBool(3))
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 6, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 1, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }
            shoottime++;
            Player player = Main.player[projectile.owner];
            bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, player.position, player.width, player.height);
            /*if (shoottime == 15 && lineOfSight)
            {


                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 45, 0.5f, 0.5f);


                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * 3f, projectile.velocity.Y * 3f, mod.ProjectileType("MeteorSpearProj2"), (int)(projectile.damage * 1f), 5, projectile.owner, 0f, 0f);


            }*/
        }
        bool meteorrain;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!meteorrain)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 45, 0.5f, 0.5f);

                Projectile.NewProjectile(target.Center.X - 200, target.Center.Y - 650, 3.5f, 10, mod.ProjectileType("MeteorSpearProj2"), projectile.damage, 0, projectile.owner); //Summoned to the left and moves left
                Projectile.NewProjectile(target.Center.X + 200, target.Center.Y - 650, -3.5f, 10, mod.ProjectileType("MeteorSpearProj2"), projectile.damage, 0, projectile.owner); //Summoned to the right and moves right

                meteorrain = true;
            }
        }

    }
    //
    //_____________________________________________________________________________________________________
    public class MeteorSpearProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 180;
            projectile.light = 0.4f;
            projectile.scale = 1;
            projectile.melee = true;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }
        int rotate;
        public override void AI()
        {
            var player = Main.player[projectile.owner];

            if (projectile.position.Y > (player.position.Y - 200))
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;

            }

            rotate += 2;
            projectile.rotation = rotate * 0.1f;
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }
            if (projectile.ai[0] > 0f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {

                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= -0.3f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust2].velocity *= -0.3f;

                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 80;
                projectile.height = 80;
                projectile.Center = projectile.position;


                projectile.knockBack = 6;
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (projectile.timeLeft > 3)
            {
                projectile.timeLeft = 3;
            }


        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);

            for (int i = 0; i < 30; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 30; i++)
            {

                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
            for (int i = 0; i < 40; i++)
            {

                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);

                dust2.scale = 1f;
                dust2.velocity *= 2;
            }

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            //return Color.White;
            return null;
        }

    }

}