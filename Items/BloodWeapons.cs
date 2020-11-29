using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class BloodSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Blade"); 
			Tooltip.SetDefault("Shoots out a trail of blood every other swing");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 42;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
            //item.useTurn = true;
            item.knockBack = 3;
            //item.shoot = mod.ProjectileType("BloodSwordProj");
            item.shoot = mod.ProjectileType("BloodSwordProj");

            item.shootSpeed = 7f;
        }
        int weaponattack = 2;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            weaponattack--;
            if (weaponattack <= 0)
            {
    
                
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);
                weaponattack = 2;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
           
        }

    }
    //____________________________________________________________________________
    public class BloodSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Capillary Trident");
            Tooltip.SetDefault("Great for stabbing in a hurry");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
    
        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 0;
            item.melee = true;
            item.width = 50;
            item.height = 64;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = false;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BloodSpearProj");
            item.shootSpeed = 6f;
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
           


                /*{
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1.7f), (float)(perturbedSpeed.Y * 1.7f), mod.ProjectileType("BloodSwordProj"), (int)(damage * 1f), knockBack, player.whoAmI);
                }*/
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);
                
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
    public class BloodBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Jugular");
            Tooltip.SetDefault("3 can be thrown out at a time");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.crit = 0;
            item.melee = true;
            item.width = 20;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = false;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BloodBoomerangProj");
            item.shootSpeed = 8f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;

        }
        /*
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1.7f), (float)(perturbedSpeed.Y * 1.7f), mod.ProjectileType("BloodSwordProj"), (int)(damage * 1f), knockBack, player.whoAmI);
            }
            Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);

            return true;
        }
        */
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
}