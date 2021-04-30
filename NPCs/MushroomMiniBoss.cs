using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCs

{
    public class MushroomMiniBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angry Mushroom"); // Automatic from .lang files
                                                      // make sure to set this for your modnpcs.
            Main.npcFrameCount[npc.type] = 5;

        }
        public override void SetDefaults()
        {
            
            npc.width = 34;
            npc.height = 34;

            npc.aiStyle = 1; 
            aiType = NPCID.CorruptSlime;
            //animationType = NPCID.BlueSlime;
            
            npc.damage = 30;
            
            npc.defense = 5;
            npc.lifeMax = 200;
            
            npc.rarity = 2;
            

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.9f;
            npc.value = Item.buyPrice(0, 0, 50, 0);

           banner = npc.type;
           bannerItem = mod.ItemType("MushroomMiniBossBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (!NPC.AnyNPCs(mod.NPCType("MushroomMiniBoss")) && NPC.downedBoss1 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneGlowshroom)
            {
                return SpawnCondition.Cavern.Chance * 0.1f;
            }
            else
            {
                return SpawnCondition.Cavern.Chance * 0f;
            }

        }
        int shoottime = 0;

        bool summoning;
        bool jumping;
        public override void AI()
        {
            npc.spriteDirection = npc.direction;

            if (npc.velocity.Y == 0)
            {
                shoottime++;
            }

            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.3f * Main.essScale);


            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance  <= 600f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 100)
                {
                    if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
                    {
                        

                            var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Top.Y), npc.width, 3, 113);

                            dust.noGravity = true;
                        

                    }
                    npc.velocity.X = 0;
                    npc.velocity.Y = 0;
                    summoning = true;
                }
                if (shoottime >= 120)
                {
                    float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 15; // The damage your projectile deals. normal x2, expert x4
                    float knockBack = 1;
                    int type = mod.ProjectileType("MushroomMiniBossProj");

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);


                    for (int i = 0; i < 1; i++)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(0)); 
                                                                                                                                  
                            Projectile.NewProjectile(npc.Center.X, npc.TopLeft.Y, - 3, -6, type, damage, knockBack, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center.X, npc.TopRight.Y, + 3, -6, type, damage, knockBack, Main.myPlayer);

                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {

                        var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 113);
                        dust.noGravity = true;
                        dust.velocity *= 3;

                    }

                    shoottime = 0;
                    summoning = false;
                }
            }
            else
            {
                shoottime = 70;
                summoning = false;

            }
            if (npc.velocity.Y != 0)
            {
                jumping = true;
            }
            else
            {
                jumping = false;
            }


            if (Main.rand.Next(10) == 0)
            {
                
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 113, npc.velocity.X, npc.velocity.Y, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                
            }
        }

        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
            if (jumping)
            {
                npc.frame.Y = 2 * frameHeight; //Picks frame 2 when in the air
            }
            if (summoning)
            {
                //npc.frame.Y = 3 * frameHeight; //Cycles bewteen frame 3 and 4 when summoning msuhroom
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 2)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 5 || npcframe <= 2) //Cycles through frames 2-3 when not summoning
                {
                    npcframe = 3;
                }
            }
            if (!jumping && !summoning)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 10)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 2) //Cycles through frames 0-1 when not casting
                {
                    npcframe = 0;
                }
            }

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
              
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 70;
            summoning = false;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 31);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MushroomMiniBossGore1"), 1f);   
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MushroomMiniBossGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MushroomMiniBossGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MushroomMiniBossGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 113);
                }
              

            }
        }
        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                if (Main.rand.Next(100) < 33)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SuperMushroom"));
                }
            }
            else
            {
                if (Main.rand.Next(100) < 25)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SuperMushroom"));
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/MushroomMiniBoss_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

        }

    }
}