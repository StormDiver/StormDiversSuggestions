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
            DisplayName.SetDefault("Desert Bullet");
            Tooltip.SetDefault("Has a chance to spilt into 2-3 bullets mid-flight");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 2, 0);
            item.rare = 5;

            
            item.ranged = true;
            
           
            item.damage = 10;
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
}