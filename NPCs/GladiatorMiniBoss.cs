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
            DisplayName.SetDefault("Fallen Champion"); // Automatic from .lang files
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
            npc.lifeMax = 150;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0.85f;
            npc.value = Item.buyPrice(0, 1, 0, 0);
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

            if (spawnInfo.marble && !NPC.AnyNPCs(mod.NPCType("GladiatorMiniBoss")))
            {
                return SpawnCondition.Cavern.Chance * 0.06f;
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

            /*if (distance  >= 500f )
            {

                float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 15; // The damage your projectile deals.
                    float knockBack = 1;
                    int type = mod.ProjectileType("Projectile");

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

                        var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 57);
                        dust.noGravity = true;
                        dust.velocity *= 3;

                    }

                    shoottime = 0;
        }*/



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
            shoottime = 0;

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
              

            }
        }
        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GladiatorAccess"));
                }
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("RedSilk"), Main.rand.Next(1, 3));
            }
            else
            {
                if (Main.rand.Next(5) == 0)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("GladiatorAccess"));
                }
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("RedSilk"));
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