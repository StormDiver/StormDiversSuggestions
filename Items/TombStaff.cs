using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class TombStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tombstone Staff");
            Tooltip.SetDefault("Fires out magical tombstones that bounce around\nTombstones spawn a miniature ghost upon hitting an enemy");
            Item.staff[item.type] = true;


        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 34;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 2;
            item.useStyle = 5;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 10;
            item.UseSound = SoundID.Item8;

            item.damage = 30;
         
            item.knockBack = 10f;

            item.shoot = mod.ProjectileType("TombProj");

            item.shootSpeed = 16f;
   
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            
            {
                

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), type, (int)(damage * 1f), knockBack, player.whoAmI);

                
            }
           
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Tombstone, 5);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 20);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
       
    }
    //_____________________________________________________________________________________________________________________________
   
}