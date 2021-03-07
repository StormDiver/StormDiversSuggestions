using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class ShroomArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Arrow");
            Tooltip.SetDefault("Can pierce once\nLeaves behind a trail of damaging mushrooms");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 36;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 16);
            item.rare = ItemRarityID.Yellow;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 20;
            item.crit = 6;
            item.knockBack = 2f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("ShroomArrowProj");
            item.shootSpeed = 6f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.WoodenArrow, 150);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}
