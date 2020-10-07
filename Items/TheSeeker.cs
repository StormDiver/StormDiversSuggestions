using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class TheSeeker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Seeker");
            Tooltip.SetDefault("Fires out miniature eyes that seek out nearby enemies\nRequires Seeker Bolts");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.shoot = mod.ProjectileType("SeekerBoltProj");
            item.useAmmo = ItemType<Ammo.SeekerBolt>();
            item.UseSound = SoundID.Item11;

            item.damage = 46;
            //item.crit = 0;
            item.knockBack = 2f;

            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.ExplosivePowder, 20);
            recipe.AddIngredient(ItemID.SoulofSight, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}