using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.NPCs;

namespace StormDiversSuggestions.Items.Tools
{
    public class EnemySummonerTemplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner");
            Tooltip.SetDefault("Summons Something");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useTurn = false;
            item.autoReuse = false;
            item.consumable = true;
           
            item.noMelee = true; 
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool CanUseItem(Player player)
        {
            //return NPC.downedMoonlord && player.ZoneSkyHeight && !NPC.AnyNPCs(ModContent.NPCType<NPCs.MoonDerp>());
            return true;
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, (int)player.position.X, (int)player.position.Y, 0);


            //Main.NewText("The Storm God has awoken!", 175, 75, 255);
            //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.MoonDerp>());
            return true;
        }
       

      
    }
}