using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Projectiles
{
    public class LavaSpellProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Lava Orb");
            Main.projFrames[projectile.type] = 5;

        }
        public override void SetDefaults()
        {

            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.aiStyle = 14;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            AnimateProjectile();

            if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 259, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 0, new Color(255, 255, 255), .8f);
                dust.noGravity = true;
                /*Dust dust2;
                dust2 = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 127, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust2.noGravity = true;*/
               

            }
            Dust dust3;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position2 = projectile.Center;
            dust3 = Terraria.Dust.NewDustPerfect(position2, 127, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust3.noGravity = true;
            dust3.noLight = true;


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
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

                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 86, 1, -2);
                for (int i = 0; i < 10; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 259);
                }

            }
            {

                int numberProjectiles = 4 + Main.rand.Next(2); //This defines how many projectiles to shot.


                for (int i = 0; i < numberProjectiles; i++)
                {


                    float speedX = 0f;
                    float speedY = -7f;

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(170));
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("LavaSmallProj"), (int)(projectile.damage * 0.5f), 1f, projectile.owner, 0f, 0f);
                }
            }
        }
        public void AnimateProjectile() // Call this every frame, for example in the AI method.
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
            {
                projectile.frame++;
                projectile.frame %= 5; // Will reset to the first frame if you've gone through them all.
                projectile.frameCounter = 0;
            }
        }
    }
    //_____________________________________________________
    public class LavaSmallProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Lava Bolt");
        }
        public override void SetDefaults()
        {

            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.aiStyle = 14;
            projectile.magic = true;
            aiType = ProjectileID.WoodenArrowFriendly;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            //drawOffsetX = -2;
            //drawOriginOffsetY = -2;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 259, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 0, new Color(255, 255, 255), .8f);
                dust.noGravity = true;
                Dust dust2;
                dust2 = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 127, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust2.noGravity = true;


            }
            projectile.rotation += (float)projectile.direction * -0.2f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
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
                Main.PlaySound(SoundID.Item, (int)projectile.Center.X, (int)projectile.Center.Y, 85, 1, -2);

                for (int i = 0; i < 5; i++)
                {

                    
                    var dust = Dust.NewDustDirect(projectile.Center, projectile.width = 10, projectile.height = 10, 259);
                    dust.scale = 0.5f;

                }

            }
        }
    }
   
}
