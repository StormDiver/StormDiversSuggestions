using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using Terraria.Localization;

namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Legs)]
    public class RainBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Rain Boots");
            //Tooltip.SetDefault("Rain");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = ItemRarityID.White;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {
            
        }

        public override void ArmorSetShadows(Player player)
        {
            
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemID.RainHat && body.type == ItemID.RainCoat;

        }

        public override void UpdateArmorSet(Player player)
        {
                if (Main.raining)
                {

                    player.AddBuff(mod.BuffType("RainBuff"), 2);
                }
                player.setBonus = "50% increased Movement Speed while raining";
     
        }
    
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 5)

                {
                    if (npc.type == NPCID.ZombieRaincoat)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RainBoots"));
                    }
                }
            }
        }
        public override bool DrawLegs()
        {
            return true;
        }
    }

   

}