using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class FlamingSeedLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Seed Launcher");
            Tooltip.SetDefault("Sets seeds ablaze\nObtain more from the Witch Doctor");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 18;
            item.useAnimation = 18;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            //item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.shoot = ProjectileID.Seed;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item64;

            item.damage = 20;
            //item.crit = 4;
            item.knockBack = 3f;
            item.shootSpeed = 13f;
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override void HoldItem(Player player)
        {
            
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (type == ProjectileID.Seed)
            {
                type = mod.ProjectileType("FlamingSeed");
                damage += (damage /3);
            }
      
            for (int i = 0; i < 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            }

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Blowgun, 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public class SeedShop : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.WitchDoctor:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("FlamingSeedLauncher")))
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.Seed);
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
    
}
 