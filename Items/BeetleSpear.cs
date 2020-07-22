using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items
{
	public class BeetleSpear : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Beetle Lance"); 
			Tooltip.SetDefault("Summons beetles that attack and swarm your foes");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

		public override void SetDefaults() 
		{
			item.damage = 100;
            //item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("BeetleSpearProj");
            item.shootSpeed = 10f;
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
           /* projshoot++;
            if (projshoot >= 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("TurtleProj"), (int)(damage * 1.5), knockBack, player.whoAmI);
                Main.PlaySound(3, (int)player.Center.X, (int)player.Center.Y, 24);
                projshoot = 0;
            }*/
            return true;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("TurtleSpear"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}