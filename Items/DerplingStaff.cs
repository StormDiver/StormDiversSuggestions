using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DerplingStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Scepter");
            Tooltip.SetDefault("Rapidly fires out mini derpling heads\nHas a small chance to fire out a slow moving head that explodes into smaller heads");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 4, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 8;
            item.useAnimation = 8;  
            item.autoReuse = true;
           // item.UseSound = SoundID.Item43;
            item.magic = true;
            item.damage = 44;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item13;
            item.shoot = mod.ProjectileType("DerpMagicProj2");
            item.shootSpeed = 16f;
            item.mana = 4;
            
            item.noMelee = true; //Does the weapon itself inflict damage?

        }
       

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int choice = Main.rand.Next(10);
            if (choice == 0)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * .6f), (float)(perturbedSpeed.Y * .6f), mod.ProjectileType("DerpMagicProj"), (int)(damage * 1.5f), knockBack, player.whoAmI);
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 20);

                }
            }
            else
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("DerpMagicProj2"), damage, knockBack, player.whoAmI);

                }
            }
            return false;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}