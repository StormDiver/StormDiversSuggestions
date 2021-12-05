using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    public class FlameCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Betsy's Flame");
            Tooltip.SetDefault("Has a chance to summon Betsy's flames when using any weapon\nSlightly increases player acceleration");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = -12;
           
            item.accessory = true;
            item.expert = true;
        }
        //int particle = 5;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
     
            player.GetModPlayer<StormPlayer>().flameCore = true;
     
            
        }
        
       
        

       
    }
}