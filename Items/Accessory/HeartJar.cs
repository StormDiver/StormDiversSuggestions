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
            Tooltip.SetDefault("While below 70% life, you have a chance to make enemies below 25% life drop a heart whiling inflicting a debuff\nEnemies cannot drop more than one heart this way\n'Heart Stealer'");
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
            if (player.statLife <= (player.statLifeMax2 * 0.7f))
            {
                
                player.AddBuff(mod.BuffType("HeartBuff"), 1);
                
            }
           
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(mod.GetItem("CrackedHeart"), 3);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

       /* public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                
                    if (Main.expertMode && npc.lifeMax >= 250)
                    { 
                        if (Main.rand.Next(100) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeartJar"));
                        }
                    }
                    if (!Main.expertMode && npc.lifeMax >= 150)
                    {
                        if (Main.rand.Next(150) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeartJar"));
                        }
                    }
            }
        }*/
    }
}