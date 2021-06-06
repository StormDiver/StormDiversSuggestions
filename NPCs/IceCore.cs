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
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.NPCs

{
    public class IceCore : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigid Snowflake");
            Main.npcFrameCount[npc.type] = 9;


        }
        public override void SetDefaults()
        {
            
            npc.width = 54;
            npc.height = 54;

            //npc.aiStyle = 22;

            //aiType = NPCID.Wraith;
            //animationType = NPCID.FlyingSnake;
            
            npc.damage = 50;
            npc.lavaImmune = true;
            npc.defense = 10;
            npc.lifeMax = 1250;
            npc.noGravity = true;
            npc.noTileCollide = false;


            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath7;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 1, 0, 0);

           banner = npc.type;
           bannerItem = mod.ItemType("IceCoreBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (!NPC.AnyNPCs(mod.NPCType("IceCore")) && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
            {
                {
                    return SpawnCondition.Cavern.Chance * 0.04f;
                }
            }
            
            else
            {
                return SpawnCondition.Cavern.Chance * 0f;
            }
        }
        int shoottime = 0;
        int phasetime = 0;
        bool phase1 = true;
        bool phase2;
        float ypos = -150;
        float movespeed = 3f; //Speed of the npc

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.6f * Main.essScale);

            npc.spriteDirection = npc.direction;



            Player player = Main.player[npc.target];
            npc.TargetClosest();
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center + new Vector2(0, ypos);
            float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);

            if (magnitude > movespeed)
            {
                move *= movespeed / magnitude;
            }
            npc.velocity = move;

            npc.spriteDirection = npc.direction;
            npc.velocity.Y *= 0.96f;
            


            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            if (!Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                movespeed = 1.5f;
                ypos = 0;
                npc.noTileCollide = true;
            }
            else
            {
                movespeed = 3;
                ypos = -150;
                npc.noTileCollide = false;

            }
            if (player.dead)
            {
                npc.velocity.Y = -0.5f;
            }
            if (phase1)
            {
                npc.rotation = npc.velocity.X / 50;

                if (distance <= 500f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                {
                    shoottime++;
                    phasetime++;


                    if (shoottime >= 12 && (npc.position.Y < player.position.Y - 100))//fires the projectiles
                    {

                        //xpostion = Main.rand.NextFloat(200f, -200f);
                        //ypostion = Main.rand.NextFloat(-100f, -250f);

                        //int type = mod.ProjectileType("GolemMinionProj");

                        //Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 33);

                        /*Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                        new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;*/



                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {


                            Vector2 perturbedSpeed = new Vector2(0, 10).RotatedByRandom(MathHelper.ToRadians(12));
                            float scale = 1f - (Main.rand.NextFloat() * .2f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X + Main.rand.NextFloat(-30f, 30f), npc.Center.Y + Main.rand.NextFloat(-30f, 30f), perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("IceCoreProj"), 15, 3);

                        }


                        shoottime = 0;

                    }
                }
                else
                {
                    shoottime = 0;
                   
                }

                if (phasetime >= 360) //Phase 1 to 2
                {
                    shoottime = 0;

                    phase2 = true;
                    phase1 = false;
                    phasetime = 0;
                }
            }
            if (phase2)
            {
                npc.rotation += (float)npc.direction * -0.5f;
                npc.velocity.X *= 0.5f;
                npc.velocity.Y *= 0.5f;
                phasetime++;
                if (distance <= 500f)
                {
                    shoottime++;
                    if (shoottime >= 80 && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                    {
                        float numberProjectiles = 10 + Main.rand.Next(4);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < numberProjectiles; i++)
                            {


                                float speedX = 0f;
                                float speedY = -8f;
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(150));
                                float scale = 1f - (Main.rand.NextFloat() * .5f);
                                perturbedSpeed = perturbedSpeed * scale;
                                //Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostAccessProj"), 50, 3f, player.whoAmI);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("IceCoreProj"), 20, 3f);


                            }
                            for (int i = 0; i < 30; i++)
                            {

                                Dust dust;
                                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                                Vector2 position = npc.position;
                                dust = Main.dust[Terraria.Dust.NewDust(position, npc.width, npc.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                                dust.noGravity = true;
                            }
                        }
                        shoottime = 0;
                    }
                }
                    
                if (phasetime >= 250) //Phase 2 to 1
                {
                    

                    shoottime = 0;

                    phase2 = false;
                    phase1 = true;
                    phasetime = 0;
                }
            }

            if (Main.rand.Next(4) == 0) //Dust effects
            {
                var dust3 = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Bottom.Y - 10), 10, 20, 187, 0, 10);
                dust3.noGravity = true;
            }
            /*if (npc.collideX)
            {
                npc.velocity.X = npc.velocity.X * -1;
            }
            if (npc.collideY)
            {
                npc.velocity.Y = npc.velocity.Y * -1;
            }*/
        }
        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
           
            if (phase1)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 6) //Cycles through frames 0-6 when  in phase 1
                {
                    npcframe = 0;
                }
            }
            if (phase2)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe < 7 || npcframe >= 9) //Cycles through frames 7-8 when in phase 2
                {
                    npcframe = 7;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Chilled, 600);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (phase1)
            {
                shoottime = -10;
            }
            if (phase2)
            {
                shoottime = 50;
            }
      
            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 187);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) they will spawn this
            {
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore1"), 1f);   
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore2"), 1f);    
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/IceCoreGore4"), 1f);

                for (int i = 0; i < 40; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 187);
                    dust.scale = 2;
                    dust.velocity *= 3;
                    dust.noGravity = true;
                }
                

            }
        }
        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceOre"), Main.rand.Next(5, 8));
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostCore);
                }
            }
          
            else
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceOre"), Main.rand.Next(4, 7));
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrostCore);
                }
            }
            if (!StormWorld.SpawnIceOre)
            {
                StormWorld.SpawnIceOre = true;
            }
        }
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/GolemMinion_Glow");
            Vector2 drawPos = new Vector2(0, 0) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }*/
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}