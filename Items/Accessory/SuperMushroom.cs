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
            
            DisplayName.SetDefault("Enchanted Mushroom");
            Tooltip.SetDefault("Empowers you with more defense and increases damage dealt when losing health");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            /*foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "Defense")
                {
                    line.text = line.text + " and % increased damage";
                }

            }*/
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
            item.maxStack = 1;
            
        }
        //int dustchance;
        public override void UpdateEquip(Player player)
        {
            /*if (Main.rand.Next(dustchance) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }*/
        }
        public override void UpdateAccessory(Player player, bool hideVisual) //Maybe add buffs for the levels
        {
            
            if (player.statLife >= player.statLifeMax2 * .75f)
            {
                item.defense = 2;
                /*player.allDamage += 0.02f;
                dustchance = 16;*/
                player.ClearBuff(mod.BuffType("MushBuff2"));
                player.ClearBuff(mod.BuffType("MushBuff3"));
                player.ClearBuff(mod.BuffType("MushBuff4"));

                player.AddBuff(mod.BuffType("MushBuff1"), 2);

            }
            else if (player.statLife >= player.statLifeMax2 * .5f && player.statLife < player.statLifeMax2 * .75f)
            {
                item.defense = 5;

                player.ClearBuff(mod.BuffType("MushBuff1"));
                player.ClearBuff(mod.BuffType("MushBuff3"));
                player.ClearBuff(mod.BuffType("MushBuff4"));

                player.AddBuff(mod.BuffType("MushBuff2"), 2);
            }
            else if (player.statLife >= player.statLifeMax2 * .25f && player.statLife < player.statLifeMax2 * .5f)
            {
                item.defense = 10;

                player.ClearBuff(mod.BuffType("MushBuff1"));
                player.ClearBuff(mod.BuffType("MushBuff2"));
                player.ClearBuff(mod.BuffType("MushBuff4"));

                player.AddBuff(mod.BuffType("MushBuff3"), 3);

            }
            else 
            {
                item.defense = 16;

                player.ClearBuff(mod.BuffType("MushBuff1"));
                player.ClearBuff(mod.BuffType("MushBuff2"));
                player.ClearBuff(mod.BuffType("MushBuff3"));

                player.AddBuff(mod.BuffType("MushBuff4"), 2);

            }



        }
        

    }
}