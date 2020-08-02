using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Items.Accessory
{
   
    //__________________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Shoes)]
    public class StompBoot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavy Boots");
            Tooltip.SetDefault("Allows you to fall faster and creates a shockwave when impacting the ground with enough speed\n'What did you think would happen if you attached an Anvil to a pair of boots?'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.value = Item.sellPrice(0, 1, 25, 0);
            item.rare = 3;

            item.defense = 3;
            item.accessory = true;
        }

       
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().bootFall = true;
        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.IronAnvil);
            
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RocketBoots, 1);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.LeadAnvil);
            
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //________________________________________________________________________________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Shoes)]
    public class StompBootHorse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavy Horseshoe Boots");
            Tooltip.SetDefault("Allows you to fall faster and creates a shockwave when impacting the ground with enough speed\nNegates fall damage");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = 3;

            item.defense = 3;
            item.accessory = true;
        }

        //bool falling;

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().bootFall = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("StompBoot"));
            recipe.AddIngredient(ItemID.LuckyHorseshoe);
           
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}