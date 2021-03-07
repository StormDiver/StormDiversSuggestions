using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Projectiles
{

    public class PrimeAccessProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skull Spinner");
        }

        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;

            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.knockBack = 0;
            projectile.ignoreWater = true;
            projectile.timeLeft = 72;
            projectile.tileCollide = false;
            projectile.MaxUpdates = 1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
        }

        bool lineOfSight;
        public override void AI()
        {
            var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 6);
            dust.noGravity = true;
            projectile.rotation += (float)projectile.direction * -0.2f;
            //Making player variable "p" set as the projectile's owner
            Player p = Main.player[projectile.owner];

            //Factors for calculations
            double deg = (double)projectile.ai[1] * 5; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 150; //Distance away from the player

            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */

            projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
            projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
            var player = Main.player[projectile.owner];


            if (player.GetModPlayer<StormPlayer>().primeSpin == false || player.dead)

            {
                for (int i = 0; i < 20; i++)
                {

                    var dust2 = Dust.NewDustDirect(projectile.Center, 0, 0, 6);
                    dust2.velocity *= 2;
                    dust2.scale = 1.5f;
                }
                projectile.Kill();
                return;
            }

            lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, player.position, player.width, player.height);

           /* if (!lineOfSight)
            {
                projectile.damage = 0;
            }
            if (lineOfSight)
            {
                projectile.damage = 65;
            }*/
        }
        public override bool CanDamage()
        {
            if (!lineOfSight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

          

        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.defense <= 1000)
            {
                damage = damage + (int)(target.defense * 0.5f);
            }
        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                //Main.PlaySound(SoundID.Item14, projectile.position);



            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Projectiles/PrimeAccessProj_Glow");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }
    }
    public class PrimeAccessAI : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        bool projCheck = false;


        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];


            if (player.GetModPlayer<StormPlayer>().primeSpin == true)

            {

                if (projectile.hostile)
                {
                    if (projectile.type != ProjectileID.PhantasmalDeathray &&
                        projectile.type != ProjectileID.SaucerDeathray &&
                        projectile.type != ProjectileID.CultistRitual &&
                        projectile.type != ProjectileID.CultistBossIceMist &&
                        projectile.type != ProjectileID.CultistBossLightningOrb &&
                        projectile.type != ProjectileID.VortexVortexPortal &&
                        projectile.type != ProjectileID.VortexVortexLightning &&
                        projectile.type != ProjectileID.Sharknado &&
                        projectile.type != ProjectileID.SharknadoBolt &&
                        projectile.type != ProjectileID.Cthulunado &&
                        projectile.aiStyle != 10 &&
                        projectile.aiStyle != 17 &&
                        projectile.aiStyle != -1
                        )
                    {
                        //Player player = Main.player[npc.target];

                        float distanceX = player.Center.X - projectile.Center.X;
                        float distanceY = player.Center.Y - projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

                        { }
                        if (distance >= 140 && distance <= 160 && !projCheck)
                        {
                            int choice = Main.rand.Next(7);
                            if (choice == 0)
                            {
                                projCheck = true;
                                Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 4);
                                projectile.Kill();

                            }
                            else  
                            {
                                projCheck = true;
                            }
                            
                        }
                    }
                }
                /*    Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = projectile.position;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 59, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;*/

            }

        }
    }
}
