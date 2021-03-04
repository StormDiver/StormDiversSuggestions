using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class DesertBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Bullet");
            Tooltip.SetDefault("Has a chance to spilt into two mid-flight");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.rare = 5;

            
            item.ranged = true;
            
           
            item.damage = 12;
            item.crit = 0;
            item.knockBack = 0f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("DesertBulletProj");
            item.shootSpeed = 5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.AddIngredient(mod.ItemType("DesertBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
 
    }
    //________________________________________________________________________
    public class DesertArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Arrow");
            Tooltip.SetDefault("Bounces twice, spins after bouncing");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 40;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.rare = 5;

            item.ranged = true;


            item.damage = 15;

            item.knockBack = 2f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("DesertArrowProj");
            item.shootSpeed = 3f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddIngredient(mod.ItemType("DesertBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
