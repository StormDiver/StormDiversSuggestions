using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Tools
{
    public class SuperHeartPickup : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Heart");
            Tooltip.SetDefault("Heals 25 health when picked up");
        
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 1;
            item.rare = ItemRarityID.Orange;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            
        }
        public override bool GrabStyle(Player player)
        {
            return false;
        }
        public override void GrabRange(Player player, ref int grabRange)
        {
           
            if (player.HasBuff(BuffID.Heartreach))
            {
                grabRange = 400;
                
            }
            else
            {
                grabRange = 150;

            }
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override bool CanPickup(Player player)
        {
            return true;
        }
        public override bool OnPickup(Player player)
        {
            Main.PlaySound(SoundID.Grab, (int)player.position.X, (int)player.position.Y);

            player.statLife += 25;
            player.HealEffect(25, true);
            return false;
        }
       
        public override bool ItemSpace(Player player)
        {
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}