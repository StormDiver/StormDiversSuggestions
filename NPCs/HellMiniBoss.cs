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
    public class HellMiniBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Cauldron"); // Automatic from .lang files
                                                      // make sure to set this for your modnpcs.

        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 6;

            npc.width = 42;
            npc.height = 38;

            npc.aiStyle = 14; 
            aiType = NPCID.FlyingSnake;
            //animationType = NPCID.BlueSlime;
            
            npc.damage = 60;
            
            npc.defense = 15;
            npc.lifeMax = 1600;
            
            npc.rarity = 3;
            

            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 2, 0, 0);

            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[(BuffType<SuperBurnDebuff>())] = true;
            npc.buffImmune[(BuffType<HellSoulFireDebuff>())] = true;
            npc.lavaImmune = true;
            banner = npc.type;
            bannerItem = mod.ItemType("HellMiniBossBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (!NPC.AnyNPCs(mod.NPCType("HellMiniBoss")) && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                return SpawnCondition.Underworld.Chance * 0.07f;
            }
            else
            {
                return SpawnCondition.Underworld.Chance * 0f;
            }

        }
        int shoottime = 0;
        int phasetime; //How long to remain in a phase
        bool phase1 = true; //FIrts phase, shoots regular souls
        bool phase2; //Summons homing souls
        bool phase3; //Summons 2-3 minions


        public override void AI()
        {

            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X / 12;

            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.3f * Main.essScale);


            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            if (phase1) //phase1 _________________________________________________________________________________________________________________________
            {
                npc.defense = 15;

                if (distance <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                {
                    phasetime++;
                    shoottime++;

                    if (shoottime >= 120)
                    {
                        float projectileSpeed = 4.5f; // The speed of your projectile (in pixels per second).
                        int damage = 30; // The damage your projectile deals. normal x2, expert x4
                        float knockBack = 1;
                        int type = mod.ProjectileType("HellMiniBossProj1");

                        Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                        new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                        Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);


                        for (int i = 0; i < 3; i++)
                        {
                            float posX = npc.position.X + Main.rand.NextFloat(45f, -45f);
                            float posY = npc.position.Y + Main.rand.NextFloat(45f, -45f);
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {

                                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(0));

                                Projectile.NewProjectile(posX, posY, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, Main.myPlayer);
                            }
                        }
                        npc.velocity *= 0;
                        for (int i = 0; i < 20; i++)
                        {

                            var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 173);
                            dust.noGravity = true;
                            dust.velocity *= 3;
                            dust.scale = 2f;

                        }

                        shoottime = 0;
                    }
                }
                else
                {
                    shoottime = 70;

                }
                if (Main.rand.Next(5) == 0)
                {

                    var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Top.Y), npc.width, npc.height / 2, 135, 0, -2);
                    dust2.scale = 1.5f;
                    dust2.noGravity = true;

                }
                if (phasetime >= 400) //Phase 1 to 2
                {
                    shoottime = 0;

                    phase2 = true;
                    phase1 = false;
                    phasetime = 0;
                }
            }
            if (phase2) //Phase2_________________________________________________________________________________________________________________________
            {
                phasetime++;
                shoottime++;
                if (distance <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                {

                    if (shoottime >= 150)
                    {
                        float projectileSpeed = 5f; // The speed of your projectile (in pixels per second).
                        int damage = 20; // The damage your projectile deals. normal x2, expert x4
                        float knockBack = 1;
                        int type = mod.ProjectileType("HellMiniBossProj2");

                        Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                        new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                        Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);


                        for (int i = 0; i < 1; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {

                              
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, type, damage, knockBack);

                                npc.velocity *= 0.5f;

                            }
                        }
                        for (int i = 0; i < 20; i++)
                        {

                            var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 173);
                            dust.noGravity = true;
                            dust.velocity *= 3;
                            dust.scale = 1.5f;
                        }

                        shoottime = 0;
                    }
                }
                else
                {
                    shoottime = 70;

                }
                if (Main.rand.Next(3) == 0)
                {

                    var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Top.Y), npc.width, npc.height / 2, 135, 0, -4);
                    dust2.scale = 1.5f;
                    dust2.noGravity = true;

                }
                if (phasetime >= 500) //Phase 2 to 3
                {
                    shoottime = 0;

                    phase3 = true;
                    phase2 = false;
                    phasetime = 0;
                }
            }
            if (phase3) //summons minions _________________________________________________________________________________________________________________________
            {
                phasetime++;
                shoottime++;
                npc.defense = 100;
                npc.velocity *= 0f;
                if (distance <= 1200f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                {
                    if (shoottime >= 60)
                    {

                        int type = mod.NPCType("HellMiniBossMinion");


                        Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {

                            NPC.NewNPC((int)Math.Round(npc.Center.X), (int)Math.Round(npc.Center.Y), type);


                            for (int i = 0; i < 30; i++)
                            {
                                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 15, npc.Center.Y - 15), 30, 30, 173);
                                dust.noGravity = true;
                                dust.velocity *= 3;
                                dust.scale = 1.5f;
                            }
                        }

                        shoottime = 0;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Center.Y - 10), npc.width, 4, 173, 0, -5);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;
                }

                if (phasetime >= 150) //Phase 3 to 1
                {
                    shoottime = 0;

                    phase1 = true;
                    phase3 = false;
                    phasetime = 0;
                }
            }
            if (player.dead)
            {
                phase1 = true;
                phase2 = false;
                phase3 = false;
                shoottime = 0;
                phasetime = 0;
            }

            if (Main.rand.Next(2) == 0)
            {

                var dust3 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Bottom.Y - 6), npc.width, 6, 173, 0, 5);
                dust3.noGravity = true;

            }
        }

        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
            if (phase1 || phase2)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 6)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 3) //Cycles through frames 0-2 when in phase 1 or 2
                {
                    npcframe = 0;
                }
            }
           
            if (phase3)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 3)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe <= 2 || npcframe >= 6) //Cycles through frames 3-5 when in phase 3
                {
                    npcframe = 3;
                }
            }

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 300);

        }
        public override void HitEffect(int hitDirection, double damage)
        {

            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 173);
                dust.noGravity = true;
                dust.scale = 1.5f;
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) it will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossGore1"), 1f);   
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellMiniBossGore4"), 1f);
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 173);
                    
                    dust.noGravity = true;
                    dust.velocity *= 5;
                    dust.scale = 2f;
                }
                for (int i = 0; i < 20; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 31, 0f, 0f, 0, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }

            }
        }
        public override void NPCLoot()
        {
            
            if (Main.expertMode)
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SoulFire"), Main.rand.Next(10, 16));

            }
            else
            {
               
               Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SoulFire"), Main.rand.Next(8, 13));
                
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/HellMiniBoss_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

        }
        
    }
}