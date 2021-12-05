using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class MeteorArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Arrow");
            Tooltip.SetDefault("Slightly attracted towards enemies");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 32;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = ItemRarityID.Blue;
            
            item.ranged = true;


            item.damage = 5;

            item.knockBack = 0f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("MeteorArrowProj");
            item.shootSpeed = 1f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddIngredient(ItemID.MeteoriteBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
