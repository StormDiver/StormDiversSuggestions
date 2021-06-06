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
    public class SandCore : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Blaster");
            Main.npcFrameCount[npc.type] = 9;


        }
        public override void SetDefaults()
        {
            
            npc.width = 54;
            npc.height = 54;
            
            
            npc.damage = 40;
            npc.lavaImmune = true;
            npc.defense = 12;
            npc.lifeMax = 1000;
            npc.noGravity = true;
            npc.noTileCollide = false;


            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 1, 0, 0);

           banner = npc.type;
           bannerItem = mod.ItemType("SandCoreBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (!NPC.AnyNPCs(mod.NPCType("SandCore")) && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUndergroundDesert)
            {
                {
                    return SpawnCondition.Cavern.Chance * 0.1f;
                }
            }
            
            else
            {
                return SpawnCondition.Cavern.Chance * 0f;
            }
        }
        int shoottime = 0;
        int shootduration;
        bool attacking;
        int sounddelay;
        //float ypos = -150;
        float movespeed = 3f; //Speed of the npc

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.6f * Main.essScale);

            npc.spriteDirection = npc.direction;



            Player player = Main.player[npc.target];
            npc.TargetClosest();
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center + new Vector2(0, 0);
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
          
            if (player.dead)
            {
                npc.velocity.Y = -0.5f;
            }
           
                npc.rotation = npc.velocity.X / 50;

            if (distance <= 300f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                shoottime++;
                movespeed = 1.5f;
                shootduration++;
                sounddelay++;
               
                if (shoottime >= 4 && !player.dead && shootduration < 300)//fires the projectiles
                {
                    attacking = true;

                    float projectileSpeed = 3f;
                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) - new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5));
                        float scale = 1f - (Main.rand.NextFloat() * .2f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SandCoreProj"), 15, 0);

                    }


                    shoottime = 0;

                }

                if (sounddelay > 10 && shootduration < 300)
                {
                    Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 34, 1, 0.25f);
                    sounddelay = 0;
                }
                if (shootduration > 150) // shoots for 2.5 seconds
                {
                    attacking = false;
                    sounddelay = 0;
                    shoottime = 0;

                }
                if (shootduration > 300) // pauses for 2.5
                {
                    shootduration = 0;
                }
            }
            else
            {
                shoottime = 0;
                attacking = false;
                movespeed = 3f;

            }


            if (Main.rand.Next(4) == 0) //Dust effects
            {
                var dust3 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Bottom.Y - 15), npc.width, 20, 138, 0, 10);
                dust3.noGravity = true;
            }
       
        }
        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
           
            if (!attacking)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 5) //Cycles through frames 0-4 when not attacking
                {
                    npcframe = 0;
                }
            }
            if (attacking)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 3)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe < 5 || npcframe >= 9) //Cycles through frames 5-8 when attacking
                {
                    npcframe = 5;
                }
            }
        }
    
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 600);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            
            shoottime = -20;
            attacking = false;
            shootduration = 0;
            sounddelay = 0;

            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 138);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) they will spawn this
            {
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore1"), 1f);   
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SandCoreGore4"), 1f);

                for (int i = 0; i < 40; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 138);
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
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertOre"), Main.rand.Next(5, 8));
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientBattleArmorMaterial);
                }
            }
          
            else
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertOre"), Main.rand.Next(4, 7));
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientBattleArmorMaterial);
                }
            }
            if (!StormWorld.SpawnDesertOre)
            {
                StormWorld.SpawnDesertOre = true;
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