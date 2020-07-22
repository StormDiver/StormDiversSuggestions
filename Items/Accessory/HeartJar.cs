using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.DataStructures;

using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
  
    public class HeartJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jar of hearts");
            Tooltip.SetDefault("While below 90% life, you have a chance to instantly kill non-boss enemies who are below 25% life, making them drop a heart\n'Heart Stealer'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;

            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            
            item.accessory = true;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= (player.statLifeMax2 * 0.9f))
            {
                /*player.allDamage += 0.08f;
                player.moveSpeed += 0.10f;
                player.meleeCrit += 6;
                player.rangedCrit += 6;
                player.magicCrit += 6;
                player.thrownCrit += 6;
                player.statDefense += 5;*/
                player.AddBuff(mod.BuffType("HeartBuff"), 1);
                
            }
           
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
            recipe.AddIngredient(ItemID.BandofRegeneration, 1);
            recipe.AddIngredient(ItemID.CrimtaneBar, 14);
           
 
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
            recipe.AddIngredient(ItemID.BandofRegeneration, 1);
            recipe.AddIngredient(ItemID.DemoniteBar, 14);
 
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}