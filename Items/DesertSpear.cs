using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class DesertSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ancient Pike"); 
			Tooltip.SetDefault("Unleash the power of the sand");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

		public override void SetDefaults() 
		{
			item.damage = 30;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("DesertSpearProj");
            item.shootSpeed = 5f;
            item.noMelee = true; 
            item.noUseGraphic = true; 
            
        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.5f), (float)(perturbedSpeed.Y * 0.5f), mod.ProjectileType("DesertSpearTipProj"), (int)(damage * 1.5), knockBack, player.whoAmI);

            return true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("DesertBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}