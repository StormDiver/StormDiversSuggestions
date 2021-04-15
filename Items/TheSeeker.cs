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
            Tooltip.SetDefault("Summons explosive bolts that can be guided towards the cursor when holding right click\nRequires Seeker Bolts, craft more with Souls of Sight");
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.shoot = mod.ProjectileType("SeekerBoltProj");
            item.useAmmo = ItemType<Ammo.SeekerBolt>();
            item.UseSound = SoundID.Item11;

            item.damage = 45;
            //item.crit = 0;
            item.knockBack = 6f;

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
            recipe.AddIngredient(ItemID.ExplosivePowder, 20);
            recipe.AddIngredient(ItemID.SoulofSight, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}