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
            DisplayName.SetDefault("Jar of Hearts");
            Tooltip.SetDefault("When not at max health, enemies below 30% life have a one time chance to drop a heart when hit\nEnemies that drop a heart lose life rapidly\n'Heart Stealer'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 28;

            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            
            item.accessory = true;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife < (player.statLifeMax2))
            {
                
                player.AddBuff(mod.BuffType("JarBuff"), 1);
                
            }
           
        }

       /* public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ClayPot);
            recipe.AddIngredient(mod.GetItem("CrackedHeart"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

         public class ModGlobalNPC : GlobalNPC
         {
             public override void NPCLoot(NPC npc)
             {
                if (NPC.downedBoss3)
                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(50) == 0)
                        {
                            if (npc.type == NPCID.Demon)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeartJar"));
                            }
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(60) == 0)
                        {
                            if (npc.type == NPCID.Demon)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HeartJar"));
                            }
                        }
                    }
                }
             }
         }
    }
}