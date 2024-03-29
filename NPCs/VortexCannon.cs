using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Banners;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCs

{
    public class VortexCannon : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortexian Cannon"); 
            Main.npcFrameCount[npc.type] = 10; 
        }
        public override void SetDefaults()
        {
            npc.width = 56;
            npc.height = 44;

            npc.aiStyle = 3; 
            aiType = NPCID.VortexSoldier;
            animationType = NPCID.VortexSoldier;

            npc.damage = 80;
            
            npc.defense = 20;
            npc.lifeMax = 750;


            
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            Item.buyPrice(0, 0, 0, 0);
            
            
            banner = npc.type;
            bannerItem = mod.ItemType("VortCannonBannerItem");
        }
      
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!GetInstance<Configurations>().PreventPillarEnemies)
            {
                return SpawnCondition.VortexTower.Chance * 0.22f;
            }
            else
            {
                return SpawnCondition.VortexTower.Chance * 0f;
            }

        }
        int shoottime = 0;
        int firerate = 0;
        public override void AI()
        {
            shoottime++;
            

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance <= 800f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                

                if (shoottime >= 180)
                {
                    npc.velocity.X = 0;
                    //float projectileSpeed = 8f; // The speed of your projectile (in pixels per second).
                    int damage = 50; // The damage your projectile deals.
                    float knockBack = 3;
                    int projectileSpeed = 5;
                    int type = mod.ProjectileType("VortCannonProj");
                    //int type = ProjectileID.PinkLaser;

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2) -
                   new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    // Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);
                   


                    //int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
                    firerate++;
                    if (firerate >= 10)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15)); // 15 degree spread.
                                                                                                                                        // If you want to randomize the speed to stagger the projectiles
                                float scale = 1f - (Main.rand.NextFloat() * .2f);
                                perturbedSpeed = perturbedSpeed * scale;
                                Projectile.NewProjectile(npc.Center.X, npc.Top.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                            }
                            Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 92);
                            firerate = 0;
                        }
                    }
                    if (shoottime >= 220)
                    {
                        shoottime = 0;
                    }
                }
               
            }
            else
            {
                shoottime = 100;
                firerate = 0;
    
            }
        }

      

        public override void HitEffect(int hitDirection, double damage)
        {
            //shoottime = 100;
            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 10), 20, 20, 229);
                dust.scale = 0.5f;

            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore2"), 1f);     
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore5"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 229);
                }
                if (NPC.ShieldStrengthTowerVortex > 0)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ProjectileID.TowerDamageBolt, 0, 0f, Main.myPlayer, NPC.FindFirstNPC(422));
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/VortexCannon_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

        }

    }
}