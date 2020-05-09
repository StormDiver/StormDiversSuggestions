using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class PrimeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prime Staff");
            Tooltip.SetDefault("Fires out bouncing piercing skulls\nRight click to summon a spinning spike ball");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 20, 00, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            //item.melee = true;
            //item.ranged = true;
            item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 4f;

            


            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
            //item.noUseGraphic = true; //When uses no graphic is shown
            //item.channel = true; //Speical conditons when held down
           
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 40;
                item.useAnimation = 40;
                item.shoot = mod.ProjectileType("Primeheadspin");
                item.shootSpeed = 4.5f;
                item.mana = 40;
                item.useStyle = 1;
                return player.ownedProjectileCounts[item.shoot] < 1;
            }
            else
            {
                item.useTime = 20;
                item.useAnimation = 20;
                item.mana = 12;
                item.shoot = mod.ProjectileType("SkullSeek");
                item.shootSpeed = 10f;
                item.magic = true;
                item.noMelee = true;
                item.useStyle = 5;


            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                return true;
            }
            else
            {
                int numberProjectiles = 1 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
                return false;
            }
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RubyStaff, 1);
            recipe.AddIngredient(ItemID.CrystalShard, 20);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DiamondStaff, 1);
            recipe.AddIngredient(ItemID.CrystalShard, 20);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}