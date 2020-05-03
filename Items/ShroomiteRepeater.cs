using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class ShroomiteRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Repeater");
            Tooltip.SetDefault("Rapidly fires arrows");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 50;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            //item.shoot = ProjectileID.GrenadeI;
            item.shootSpeed = 14f;

            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}