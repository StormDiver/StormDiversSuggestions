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
    public class GolemMinion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temple Guardian");
            Main.npcFrameCount[npc.type] = 6;


        }
        public override void SetDefaults()
        {
            
            npc.width = 34;
            npc.height = 50;

            //npc.aiStyle = 22;

            //aiType = NPCID.Wraith;
            //animationType = NPCID.FlyingSnake;
            
            npc.damage = 60;
            npc.lavaImmune = true;
            npc.defense = 32;
            npc.lifeMax = 2000;
            npc.noGravity = true;
            npc.rarity = 3;


            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 2, 0, 0);

           banner = npc.type;
           bannerItem = mod.ItemType("GolemMinionBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (!NPC.downedPlantBoss)
            {
                //Summoning done in StormPlayer.cs
                return SpawnCondition.JungleTemple.Chance * 0f;
            }
            else if (NPC.downedPlantBoss && !NPC.AnyNPCs(mod.NPCType("GolemMinion")))
            {
                return SpawnCondition.JungleTemple.Chance * 0.08f;
            }
            else
            {
                return SpawnCondition.JungleTemple.Chance * 0f;
            }
        }
        int shoottime = 0;

        bool shooting;
        float xpostion = 0f; // The picked x postion
        float ypostion = -150;

        public override void AI()
        {
            npc.noTileCollide = true;
            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.6f * Main.essScale);

            npc.spriteDirection = npc.direction;


            Player player = Main.player[npc.target];
            npc.TargetClosest();
            if (player.ZoneJungle && player.ZoneRockLayerHeight)
            {
                Vector2 moveTo = player.Center;
                Vector2 move = moveTo - npc.Center + new Vector2(xpostion, ypostion);
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                float movespeed = 5f; //Speed of the npc

                if (magnitude > movespeed)
                {
                    move *= movespeed / magnitude;
                }
                npc.velocity = move;
            }
            npc.rotation = npc.velocity.X / 25;
            npc.spriteDirection = npc.direction;
            npc.velocity.Y *= 0.96f;



            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            if (player.dead || (!player.ZoneJungle || !player.ZoneRockLayerHeight)) //Now flees if the player leaves the Underground Jungle
            {
                npc.velocity.Y = 8;
            }

            if (distance <= 700f)
            {
                shoottime++;

                if (shoottime >= 60)//starts the shooting animation
                {
                    //npc.velocity.X = 0;
                    npc.velocity.Y *= 0.98f;
                    npc.velocity.X *= 0.98f;


                    var dust2 = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Top.Y + 10), 10, 8, 6, 0, 0);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;
                    shooting = true;

                }
                else
                {
                    shooting = false;
                }
                if (shoottime >= 80)//fires the projectiles
                {

                    xpostion = Main.rand.NextFloat(150f, -150f);
                    ypostion = Main.rand.NextFloat(-50f, -200f);


                    float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 35; // The damage your projectile deals. normal x2, expert x4
                    float knockBack = 3;
                    int type = mod.ProjectileType("GolemMinionProj");
                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 33);

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {

                           
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(12));
                            float scale = 1f - (Main.rand.NextFloat() * .2f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                           
                        }
                    

                    shoottime = 0;
                    shooting = false;

                }
            }
            else
            {
                shoottime = 30;
                shooting = false;
                xpostion = 0f;
                ypostion = -200f;
            }
            if (Main.rand.Next(4) == 0)
            {
                var dust3 = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Bottom.Y - 10), 10, 20, 6, 0, 10);
                dust3.noGravity = true;
            }
        }
        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
            if (shooting)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 4)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe < 4 || npcframe >= 6) //Cycles through frames 4-5 when about to fire
                {
                    npcframe = 4;
                }
            }
            else
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 6)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 4) //Cycles through frames 0-3 when not casting
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
            
      
            for (int i = 0; i < 2; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(10, 10));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 25);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) they will spawn this
            {
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore1"), 1f);   
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore2"), 1f);    
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemMinionGore4"), 1f);
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }
                for (int i = 0; i < 30; i++)
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
            if (NPC.downedPlantBoss)
            {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarTabletFragment, Main.rand.Next(3, 5));
        
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell);
            }

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/GolemMinion_Glow");
            Vector2 drawPos = new Vector2(0, 0) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }

    }
}