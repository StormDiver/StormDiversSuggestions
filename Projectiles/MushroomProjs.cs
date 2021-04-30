using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Projectiles
{
   
    //_______________________________________________________________________________________
    public class MagicMushProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            //projectile.aiStyle = 8;
            projectile.friendly = true;
            projectile.penetrate = 4;
            projectile.magic = true;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.light = 0.5f;
        }
        int reflect = 4;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            reflect--;
       
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

                if (reflect == 0)
                {
                    projectile.Kill();
                }
                return false;
            }
        }
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.4f;

            if (Main.rand.Next(3) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 113, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
            projectile.spriteDirection = projectile.direction;

           
        }
    
        
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
          
            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, projectile.height, 113);
                dust.velocity *= 0.5f;

            }
            projectile.damage = (projectile.damage * 9) / 10;

        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

                for (int i = 0; i < 20; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 113);
                    dust.velocity *= 0.75f;
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 50;
            return color;

        }
    }
    //_______________________________________________________________________________________
    public class MagicMushArmourProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 20;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.light = 0.5f;
        }
        bool spawntime;
        public override void AI()
        {
            if (!spawntime)
            {
                for (int i = 0; i < 10; i++)
                {

                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 113);
                    dust.velocity *= 0.5f;

                }
                Main.PlaySound(SoundID.Item, projectile.position, 8);

                spawntime = true;

            }
            projectile.rotation += (float)projectile.direction * -0.4f;

            if (Main.rand.Next(3) == 0)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 113, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
            projectile.spriteDirection = projectile.direction;


        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 10; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                var dust = Dust.NewDustDirect(target.position, target.width, projectile.height, 113);
                dust.velocity *= 0.25f;

            }
            projectile.damage = (projectile.damage * 9) / 10;
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);
                


                for (int i = 0; i < 20; i++)
                {

                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 113);
                    dust.velocity *= 0.5f;
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 50;
            return color;

        }
    }
}
