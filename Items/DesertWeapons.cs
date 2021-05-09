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
			Tooltip.SetDefault("Unleash the power of the ancient sands");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

		public override void SetDefaults() 
		{
			item.damage = 30;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 50;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
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
    //_______________________________________________________________________________________________
    public class DesertBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Fury");
            Tooltip.SetDefault("Converts all arrows to ancient arrows that rain down the heat of the Desert");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 34;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item5;
            item.damage = 45;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = mod.ProjectileType("AncientArrowProj");
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X), (float)(perturbedSpeed.Y), mod.ProjectileType("AncientArrowProj"), damage, knockBack, player.whoAmI);
            /* if (type == ProjectileID.WoodenArrowFriendly || type == ProjectileID.FlamingArrow) 
             {
                 type = mod.ProjectileType("DesertArrowProj");
             }*/

            return false;
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
    //_______________________________________________________________________________________________
    public class DesertSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SandStorm");
            Tooltip.SetDefault("Summons Burning sand");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 12;
            item.UseSound = SoundID.Item20;

            item.damage = 32;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("DesertSpellProj");

            item.shootSpeed = 3f;

            //item.useAmmo = AmmoID.Arrow;
            item.scale = 0.9f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
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

    //_______________________________________________________________________________________________
    public class DesertStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Staff");
            Tooltip.SetDefault("Summons a floating Ancient Sentry that blasts sand in all directions");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            //Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.summon = true;
            item.sentry = true;
            item.mana = 10;
            item.UseSound = SoundID.Item78;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("DesertStaffProj");

            //item.shootSpeed = 3.5f;



            item.noMelee = true;
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = Main.MouseWorld;

            /* for (int l = 0; l < Main.projectile.Length; l++)
              {                                                                  //this make so you can only spawn one of this projectile at the time,
                  Projectile proj = Main.projectile[l];
                  if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                  {
                      proj.active = false;
                  }
              }*/

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