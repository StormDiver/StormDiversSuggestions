using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DesertBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Fury");
            Tooltip.SetDefault("Makes all arrows rain down the heat of the Desert");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 45;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = mod.ProjectileType("DesertArrowProj");
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
            Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X), (int)(perturbedSpeed.Y), mod.ProjectileType("AridArrowProj"), damage, knockBack, player.whoAmI);
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
}