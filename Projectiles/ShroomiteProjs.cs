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
            DisplayName.SetDefault("ShroomiteBullet");
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
            projectile.penetrate = 4;
            
            
            projectile.tileCollide = true;
            

            projectile.ranged = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;

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
            DisplayName.SetDefault("ShroomiteArrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;

            projectile.aiStyle = 1;
            projectile.light = 0.5f;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 3;
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
            DisplayName.SetDefault("ShroomiteGrenade");
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
            DisplayName.SetDefault("ShroomiteRocket");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 12;


            projectile.light = 2f;
            projectile.friendly = true;

            projectile.CloneDefaults(134);
            aiType = 134;

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
            DisplayName.SetDefault("Spinning Mushroom Ranged");
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
   
}
