using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class LunaticHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Hood of Command");
            Tooltip.SetDefault("Summons 2 mini cultists minions that fly next to you and fire shadow fireballs at enemies");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 28;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.Red;

            item.accessory = true;
            item.expert = true;
        }


        //int skulltime = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
            player.GetModPlayer<StormPlayer>().lunaticHood = true;
           
           
        }
       //Drops from treasure bag

    }
}