using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DestroyerFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Vaporiser");
            Tooltip.SetDefault("Right Click to throw an unchained ball");
        }

        public override void SetDefaults()
        {
   
            item.width = 30;
            item.height = 10;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 5;
            item.crit = 4;
            item.useAnimation = 20; 
            item.useTime = 20; 
            item.knockBack = 4f;
            item.damage = 65;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.melee = true;

        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 40;
                item.useAnimation = 40;
                item.shoot = mod.ProjectileType("DestroyerFlailProj2");
                item.shootSpeed = 9f;
                item.noUseGraphic = true;
                item.useStyle = 1;

            }
            else
            {
                item.useTime = 20;
                item.useAnimation = 20;
                item.shoot = mod.ProjectileType("DestroyerFlailProj");
                item.shootSpeed = 24f;
                item.melee = true;
                item.noMelee = true;
                
                item.channel = true;
                item.noUseGraphic = true;
                item.useStyle = 5;
            }
            return base.CanUseItem(player);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DaoofPow, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}