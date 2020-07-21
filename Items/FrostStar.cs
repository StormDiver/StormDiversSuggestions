using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class FrostStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Frizbee");
            Tooltip.SetDefault("Bounces around after being thrown");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            
            item.damage = 45;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 28;
            item.useAnimation = 28;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 6;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("FrostStarProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
       
       
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(2, (int)position.X, (int)position.Y, 1);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}