using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
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

namespace StormDiversSuggestions.Items.Accessory
{

    [AutoloadEquip(EquipType.Wings)]
    public class SpaceRockWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Wings");
            Tooltip.SetDefault("Allows flight and slow fall\nHas a fast horizontal acceleration");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
 
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;

            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
           
            item.accessory = true;
            
        }
    
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 210;
        
            /*if (player.controlDown && player.controlJump && player.wingTime > 0)
            { 
                if (Main.rand.Next(4) == 0)     //this defines how many dust to spawn
                {
                    player.wingTime += 1;
                }
            }*/

        }
       
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        { 
                ascentWhenFalling = 2f;
                ascentWhenRising = 0.3f;
                maxCanAscendMultiplier = 1f;
                maxAscentMultiplier = 2f;
                constantAscend = 0.15f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 9;
                acceleration *= 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 18);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}