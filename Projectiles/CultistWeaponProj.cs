using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Enums;
using StormDiversSuggestions.Buffs;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Projectiles
{
 
    public class CultistSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.25f;
            projectile.alpha = 0;

            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            
        }
        bool fireBall;

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
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 57, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 50, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

            shoottime++;
           

        }
        int firespeed = 10;
        int distance = 200;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!fireBall)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 45, 0.5f, 0.5f);

                Projectile.NewProjectile(target.Center.X - distance, target.Center.Y - distance, firespeed, firespeed, mod.ProjectileType("CultistSpearProj2"), (int)(projectile.damage * 0.66f), 0, projectile.owner); 
                Projectile.NewProjectile(target.Center.X + distance, target.Center.Y + distance, -firespeed, -firespeed, mod.ProjectileType("CultistSpearProj2"), (int)(projectile.damage * 0.66f), 0, projectile.owner); 
                Projectile.NewProjectile(target.Center.X + distance, target.Center.Y - distance, -firespeed, firespeed, mod.ProjectileType("CultistSpearProj2"), (int)(projectile.damage * 0.66f), 0, projectile.owner); 
                Projectile.NewProjectile(target.Center.X - distance, target.Center.Y + distance, firespeed, -firespeed, mod.ProjectileType("CultistSpearProj2"), (int)(projectile.damage * 0.66f), 0, projectile.owner); 

                fireBall = true;
            }
        }
      

    }
    //______________________________________________
    public class CultistSpearProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Blast");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
      
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.width = 24;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 40;
            projectile.aiStyle = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.5f;
            projectile.tileCollide = false;

        }
        int spawntime;
        int rotate;

        public override void AI()
        {

            rotate += 3;
            projectile.rotation = rotate * 0.1f;
            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0);
                dust.noGravity = true;
                dust.scale = 2f;
            }
            spawntime++;
            if (spawntime == 1)
            {

                for (int i = 0; i < 25; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X - projectile.width / 2, projectile.position.Y - projectile.height / 2), projectile.width * 2, projectile.height * 2, 6, 0f, 0f, 0, default, 2f);

                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].velocity *= 3f;

                }
            }


          
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            projectile.damage = (projectile.damage * 9) / 10;
            target.AddBuff(mod.BuffType("UltraBurnDebuff"), 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {

            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 74, 0.5f, 0.5f);


                for (int i = 0; i < 25; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(projectile.position.X - projectile.width / 2, projectile.position.Y - projectile.height / 2), projectile.width * 2, projectile.height * 2, 6, 0f, 0f, 0, default, 2f);

                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].velocity *= 3f;

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
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }

    //_______________________________________________________________________
    //____________________________________________________________________________________________________________________________________________
    public class CultistBowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice mist arrow");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;


            //projectile.light = 0.6f;
            projectile.friendly = true;

           
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.timeLeft = 300;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

           
            return true;
        }


        public override void AI()
        {
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
            dust.noGravity = true;
            dust.scale = 1.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("UltraFrostDebuff"), 300);
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 27);

            for (int i = 0; i < 20; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                dust.velocity *= 2;
                dust.scale = 1.5f;
                dust.noGravity = true;
            }
            for (int j = 0; j < 5; j++)
                {
                float xpos = (Main.rand.NextFloat(-200, 200));
                float ypos = (Main.rand.NextFloat(250, 350));

                int projID = Projectile.NewProjectile(projectile.Center.X - xpos, projectile.Center.Y - ypos, xpos * 0.02f, 5, ProjectileID.Blizzard, (int)(projectile.damage * 0.6f), 0, projectile.owner);
                Main.projectile[projID].ranged = true;
                Main.projectile[projID].magic = false;
                Main.projectile[projID].tileCollide = false;


            }

        }

        
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
    //___________________________________________
    //_______________________________________________________________________________________
    public class CultistTomeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Star");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;

            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
        }

        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.magic = true;
            projectile.timeLeft = 180;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.light = 0.5f;
        }

        int rotate;
        public override void AI()
        {
            rotate++;
            projectile.rotation = rotate * 0.1f;
            if (Main.rand.Next(3) == 0)     //this defines how many dust to spawn
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, 0, 0, 130, default, 1.5f);

                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= 0.5f;
            }


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

        private void AdjustMagnitude(ref Vector2 vector)
        {
            
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 12f)
                {
                    vector *= 12f / magnitude;
                }
            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
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


            return false;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0, 0, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, projectile.Center, 7);

                for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0, 0, 120, default, 1f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                }

            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++) //Distance between afterimages
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0, 0);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(mod.GetTexture("Projectiles/CultistTomeProj_Trail"), drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}

