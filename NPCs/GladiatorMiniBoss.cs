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
    public class GladiatorMiniBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Warrior"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
           
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
            
            npc.width = 28;
            npc.height = 48;

            npc.aiStyle = 22; 
            aiType = NPCID.Wraith;
            animationType = NPCID.FlyingSnake;

            npc.damage = 30;
           
            npc.defense = 10;
            npc.lifeMax = 180;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0.85f;
            npc.value = Item.buyPrice(0, 0, 50, 0);
            npc.rarity = 2;

            banner = npc.type;
            bannerItem = mod.ItemType("GladiatorMiniBossBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (spawnInfo.marble && !NPC.AnyNPCs(mod.NPCType("GladiatorMiniBoss")) && NPC.downedBoss1)
            {
                return SpawnCondition.Cavern.Chance * 0.1f;
            }
            else
            return SpawnCondition.Cavern.Chance * 0f;
    
            
        }
        int shoottime = 0;


        public override void AI()
        {
            shoottime++;

            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.3f * Main.essScale);

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            if (distance <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                
            {

                if (shoottime >= 300)
                {
                    float projectileSpeed = 1f; // The speed of your projectile (in pixels per second).
                    int damage = 15; // The damage your projectile deals. normal x2, expert x4
                    float knockBack = 1;
                    int type = mod.ProjectileType("GladiatorMiniBossProj");

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 8);
                    
                    for (int i = 0; i < 3; i++)
                    {
                        float posX = npc.position.X + Main.rand.NextFloat(60f, -60f);
                        float posY = npc.position.Y + Main.rand.NextFloat(60f, -60f);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {

                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(0));

                            Projectile.NewProjectile(posX, posY, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, Main.myPlayer);
                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {

                        var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 57);
                        dust.noGravity = true;
                        dust.velocity *= 3;
                        dust.scale = 2;

                    }
                    shoottime = 0;

                }
               
            }
            else
            {
                shoottime = 160;


            }


            if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, 57);
                //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                dust2.noGravity = true;
                dust2.scale = 1f;
                

            }
            if (Main.rand.Next(2) == 0)
            {

                int dust2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height / 2), npc.width, npc.height / 2, 5, 0, 2, 150, default, 1f);
            }
        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
               
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 160;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 10), 20, 20, 5);
                dust.alpha = 150;
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                //Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore1"), 1f);   
                //Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore2"), 1f);    
                //Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore3"), 1f);
                //Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5);
                    dust.alpha = 150;
                }
                for (int i = 0; i < 30; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 31, 0f, 0f, 100, default, 1f);
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
                if (Main.rand.Next(100) < 40)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GladiatorAccess"));
                }
            }
            else
            {
                if (Main.rand.Next(100) < 30)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GladiatorAccess"));
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;
        }
    }
}