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
        //CREATE NEW FROST MOON ACCESSORY THAT DOES THIS, AND TURN THIS INTO A GENERIC MULTICLASS THINGY
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Core");
            Tooltip.SetDefault("Creates Spooky flames that home in on enemies when using any weapon");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 8;
            
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
                        if (Main.rand.Next(8) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpookyCore"));
                        }
                    }
                    if (!Main.expertMode)
                    {
                        if (Main.rand.Next(10) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpookyCore"));
                        }
                    }
                }
            }
        }


    }
   
        }