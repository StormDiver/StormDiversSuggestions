using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Buffs;

namespace StormDiversSuggestions.NPCs

{
    public class HellMiniBossMinion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Cauldron Servant"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
            
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 3;
            
            npc.width = 30;
            npc.height = 30;

            npc.aiStyle = 14; 
            aiType = NPCID.IlluminantBat;
            //animationType = NPCID.CaveBat;

            npc.damage = 40;
           
            npc.defense = 10;
            npc.lifeMax = 200;


            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0.9f;
            npc.value = Item.buyPrice(0, 0, 0, 0);

            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[(BuffType<SuperBurnDebuff>())] = true;
            npc.buffImmune[(BuffType<HellSoulFireDebuff>())] = true;
            
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        
        int shoottime = 0;
        //private float rotation;
        //private float scale;
        bool shooting;
        public override void AI()
        {
            shoottime++;
            npc.rotation = npc.velocity.X / 15;


            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance  <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >=  120)
                {

                   
                    shooting = true;
                    if (Main.rand.Next(5) == 0)
                    {
                        var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Center.Y - 6), npc.width, 4, 173, 0, -5);
                        dust2.noGravity = true;
                        dust2.scale = 1.5f;
                    }
                }
                if (shoottime >= 140)
                {
                    npc.velocity *= 0f;
              
                    float projectileSpeed = 3.5f; // The speed of your projectile (in pixels per second).
                    int damage = 25; // The damage your projectile deals.
                    float knockBack = 3;
                    int type = mod.ProjectileType("HellMiniBossProj1");
                    //int type = ProjectileID.PinkLaser;

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    // Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);


                    //int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots

                    for (int i = 0; i < 1; i++)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                            float scale = 1f - (Main.rand.NextFloat() * .3f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X + 10 * npc.direction, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                        }
                    }
                                      
                    shoottime = 0;
                    shooting = false;
                }
            }
            else
            {
                shoottime = 70;
                shooting = false;

            }
            if (Main.rand.Next(5) == 0)
            {

                var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Top.Y), npc.width, npc.height / 2, 135, 0, -2);
                dust2.scale = 1f;
                dust2.noGravity = true;

            }
            if (Main.rand.Next(4) == 0)
            {

                var dust3 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Bottom.Y - 4), npc.width, 6, 173, 0, 5);
                dust3.noGravity = true;

            }
        }

        int npcframe = 0;
        int frametime;
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
      
            if (shooting)
            {
                frametime = 3;
            }
            else
            {
                frametime = 6;
            }

                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > frametime)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 3) //Cycles through frames 0-2
                {
                    npcframe = 0;
                }
            

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
                target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 180);
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 70;
            shooting = false;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 173);
                dust.scale = 0.5f;

            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossMinionGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossMinionGore2"), 1f);     // 1f is the gore sprite size, you can change it but i suggest to keep it to 1f
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossMinionGore3"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 173);

                    dust.noGravity = true;
                    dust.velocity *= 5;
                    dust.scale = 2f;
                }
                for (int i = 0; i < 10; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 31, 0f, 0f, 0, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }


            }
        }
         public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
         {
             Texture2D texture = mod.GetTexture("NPCs/HellMiniBossMinion_Glow");
             Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

             spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


         }
         
        
    }
}