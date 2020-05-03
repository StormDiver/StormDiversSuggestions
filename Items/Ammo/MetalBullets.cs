using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Ammo
{
    public class TungstenBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tungsten Bullet");
            
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 15);
            item.rare = 0;

            
            item.ranged = true;
            

            item.damage = 10;
            
            item.knockBack = 1f;
            item.consumable = true;
            item.shoot = mod.ProjectileType("TungstenBulletProj");
            item.shootSpeed = 4.5f;
            item.ammo = AmmoID.Bullet;
        }

       

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddIngredient(ItemID.TungstenBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
    public class IronShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron shot");
            Tooltip.SetDefault("Heavy bullet that obeys gravity and has a strong knockback");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 15);
            item.rare = 0;


            item.ranged = true;


            item.damage = 6;

            item.knockBack = 4f;
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
            DisplayName.SetDefault("Lead shot");
            Tooltip.SetDefault("Heavy bullet that obeys gravity and has a strong knockback");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 15);
            item.rare = 0;


            item.ranged = true;


            item.damage = 7;

            item.knockBack = 3f;
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
