using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SpectreDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Dagger");
            Tooltip.SetDefault("Rapidly throws daggers that bounce through enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 1;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useTurn = false;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.magic = true;

            item.UseSound = SoundID.Item1;

            item.damage = 100;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = mod.ProjectileType("SpectreDaggerProj");
            
            item.shootSpeed = 15f;

            item.mana = 9;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}