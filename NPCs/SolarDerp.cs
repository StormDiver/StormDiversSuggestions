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
    public class SolarDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazling"); // Automatic from .lang files
            Main.npcFrameCount[npc.type] = 3; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            npc.width = 68;
            npc.height = 72;

            npc.aiStyle = 41; 
            aiType = NPCID.Derpling;
            animationType = NPCID.Derpling;
            npc.alpha = 3;

            npc.damage = 120;
            
            npc.defense = 25;
            npc.lifeMax = 1200;


            
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath18;
            npc.knockBackResist = 0.5f;
            Item.buyPrice(0, 0, 0, 0);
            
            banner = npc.type;
            bannerItem = mod.ItemType("SolarDerpBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return SpawnCondition.SolarTower.Chance * 0.2f;
        }

       
        
       
        int shoottime = 0;
        int firetime = 0;
        public override void AI()
        {

            if (Main.rand.NextFloat() < 0.8f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = npc.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, npc.width, npc.height, 153, 0f, 0f, 0, new Color(255, 255, 255), 1.5f)];
                dust.noGravity = true;
            }


            shoottime++;
            
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            
            if (distance <= 500f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 240)
                {
                    float projectileSpeed = 2f; // The speed of your projectile (in pixels per second).
                    int damage = 30; // The damage your projectile deals.
                    float knockBack = 3;
                     int type = mod.ProjectileType("SolarDerpProj");


                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    //Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2, velocity.X, velocity.Y, type, damage, knockBack, Main.myPlayer);


                    //Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 20);
                    firetime++;
                    if (firetime >= 10)
                    {
                        Vector2 perturbedSpeed = new Vector2(0, -4).RotatedByRandom(MathHelper.ToRadians(45)); 
                                                                                                                
                        float scale = 1f - (Main.rand.NextFloat() * .3f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                        Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 7);
                        
                        for (int i = 0; i < 10; i++)
                        {
                            Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                            var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 244);
                        }

                        firetime = 0;
                    }
                    
                    if (shoottime >= 300)
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
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 244);
            }

            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SolarDerpGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SolarDerpGore2"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SolarDerpGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/SolarDerpGore4"), 1f);

                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 244);
                }
                if (NPC.ShieldStrengthTowerSolar > 0)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, 629, 0, 0f, Main.myPlayer, NPC.FindFirstNPC(517));
                }
            }
        }
        
       public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/SolarDerp_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        
        }

        

    }

}
