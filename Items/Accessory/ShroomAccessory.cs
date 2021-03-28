using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using StormDiversSuggestions.Basefiles;

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
    //[AutoloadEquip(EquipType.Shoes)]
    public class ShroomAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Launcher Attachment");
            Tooltip.SetDefault("Makes all guns fire out rockets");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Yellow;

             item.accessory = true;
            
        }
      
        public override void UpdateAccessory(Player player, bool hideVisual)
        {


            player.GetModPlayer<StormPlayer>().shroomaccess = true;



        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe.AddIngredient(ItemID.RocketI, 250);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}