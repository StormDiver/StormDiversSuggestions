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
    //[AutoloadEquip(EquipType.Shoes)]
    public class ShroomAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Launcher Attachment");
            Tooltip.SetDefault("Makes all ranged weapons fire off exploding projectiles\n8% increased ranged critical strike chance");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
           
            Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
            item.defense = 5;
            item.accessory = true;
            
        }
        int shotCount = 0;
        bool shot;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {


            player.rangedCrit += 8;

            if (player.itemTime > 1 && player.HeldItem.ranged) //ranged item is in use
                {

                    if (!shot)
                    {
                        shotCount++;
                        if (shotCount >= 4)
                        {
                            shotCount = 0;
                            float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in
                            float velocity = 15f;
                            int type = mod.ProjectileType("ShroomSetRocketProj");
                            int damage = (int)(player.HeldItem.damage * 3f);
                            Projectile.NewProjectile(player.Center, new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * velocity, type, damage, 2f, player.whoAmI);
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 92);
                        }

                    }
                    shot = true;
                }
                else
                {
                    shot = false;
                }

            

        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 18);
            recipe.AddIngredient(ItemID.RocketI, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}