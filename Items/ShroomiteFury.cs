using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class ShroomiteFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Fury");
            Tooltip.SetDefault("Shoots out multiple arrows in an even spread");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 65;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = ProjectileID.WoodenArrowFriendly;

            item.shootSpeed = 80f;
            
            item.useAmmo = AmmoID.Arrow;
                

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            float numberProjectiles = 3 + Main.rand.Next(2); 
            float rotation = MathHelper.ToRadians(10);
            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            /* int numberProjectiles = 3 + Main.rand.Next(1); //This defines how many projectiles to shot.
             for (int i = 0; i < numberProjectiles; i++)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // This defines the projectiles random spread . 10 degree spread.
                 Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
             }*/
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}