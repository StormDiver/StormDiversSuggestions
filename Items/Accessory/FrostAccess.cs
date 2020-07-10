using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class FrostAccess : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Core");
            Tooltip.SetDefault("Frost shards explode out of you when taking damage\nIncreases critical strike chance and movement speed for 5 seconds afterwards");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 5;

            item.defense = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().frostSpike = true;
            
        }

       /* public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
        {
            
        
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            
            recipe.AddIngredient(mod, "IceBar", 10);
            recipe.AddIngredient(ItemID.FrostCore, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
    }
}