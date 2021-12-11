using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class SantankDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Drill");
            Tooltip.SetDefault("'For use on those who have been naughty'");
        }

        public override void SetDefaults()
        {
            
            item.damage = 50;
            item.melee = true;
            item.width = 40;
            item.height = 22;

            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 9, 0, 0);
                     item.rare = ItemRarityID.Yellow;
            item.knockBack = 3f;
           
            item.useTurn = true;
            item.shoot = mod.ProjectileType("SantankDrillProj");
            item.shootSpeed = 40f;
            item.pick = 205;
            item.tileBoost = 0;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true; 
            item.channel = true; 
            item.autoReuse = true;
            
            
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class SantankSaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Chainsaw");
            Tooltip.SetDefault("'For use on those who have been naughty'");
        }

        public override void SetDefaults()
        {

            item.damage = 65;
            item.melee = true;
            item.width = 60;
            item.height = 20;
            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 9, 0, 0);
                     item.rare = ItemRarityID.Yellow;
            item.knockBack = 5f;
          
            item.useTurn = true;
            item.shoot = mod.ProjectileType("SantankSawProj");
            item.shootSpeed = 55f;
            item.axe = 27;
            item.tileBoost = 0;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
            
           
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class SantankJackham : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Jackhammer");
            Tooltip.SetDefault("'For use on those who have been naughty'");
        }

        public override void SetDefaults()
        {

            item.damage = 55;
            item.melee = true;
            item.width = 50;
            item.height = 20;
            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 9, 0, 0);
                     item.rare = ItemRarityID.Yellow;
            item.knockBack = 7f;

            item.useTurn = true;
            item.shoot = mod.ProjectileType("SantankJackhamProj");
            item.shootSpeed = 40f;
            item.hammer = 100;
            item.tileBoost = 0;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;

           
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}