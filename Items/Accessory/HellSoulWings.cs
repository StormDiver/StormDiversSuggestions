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
    public class HellSoulWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellSoul Wings");
            Tooltip.SetDefault("Allows flight and slow fall\nHold UP to ascend faster");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
 
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;

            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.accessory = true;
            
        }
    
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 160;
            if (player.controlUp && player.controlJump && player.wingTime > 0)
            {

                if (Main.rand.Next(10) == 0)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                    dust.scale = 2f;
                }

            }
            


        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        { 
            if (player.controlUp)
            {
                ascentWhenRising = 0.25f;
                maxAscentMultiplier = 2.5f;

            }
            else
            {
                ascentWhenRising = 0.15f;
                maxAscentMultiplier = 1.75f;
            
            }
            ascentWhenFalling = 1f;
                maxCanAscendMultiplier = 1f;
                constantAscend = 0.15f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 8;
            acceleration *= 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 12);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulWings_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}