using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class SolarSpin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blazing Star"); 
			Tooltip.SetDefault("Spins around with the force of a star");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }

		public override void SetDefaults() 
		{
			item.damage = 160;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 100;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.rare = 10;
			item.UseSound = SoundID.Item116;
			item.autoReuse = false;
           item.useTurn = true;
            item.channel = true;
            item.knockBack = 7f;
            item.shootSpeed = 1f;
            item.shoot = mod.ProjectileType("SolarSpinProj");
            
            item.noMelee = true; 
            item.noUseGraphic = true; 
            
        }
        public override bool UseItemFrame(Player player)     //this defines what frame the player use when this weapon is used
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}