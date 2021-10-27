using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    public class GladiatorAccess : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Warrior's Trophy");
            Tooltip.SetDefault("While above 75% HP your critical strike chance is increased by 20%");
        }

        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 2;
            item.accessory = true;
            
            
        }
       
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.GetModPlayer<StormPlayer>().graniteBuff = true;
            if (player.statLife >= player.statLifeMax2 * 0.75f)
            {
                player.AddBuff(mod.BuffType("GladiatorAccessBuff"), 2);

               
            }
        }
      

    }
}