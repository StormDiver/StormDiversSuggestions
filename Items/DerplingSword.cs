using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class DerplingSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Derpling Sword"); 
			Tooltip.SetDefault("Sends out a bunch of Derpling heads every third swing");
		}

		public override void SetDefaults() 
		{
			item.damage = 65;
         
			item.melee = true;
			item.width = 40;
			item.height = 50;
			item.useTime = 11;
			item.useAnimation = 11;
			item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 4, 0, 0);
                     item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            //item.useTurn = true;
            item.knockBack = 6;
            item.shoot = mod.ProjectileType("DerpMeleeProj");
            item.shootSpeed = 8f;
        }
        int weaponattack = 3;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            weaponattack--;
            if (weaponattack <= 0)
            {
                int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 22);
                weaponattack = 3;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}