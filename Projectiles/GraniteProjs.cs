using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class GraniteBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Bullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = true;
            projectile.timeLeft = 180;
            projectile.penetrate = 2;
            
            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            
            aiType = ProjectileID.Bullet;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

        }
       
        
        int dusttime;
        public override void AI()
        {

             dusttime++;
           
            if (dusttime > 5)
            {
                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 5f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 5f * (float)i;
                 

                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 70, 0, 0, 100, default, 1f);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;

                }
            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 15; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 130, default, 1.2f);
                dust.noGravity = true;
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70);
                dust.noGravity = true;

            }

        }
    
        public override Color? GetAlpha(Color lightColor)
        {

            return Color.White;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length * 0.5f; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            }
            return true;

        }
    
    }
    //______________________________________________________________________________________________________________________
    public class GraniteSpearProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Spear");
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
                    MovementFactor = 1.2f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 2) // Somewhere along the item animation, make sure the spear moves back
                {
                    MovementFactor -= 1f;
                }
                else // Otherwise, increase the movement factor
                {
                    MovementFactor += 1.2f;
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
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 65, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 1, Scale: 1.2f);
                dust.noGravity = true;
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }

        }


    }

    //___________________________________
    public class GraniteSpearProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Spear Orb");


        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.melee = true;
            projectile.timeLeft = 25;
            projectile.aiStyle = 0;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        int dusttime;
        public override void AI()
        {

            dusttime++;

            if (dusttime > 10)
            {

                for (int i = 0; i < 10; i++)
                {
                    float X = projectile.Center.X - projectile.velocity.X / 5f * (float)i;
                    float Y = projectile.Center.Y - projectile.velocity.Y / 5f * (float)i;


                    int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 70, 0, 0, 100, default, 1);
                    Main.dust[dust].position.X = X;
                    Main.dust[dust].position.Y = Y;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;

                }
            }
            Dust dust2;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position2 = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position2, 65, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1.5f);
            dust2.noGravity = true;
            dust2.noLight = true;


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {

        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70);
                dust.noGravity = true;
            }
        }

    }
    //___________________________________
    public class GraniteStaffProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Energy Orb");
           

        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            
            
        }

        public override void AI()
        {
          

            for (int i = 0; i < 10; i++)
            {
                float X = projectile.Center.X - projectile.velocity.X / 5f * (float)i;
                float Y = projectile.Center.Y - projectile.velocity.Y / 5f * (float)i;


                int dust = Dust.NewDust(new Vector2(X, Y), 1, 1, 70, 0, 0, 100, default, 1f);
                Main.dust[dust].position.X = X;
                Main.dust[dust].position.Y = Y;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].scale *= 1f;
            }
            Dust dust2;
            Vector2 position2 = projectile.Center;
            dust2 = Terraria.Dust.NewDustPerfect(position2, 65, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1.5f);
            dust2.noGravity = true;
            dust2.noLight = true;


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)

        {
            projectile.Kill();
            return true;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 70);
                dust.noGravity = true;
            }
        }
        
    }

}
