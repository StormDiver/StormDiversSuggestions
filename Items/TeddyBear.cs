using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items
{
    public class TeddyBear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Teddy Bear");
            Tooltip.SetDefault("Hug the bear to regenerate life\n'Full of love'");

        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 38;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 0;
            item.useStyle = 5;
            item.useTime = 120;
            item.useAnimation = 120;
            item.useTurn = true;
            item.autoReuse = true;
            item.holdStyle = 0;
            item.noMelee = true; 
        }

        public override void HoldItem(Player player)
        {
            //item.holdStyle = 1;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
        public override bool UseItem(Player player)
        {
            //player.AddBuff(BuffID.Regeneration, 300);
            //player.AddBuff(BuffID.Lovestruck, 300);
            if (player.GetModPlayer<StormPlayer>().bearcool == 0)
            {
                player.AddBuff(mod.BuffType("TeddyBuff"), 600);
                player.GetModPlayer<StormPlayer>().bearcool = 1200;
            }
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Cobweb, 45);
            recipe.AddIngredient(ItemID.BlackThread, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
}