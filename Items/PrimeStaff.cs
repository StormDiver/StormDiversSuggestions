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
            Tooltip.SetDefault("Fires out spinning skulls that will latch onto any enemy they touch");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 52;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
       
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
         
            item.magic = true;
        

            item.damage = 40;
            item.knockBack = 4f;

            item.useTime = 28;
            item.useAnimation = 28;
            item.mana = 12;
            item.shoot = mod.ProjectileType("SkullSeek");
            item.shootSpeed = 16f;
   
            item.useStyle = ItemUseStyleID.HoldingOut;

            item.noMelee = true; 

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
          
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
            
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:RDStaffs");
           
            recipe.AddIngredient(ItemID.CrystalShard, 20);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            
        }
    }
}