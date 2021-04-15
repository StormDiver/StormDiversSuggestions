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
            Main.npcFrameCount[npc.type] = 4;

            npc.width = 60;
            npc.height = 42;

            npc.aiStyle = 86; 
            
            animationType = NPCID.Harpy;

            npc.damage = 125;

            npc.defense = 60;
            npc.lifeMax = 12000;
            npc.alpha = 3;


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
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType("MoonDerp")))
            {
                return SpawnCondition.Sky.Chance * 0.1f;
            }
            return SpawnCondition.Sky.Chance * 0f;
        }
        int shoottime = 0;
        int shootspeed = 0;
        int dusttime = 0;
        int eyetime = 0;
        bool halflife3 = false;
        public override void AI()
        {
            dusttime++;
            
            
            npc.noTileCollide = true;

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance <= 1000f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                shoottime++;
                eyetime++;
                if (shoottime >= 160)
                {
                    float projectileSpeed = 12f; // The speed of your projectile (in pixels per second).
                    int damage = 40; // The damage your projectile deals.
                    float knockBack = 2;
                    int type = mod.ProjectileType("MoonDerpBoltProj");
                    //int type = ProjectileID.PhantasmalBolt;
                    shootspeed++;
                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) - new Vector2(npc.Center.X, npc.Top.Y)) * projectileSpeed;


                   
                    if (shootspeed == 10)
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
                    if (shoottime >= 180)
                    {
                        shoottime = 0;
                        shootspeed = 0;
                    }
                    if (halflife3 && eyetime > 240 && Main.expertMode)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Top.Y, 0, -4, mod.ProjectileType("MoonDerpEyeProj"), 35, 6f);
                            
                        }
                        Main.PlaySound(SoundID.Zombie, (int)npc.position.X, (int)npc.position.Y, 103);
                        eyetime = 0;
                    }
                }
               if (npc.life < npc.lifeMax * 0.4f && halflife3 == false && Main.expertMode)
                {
                    Main.PlaySound(SoundID.Zombie, (int)npc.position.X, (int)npc.position.Y, 101);
                    halflife3 = true;
                }
            }
            else
            {
                shoottime = 0;
                shootspeed = 0;
                eyetime = 0;
            }
        }


       
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 10), 20, 20, 265);
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
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
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

            
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.LunarOre, Main.rand.Next(5, 7));
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart, Main.rand.Next(3, 5));
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
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, fragdrop, Main.rand.Next(2, 4));

            }

        }
    }
}