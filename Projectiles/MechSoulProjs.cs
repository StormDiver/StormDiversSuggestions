﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Projectiles
{
    public class SeekerBoltProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seeker Bolt");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;

            
            projectile.light = 0.5f;
            projectile.friendly = true;

            // projectile.CloneDefaults(338);
            // aiType = 338;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 300;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            //drawOffsetX = -4;
            //drawOriginOffsetY = 0;

        }
        //int homed;
        int dusttime;
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            dusttime++;

            /* Dust dust;
             // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
             Vector2 position = projectile.Center;
             dust = Terraria.Dust.NewDustPerfect(position, 182, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
             dust.noGravity = true;
             dust.fadeIn = 1;*/
            if (dusttime > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 6, 0, 0, 100, default, 1f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                }
            }

            var player = Main.player[projectile.owner];

            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 750f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                //if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
                if (player.controlUseTile && player.HeldItem.type == mod.ItemType("TheSeeker") && !player.dead && projectile.timeLeft > 60 && projectile.owner == Main.myPlayer)
                {
                    if (Collision.CanHit(projectile.Center, 0, 0, Main.MouseWorld, 0, 0))
                    {


                        //projectile.timeLeft = 120;
                        Vector2 newMove = Main.MouseWorld - projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;
                        }
                    }

                }


            }
          
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (11 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
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

                projectile.width = 100;
                projectile.height = 100;
                projectile.Center = projectile.position;


                projectile.knockBack = 6;
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 15f)
            {
                vector *= 15f / magnitude;
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
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
                
                for (int i = 0; i < 50; i++)
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

                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;
                }



            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * 0.8f; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale * 0.9f, SpriteEffects.None, 0f);

            }
            return true;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
    //_______________________________________________________________________________________
    public class SawBladeChain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical ChainSaw");
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
            
            drawOffsetX = 5;
            drawOriginOffsetY = 0;

            
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default, 1.9f);
            Main.dust[dust].noGravity = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 8;
            Player player = Main.player[projectile.owner];
            if (Main.rand.Next(16) == 0)
            {
                
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedByRandom(MathHelper.ToRadians(25));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float) (perturbedSpeed.X * 0.22f), (float)(perturbedSpeed.Y * 0.22f), ProjectileID.MolotovFire, (int)(projectile.damage * 0.4f), 0, player.whoAmI); 
                
            }

           
            AnimateProjectile();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
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
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
    //_______________________________________________________________________________________
    public class SawBladeProj : ModProjectile //This is so old and unused that if you find this I'll add your name to something maybe
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SawbladeBoltProj");

        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
          
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.melee = true;
            projectile.aiStyle = 1;

            projectile.timeLeft = 90;
            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }

        public override void AI()
        {
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
            /* for (int i = 0; i < 100; i++) //The old code for the old unused projectile
            {
                NPC target = Main.npc[i];
                target.TargetClosest(true);
                float shootToX = target.Center.X - projectile.Center.X;
                float shootToY = target.Center.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                bool lineOfSight = Collision.CanHitLine(target.position, target.width, target.height, projectile.position, projectile.width, projectile.height);
                if (distance < 300f && !target.friendly && target.active && lineOfSight)
                {
                    if (projectile.ai[0] > 10f)
                    {
                        distance = 3f / distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("SawBladeProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[proj].timeLeft = 30;
                        Main.projectile[proj].netUpdate = true;
                        projectile.netUpdate = true;
                        Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 34);
                        projectile.ai[0] = -60f;
                    }
                }
            }
            projectile.ai[0] += 1f;*/
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 108);
            Main.NewText("Wait WHAT? This shouldn't be usable!!!!!", 255, 0, 0);

        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 90);
                }
            }
        }
    }
    
    //_______________________________________________________________________________________
    public class DestroyerFlailProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destroyer Flail");
        }
        public override void SetDefaults()
        {

            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = -1; 
            projectile.melee = true; 

            projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }
        int shoottime = 0;
        bool firedspike = false;

        public override void AI()
        {
          
            
            // Spawn some dust visuals
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 1.5f);
            dust.noGravity = true;
            dust.velocity /= 2f;

            var player = Main.player[projectile.owner];

            if (!player.controlUseItem)
            {
                firedspike = true;

            }
            shoottime++;
            if (shoottime == 14 && player.controlUseItem)
            {
                if (!firedspike)
                {
                    float numberProjectiles = 8;
                    float rotation = MathHelper.ToRadians(180);
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                    for (int j = 0; j < numberProjectiles; j++)
                    {
                        float speedX = 0f;
                        float speedY = 11f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, j / (numberProjectiles)));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DestroyerFlailProj3"), (int)(projectile.damage * 0.6f), projectile.knockBack, Main.myPlayer);
                    }
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 17, 1.5f);

                    firedspike = true;
                }

            }
            // If owner player dies, remove the flail.
            if (player.dead)
            {
                projectile.Kill();
                return;
            }

            // This prevents the item from being able to be used again prior to this projectile dying
            player.itemAnimation = 10;
            player.itemTime = 10;

            // Here we turn the player and projectile based on the relative positioning of the player and projectile.
            int newDirection = projectile.Center.X > player.Center.X ? 1 : -1;
            player.ChangeDir(newDirection);
            projectile.direction = newDirection;

            var vectorToPlayer = player.MountedCenter - projectile.Center;
            float currentChainLength = vectorToPlayer.Length();

            // Here is what various ai[] values mean in this AI code:
            // ai[0] == 0: Just spawned/being thrown out
            // ai[0] == 1: Flail has hit a tile or has reached maxChainLength, and is now in the swinging mode
            // ai[1] == 1 or !projectile.tileCollide: projectile is being forced to retract

            // ai[0] == 0 means the projectile has neither hit any tiles yet or reached maxChainLength
            if (projectile.ai[0] == 0f)
            {
                // This is how far the chain would go measured in pixels
                float maxChainLength = 1000f;
                projectile.tileCollide = true;
               
                if (currentChainLength > maxChainLength)
                {
                    // If we reach maxChainLength, we change behavior.
                    projectile.ai[0] = 1f;
                    projectile.netUpdate = true;

                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;



                }
                else if (!player.channel)
                {
                    // Once player lets go of the use button, let gravity take over and let air friction slow down the projectile
                    if (projectile.velocity.Y < 0f)
                        projectile.velocity.Y *= 0.9f;

                    projectile.velocity.Y += 1f;
                    projectile.velocity.X *= 0.9f;
                }
            }
            else if (projectile.ai[0] == 1f)
            {

               
                // When ai[0] == 1f, the projectile has either hit a tile or has reached maxChainLength, so now we retract the projectile
                float elasticFactorA = 14f / player.meleeSpeed;
                float elasticFactorB = 0.9f / player.meleeSpeed;
                float maxStretchLength = 1100f; // This is the furthest the flail can stretch before being forced to retract. Make sure that this is a bit more than maxChainLength so you don't accidentally reach maxStretchLength on the initial throw.

                if (projectile.ai[1] == 1f)
                    projectile.tileCollide = false;

                // If the user lets go of the use button, or if the projectile is stuck behind some tiles as the player moves away, the projectile goes into a mode where it is forced to retract and no longer collides with tiles.
                if (!player.channel || currentChainLength > maxStretchLength || !projectile.tileCollide)
                {
                    projectile.ai[1] = 1f;

                    if (projectile.tileCollide)
                        projectile.netUpdate = true;

                    projectile.tileCollide = false;

                    if (currentChainLength < 20f)
                        projectile.Kill();
                }

                if (!projectile.tileCollide)
                    elasticFactorB *= 2f;

                int restingChainLength = 60;

                // If there is tension in the chain, or if the projectile is being forced to retract, give the projectile some velocity towards the player
                if (currentChainLength > restingChainLength || !projectile.tileCollide)
                {
                    var elasticAcceleration = vectorToPlayer * elasticFactorA / currentChainLength - projectile.velocity;
                    elasticAcceleration *= elasticFactorB / elasticAcceleration.Length();
                    projectile.velocity *= 0.98f;
                    projectile.velocity += elasticAcceleration;
                }
                else
                {
                    // Otherwise, friction and gravity allow the projectile to rest.
                    if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
                    {
                        projectile.velocity.X *= 0.96f;
                        projectile.velocity.Y += 0.2f;
                    }
                    if (player.velocity.X == 0f)
                        projectile.velocity.X *= 0.96f;
                }
            }

            // Here we set the rotation based off of the direction to the player tweaked by the velocity, giving it a little spin as the flail turns around each swing 
            projectile.rotation = vectorToPlayer.ToRotation() - projectile.velocity.X * 0.1f;

            // Here is where a flail like Flower Pow could spawn additional projectiles or other custom behaviors
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            if (shoottime > 2)
            {
                firedspike = true;
            }
            // This custom OnTileCollide code makes the projectile bounce off tiles at 1/5th the original speed, and plays sound and spawns dust if the projectile was going fast enough.
            bool shouldMakeSound = false;

            if (oldVelocity.X != projectile.velocity.X)
            {
                if (Math.Abs(oldVelocity.X) > 4f)
                {
                    shouldMakeSound = true;
                }

                projectile.position.X += projectile.velocity.X;
                projectile.velocity.X = -oldVelocity.X * 0.2f;
            }

            if (oldVelocity.Y != projectile.velocity.Y)
            {
                if (Math.Abs(oldVelocity.Y) > 4f)
                {
                    shouldMakeSound = true;
                }

                projectile.position.Y += projectile.velocity.Y;
                projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }

            // ai[0] == 1 is used in AI to represent that the projectile has hit a tile since spawning
            projectile.ai[0] = 1f;

            if (shouldMakeSound)
            {
                // if we should play the sound..
                projectile.netUpdate = true;
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                // Play the sound
                Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            }

            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var player = Main.player[projectile.owner];

            Vector2 mountedCenter = player.MountedCenter;
            Texture2D chainTexture = ModContent.GetTexture("StormDiversSuggestions/Projectiles/DestroyerFlailChain");

            var drawPosition = projectile.Center;
            var remainingVectorToPlayer = mountedCenter - drawPosition;

            float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

            if (projectile.alpha == 0)
            {
                int direction = -1;

                if (projectile.Center.X < mountedCenter.X)
                    direction = 1;

                player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * direction, remainingVectorToPlayer.X * direction);
            }

            // This while loop draws the chain texture from the projectile to the player, looping to draw the chain texture along the path
            while (true)
            {
                float length = remainingVectorToPlayer.Length();

                // Once the remaining length is small enough, we terminate the loop
                if (length < 25f || float.IsNaN(length))
                    break;

                // drawPosition is advanced along the vector back to the player by 12 pixels
                // 12 comes from the height of ExampleFlailProjectileChain.png and the spacing that we desired between links
                drawPosition += remainingVectorToPlayer * 12 / length;
                remainingVectorToPlayer = mountedCenter - drawPosition;

                // Finally, we draw the texture at the coordinates using the lighting information of the tile coordinates of the chain section
                Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
                spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
            }

            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!firedspike)
            {

                float numberProjectiles = 8;
                float rotation = MathHelper.ToRadians(180);
                //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                for (int j = 0; j < numberProjectiles; j++)
                {
                    float speedX = 0f;
                    float speedY = 11f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, j / (numberProjectiles)));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DestroyerFlailProj3"), (int)(projectile.damage * 0.5f), projectile.knockBack, Main.myPlayer);
                }

                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 17, 1.5f);

                firedspike = true;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/DestroyerFlailProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //_______________________________________________________________________________________
    public class DestroyerFlailProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Destroyer Flail");
        }
        public override void SetDefaults()
        {

            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            //aiType = ProjectileID.Meteor1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        public override void AI()
        {
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
            dust.noGravity = true;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           

        }
        int bouncesound = 0;
        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            bouncesound++;
            if (projectile.velocity.X >= 0.3f || projectile.velocity.Y >= 0.3f)
            {
                if (bouncesound <= 5)
                {
                    Main.PlaySound(SoundID.Item10, projectile.position);
                }
            
            }
            return true;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.Item14, projectile.position);

                for (int i = 0; i < 20; i++)
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                    
                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;
                }
                for (int i = 0; i < 25; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }

            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/DestroyerFlailProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //_____________________________________________________________________________________________________________________________________________________
    public class DestroyerFlailProj3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vaporiser Spike");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;

            projectile.friendly = true;
            projectile.timeLeft = 30;
            projectile.penetrate = 3;

            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;


            projectile.melee = true;



        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);

            return true;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            projectile.alpha += 15;
            if (projectile.alpha > 250)
            {
                projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
        }

        public override void Kill(int timeLeft)
        {

            //Main.PlaySound(SoundID.Item10, projectile.position);
          

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

    }

    //_______________________________________________________________________________________
    public class SkullSeek : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Skull");
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            //projectile.aiStyle = 8;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.light = 0.5f;
        }
        bool reflect = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (!reflect) //Projectile will be destroyed if it hits a wall before an enemy, but once it hits an enemy it can bounce off walls
            {
                return true;
            }
            else
            {
                {
                    Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X * 1;
                    }
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y * 1f;
                    }

                }
                return false;
            }
        }
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.4f;

            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            projectile.spriteDirection = projectile.direction;

            if (reflect == true)
            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 400f;
                bool target = false;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
                    {
                        if (Collision.CanHit(projectile.Center, 0, 0, Main.npc[k].Center, 0, 0))
                        {
                            Vector2 newMove = Main.npc[k].Center - projectile.Center;
                            float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                            if (distanceTo < distance)
                            {
                                move = newMove;
                                distance = distanceTo;
                                target = true;
                            }
                        }
                    }
                }

                if (target)
                {
                    AdjustMagnitude(ref move);
                    projectile.velocity = (10 * projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref projectile.velocity);
                }
            }
        }
    
         private void AdjustMagnitude(ref Vector2 vector)
         {
            if (reflect == true)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
               if (magnitude > 10f)
                {
                   vector *= 10f / magnitude;
              }
            }
         }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            reflect = true; //Once this projectile has hit an enemy it will home in and bounce off walls
           
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 5);
            }
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item14, projectile.position);

                for (int i = 0; i < 15; i++)
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);

                    dust2.scale = 1.25f;
                    dust2.velocity *= 2;
                }
                for (int i = 0; i < 20; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (reflect)
            {
                Texture2D texture = mod.GetTexture("Projectiles/SkullSeek_Glow");

                spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, projectile.frame * (Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height)
, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
            }
            else return;

        }
    }
   
}
