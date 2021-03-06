using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
   
    public class StoneSolar : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Stone Boulder");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.8f;
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 60;
            projectile.aiStyle = 14;
            projectile.scale = 0.75f;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
         
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;

        }
       
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 174, 0f, 0f, 0, new Color(255, 255, 255), 1.2f);
            dust.noGravity = true;
            dust.fadeIn = 1;

            projectile.rotation += (float)projectile.direction * -0.2f;
            projectile.width = 28;
            projectile.height = 28;

        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 1000);
           
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
            }
        }

     

       
            int reflect = 2;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 1f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 1f;
                }
            }
            if (reflect >= 1)
            {

                int numberProjectiles = 20 + Main.rand.Next(5); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {

                    float speedX =  Main.rand.NextFloat(-12f, 12f);
                    float speedY =  Main.rand.NextFloat(-12f, 12f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneSolarFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
                }
            }
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
             
                return false;
            
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
                }

            }

          int numberProjectiles = 20 + Main.rand.Next(5); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX =  Main.rand.NextFloat(-13f, 13f);
                float speedY =  Main.rand.NextFloat(-13f, 13f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneSolarFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
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
    }
    //______________________________________________________________________________________
    
    public class StoneSolarFrag : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.2f;
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        
            drawOffsetX = -2;
            drawOriginOffsetY = -2;
        }
        
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 244, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
            }
            projectile.damage = (projectile.damage * 9) / 10;

        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 240);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
            }
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
                Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 3; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 244);
                }

            }
        }
       
    }
    //______________________________________________________________________________________
    //______________________________________________________________________________________
    public class StoneVortex : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Stone Boulder");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.8f;
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 0;
            projectile.scale = 0.75f;
            aiType = ProjectileID.Bullet;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;

        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 110, 0f, 0f, 0, new Color(255, 255, 255), 1.2f);
            dust.noGravity = true;
            dust.fadeIn = 1;
            projectile.rotation += (float)projectile.direction * -0.2f;
            projectile.width = 26;
            projectile.height = 26;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 1000);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
            }
            int numberProjectiles = 5 + Main.rand.Next(3); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-6f, 6f);
                float speedY = Main.rand.NextFloat(-6f, 6f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneVortexFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
            }
        }

         int reflect = 5;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            reflect--;
             if (reflect <= 0)
             {
                 projectile.Kill();

             }
            
            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 1f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 1f;
                }
            }
            if (reflect >= 1)
            {
            int numberProjectiles = 7 + Main.rand.Next(3); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                    float speedX = Main.rand.NextFloat(-8f, 8f);
                    float speedY = Main.rand.NextFloat(-8f, 8f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneVortexFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
            }
            }
            Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
            
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
                }

            }

             int numberProjectiles = 10 + Main.rand.Next(3); //This defines how many projectiles to shot.
             for (int i = 0; i < numberProjectiles; i++)
             {

                float speedX = Main.rand.NextFloat(-10f, 10f);
                float speedY = Main.rand.NextFloat(-10f, 10f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneVortexFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
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
    }
    //______________________________________________________________________________________

    public class StoneVortexFrag : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.2f;
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
         
            drawOffsetX = -3;
            drawOriginOffsetY = -3;
        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 110, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
            }
            projectile.damage = (projectile.damage * 9) / 10;

        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 240);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
            }
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
                Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 3; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 110);
                }

            }
        }
        
    }
    //_________________________________________________________________
    //_____________________________________________________________________
    public class StoneNebula : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Stone Boulder");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.8f;
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            projectile.scale = 0.75f;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;

        }
       
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 112, 0f, 0f, 0, new Color(255, 255, 255), 1.2f);
            dust.noGravity = true;
            dust.fadeIn = 1;
            projectile.rotation += (float)projectile.direction * -0.2f;

            projectile.width = 26;
            projectile.height = 26;


        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 1000);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
            }
        }

        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }
            }
            if (reflect >= 1)
            {
                int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {

                    float speedX = Main.rand.NextFloat(-7f, 7f);
                    float speedY = Main.rand.NextFloat(-7f, 7f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneNebulaFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
                }
            }

            Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);

            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
                }

            }

            int numberProjectiles = 5 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-9f, 9f);
                float speedY = Main.rand.NextFloat(-9f, 9f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneNebulaFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
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
    }
    //______________________________________________________________________________________

    public class StoneNebulaFrag : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.2f;
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
            drawOffsetX = -3;
            drawOriginOffsetY = -3;
        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 112, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
            }
            projectile.damage = (projectile.damage * 9) / 10;

        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 240);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
            }
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
                Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 3; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 112);
                }

            }
        }
        
    }
    //________________________________________
    
    //__________________________________________________________________________________________________
    //__________________________________________________________________________________________________
    public class StoneStardust : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Stone Boulder");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.8f;
            projectile.width = 28;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            projectile.scale = 0.75f;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
            //drawOffsetX = -5;
            //drawOriginOffsetY = -5;

        }
       
        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 111, 0f, 0f, 0, new Color(255, 255, 255), 1.2f);
            dust.noGravity = true;
            dust.fadeIn = 1;
            projectile.rotation += (float)projectile.direction * -0.2f;

            if (Main.rand.Next(12) == 0)
            {
                int numberProjectiles = 1 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int j = 0; j < numberProjectiles; j++)
                {

                    float speedX = Main.rand.NextFloat(-3f, 3f);
                    float speedY = Main.rand.NextFloat(-3f, 3f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneStardustFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);


                }
            }

            projectile.width = 28;
            projectile.height = 28;

        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 1000);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
            }
        }

        int reflect = 3;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            reflect--;
            if (reflect <= 0)
            {
                projectile.Kill();

            }

            {
                Collision.HitTiles(projectile.Center + projectile.velocity, projectile.velocity, projectile.width, projectile.height);

                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X * 0.8f;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y * 0.8f;
                }
            }
            if (reflect >= 1)
            {
                int numberProjectiles = 3 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {

                    float speedX = Main.rand.NextFloat(-7f, 7f);
                    float speedY = Main.rand.NextFloat(-7f, 7f);

                    Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneStardustFrag"), (int)(projectile.damage * 0.33), 0f, projectile.owner, 0f, 0f);
                }
            }

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
            
            return false;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 62);
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
                }

            }

            int numberProjectiles = 4 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                float speedX = Main.rand.NextFloat(-9f, 9f);
                float speedY = Main.rand.NextFloat(-9f, 9f);

                Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, mod.ProjectileType("StoneStardustFrag"), (int)(projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
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
    }
    //______________________________________________________________________________________

    public class StoneStardustFrag : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.light = 0.2f;
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.ranged = true;
            projectile.timeLeft = 180;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
           
            drawOffsetX = -3;
            drawOriginOffsetY = -3;
        }

        public override void AI()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 111, new Vector2(0f, 0f), 0, new Color(255, 100, 0), 1f);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 500);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
            }
        }
        public override void OnHitPvp(Player target, int damage, bool crit)

        {
            target.AddBuff(mod.BuffType("LunarBoulderDebuff"), 240);
            for (int i = 0; i < 3; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
            }
            projectile.damage = (projectile.damage * 9) / 10;

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
                Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

                for (int i = 0; i < 3; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 111);
                }

            }
        }
       
    }

}
