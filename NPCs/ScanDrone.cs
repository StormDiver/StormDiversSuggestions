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
    public class ScanDrone : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ScanDrone"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
            
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 5;
            
            npc.width = 40;
            npc.height = 20;

            npc.aiStyle = 14; 
            aiType = NPCID.GiantFlyingFox;
            //animationType = NPCID.CaveBat;

            npc.damage = 60;
            
            npc.defense = 15;
            npc.lifeMax = 300;
            npc.alpha = 3;
            

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0.9f;
            npc.value = Item.buyPrice(0, 0, 0, 0);

            banner = npc.type;
            bannerItem = mod.ItemType("ScanDroneBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

        
            if (!GetInstance<Configurations>().PreventPillarEnemies)
            {
                return SpawnCondition.VortexTower.Chance * 0.15f;
            }
            else
            {
                return SpawnCondition.VortexTower.Chance * 0f;
            }
        }
        int shoottime = 0;
        //private float rotation;
        //private float scale;
        bool shooting;
        public override void AI()
        {
            shoottime++;
            npc.noTileCollide = true;
            

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance  <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 100)
                {
                    shooting = true;
                    npc.velocity *= 0f;

                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        dust = Terraria.Dust.NewDustPerfect(new Vector2(npc.Center.X + 12 * npc.direction, npc.Center.Y), 156, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
                        dust.noGravity = true;
                        dust.scale = 1.5f;
                    }
                }
                if (shoottime >= 120)
                {
                    float projectileSpeed = 8f; // The speed of your projectile (in pixels per second).
                    int damage = 30; // The damage your projectile deals.
                    float knockBack = 3;
                    int type = mod.ProjectileType("ScanDroneProj");
                    //int type = ProjectileID.PinkLaser;

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                   // Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 17);


                    //int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots

                    for (int i = 0; i < 1; i++)
                    {
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                            float scale = 1f - (Main.rand.NextFloat() * .3f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X + 10 * npc.direction, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                        }
                    }
                                      
                    shoottime = 0;
                    shooting = false;
                }
            }
            else
            {
                shoottime = 60;
                shooting = false;

            }
        }

        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (shooting)
            {
                npc.frame.Y = 4 * frameHeight; //Picks frame 4 when shooting
            }
            else
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 10)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe == 4) //Cycles through frames 0-3 when not casting
                {
                    npcframe = 0;
                }
            }

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
                target.AddBuff(mod.BuffType("ScanDroneDebuff"), 800);
            
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 60;
            shooting = false;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 229);
                dust.scale = 0.5f;

            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/ScanDroneGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/ScanDroneGore2"), 1f);     // 1f is the gore sprite size, you can change it but i suggest to keep it to 1f
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/ScanDroneGore3"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 229);
                }
                //NPC.ShieldStrengthTowerVortex = (int)MathHelper.Clamp(NPC.ShieldStrengthTowerVortex - 1, 0f, NPC.ShieldStrengthTowerMax);
                if (NPC.ShieldStrengthTowerVortex > 0)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ProjectileID.TowerDamageBolt, 0, 0f, Main.myPlayer, NPC.FindFirstNPC(422));
                }

            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/ScanDrone_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }


    }
}