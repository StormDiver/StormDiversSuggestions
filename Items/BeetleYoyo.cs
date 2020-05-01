using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items
{
	public class BeetleYoyo : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Thorax"); 
			Tooltip.SetDefault("Summons beetles to attack your foes");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 30;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

		public override void SetDefaults() 
		{
			item.damage = 100;
            //item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.rare = 8;
			item.UseSound = SoundID.Item1;
            item.channel = true;
            item.useTurn = true;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BeetleYoyoProj");
           // item.shootSpeed = 9f;
            item.noMelee = true; 
            item.noUseGraphic = true; 
            
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
            recipe.AddIngredient(mod.GetItem("TurtleYoyo"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}