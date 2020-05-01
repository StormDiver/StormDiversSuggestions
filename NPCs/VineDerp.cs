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
    public class VineDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Camouflaged Derpling"); 
            Main.npcFrameCount[npc.type] = 24; 
        }
        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 32;

            npc.aiStyle = 25; 
            aiType = NPCID.Mimic;
            animationType = NPCID.Mimic;

            npc.damage = 120;
            
            npc.defense = 25;
            npc.lifeMax = 1000;


            
            npc.HitSound = SoundID.NPCHit22;
            npc.DeathSound = SoundID.NPCDeath25;
            npc.knockBackResist = 0.3f;
            npc.value = Item.buyPrice(0, 0, 50, 0);
            //npc.rarity = 2;
            banner = npc.type;
            bannerItem = mod.ItemType("VineDerpBannerItem");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedPlantBoss)
            { 
                return SpawnCondition.UndergroundJungle.Chance * 1f;
            }
            return SpawnCondition.UndergroundJungle.Chance * 0f;
        }
        public override void AI()
        {
           
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
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VineDerpGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VineDerpGore2"), 1f);     
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VineDerpGore3"), 1f);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/VineDerpGore4"), 1f);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 265);
                }
            }
        }
        public override void NPCLoot()
        {
            int drops = 8 + Main.rand.Next(4); //This defines how many projectiles to shot.
            for (int i = 0; i < drops; i++)
            {
                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.ChlorophyteOre);
            }
            if (Main.expertMode)
            {
                if (Main.rand.Next(5) == 0)
                {

                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("DerplingVine"));
                }
            }
            else
             if (Main.rand.Next(6) == 0)
            {

                Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, mod.ItemType("DerplingVine"));
            }
        } 
    }
}