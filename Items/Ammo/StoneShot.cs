using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class StoneShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miniature Boulder");
            Tooltip.SetDefault("For use with Stone Launchers");
            
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = 1;
            item.ranged = true;

            item.damage = 20;
            
            item.knockBack = 4f;
            item.consumable = true;
            
            item.shoot = mod.ProjectileType("StoneProj");
            item.shootSpeed = 5f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 333);           
            recipe.SetResult(this, 111);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 111);            
            recipe.SetResult(ItemID.StoneBlock, 333);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 3);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 1);
            recipe.SetResult(ItemID.StoneBlock, 3);
            recipe.AddRecipe();

        }
       
    }
}
