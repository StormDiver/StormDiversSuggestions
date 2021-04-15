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
    public class SpaceRockHead : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Orbiter"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
            
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
            
            npc.width = 34;
            npc.height = 34;

            npc.aiStyle = 14; 
            aiType = NPCID.FlyingSnake;
            animationType = NPCID.FlyingSnake;

            npc.damage = 70;
            
            npc.defense = 10;
            npc.lifeMax = 600;
            npc.noGravity = true;


            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath43;
            npc.knockBackResist = 0.1f;
            npc.value = Item.buyPrice(0, 0, 20, 0);

           banner = npc.type;
            bannerItem = mod.ItemType("SpaceRockHeadBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedPlantBoss)
            {
                return SpawnCondition.Sky.Chance * 0.7f;
            }
            return SpawnCondition.Sky.Chance * 0f;
            
        }
        int shoottime = 0;

        int movetime;

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
                if (shoottime >= 240)
                {
                    float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 30; // The damage your projectile deals.
                    float knockBack = 3;
                    int type = mod.ProjectileType("SpaceHeadProj");

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 13);


                    for (int i = 0; i < 4; i++)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(180)); // 30 degree spread.
                                                                                                                                     // If you want to randomize the speed to stagger the projectiles
                            float scale = 1f - (Main.rand.NextFloat() * .3f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, Main.myPlayer);
                        }
                    }

                    
                    movetime = 30;
                    shoottime = 0;
                }
            }
            else
            {
                shoottime = 0;
            }


            if (movetime > 0)
            {
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
                movetime--;
            }
            if (Main.rand.Next(5) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, 6);
                //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                dust2.noGravity = true;
                dust2.scale = 1.5f;
                dust2.velocity *= 2;

            }
            if (Main.rand.Next(2) == 0)
            {

                int dust2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 0, npc.velocity.X, npc.velocity.Y, 0, default, 0.5f);
            }
        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
               
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 150;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 6);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore1"), 1f);   
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SpaceRockHeadGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6);
                }
              

            }
        }
        public override void NPCLoot()
        {

            if (Main.expertMode)
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SpaceRock"), Main.rand.Next(2, 5));
            }
            else
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("SpaceRock"), Main.rand.Next(2, 4));
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {

            return Color.White;

        }

    }
}