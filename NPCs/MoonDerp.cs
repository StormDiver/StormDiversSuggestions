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
    public class MoonDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling"); // Automatic from .lang files
                                                // make sure to set this for your modnpcs.

        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 8;

            npc.width = 60;
            npc.height = 42;
            
            npc.damage = 125;

            npc.defense = 60;
            npc.lifeMax = 30000;


            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit56;
            npc.DeathSound = SoundID.NPCDeath62;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 10, 0, 0);
            npc.rarity = 5;
            banner = npc.type;
            bannerItem = mod.ItemType("MoonDerpBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax / 3 * 2);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType("MoonDerp")))
            {
                return SpawnCondition.Sky.Chance * 0.09f;
            }
            return SpawnCondition.Sky.Chance * 0f;
        }

        int shoottime = 0; // Counts up to shoot the bolts
        int shootspeed = 0; // TIem between the 2 shots
        int eyetime = 0; // Counts up to fire the Eyes
        bool halflife3 = false; //When below half health enter second phase
        int timetoshoot = 120; //How often bolts will fire, gets faster in phase 2
        int timetoshootspeed = 10; //How rapid it fires
        float movespeed = 8f; //Speed of the npc

        float xpostion = 0; // The picked x postion
        float ypostion = -150f;
        int poschoice; 
        public override void AI()
        {
            npc.spriteDirection = npc.direction;

            Player player = Main.player[npc.target]; //Code to move towards player
            npc.TargetClosest();
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center + new Vector2(xpostion, ypostion); //Postion around player
            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (magnitude > movespeed)
            {
                move *= movespeed / magnitude;
            }
            npc.velocity = move;
            //The 5 positions it can be in after firing
            if (poschoice == 1) //Top 
            {
                xpostion = 0f;
                ypostion = -150f;
            }
            else if (poschoice == 2) // left
            {
                xpostion = -200f;
                ypostion = 0;
            }
            else if (poschoice == 3) //  right
            {
                xpostion = 200f;
                ypostion = 0f;
            }
            else if (poschoice == 4) //Bottom 
            {
                xpostion = 0f;
                ypostion = 150f;
            }
            else if (poschoice == 5) //On top of player
            {
                xpostion = 0f;
                ypostion = -20f;
            }


            npc.rotation = npc.velocity.X / 12 ;
            npc.velocity.Y *= 0.96f;

            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            if (player.dead)
            {
                npc.velocity.Y = -8;
            }
            if (distance <= 1000f) //&& Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height)
            {
                shoottime++;
               
                if (shoottime >= timetoshoot)
                {
                    float projectileSpeed = 13f; // The speed of your projectile (in pixels per second).
                    int damage = 40; // The damage your projectile deals. normal x2, expert x4
                    float knockBack = 2;
                    int type = mod.ProjectileType("MoonDerpBoltProj");
                    //int type = ProjectileID.PhantasmalBolt;
                    shootspeed++;
                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) - new Vector2(npc.Center.X, npc.Top.Y)) * projectileSpeed;

                    


                    if (shootspeed == timetoshootspeed)
                    {
                        
                        for (int i = 0; i < 1; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                                        // If you want to randomize the speed to stagger the projectiles
                                float scale = 1f - (Main.rand.NextFloat() * .3f);
                                perturbedSpeed = perturbedSpeed * scale;
                                Projectile.NewProjectile(npc.Center.X, npc.Top.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                                
                            }
                            Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 124);
                        }
                        shootspeed = 0;
                    }
                    if (shoottime >= (timetoshoot + 20))
                    {
                        poschoice = Main.rand.Next(1, 6); //Picks one of the 5 random postions after each shot

                        //xpostion *= -1f;
                        //ypostion *= -1f;
                        shoottime = 0;
                        shootspeed = 0;
                    }
                    
                }
                if (halflife3 && Main.expertMode)
                {
                    eyetime++;
                }
                if (eyetime >= 180)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Projectile.NewProjectile(npc.Center.X, npc.Top.Y, -3, -4, mod.ProjectileType("MoonDerpEyeProj"), 35, 6f);
                        Projectile.NewProjectile(npc.Center.X, npc.Top.Y, +3, -4, mod.ProjectileType("MoonDerpEyeProj"), 35, 6f);

                    }

                    Main.PlaySound(SoundID.Zombie, (int)npc.position.X, (int)npc.position.Y, 103);
                    eyetime = 0;
                }
                if (npc.life < npc.lifeMax * 0.5f && halflife3 == false) //Entering phase 2--------------------------------------------------------------------------------------
                {
                    Main.PlaySound(SoundID.Zombie, (int)npc.position.X, (int)npc.position.Y, 101);
                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore6"), 1f);
                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore6"), 1f);

                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore3"), 1f);
                    Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore4"), 1f);

                    for (int i = 0; i < 20; i++)
                    {
                        var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156);
                        
                    }
                    
                   //npc.damage = npc.damage / 10 * 14;  //Would be 40% extra damage but too OP
                   npc.defense = 50;
                   timetoshoot = 90;
                   timetoshootspeed = 6;
                    npc.velocity *= 0;
                    movespeed += 3;
                
                   halflife3 = true;
                }
            }
            else
            {
                shoottime = 40;
                shootspeed = 0;
                eyetime = 100;
            }
            if (halflife3)
            {
                if (Main.rand.Next(10) == 0)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156);
                }
            }
        }
        int npcframe = 0;

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;

            if (halflife3)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 8)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe <= 3 || npcframe >=8) //Cycles through frames 4-7 when below half health
                {
                    npcframe = 4;
                }
            }
            else
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 4) //Cycles through frames 0-3 when above half health
                {
                    npcframe = 0;
                }
            }

        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 10), 20, 20, 265);
                dust.scale = 0.75f;
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore2"), 1f);     // 1f is the gore sprite size, you can change it but i suggest to keep it to 1f
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MoonDerpGore5"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 265);
                }



            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/MoonDerp_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

    
        }

        public override void NPCLoot()
        {
            int heartdrop = 2 + Main.rand.Next(2);

            {
                if (Main.expertMode)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.LunarOre, Main.rand.Next(10, 14));
                }
                else
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.LunarOre, Main.rand.Next(8, 11));

                }
                for (int i = 0; i < heartdrop; i++)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart);
                }
            }

            int fragdrop;
            int choice = Main.rand.Next(4);
            {
                if (choice == 0)
                {
                    fragdrop = ItemID.FragmentVortex;
                }
                else if (choice == 1)
                {
                    fragdrop = ItemID.FragmentSolar;
                }
                else if (choice == 2)
                {
                    fragdrop = ItemID.FragmentStardust;
                }
                else 
                {
                    fragdrop = ItemID.FragmentNebula;
                }
                if (Main.expertMode)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, fragdrop, Main.rand.Next(4, 7));
                }
                else
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, fragdrop, Main.rand.Next(3, 6));

                }
            }

        }
    }
}