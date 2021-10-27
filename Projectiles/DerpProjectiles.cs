using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Projectiles
{
    public class DerpMeleeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Shell Shard");
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
           
            projectile.friendly = true;
            
            projectile.tileCollide = true;
            projectile.melee = true;

           projectile.aiStyle = 14;
          
            projectile.timeLeft = 300;
            drawOffsetX = -3;
            drawOriginOffsetY = 0;
        }
        
        public override void AI()
        {

            /*
            int dust = Dust.NewDustPerfect(projectile.position - projectile.velocity, projectile.width, projectile.height, 48, 0f, 0f, 200, default, 1.5f);
                Main.dust[dust].velocity *= -1f;
                Main.dust[dust].noGravity = true;
               */

            projectile.rotation += (float)projectile.direction * -0.6f;

           
            projectile.melee = true;
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

            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 3);

            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            
           
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                //Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 22);
                for (int i = 0; i < 5; i++)
                {


                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {

            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.oldRot[k], drawOrigin, projectile.scale * 0.9f, SpriteEffects.None, 0f);

            }
            return true;

        }
    }
   
    //__________________________________________________________________________________________________________________
    public class DerpMagicProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Magic Shell");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
           
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.magic = true;

            projectile.aiStyle = 0;
            projectile.timeLeft = 60;
            projectile.scale = 0.7f;

        }

        


        public override void AI()
        {


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 68, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;

            projectile.rotation += (float)projectile.direction * -0.6f;



            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 150f;
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
                projectile.velocity = (10 * projectile.velocity + move) / 10f;
                AdjustMagnitude(ref projectile.velocity);
            }

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 10f)
            {
                vector *= 10f / magnitude;
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

            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 22);
            for (int i = 0; i < 5; i++)
            {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
            }
            int numberProjectiles = 3 + Main.rand.Next(3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                // Calculate new speeds for other projectiles.
                // Rebound at 40% to 70% speed, plus a random amount between -8 and 8
                float speedX = Main.rand.NextFloat(-7f, 7f);
                float speedY = Main.rand.NextFloat(-7f, 7f);

                Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, mod.ProjectileType("DerpMagicProj2"), (int)(projectile.damage * 0.75), 0f, projectile.owner, 0f, 0f);
            }
        }

    }
    //__________________________________________________________________________________________________________________
    public class DerpMagicProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Magic Shard");

        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
           
            projectile.friendly = true;

            projectile.tileCollide = true;
            projectile.magic = true;
            //projectile.extraUpdates = 1;
            //projectile.CloneDefaults(297);
            projectile.aiStyle = 2;
            //aiType = 297;
            //projectile.timeLeft = 240;
            projectile.timeLeft = 360;
        }
       
        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * -0.6f;


            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = projectile.Center;
            dust = Terraria.Dust.NewDustPerfect(position, 68, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 0.5f);
            dust.noGravity = true;



        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {


           
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }
        public override void Kill(int timeLeft)
        {


            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            //Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 22);
            for (int i = 0; i < 5; i++)
            {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
            }

        }
    }
}
