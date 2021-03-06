using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
   
    public class IronShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Shot");
            Tooltip.SetDefault("Heavy bullet that obeys gravity and has a strong knockback");
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 3);
            item.rare = ItemRarityID.White;


            item.ranged = true;


            item.damage = 6;

            item.knockBack = 5f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("IronShotProj");
            item.shootSpeed = 2.5f;
            item.ammo = AmmoID.Bullet;
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
    public class LeadShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Shot");
            Tooltip.SetDefault("Heavy bullet that obeys gravity and has a strong knockback");
        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 3);
            item.rare = ItemRarityID.White;


            item.ranged = true;


            item.damage = 7;

            item.knockBack = 5f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("LeadShotProj");
            item.shootSpeed = 3f;
            item.ammo = AmmoID.Bullet;
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddIngredient(ItemID.LeadBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
}
