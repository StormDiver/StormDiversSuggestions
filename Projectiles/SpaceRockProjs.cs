using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles       //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class SpaceGlobeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Boulder");
        }
        public override void SetDefaults()
        {

            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
            projectile.extraUpdates = 2;
            projectile.scale = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.4f;
        }
        public override bool CanDamage()
        {

            return false;
        }
        int rotate;
        int opacity = 255;
        public override void AI()
        {
            rotate += 1;
            projectile.rotation = rotate * 0.1f;
            opacity -= 10;
            projectile.alpha = opacity;


            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors

            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                    //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;

                }
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, 0, 10, 150, default, 0.5f);

                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    Main.dust[dust].velocity *= 0.5f;
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 0, default, 0.5f);
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
            return false;
        }

        public override void Kill(int timeLeft)
        {
            float numberProjectiles = 6 + Main.rand.Next(3);
            float rotation = MathHelper.ToRadians(180);
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                float speedX = 0f;
                float speedY = -8f;
                
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(180));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SpaceGlobeProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);
            for (int i = 0; i < 30; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 1f);
            }



        }
    }
    //__________________________________________________________________________________________________________________________________________________
    public class SpaceGlobeProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Boulder Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.aiStyle = 14;
            projectile.penetrate = 2;
            projectile.timeLeft = 200;
            projectile.light = 0.4f;
            projectile.scale = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -6;
        }
        int rotate;
        public override void AI()
        {
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
           
        }
       

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1f);
            }
            Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

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
    //______________________________________________
    public class SpaceArmourProj : ModProjectile
    { //For the armour set bonus
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Space Boulder");
        }
        public override void SetDefaults()
        {

            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 240;
            projectile.extraUpdates = 2;
            projectile.scale = 1f;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.light = 0.4f;
            projectile.aiStyle = 1;
        }
        
        int rotate;
        int opacity = 255;
        public override void AI()
        {
            rotate += 1;
            projectile.rotation = rotate * 0.1f;
            opacity -= 10;
            projectile.alpha = opacity;
            
            var player = Main.player[projectile.owner];

            if (projectile.position.Y > player.position.Y)
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;

            }

            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);   //this is the light colors
            
            if (projectile.ai[0] > 12f)  //this defines where the flames starts
            {
                if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
                {

                    var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
                    //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;

                }
                if (Main.rand.Next(2) == 0)
                {
                   
                    int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 0, projectile.velocity.X, projectile.velocity.Y, 0, default, 0.5f);
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 150;
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
                projectile.velocity = (10 * projectile.velocity + move) / 7f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 5f)
            {
                vector *= 5f / magnitude;
            }
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.defense <= 1000)
            {
                damage = damage + (int)(target.defense * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return true;
        }

        public override void Kill(int timeLeft)
        {
           
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62);
            for (int i = 0; i < 30; i++)
            {
                float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, speedX, speedY, 130, default, 1.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 1f);
            }

            float numberProjectiles = 2 + Main.rand.Next(2);
            float rotation = MathHelper.ToRadians(180);
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                float speedX = 0f;
                float speedY = -8f;

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(180));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SpaceArmourProj2"), (int)(projectile.damage * 0.5f), projectile.knockBack, Main.myPlayer, 0f, 0f);
            }

        }
    }
    //__________________________________________________________________________________________________________________________________________________
    public class SpaceArmourProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Boulder Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.aiStyle = 14;
            projectile.penetrate = 2;
            projectile.timeLeft = 180;
            projectile.light = 0.4f;
            projectile.scale = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -6;
        }
        int rotate;
        public override void AI()
        {
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

        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 8) / 10;

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 0.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, 0, 0, 130, default, 1f);
            }
            Main.PlaySound(SoundID.Tink, (int)projectile.Center.X, (int)projectile.Center.Y);

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
    //__________________________________________________________________________________________________________________________________________________
    public class SpaceSwordProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Sword Fragment");
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
        }
        public override void SetDefaults()
        {

            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.aiStyle = 14;
            projectile.penetrate = 1;
            projectile.timeLeft = 200;
            projectile.light = 0.4f;
            projectile.scale = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            drawOffsetX = 0;
            drawOriginOffsetY = -6;
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

        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-8f, 8f);
                float speedY = -projectile.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-8f, 8f);
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6, speedX, speedY, 130, default, 1.5f);
                var dust2 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 0, 0, 0, 130, default, 1f);
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 62, 0.5f, 0.2f);

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
}