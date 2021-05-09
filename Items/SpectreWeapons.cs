using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items
{
    public class SpectreDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Dagger");
            Tooltip.SetDefault("Summons magical controllable daggers\nMaximum of 5 can be controlled at any time");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.useTime = 12;
            item.useAnimation = 12;
            item.useTurn = false;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.magic = true;

            item.UseSound = SoundID.Item1;

            item.damage = 42;
            //item.crit = 4;
            item.knockBack = 2f;

            item.shoot = mod.ProjectileType("SpectreDaggerProj");
            
            item.shootSpeed = 16f;

            item.mana = 8;
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override void HoldItem(Player player)
        {
            
        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 5;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //________________________________________________________________
    public class SpectreHose : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Scepter");
            Tooltip.SetDefault("Rapidly fires mini Spectre skulls that speed up rapidly\nDeals more damage the faster the skulls travels");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 7;
            item.UseSound = SoundID.Item8;

            item.damage = 80;

            item.knockBack = 3f;

            item.shoot = mod.ProjectileType("SpectreHoseProj");

            item.shootSpeed = 6f;



            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //________________________________________________________________
    public class SpectreStaff2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orbiter");
            Tooltip.SetDefault("Summons spectre orbs that orbit around you at varying distances\nRight click to launch any orbs at their maximum orbital distance towards the cursor");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.autoReuse = true;
            item.UseSound = SoundID.Item43;

            item.magic = true;

            item.damage = 50;

            item.knockBack = 0f;

            item.useTime = 14;
            item.useAnimation = 14;
            //item.reuseDelay = 20;
            item.shoot = mod.ProjectileType("SpectreStaffSpinProj");
            item.shootSpeed = 4.5f;
            item.mana = 8;



            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
                                 //item.noUseGraphic = true; //When uses no graphic is shown
                                 //item.channel = true; //Speical conditons when held down

        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 10;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
            //Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SpectreStaffSpinProj2"), (int)(damage * 1f), knockBack, player.whoAmI);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
}