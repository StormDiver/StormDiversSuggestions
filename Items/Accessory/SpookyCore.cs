using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
  
    public class SpookyCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Emblem");
            Tooltip.SetDefault("Inflict fear upon nearby enemies\nHas a greater range the lower on health you are");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;

        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Yellow;

            item.accessory = true;
            
        }
      
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
                player.GetModPlayer<StormPlayer>().spooked = true;
            
        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.Pumpking)
                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(100) < 15)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpookyCore"));
                        }
                    }
                    if (!Main.expertMode)
                    {
                        if (Main.rand.Next(100) < 10)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpookyCore"));
                        }
                    }
                }
            }
        }


    }
   
        }