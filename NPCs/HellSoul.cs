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
    public class HellSoul : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartless Soul");
            Main.npcFrameCount[npc.type] = 5;


        }
        public override void SetDefaults()
        {
            
            npc.width = 22;
            npc.height = 50;

            npc.aiStyle = 22;

            aiType = NPCID.Wraith;
            //animationType = NPCID.FlyingSnake;
            
            npc.damage = 35;
            npc.lavaImmune = true;
            npc.defense = 12;
            npc.lifeMax = 150;
            npc.noGravity = true;
            
            
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.7f;
            npc.value = Item.buyPrice(0, 0, 25, 0);

           banner = npc.type;
           bannerItem = mod.ItemType("HellSoulBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

           
                return SpawnCondition.Underworld.Chance * 0.1f;
           

        }
        int shoottime = 0;

        bool casting;
        public override void AI()
        {
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[(BuffType<SuperBurnDebuff>())] = true;


            shoottime++;

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            if (distance <= 1000f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 250)
                {
                    //npc.velocity.X = 0;
                    npc.velocity.Y *= 0.95f;
                    npc.velocity.X *= 0.8f;


                    var dust2 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Top.Y), npc.width, 2, 6, 0, -5);
                    dust2.noGravity = true;
                    dust2.scale = 1.5f;

                    casting = true;

                }
                else
                {
                    casting = false;
                }
                if (shoottime >= 300)
                {


                    float projectileSpeed = 7f; // The speed of your projectile (in pixels per second).
                    int damage = 20; // The damage your projectile deals.
                    float knockBack = 3;
                    int type = mod.ProjectileType("HellSoulProj");
                    Main.PlaySound(2, (int)npc.Center.X, (int)npc.Center.Y, 8);

                    Vector2 velocity = Vector2.Normalize(new Vector2(player.Center.X, player.Center.Y) -
                    new Vector2(npc.Center.X, npc.Center.Y)) * projectileSpeed;


                    for (int i = 0; i < 3; i++)
                    {
                        if (Main.netMode != 1)
                        {

                            float speedX = 0f;
                            float speedY = -4f;
                            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(70));
                            float scale = 1f - (Main.rand.NextFloat() * .2f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack);
                           
                        }
                    }

                    shoottime = 0;
                }
            }
            else
            {
                shoottime = 0;
                casting = false;
            }
            var dust3 = Dust.NewDustDirect(new Vector2(npc.position.X, npc.Bottom.Y - 2), npc.width, 2, 6, 0, 5);
            dust3.noGravity = true;
        }
        int npcframe = 0;
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (casting)
            {
                npc.frame.Y = 4 * frameHeight; //Picks frame 4 when casting
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

            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 600);


        }
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 0;

            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 5, npc.Center.Y - 5), 10, 10, 5);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellSoulGore1"), 1f);   
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellSoulGore2"), 1f);    
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellSoulGore3"), 1f);
                 Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/HellSoulGore4"), 1f);
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5);
                    dust.scale = 2f;
                }
              

            }
        }
        public override void NPCLoot()
        {


            if (Main.expertMode)
            {
                

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrackedHeart"));
                
            }
            if (!Main.expertMode)
            {
                if (Main.rand.Next(100) < 50)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrackedHeart"));
                }
            }

        }
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/GraniteMiniBoss_Glow");
            Vector2 drawPos = new Vector2(0, 2) + npc.Center - Main.screenPosition;

            spriteBatch.Draw(texture, drawPos, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }*/
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}