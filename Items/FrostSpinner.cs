using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class FrostSpinner : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blizzard Baton"); 
			Tooltip.SetDefault("Spins with the power of a small blizzard");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

		public override void SetDefaults() 
		{
			item.damage = 38;
            
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 100;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item7;
			item.autoReuse = false;
            item.useTurn = true;
            item.channel = true;
            item.knockBack = 3f;
            item.shoot = mod.ProjectileType("FrostSpinProj");
            item.shootSpeed = 1f;
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
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}