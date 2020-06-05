using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SpectreHose : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Hose");
            Tooltip.SetDefault("Rapidly fires mini Spectre skulls that speed up rapidly\nDeals more damage the faster the skulls travels");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 8;
            item.UseSound = SoundID.Item8;

            item.damage = 80;
          
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("SpectreGunProj");

            item.shootSpeed = 3f;
            
            //item.useAmmo = AmmoID.Arrow;
                

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
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}