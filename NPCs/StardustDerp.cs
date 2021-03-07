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
    public class StardustDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Hopper"); // Automatic from .lang files
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
            npc.dontTakeDamageFromHostiles = true;
            npc.damage = 80;
            
            npc.defense = 10;
            npc.lifeMax = 800;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath18;
            npc.knockBackResist = 0.5f;
            Item.buyPrice(0, 0, 0, 0);

            banner = npc.type;
            bannerItem = mod.ItemType("StardustDerpBannerItem"); 
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!GetInstance<Configurations>().PreventPillarEnemies)
            {
                return SpawnCondition.StardustTower.Chance * 0.3f;
            }
            else
            {
                return SpawnCondition.StardustTower.Chance * 0f;

            }
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



            if (distance <= 600f && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
            {
                if (shoottime >= 180)
                {
                    
                    int type = mod.NPCType("StardustMiniDerp");


                    Main.PlaySound(SoundID.NPCHit, (int)npc.Center.X, (int)npc.Center.Y, 5);
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        NPC.NewNPC((int)Math.Round(npc.Center.X), (int)Math.Round(npc.Center.Y), type);
                        
                        for (int i = 0; i < 30; i++)
                        {
                            Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                            var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 15, npc.Center.Y - 15), 30, 30, 111);
                        }
                    }
 

                   

                    shoottime = 0;
                }
            }
            else
            {
                shoottime = 0;
            }
        }
        
        public override void HitEffect(int hitDirection, double damage)
        {
            shoottime = 0;

            for (int i = 0; i < 2; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 10), 20, 20, 111);
                dust.scale = 0.5f;
            }

            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpGore2"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpGore4"), 1f);
                
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 111);
                }
                if (NPC.ShieldStrengthTowerStardust > 0)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ProjectileID.TowerDamageBolt, 0, 0f, Main.myPlayer, NPC.FindFirstNPC(493));
                }
                
            }
        }
        
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/StardustDerp_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
        
        } 

       

    }

}
