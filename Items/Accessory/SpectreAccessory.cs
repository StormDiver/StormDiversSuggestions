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

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class SpectreAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Skull");
            Tooltip.SetDefault("Mana usage is almost negated when under the effects of mana sickness\nIncreases maximum mana by 60");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
           
            Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
            
            item.accessory = true;
            
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 60;
            if (Main.LocalPlayer.HasBuff(BuffID.ManaSickness))
            {
                
                player.manaCost *= 0.2f;
                
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = Main.LocalPlayer.position;
                    dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 15, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;



            }

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddIngredient(ItemID.SuperManaPotion, 30);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}