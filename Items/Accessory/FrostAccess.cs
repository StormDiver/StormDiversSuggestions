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
            Tooltip.SetDefault("Multiple frost shards explode out of you when taking damage, each dealing 100% of the damage taken\nIncreases critical strike chance and movement speed for 6 seconds afterwards");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 5;

            
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().frostSpike = true;
            
        }

    

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