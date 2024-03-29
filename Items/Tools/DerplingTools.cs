using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class DerplingDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Drill");
            Tooltip.SetDefault("'Drill through the ground'");
        }

        public override void SetDefaults()
        {
            
            item.damage = 40;
            item.melee = true;
            item.width = 40;
            item.height = 22;

            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.knockBack = 1f;
           
            item.useTurn = true;
            item.shoot = mod.ProjectileType("DerpDrillProj");
            item.shootSpeed = 30f;
            item.pick = 200;
            item.tileBoost = 1;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true; 
            item.channel = true; 
            item.autoReuse = true;
            
            
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class DerplingChainsaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Chainsaw");
            Tooltip.SetDefault("'Cut down the trees'");
        }

        public override void SetDefaults()
        {

            item.damage = 55;
            item.melee = true;
            item.width = 60;
            item.height = 20;
            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.knockBack = 4.6f;
          
            item.useTurn = true;
            item.shoot = mod.ProjectileType("DerpChainProj");
            item.shootSpeed = 40f;
            item.axe = 24;
            item.tileBoost = 1;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            
           
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class DerplingJackhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Jackhammer");
            Tooltip.SetDefault("'Smash down the walls'");
        }

        public override void SetDefaults()
        {

            item.damage = 50;
            item.melee = true;
            item.width = 50;
            item.height = 20;
            item.useTime = 6;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.knockBack = 5.2f;

            item.useTurn = true;
            item.shoot = mod.ProjectileType("DerpJackProj");
            item.shootSpeed = 35f;
            item.hammer = 100;
            item.tileBoost = 1;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;

           
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}