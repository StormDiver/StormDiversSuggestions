using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DerplingStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Scepter");
            Tooltip.SetDefault("Summons Derpling heads that rain down upon your foes");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 7;
            item.useStyle = 5;
            item.useTime = 22;
            item.useAnimation = 22;  
            item.autoReuse = true;
           // item.UseSound = SoundID.Item43;
            item.magic = true;
            item.damage = 55;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item43;
            item.shoot = mod.ProjectileType("DerpMagicProj");
            item.shootSpeed = 15f;
            item.mana = 9;
            
            item.noMelee = true; //Does the weapon itself inflict damage?

           
        }
       

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
           // Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 44);

            return true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}