using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items.Vanitysets
{
    [AutoloadEquip(EquipType.Head)]
    public class ThePainMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("ThePain");
            Tooltip.SetDefault("When the pain is too much");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.White;
            item.vanity = true;
            
        }
       
        
        public override void ArmorSetShadows(Player player)
        {
           
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                if (Main.rand.Next(5000) < 1)

                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThePainMask"));
                }
               
            }
        }

    }
    [AutoloadEquip(EquipType.Head)]
    public class TheClaymanMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Clayman");
            Tooltip.SetDefault("Sliently judge everybody around you");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.White;
            item.vanity = true;

        }


        public override void ArmorSetShadows(Player player)
        {

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                if (Main.rand.Next(50) < 1 && npc.boss)

                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheClaymanMask"));
                }

            }
        }

    }

}