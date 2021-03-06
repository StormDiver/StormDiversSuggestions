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
            DisplayName.SetDefault("Heart Emblem");
            Tooltip.SetDefault("Some enemies will drop a super heart when hit below half life\nEnemies that drop the heart lose life rapidly");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;

            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            
            item.accessory = true;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().heartSteal = true;

        }

         public class ModGlobalNPC : GlobalNPC
         {
             public override void NPCLoot(NPC npc)
             {
                if (NPC.downedBoss3)
                {
                    
                        if (Main.rand.Next(100) < 2)
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