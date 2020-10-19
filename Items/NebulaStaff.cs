using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class NebulaStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Storm");
            Tooltip.SetDefault("Summons Explosive nebula flame blasts");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 15;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.useStyle = 5;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 12;
            item.UseSound = SoundID.Item20;

            item.damage = 70;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("NebulaStaffProj");

            item.shootSpeed = 8f;
            
            //item.useAmmo = AmmoID.Arrow;
                

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
       /* public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            /*int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }*/
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}