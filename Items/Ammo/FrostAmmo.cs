using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class FrostBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Bullet");
            Tooltip.SetDefault("Can pierce through walls, but scatters when doing so");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.rare = ItemRarityID.Pink;

            
            item.ranged = true;
            
           
            item.damage = 10;
            item.crit = 0;
            item.knockBack = 0f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("FrostBulletProj");
            item.shootSpeed = 5f;
            item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 100);
            recipe.AddIngredient(mod.ItemType("IceBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }

        
    }
    //________________________________________________________________________
    public class FrostArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Arrow");
            Tooltip.SetDefault("Explodes into tiny shards on impact");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 44;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.rare = ItemRarityID.Pink;

      
            item.ranged = true;
        

            item.damage = 15;
     
            item.knockBack = 2f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("FrostArrowProj");
            item.shootSpeed = 3f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddIngredient(mod.ItemType("IceBar"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
