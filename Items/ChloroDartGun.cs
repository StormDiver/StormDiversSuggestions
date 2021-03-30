using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class ChloroDartGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Dart Shotgun");
            Tooltip.SetDefault("Fires out a burst of darts");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useTurn = false;
            item.autoReuse = true;
        
            item.ranged = true;

            item.shoot = ProjectileID.Seed;
            item.useAmmo = AmmoID.Dart;
            //item.UseSound = SoundID.Item99;

            item.damage = 25;
            item.knockBack = 3f;
            item.shootSpeed = 13f;
            item.noMelee = true; 
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 3 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
            if (type == ProjectileID.IchorDart)
            {
                damage = (damage * 8 / 10);
                numberProjectiles = 3;
            }
            if (type == ProjectileID.CrystalDart)
            {
                damage = (damage / 8 * 10);
            }
           
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
            }
            Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 98, 1.5f, -0.4f);

            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        
    }
    
}
 