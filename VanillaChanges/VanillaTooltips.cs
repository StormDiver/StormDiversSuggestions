using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.VanillaChanges
{
    public class VanillaTooltips : GlobalItem
    {

        //=====================================================TOOLTIPS==============================================================

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {
                if (item.type == ItemID.GladiatorHelmet)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense")
                        {
                            line.text = line.text + "\n3% increased ranged damage";
                        }

                    }
                if (item.type == ItemID.GladiatorBreastplate) /// Only for the item
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense") /// "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = line.text + "\n2% increased ranged damage and critical strike chance";
                        }

                    }
                if (item.type == ItemID.GladiatorLeggings) /// Only for the item
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense") /// "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = line.text + "\n3% increased ranged critical stirke chance\n10% increased movement speed";
                        }

                    }



                if (item.type == ItemID.NecroBreastplate)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "5% increased ranged damage and ranged critical strike chance";
                        }

                    }




                if (item.type == ItemID.FrostBreastplate)
                {
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "15% increased melee and ranged critical strike chance";
                        }

                    }

                }

                if (item.type == ItemID.FrostLeggings)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0") // "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = "5% increased melee and ranged damage";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1") // "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = "25% increased melee and movement speed";
                        }
                    }


                if (item.type == ItemID.FrostsparkBoots)
                {
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "26% increased movement speed";
                        }
                    }

                }


                if (item.type == ItemID.AncientBattleArmorShirt)
                {
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "8% increased magic critical strike chance\n8% increased minion damage\nIncreases maximum mana by 80";
                        }
                    }

                }

                if (item.type == ItemID.AncientBattleArmorPants)
                {
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "Increases your max number of minions by 2\n12% reduced mana usage";
                        }
                    }

                }



                if (item.type == ItemID.SolarFlareHelmet)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "25% increased melee critical strike chance";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases maximum health by 15\nEnemies are more likely to target you";
                        }
                    }
                if (item.type == ItemID.SolarFlareBreastplate)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "30% increased melee damage";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases maximum health by 20\nEnemies are more likely to target you";
                        }
                    }
                if (item.type == ItemID.SolarFlareLeggings)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "35% increased melee speed\n50% increased movement speed";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases maximum health by 15\nEnemies are more likely to target you";
                        }
                    }
                if (item.type == ItemID.VortexHelmet)
                    foreach (TooltipLine line in tooltips)
                    {


                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "7% increased ranged critical strike chance\nIncreased night vision";
                        }
                    }

                if (item.type == ItemID.VortexLeggings)
                    foreach (TooltipLine line in tooltips)
                    {


                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "50% increased movement speed";
                        }
                    }
                if (item.type == ItemID.ShroomiteLeggings)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "15% increased ranged critical strike chance";
                        }

                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "30% increased movement speed";
                        }
                    }
                if (item.type == ItemID.TurtleHelmet)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "6% increased melee damage and critical strike chance";
                        }

                    }
                if (item.type == ItemID.TurtleLeggings)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "4% increased melee damage and critical strike chance";
                        }

                    }

                if (item.type == ItemID.BeetleHelmet)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "12% increased melee damage";
                        }

                    }
                if (item.type == ItemID.BeetleLeggings)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "20% increased movement and melee speed";
                        }

                    }
                if (item.type == ItemID.ShadowHelmet)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "4% increased damage";
                        }

                    }
                if (item.type == ItemID.ShadowScalemail)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "4% increased damage";
                        }

                    }
                if (item.type == ItemID.ShadowGreaves)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "4% increased damage";
                        }

                    }
            }
        }



    }

}