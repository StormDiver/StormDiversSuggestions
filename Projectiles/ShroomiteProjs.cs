using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Dusts;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class ShroomBulletProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Bullet");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 1;
            projectile.light = 0.1f;
            
            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = 3;
            
            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

        }
        int reflect = 3;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
       // int dusttime = 10;
        public override void AI()
        {
           
           // dusttime--;
           /* if (Main.rand.Next(10) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("ShroomDust"));
                
            }*/
            Dust dust;
           
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 187, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

            /*
                if (Main.rand.Next(75) == 0)
                {

                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 1.25), 0f, projectile.owner, 0f, 0f);
                }
            */
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomBulletProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }

    }
    //______________________________________________________________________________________
    public class ShroomArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 2;
            projectile.arrow = true;
            projectile.tileCollide = true;

            projectile.ranged = true;

            projectile.arrow = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            //Creates no immunity frames
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;

            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }
        int spwmushroom = 8;
        public override void AI()
        {

            spwmushroom--;
            if (Main.rand.Next(20) == 0)
            {
                
                
                int speedX = 0;
                int speedY = 0;

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 1.25), 0f, projectile.owner, 0f, 0f);
                spwmushroom = 8;
            }
            Dust dust;

            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 187, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 206);
            }
        }
        public override void Kill(int timeLeft)
        {

            int item = Main.rand.NextBool(5) ? Item.NewItem(projectile.getRect(), mod.ItemType("ShroomArrow")) : 0;
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomArrowProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //______________________________________________________________________________________________
    public class ShroomGrenProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Grenade");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;


            projectile.light = 2f;
            projectile.friendly = true;

            projectile.CloneDefaults(133);
            aiType = 133;

            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;

            projectile.timeLeft = 300;

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //projectile.Kill();

            return false;
        }
        int timeleft = 240;
        public override void AI()
        {
            timeleft--;
            if (timeleft <= 0)
            {
                projectile.Kill();
            }


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 62);



            for (int i = 0; i < 20; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                int dust2 = Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, 172, 0f, 0f, 200, default, 0.8f);
                Main.dust[dust2].velocity *= -5f;
                Main.dust[dust2].noGravity = true;

            }
            if (projectile.owner == Main.myPlayer)
            {
                int numberProjectiles = 8 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 0.9f), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomGrenProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //______________________________________________________________________________________________
    public class ShroomRocketProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Rocket");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;


            projectile.light = 2f;
            projectile.friendly = true;

            // projectile.CloneDefaults(134);
            // aiType = 134;
            projectile.aiStyle = 0;
            projectile.extraUpdates = 1;
            //aiType = ProjectileID.Bullet;
            projectile.penetrate = 1;
            projectile.tileCollide = true;
            projectile.ranged = true;
            
            projectile.timeLeft = 300;
            drawOffsetX = -3;
            drawOriginOffsetY = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();

            return false;
        }
        int timeleft = 240;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            timeleft--;
            if (timeleft <= 0)
            {
                projectile.Kill();
            }
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 45);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0.1f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 1f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item14, projectile.position);



            for (int i = 0; i < 20; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                int dust2 = Dust.NewDust(projectile.position - projectile.velocity, projectile.width, projectile.height, 172, 0f, 0f, 200, default, 0.8f);
                Main.dust[dust2].velocity *= -5f;
                Main.dust[dust2].noGravity = true;

            }
            if (projectile.owner == Main.myPlayer)
            {
                int numberProjectiles = 8 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    // Calculate new speeds for other projectiles.
                    // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                    float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                    float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);

                    Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/ShroomRocketProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    //______________________________________________________________________________________________
    public class Rangedmushroom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spinning Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.CloneDefaults(131);
            aiType = 131;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.melee = false;
            projectile.timeLeft = 50;
            projectile.tileCollide = false;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }
        }

    }
    //____________________________________________________________________________________________________________________________________________
    public class ShroomSetRocketProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Set Rocket");

        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;

            projectile.aiStyle = 0;
            projectile.light = 0.1f;

            projectile.friendly = true;
            projectile.timeLeft = 400;
            projectile.penetrate = -1;


            projectile.tileCollide = true;


            projectile.ranged = true;
            projectile.extraUpdates = 1;
            //aiType = ProjectileID.Bullet;


        }


        // int dusttime = 10;
        public override void AI()
        {


            /*  Dust dust;

              Vector2 position = projectile.Center;
              dust = Terraria.Dust.NewDustPerfect(position, 187, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
              dust.noGravity = true;*/

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int i = 0; i < 10; i++)
            {
                float x2 = projectile.Center.X - projectile.velocity.X / 20f * (float)i;
                float y2 = projectile.Center.Y - projectile.velocity.Y / 20f * (float)i;
                int j = Dust.NewDust(new Vector2(x2, y2), 1, 1, 45);
                //Main.dust[num165].alpha = alpha;
                Main.dust[j].position.X = x2;
                Main.dust[j].position.Y = y2;
                Main.dust[j].velocity *= 0.1f;
                Main.dust[j].noGravity = true;
                Main.dust[j].scale = 1f;
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


                projectile.knockBack = 3f;

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

            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74);

            projectile.alpha = 255;

            for (int i = 0; i < 50; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 80; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 45, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;
            }

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 16;
            projectile.height = 16;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

        }



    }
    //____________________________________________________________________________________________________________________________________________
    public class MushroomArrowProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 7;
            projectile.height = 7;


            //projectile.light = 1f;
            projectile.friendly = true;

             //projectile.CloneDefaults(225);
            //aiType = 225;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.aiStyle = 1;
            projectile.penetrate = 5;
            projectile.tileCollide = true;
            projectile.ranged = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.timeLeft = 300;
            drawOffsetX = -4;
            drawOriginOffsetY = 0;
        }
        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();
            }
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 1.6f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 1.6f;
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 56);
            return false;
        }


        public override void AI()
        {
            /*for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile

                //Get the shoot trajectory from the projectile and target
                float shootToX = target.Center.X - projectile.Center.X;
                float shootToY = target.Center.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the live targeted npc and the projectile is less than 480 pixels
                if (distance < 300f && target.active)
                {

                    distance = 0.5f / distance;

                    //Multiply the distance by a multiplier proj faster
                    shootToX *= distance * 12;
                    shootToY *= distance * 12;

                    //Set the velocities to the shoot values
                    projectile.velocity.X = shootToX;
                    projectile.velocity.Y = shootToY;
                }

            }*/
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


        }

        public override void Kill(int timeLeft)
        {

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
            }

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/MushroomArrowProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }

    }

}
