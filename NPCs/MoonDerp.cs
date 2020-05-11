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

            npc.aiStyle = 86; // This npc has a completely unique AI, so we set this to -1. The default aiStyle 0 will face the player, which might conflict with custom AI code.
            
            animationType = NPCID.Harpy;

            npc.damage = 150;

            npc.defense = 30;
            npc.lifeMax = 4000;
            npc.alpha = 3;


            npc.HitSound = SoundID.NPCHit56;
            npc.DeathSound = SoundID.NPCDeath62;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = mod.ItemType("MoonDerpBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (NPC.downedMoonlord)
            {
                return SpawnCondition.Sky.Chance * 0.2f;
            }
            return SpawnCondition.Sky.Chance * 0f;
        }
        int shoottime = 0;
        int shootspeed = 0;
        int dusttime = 0;
        public override void AI()
        {
            dusttime++;
            if (dusttime >= 5)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 265);
                dusttime = 0;
            }
            shoottime++;
            npc.noTileCollide = true;

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            bool lineOfSight = Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height);
            if (distance <= 900f && lineOfSight)
            {
                
                if (shoottime >= 120)
                {
                    float projectileSpeed = 5f; // The speed of your projectile (in pixels per second).
                    int damage = 60; // The damage your projectile deals.
                    float knockBack = 3;
                    //int type = mod.ProjectileType("ScanDroneProj");
                    int type = ProjectileID.PhantasmalBolt;
                    shootspeed++;
                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) - new Vector2(npc.Center.X, npc.Top.Y)) * projectileSpeed;


                   
                    if (shootspeed >= 10)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
                                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                            float scale = 1f - (Main.rand.NextFloat() * .3f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X, npc.Top.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, Main.myPlayer);
                        }
                        shootspeed = 0;
                    }
                    if (shoottime >= 140)
                    {
                        shoottime = 0;
                    }
                }
               
            }
        }


       
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 89);
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
                    var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 89);
                }

                Projectile.NewProjectile(npc.Center.X, npc.Top.Y, 0, -2, ProjectileID.PhantasmalEye, 35, 6f, Main.myPlayer);


            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/MoonDerp_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

    
        }

        public override void NPCLoot()
        {

            int drops = 5 + Main.rand.Next(4); //This defines how many projectiles to shot.
            for (int i = 0; i < drops; i++)
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.LunarOre);
            }


                int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                int vortdrop = 2 + Main.rand.Next(4); 
                for (int i = 0; i < vortdrop; i++)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.FragmentVortex);
                }
            }
            else if (choice == 1)
            {
                int solardrop = 2 + Main.rand.Next(4);
                for (int i = 0; i < solardrop; i++)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.FragmentSolar);
                }
            }
            else if (choice == 2)
            {
                int nebdrop = 2 + Main.rand.Next(4);
                for (int i = 0; i < nebdrop; i++)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.FragmentNebula);
                }
            }
            else if (choice == 3)
            {
                int stardrop = 2 + Main.rand.Next(4);
                for (int i = 0; i < stardrop; i++)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.FragmentStardust);
                }
            }
        }
    }
}