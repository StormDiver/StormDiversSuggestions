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


namespace StormDiversSuggestions.NPCs

{
    public class GolemSentry : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Flametrap");
            Main.npcFrameCount[npc.type] = 4;


        }
        public override void SetDefaults()
        {
            
            npc.width = 20;
            npc.height = 66;

            //npc.aiStyle = 22;

            //aiType = NPCID.Wraith;
            //animationType = NPCID.FlyingSnake;
            npc.noTileCollide = false;

            npc.damage = 50;
            npc.lavaImmune = true;
            npc.defense = 40;
            npc.lifeMax = 1000;
            npc.noGravity = false;
            
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.knockBackResist = 0f;
            npc.value = Item.buyPrice(0, 0, 25, 0);
            npc.gfxOffY = -2;
           banner = npc.type;
           bannerItem = mod.ItemType("GolemSentryBannerItem");
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
                return SpawnCondition.JungleTemple.Chance * 0.4f;
            }
           
            else
            {
                return SpawnCondition.JungleTemple.Chance * 0f;
            }
        }
        int shoottime = 0;

        int animatespeed;

        public override void AI()
        {
            Lighting.AddLight(npc.Center, Color.WhiteSmoke.ToVector3() * 0.6f * Main.essScale);

            //npc.velocity.Y = 3;
            Player player = Main.player[npc.target];
            npc.TargetClosest();
           


            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

           

            if (distance <= 700f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {

                shoottime++;

                if (shoottime >= 75)//starts the shooting animation
                {
                 


                    var dust2 = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Top.Y + 15), 10, 10, 6, 0, 0);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;
                    dust2.velocity *= 2;
                    animatespeed = 4;
                }
                else
                {
                    animatespeed = 10;
                }
                if (shoottime >= 90)//fires the projectiles
                {



                    float projectileSpeed = 10f; // The speed of your projectile (in pixels per second).
                    int damage = 30; // The damage your projectile deals. normal x2, expert x4
                    float knockBack = 3;
                    //int type = mod.ProjectileType("GolemMinionProj");
                    int type = ProjectileID.Fireball;

                    Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 20);

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {

                           
                            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5));
                            float scale = 1f - (Main.rand.NextFloat() * .2f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 13, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                           
                        }
                    

                    shoottime = 0;

                }
            }
            else
            {
                shoottime = 45;
                animatespeed = 10;


            }
            if (Main.rand.Next(4) == 0)
            {
                var dust3 = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Top.Y + 15), 10, 10, 6, 0, 10);
                dust3.noGravity = true;
            }
        }
        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {

            npc.frame.Y = npcframe * frameHeight;
            npc.frameCounter++;
            if (npc.frameCounter > animatespeed) //Animation speeds up when about to fire
            {
                npcframe++;
                npc.frameCounter = 0;
            }
            if ( npcframe >= 4) 
            {
                npcframe = 0;
            }

        }
        
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {



        }
        public override void HitEffect(int hitDirection, double damage)
        {
            
      
            for (int i = 0; i < 2; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 15), 10, 10, 25);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) they will spawn this
            {
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore1"), 1f);   
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore2"), 1f);    
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore4"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore5"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/GolemSentryGore5"), 1f);
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6);
                    dust.scale = 2;
                    dust.velocity *= 2;
                }
                for (int i = 0; i < 30; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 31, 0f, 0f, 0, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }

            }
        }
        public override void NPCLoot()
        {
            if (NPC.downedPlantBoss)
            {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarTabletFragment, Main.rand.Next(1, 3));
                if (Main.rand.Next(5) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LihzahrdPowerCell);
                }
            }

        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/GolemSentry_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }

    }
}