using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SawBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Shredder");
            Tooltip.SetDefault("Shreds any enemy that it comes into contact with\nEmits sparks that linger on the ground");
        }

        public override void SetDefaults()
        {
             item.damage = 55;
            item.crit = 10;
            item.melee = true;
            item.width = 60;
            item.height = 26;
            item.useTime = 10;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.knockBack = 1.5f;
           
            item.useTurn = true;
            item.shoot = mod.ProjectileType("SawBladeChain");
            item.shootSpeed = 50f;
            item.axe = 30;
            item.tileBoost = 2;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true; 
            item.channel = true; 
            item.autoReuse = true;
           
            
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SawtoothShark, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddIngredient(ItemID.Chain, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}