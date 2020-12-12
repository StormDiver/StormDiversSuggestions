using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Banners;


namespace StormDiversSuggestions.NPCs

{
    public class BabyDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Derpling"); // Automatic from .lang files
            Main.npcFrameCount[npc.type] = 3; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            npc.width = 24;
            npc.height = 24;

            npc.aiStyle = 41; 
            aiType = NPCID.Derpling;
            animationType = NPCID.Derpling;

            npc.damage = 20;
            
            npc.defense = 5;
            npc.lifeMax = 100;
            
            npc.HitSound = SoundID.NPCHit22;
            npc.DeathSound = SoundID.NPCDeath25;
            npc.knockBackResist = -0.5f;
            npc.value = Item.buyPrice(0, 0, 0, 1);

            banner = npc.type;
            bannerItem = mod.ItemType("BabyDerpBannerItem"); 
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return SpawnCondition.SurfaceJungle.Chance * 0.8f;
            }
            return SpawnCondition.SurfaceJungle.Chance * 0f;
        }
    
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 265);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/BabyDerpGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/BabyDerpGore2"), 1f);     
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/BabyDerpGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/BabyDerpGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 265);
                }
            }
        }
        /*
        public override void NPCLoot()
        {
            
                if (Main.expertMode)
                {
                    if (Main.rand.Next(8) == 0)
                    {

                        Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("DerplingShell"));
                    }
                }
                else
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("DerplingShell"));
                    }
                }
               
        } */
    }
}