using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Projectiles
{
   
    public class QuackProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Duck");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.magic = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            
        }
    
        int speedup = 0;
        public override void AI()
        {
            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }

            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;



            speedup++;
            if (speedup <= 50)
            {
                projectile.velocity.X *= 1.04f;
                projectile.velocity.Y *= 1.04f;
                
               
            }

          
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }


        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Duck, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 142);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }

        }
       

    }
    //_____________________________________________________________________________________________
    //_____________________________________________________________________________________________
    public class QuackSolarProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Solar Duck");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 0;
            projectile.light = 0.3f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

        }

        int speedup = 0;
        public override void AI()
        {
            speedup++;
            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 174);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust2].velocity *= -0.3f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;


            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.velocity.X = 0f;
                projectile.velocity.Y = 0f;
                projectile.tileCollide = false;
                // Set to transparent. This projectile technically lives as  transparent for about 3 frames
                projectile.alpha = 255;
                // change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
                projectile.position = projectile.Center;

                projectile.width = 160;
                projectile.height = 160;
                projectile.Center = projectile.position;


                projectile.knockBack = 6f;

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

            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 74);

            for (int i = 0; i < 35; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, 0, 0, 174);
                dust.noGravity = true;
                dust.scale = 2f;
                dust.velocity *= 3.5f;
                dust.fadeIn = 1f;

            }
            for (int i = 0; i < 50; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 174, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;


            }
            for (int i = 0; i < 80; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 2f;

            }

        }

        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //_____________________________________________________________________________________________
    public class QuackVortexProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Vortex Duck");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.magic = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.light = 0.3f;

            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

        }

        int speedup = 0;
        public override void AI()
        {
            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 229);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 110, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust2].velocity *= -0.3f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;



            speedup++;
            if (speedup <= 40)
            {
                projectile.velocity.X *= 1.03f;
                projectile.velocity.Y *= 1.03f;


            }


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 229, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }
        int reflect = 2;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            
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
            return false;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Duck, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 229);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //_____________________________________________________________________________________________
    public class QuackNebulaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Nebula Duck");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.magic = true;
            projectile.timeLeft = 300;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.light = 0.3f;

            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

        }

        int speedup = 0;
        public override void AI()
        {
            speedup++;

            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 130);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 130, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust2].velocity *= -0.3f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;



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
                projectile.velocity = (10 * projectile.velocity + move) / 9.1f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 11f)
            {
                vector *= 10f / magnitude;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 130, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }


        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Duck, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 130);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }

        }

        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //_____________________________________________________________________________________________
    public class QuackStardustProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Stardust Duck");
            
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.magic = true;
            projectile.timeLeft = 60;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.light = 0.3f;

            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

        }

        int speedup = 0;
        public override void AI()
        {
            speedup++;

            if (speedup < 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }
            }
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust2].velocity *= -0.3f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;

            if (speedup == 30)
            {
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                    dust.noGravity = true;
                    dust.scale = 0.6f;
                }


                float numberProjectiles = 3;
                float rotation = MathHelper.ToRadians(5);
                //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    float speedX = projectile.velocity.X * 1.2f;
                    float speedY = projectile.velocity.Y * 1.2f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("QuackStardustMiniProj"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                }
                projectile.Kill();
            }


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 9) / 10;
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Duck, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
            return true;
        }

        public override void Kill(int timeLeft)
        {

            

        }

        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //_____________________________________________________________________________________________
    public class QuackStardustMiniProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Mini Stardust Duck");

        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.magic = true;
            projectile.timeLeft = 180;
            //aiType = ProjectileID.Bullet;
            projectile.aiStyle = 0;
            projectile.light = 0.3f;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;

        }

        public override void AI()
        {
            
            if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
            {


                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 111, projectile.velocity.X, projectile.velocity.Y, 130, default, 0.5f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust].velocity *= -0.3f;
                int dust2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust2].noGravity = true; //this make so the dust has no gravity
                Main.dust[dust2].velocity *= -0.3f;

            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.spriteDirection = projectile.direction;



        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage = (projectile.damage * 8) / 10;
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }
        }


        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Duck, (int)projectile.position.X, (int)projectile.position.Y, 0, 0.3f, -0.6f);

            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 135);
                dust.noGravity = true;
                dust.scale = 0.6f;

            }

        }

        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}
