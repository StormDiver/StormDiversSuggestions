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
			item.damage = 20;
            
			item.melee = true;
			item.width = 35;
			item.height = 42;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            //item.useTurn = true;
            item.knockBack = 4;
            item.scale = 1.15f;
            //item.shoot = mod.ProjectileType("BloodSwordProj");
            item.shoot = mod.ProjectileType("BloodSwordProj");

            item.shootSpeed = 8f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 2)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
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
                Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 9);
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
            DisplayName.SetDefault("Heart Piercer");
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
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
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
           
            
                Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 9);
                
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
    
    //____________________________________
    public class BloodYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Heart Attack");
            Tooltip.SetDefault("Leaves behind a trail of damaging blood");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 25;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            //item.crit = 0;
            item.melee = true;
            item.width = 20;
            item.height = 26;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.channel = true;
            item.useTurn = true;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BloodYoyoProj");
            // item.shootSpeed = 9f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
    
    

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
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
}