using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    
    public class HellSoulBowProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Arrow");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;
            
            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;
           
        }
       
       
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            AnimateProjectile();
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 0.8f;

            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 300f;
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
                projectile.velocity = (15 * projectile.velocity + move) / 15f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 13f)
            {
                vector *= 13f / magnitude;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);


            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);

                    dust.scale = 2;
                    dust.velocity *= 2;

                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    //__________________________________________________________________________________________________________

    public class HellSoulRifleProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Bullet");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;


        }
        int dusttime;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            AnimateProjectile();

            dusttime++;
            if (dusttime >= 5)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                dust.scale = 2;


            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);
            projectile.damage= projectile.damage / 10 *  8;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }
            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    //__________________________________________________________________________________________________________

    public class HellSoulSwordProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Blade");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;


        }
        int dusttime;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            AnimateProjectile();

            dusttime++;
            if (dusttime >= 5)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                dust.scale = 2;


            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);
            projectile.damage = projectile.damage / 10 * 8;
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }
            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    //__________________________________________________________________________________________________________

    public class HellSoulArmourProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Soul");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;

        }
        int damagetime = 0;
        public override bool CanDamage()
        {
            if (damagetime <=20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void AI()
        {
            damagetime++;
            projectile.rotation = projectile.velocity.X / 20;

            AnimateProjectile();
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 0.8f;
            if (damagetime > 20)
            {
                if (projectile.localAI[0] == 0f)
                {
                    AdjustMagnitude(ref projectile.velocity);
                    projectile.localAI[0] = 1f;
                }
                Vector2 move = Vector2.Zero;
                float distance = 250f;
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
                    projectile.velocity = (15 * projectile.velocity + move) / 15f;
                    AdjustMagnitude(ref projectile.velocity);
                }
            }
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            if (damagetime > 20)
            {
                float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
                if (magnitude > 12f)
                {
                    vector *= 12f / magnitude;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);


            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    //__________________________________________________________________________________________________________

    public class HellSoulMagicProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Flare");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.ranged = true;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;

        }

        int charge;
        public override void AI()
        {
            projectile.velocity.X *= 0.9f;
            projectile.velocity.Y *= 0.9f;
            charge++;

            AnimateProjectile();
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.position;
            dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.scale = 0.8f;
            projectile.rotation = projectile.velocity.X / 20;

            if (charge == 50)
            {


                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 20, 0.5f);
               
                //for (int i = 0; i < 10; i++)
                if (projectile.owner == Main.myPlayer)
                {
                    //target = Main.MouseWorld;
                    //target.TargetClosest(true);
                    float shootToX = Main.MouseWorld.X - projectile.Center.X;
                    float shootToY = Main.MouseWorld.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                    bool lineOfSight = Collision.CanHitLine(Main.MouseWorld, 0, 0, projectile.position, projectile.width, projectile.height);


                    distance = 3f / distance;
                    shootToX *= distance * 7;
                    shootToY *= distance * 7;
                    int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("HellSoulMagicProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);

                    projectile.Kill();

                }


            }

        }
       
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);


            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {


                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);

                    dust.velocity *= 2;

                }

            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }

    }
    public class HellSoulMagicProj2 : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Fire Flare");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.melee = true;
            projectile.timeLeft = 300;
            projectile.light = 0.4f;
            projectile.scale = 1f;

            projectile.aiStyle = 0;
            //drawOffsetX = -9;
            //drawOriginOffsetY = -9;
            


        }
        int dusttime;

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            AnimateProjectile();

            dusttime++;
            if (dusttime >= 5)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                dust.scale = 2;


            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);
           
        }

        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }
            }
        }

        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
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