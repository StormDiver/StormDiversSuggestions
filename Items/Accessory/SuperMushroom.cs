using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using System.Collections.Generic;


namespace StormDiversSuggestions.Items.Accessory
{
    public class SuperMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Enchanced Mushroom");
            Tooltip.SetDefault("Empowers you with more defense and increases damage dealt when losing health");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "Defense")
                {
                    line.text = line.text + " and increased damage percentage";
                }

            }
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override void SetDefaults()
        {
       
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            
            item.accessory = true;
            
            
        }
        int dustchance;
        public override void UpdateEquip(Player player)
        {
            if (Main.rand.Next(dustchance) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
            if (player.statLife >= player.statLifeMax2 * .75f)
            {
                item.defense = 4;
                player.allDamage += 0.04f;
                dustchance = 16;
            }
            else if (player.statLife >= player.statLifeMax2 * .5f && player.statLife < player.statLifeMax2 * .75f)
            {
                item.defense = 6;
                player.allDamage += 0.06f;
                dustchance = 8;
            }
            else if (player.statLife >= player.statLifeMax2 * .25f && player.statLife < player.statLifeMax2 * .5f)
            {
                item.defense = 10;
                player.allDamage += 0.10f;
                dustchance = 4;
            }
            else 
            {
                item.defense = 15;
                player.allDamage += 0.15f;
                dustchance = 2;
            }
            
        

        }
        

    }
}