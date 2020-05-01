using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class ShroomBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Bullet");
            Tooltip.SetDefault("Ricochets off walls and pierces enemies");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 80);
            item.rare = 8;

            
            item.ranged = true;
            

            item.damage = 15;
            item.crit = 6;
            item.knockBack = 2f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("ShroomBulletProj");
            item.shootSpeed = 2f;
            item.ammo = AmmoID.Bullet;
        }

        public override void OnConsumeAmmo(Player player)
        {
            if (Main.rand.NextBool(10))
            {
               
                
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.MusketBall, 150);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
    }
}
