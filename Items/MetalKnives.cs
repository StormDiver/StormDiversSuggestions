using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SilverKnive : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Throwing Knife");
            Tooltip.SetDefault("Ricochets off tiles");

        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.thrown = true;
            item.width = 10;
            item.height = 10;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 14;
            item.useAnimation = 14;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 0, 0, 15);
            item.rare = ItemRarityID.White;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("SilverKniveProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
        }


    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.ThrowingKnife, 100);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
    public class TungstenBullet : ModItem //Actually Throwing knives
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Throwing Knife");
            Tooltip.SetDefault("Ricochets off tiles");

        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.thrown = true;
            item.width = 10;
            item.height = 10;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 14;
            item.useAnimation = 14;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(0, 0, 0, 15);
            item.rare = ItemRarityID.White;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("TungstenKniveProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(ItemID.ThrowingKnife, 100);
            recipe.AddIngredient(ItemID.TungstenBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
   
}
