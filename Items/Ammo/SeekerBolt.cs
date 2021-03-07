using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class SeekerBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seeker Bolts");
            Tooltip.SetDefault("For use with The Seeker");
            
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = ItemRarityID.Pink;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 15;
            //item.crit = 4;
            item.knockBack = 1f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("SeekerBoltProj");
            item.shootSpeed = 5f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 333);
            recipe.AddRecipe();
        }
       
    }
}
