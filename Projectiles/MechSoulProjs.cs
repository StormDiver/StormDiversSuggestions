using System;
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
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            
            projectile.light = 0.3f;
            projectile.friendly = true;

            projectile.CloneDefaults(338);
            aiType = 338;

            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 300;

            drawOffsetX = -4;
            drawOriginOffsetY = 0;

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return false;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(BuffID.OnFire, 500);
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 108);
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
                
                    for (int i = 0; i < 10; i++)
                    {
                        
                        Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                        var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 90);
                    }
                
                
            }
        }
    }
    //_______________________________________________________________________________________
    public class SawBladeChain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ChainSaw");
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
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (int) (perturbedSpeed.X * 0.22f), (int)(perturbedSpeed.Y * 0.22f), ProjectileID.MolotovFire, (int)(projectile.damage * 0.5f), 0, player.whoAmI);
                
            }

            /* for (int i = 0; i < 100; i++)
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
                         Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
                         projectile.ai[0] = -60f;
                     }
                 }
             }
             projectile.ai[0] += 1f;*/
            AnimateProjectile();
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            if (Main.rand.NextBool(10))
            {
                target.AddBuff(BuffID.OnFire, 180, false);
            }


        }



        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            if (Main.rand.NextBool(10))
            {
                target.AddBuff(BuffID.OnFire, 180, false);
            }
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


    }
    //_______________________________________________________________________________________
    public class SawBladeProj : ModProjectile
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

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(BuffID.OnFire, 500);
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 108);
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
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
        
        public override void AI()
        {
            // Spawn some dust visuals
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, default, 1.5f);
            dust.noGravity = true;
            dust.velocity /= 2f;

            var player = Main.player[projectile.owner];

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
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
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
            if (Main.rand.Next(3) == 0) // the chance
            {
                target.AddBuff(BuffID.OnFire, 240);

            }

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
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            aiType = ProjectileID.Meteor1;
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
            if (Main.rand.Next(5) == 0) // the chance
            {
                target.AddBuff(BuffID.OnFire, 240);
            }

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

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                    var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 55);
                }

            }
        }
    }
    //_________________________________________________________________________________________
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
            projectile.penetrate = 3;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.light = 0.1f;
        }
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.4f;

            //projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);
            projectile.spriteDirection = projectile.direction;
        }
        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }
            Main.PlaySound(3, (int)projectile.position.X, (int)projectile.position.Y, 3);


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
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 5);
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0) // the chance
            {
                target.AddBuff(BuffID.Confused, 240);

            }
            else
            {
                target.AddBuff(BuffID.OnFire, 240);
            }
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
                Main.PlaySound(SoundID.Item10, projectile.position);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 20);
                }
            }
        }

    }
   
}
