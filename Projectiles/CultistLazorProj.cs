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
    public class CultistLazorProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cultist Laser");
          
        }



        // The maximum charge value
        private const float MAX_CHARGE = 60f;
        //The distance charge particle from the player center
        private const float MOVE_DISTANCE = 30f;

        // The actual distance is stored in the ai0 field
        // By making a property to handle this it makes our life easier, and the accessibility more readable
        public float Distance
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }

        // The actual charge value is stored in the localAI0 field
        public float Charge
        {
            get => projectile.localAI[0];
            set => projectile.localAI[0] = value;
        }

        // Are we at max charge? With c#6 you can simply use => which indicates this is a get only property
        public bool IsAtMaxCharge => Charge == MAX_CHARGE;

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.hide = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            // We start drawing the laser if we have charged up
            if (IsAtMaxCharge)
            {
                DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center,
                    projectile.velocity, 10, projectile.damage, -1.57f, 1f, 1000f, Color.White, (int)MOVE_DISTANCE);
            
            }
            return false;
        }
    
        // The core function of drawing a laser
        public void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default, int transDist = 50)
        {
            float r = unit.ToRotation() + rotation;

            // Draws the laser 'body'
            for (float i = transDist; i <= Distance; i += step)
            {
                Color c = Color.White;
                var origin = start + i * unit;
                spriteBatch.Draw(texture, origin - Main.screenPosition,
                    new Rectangle(0, 26, 26, 12), i < transDist ? Color.Transparent : c, r,
                    new Vector2(26 * .5f, 12 * .5f), scale, 0, 0);
            }
        
            // Draws the laser 'tail'
            spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
                new Rectangle(0, 0, 26, 26), Color.White, r, new Vector2(26 * .5f, 26 * .5f), scale, 0, 0);

            // Draws the laser 'head'
            spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
                new Rectangle(0, 52, 26, 26), Color.White, r, new Vector2(26 * .5f, 26 * .5f), scale, 0, 0);
        }

        // Change the way of collision check of the projectile
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // We can only collide if we are at max charge, which is when the laser is actually fired
            if (!IsAtMaxCharge) return false;

            Player player = Main.player[projectile.owner];
            Vector2 unit = projectile.velocity;
            float point = 0f;
            // Run an AABB versus Line check to look for collisions, look up AABB collision first to see how it works
            // It will look for collisions on the given line using AABB
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center,
                player.Center + unit * Distance, 22, ref point);
        }

        // Set custom immunity time on hitting an NPC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 5;
            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(target.position, target.width, target.height, 111, projectile.velocity.X * 5, projectile.velocity.Y * 5, 50, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 3f;
            }
        }



        // The AI of the projectile
        bool firesound = false;
        float manachance;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.position = player.Center + projectile.velocity * MOVE_DISTANCE;
            projectile.timeLeft = 2;

            // By separating large AI into methods it becomes very easy to see the flow of the AI in a broader sense
            // First we update player variables that are needed to channel the laser
            // Then we run our charging laser logic
            // If we are fully charged, we proceed to update the laser's position
            // Finally we spawn some effects like dusts and light

            UpdatePlayer(player);
            ChargeLaser(player);

            // If laser is not charged yet, stop the AI here.
            if (Charge < MAX_CHARGE) return;

            SetLaserPosition(player);
            SpawnDusts(player);
            CastLights();


            Vector2 offset = projectile.velocity;
            offset *= MOVE_DISTANCE - 20;
            Vector2 pos = player.Center + offset - new Vector2(5, 5);

            if (IsAtMaxCharge && firesound == false)
            {
                //Only plays once, when the laser begins to fire
               Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 125, 1.5f, -0.3f);
                for (int i = 0; i < 100; i++) 
                {
                    int dust = Dust.NewDust(pos, 0, 0, 135, projectile.velocity.X * 2, projectile.velocity.Y * 2, 50, default, 3f);   
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 3f;
                }
                firesound = true;
            }
            projectile.soundDelay--;
            manachance = player.manaCost *= 100;
            if (IsAtMaxCharge)
            {
                
                if (projectile.soundDelay <= 0)
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 13, 1.5f, -0.2f);
                    projectile.soundDelay = 30;
                }
                if (player.statMana >= 0)
                {


                    if (Main.rand.Next(100) <= manachance)
                    {
                        player.statMana -= 1;
                    }

                }
                if (player.statMana <= 0) //If the player runs out of mana kill the projectile
                {
                    projectile.Kill();
                }
                
            }
                    
        }

        private void SpawnDusts(Player player)
        {
            Vector2 unit = projectile.velocity * -1;
            Vector2 dustPos = player.position + projectile.velocity * Distance - new Vector2(-5, -17); 
            //Dust for the end of the projectile
            for (int i = 0; i < 10; ++i)
            {
                
                Dust dust = Main.dust[Dust.NewDust(dustPos, 0, 0, 111, 0, 0)];
                dust.noGravity = true;
                dust.scale = 1.5f;
                
                dust.fadeIn = 1f;
                dust.noGravity = true;
               
                //dust.color = Color.Cyan;
            }

          
        }

        /*
		 * Sets the end of the laser position based on where it collides with something
		 */
        private void SetLaserPosition(Player player)
        {
            for (Distance = MOVE_DISTANCE; Distance <= 650f; Distance += 5f)
            {
                var start = player.Center + projectile.velocity * Distance;
                if (!Collision.CanHitLine(player.Center, 1, 1, start, 1, 1))
                {
                    Distance -= 5f;
                    break;
                }
            }
        }

        private void ChargeLaser(Player player)
        {
            // Kill the projectile if the player stops channeling
            if (!player.channel)
            {
                projectile.Kill();

            }
            else
            {
                if (Main.time % 10 < 1 && !player.CheckMana(player.inventory[player.selectedItem].mana, true))
                {
                    projectile.Kill();
                }
                if (!IsAtMaxCharge)
                {
                    if (projectile.soundDelay <= 0)
                    {
                        Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 15, 2, -0.5f);
                        projectile.soundDelay = 15;
                    }
                }
                //This is for the projectiles at the held weapon
                Vector2 offset = projectile.velocity * 1.8f;
                offset *= MOVE_DISTANCE - 20;
                Vector2 pos = player.Center + offset - new Vector2(5, 5);
                if (Charge < MAX_CHARGE)
                {
                    Charge++;
                }
                int chargeFact = (int)(Charge / 20f);
                Vector2 dustVelocity = Vector2.UnitX * 18f;
                dustVelocity = dustVelocity.RotatedBy(projectile.rotation - 1.57f);
                Vector2 spawnPos = projectile.Center;
                for (int k = 0; k < chargeFact + 1; k++)
                {
                    Vector2 spawn = spawnPos + ((float)Main.rand.NextDouble() * 6.28f).ToRotationVector2() * (12f - chargeFact * 2);
                    Dust dust = Main.dust[Dust.NewDust(pos, 0, 0, 111, projectile.velocity.X, projectile.velocity.Y)];
                    dust.velocity = Vector2.Normalize(spawnPos - spawn) * 1.5f * (10f - chargeFact * 2f) / 10f;
                    dust.noGravity = true;
                    if (IsAtMaxCharge)
                    {
                        dust.scale = 1.8f;
                    }
                    else
                    {
                        dust.scale = 1f;
                    }
                }
            }
        }

        private void UpdatePlayer(Player player)
        {
            // Multiplayer support here, only run this code if the client running it is the owner of the projectile
            if (projectile.owner == Main.myPlayer)
            {
                Vector2 diff = Main.MouseWorld - player.Center;
                diff.Normalize();
                projectile.velocity = diff;
                projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
                projectile.netUpdate = true;
            }
            int dir = projectile.direction;
            player.ChangeDir(dir); // Set player direction to where we are shooting
            player.heldProj = projectile.whoAmI; // Update player's held projectile
            player.itemTime = 2; // Set item time to 2 frames while we are used
            player.itemAnimation = 2; // Set item animation time to 2 frames while we are used
            player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * dir, projectile.velocity.X * dir); // Set the item rotation to where we are shooting
        }

        private void CastLights()
        {
            // Cast a light along the line of the laser
            DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (Distance - MOVE_DISTANCE), 26, DelegateMethods.CastLight);
        }

        public override bool ShouldUpdatePosition() => false;

        /*
		 * Update CutTiles so the laser will cut tiles (like grass)
		 */
        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 unit = projectile.velocity;
            Utils.PlotTileLine(projectile.Center, projectile.Center + unit * Distance, (projectile.width + 16) * projectile.scale, DelegateMethods.CutTiles);
        }
    }




}

