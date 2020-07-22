using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


/*namespace StormDiversSuggestions.Items.Ammo
{
    public class ShroomRocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Rockets");
            Tooltip.SetDefault("For use with the Shroomite Launcher");
            
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 16);
            item.rare = 8;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 50;
            item.crit = 4;
            item.knockBack = 1f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("ShroomRocketProj");
            item.shootSpeed = 5f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RocketI, 75);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 75);
            recipe.AddRecipe();
        }
        
    }
}
*/