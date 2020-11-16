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
			DisplayName.SetDefault("Blood Blade"); 
			Tooltip.SetDefault("Shoots out a trail of blood every other swing");
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
            item.crit = 0;
			item.melee = true;
			item.width = 40;
			item.height = 40;
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
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
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
            DisplayName.SetDefault("Bloody Trident");
            Tooltip.SetDefault("Shoots out a trail of blood every stab");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
    
        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 30;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = false;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BloodSpearProj");
            item.shootSpeed = 3.3f;
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
           


                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 1.7f), (int)(perturbedSpeed.Y * 1.7f), mod.ProjectileType("BloodSwordProj"), (int)(damage * 1f), knockBack, player.whoAmI);
                }
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);
                
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
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
            DisplayName.SetDefault("Blooderang");
            Tooltip.SetDefault("Can throw 3 out at once");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 30;
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
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 1.7f), (int)(perturbedSpeed.Y * 1.7f), mod.ProjectileType("BloodSwordProj"), (int)(damage * 1f), knockBack, player.whoAmI);
            }
            Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);

            return true;
        }
        */
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}