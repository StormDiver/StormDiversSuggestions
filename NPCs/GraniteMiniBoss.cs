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
    public class GraniteMiniBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Surged Granite Core"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
            
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
            
            npc.width = 38;
            npc.height = 38;

            npc.aiStyle = 5; 
            aiType = NPCID.Parrot;
            animationType = NPCID.FlyingSnake;
            
            npc.damage = 25;
            
            npc.defense = 12;
            npc.lifeMax = 160;
            npc.noGravity = true;
            npc.rarity = 2;


            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath44;
            npc.knockBackResist = 0.6f;
            npc.value = Item.buyPrice(0, 1, 0, 0);

           banner = npc.type;
            bannerItem = mod.ItemType("GraniteMiniBossBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.granite && !NPC.AnyNPCs(mod.NPCType("GraniteMiniBoss")) && NPC.downedBoss1)
            {
                return SpawnCondition.Cavern.Chance * 0.12f;
            }
            else
                return SpawnCondition.Cavern.Chance * 0f;

        }
        int shoottime = 0;


        public override void AI()
        {
            shoottime++;
            


            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance  <= 600f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 100)
                {
                    if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
                    {
                        var dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, 70);
                        //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                        dust2.noGravity = true;
                        dust2.scale = 1.5f;

                    }
                    npc.velocity.X = 0;
                    npc.velocity.Y = 0;
                }
                if (shoottime >= 160)
                {
                    float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 15; // The damage your projectile deals.
                    float knockBack = 1;
                    int type = mod.ProjectileType("GraniteMiniBossProj");

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 12);


                    for (int i = 0; i < 1; i++)
                    {
                        if (Main.netMode != 1)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(0)); 
                                                                                                                                  
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, Main.myPlayer);
                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {

                        var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 70);
                        dust.noGravity = true;
                        dust.velocity *= 3;

                    }

                    shoottime = 0;
                }
            }
            else
            {
                shoottime = 0;
            }

            if (Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                npc.noTileCollide = false;
                npc.velocity.X *= 0.95f;
                npc.velocity.Y *= 0.95f;
            }
            else
            {
                npc.noTileCollide = true;
        
            }
          

            if (Main.rand.Next(2) == 0)
            {

                int dust2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 70, npc.velocity.X, npc.velocity.Y, 0, default, 0.5f);
            }
        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
               
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 0;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 70);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GraniteMiniBossGore1"), 1f);   
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GraniteMiniBossGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GraniteMiniBossGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GraniteMiniBossGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 70);
                }
              

            }
        }
        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                if (Main.rand.Next(100) < 33)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GraniteCoreAccess"));
                }
            }
            else
            {
                if (Main.rand.Next(100) < 25)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GraniteCoreAccess"));
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/GraniteMiniBoss_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }

    }
}