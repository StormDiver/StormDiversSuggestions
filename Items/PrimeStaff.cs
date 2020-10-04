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
            Tooltip.SetDefault("Fires out spinning skulls that bounce and pierce\nHas a chance to fire faster more damaging skulls");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            
            
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            //item.melee = true;
            //item.ranged = true;
            item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 50;
            //item.crit = 4;
            item.knockBack = 4f;

            item.useTime = 18;
            item.useAnimation = 18;
            item.mana = 7;
            item.shoot = mod.ProjectileType("SkullSeek");
            item.shootSpeed = 14f;
   
            item.useStyle = 5;


            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
            //item.noUseGraphic = true; //When uses no graphic is shown
            //item.channel = true; //Speical conditons when held down
           
        }
      
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (Main.rand.Next(3) == 0)
            {//This defines how many projectiles to shot.
               
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 1.5f, perturbedSpeed.Y *1.5f, type, (int)(damage * 1.5f), knockBack, player.whoAmI);
                Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 60);

            }
            else
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
            
            
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