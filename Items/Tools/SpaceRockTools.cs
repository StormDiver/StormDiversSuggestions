using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class SpaceRockDrillSaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid DrillSaw");
            Tooltip.SetDefault("'Not to be confused with the SawDrill'");
        }

        public override void SetDefaults()
        {
            
            item.damage = 60;
            item.melee = true;
            item.width = 40;
            item.height = 22;

            item.useTime = 4;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 10, 0, 0);
                     item.rare = ItemRarityID.Cyan;
            item.knockBack = 1.5f;
       
            item.useTurn = true;
            item.shoot = mod.ProjectileType("SpaceRockDrillSawProj");
            item.shootSpeed = 45f;
            item.pick = 210;
            item.axe = 30;
            item.tileBoost = 3;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true; 
            item.channel = true; 
            item.autoReuse = true;
            
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
   
    public class SpaceRockJackhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Jackhammer");
            Tooltip.SetDefault("'Great for smashing down walls'");
        }

        public override void SetDefaults()
        {

            item.damage = 60;
            item.melee = true;
            item.width = 50;
            item.height = 20;
            item.useTime = 5;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.knockBack = 6f;

            item.useTurn = true;
            item.shoot = mod.ProjectileType("SpaceRockJackhammerProj");
            item.shootSpeed = 35f;
            item.hammer = 100;
            item.tileBoost = 3;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}