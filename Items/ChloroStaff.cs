using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class ChloroStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Scepter");
            Tooltip.SetDefault("Fires out a stream of damaging spore dust");
            Item.staff[item.type] = true;
        
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 6;
            item.UseSound = SoundID.Item13;

            item.damage = 38;
          
            item.knockBack = 3f;

            item.shoot = mod.ProjectileType("ChloroStaffProj");
            
            item.shootSpeed = 10f;
            
    

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
           
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            
            
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