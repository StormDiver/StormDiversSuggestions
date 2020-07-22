using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class BouncyArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouncy Arrow");
            Tooltip.SetDefault("Super bouncy");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 3);
            item.rare = 1;
            
            item.ranged = true;


            item.damage = 7;

            item.knockBack = 0f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("BouncyArrowProj");
            item.shootSpeed = 1f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 25);
            recipe.AddIngredient(ItemID.PinkGel, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
