using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;

namespace StormDiversSuggestions.Items.Accessory
{
  
    public class SpookyCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Emblem");
            Tooltip.SetDefault("Has a chance to create spooky flames that home in on enemies when using any weapon");
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