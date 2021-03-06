﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class DualArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dual Arrow");
            Tooltip.SetDefault("Two arrows tied together, has a chance to spilt in midair");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.rare = ItemRarityID.Blue;
            
            item.ranged = true;


            item.damage = 6;

            item.knockBack = 2.5f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("DualArrowProj");
            item.shootSpeed = 1f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 50);
            recipe.AddIngredient(ItemID.Rope, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
