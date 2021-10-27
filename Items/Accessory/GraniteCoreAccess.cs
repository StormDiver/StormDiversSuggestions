using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    public class GraniteCoreAccess : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Granite Core");
            Tooltip.SetDefault("Taking more than 1 damage grants the Granite Surge buff, granting 50% increased damage for 4 seconds\nHas a 10 second cooldown between activation");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            
            item.accessory = true;
            
            
        }
       
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().graniteBuff = true;
            
           
        }
        

    }
}