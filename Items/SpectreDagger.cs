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
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 8;
            item.useStyle = 1;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useTurn = false;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.magic = true;

            item.UseSound = SoundID.Item1;

            item.damage = 85;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = mod.ProjectileType("SpectreDaggerProj");
            
            item.shootSpeed = 16f;

            item.mana = 5;
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
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}