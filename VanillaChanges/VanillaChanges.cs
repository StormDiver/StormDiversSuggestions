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
    public class VanillaChanges : GlobalItem
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
                            line.text = line.text + "\n5% increased ranged damage";
                        }

                    }
                if (item.type == ItemID.GladiatorBreastplate) /// Only for the item
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense") /// "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = line.text + "\n5% increased ranged critical strike chance";
                        }

                    }
                if (item.type == ItemID.GladiatorLeggings) /// Only for the item
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Defense") /// "Tooltip0" is the first line it has. If you want to take out the second, you use "Tooltip1" and so on.  
                        {
                            line.text = line.text + "\n10% increased movement speed";
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
                            line.text = "20% increased movement and melee speed";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "20% chance not to consume ammo";
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
                            line.text = "30% increased melee critical strike chance";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases maximum health by 30\nEnemies are more likely to target you";
                        }
                    }
                if (item.type == ItemID.SolarFlareBreastplate)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "35% increased melee damage";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increases maximum health by 40\nEnemies are more likely to target you";
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
                            line.text = "Increases maximum health by 30\nEnemies are more likely to target you";
                        }
                    }
                if (item.type == ItemID.VortexHelmet)
                    foreach (TooltipLine line in tooltips)
                    {

                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "16% increased ranged damage and critical strike chance";
                        }
                        if (line.mod == "Terraria" && line.Name == "Tooltip1")
                        {
                            line.text = "Increased night vision";
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



                if (item.type == ItemID.ShroomiteHeadgear)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "15% increased ranged damage";
                        }

                    }
                if (item.type == ItemID.ShroomiteHelmet)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "15% increased ranged damage";
                        }

                    }
                if (item.type == ItemID.ShroomiteMask)
                    foreach (TooltipLine line in tooltips)
                    {
                        if (line.mod == "Terraria" && line.Name == "Tooltip0")
                        {
                            line.text = "15% increased ranged damage";
                        }

                    }
            }
        }



        //==============================================DEFENSE====================================================




        public override void SetDefaults(Item item)
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {

                if (item.type == ItemID.CopperHelmet)
                {
                    item.defense = 2;


                }
                if (item.type == ItemID.CopperChainmail)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.CopperGreaves)
                {
                    item.defense = 3;

                }
                //
                if (item.type == ItemID.TinHelmet)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.TinChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.TinGreaves)
                {
                    item.defense = 3;

                }
                //
                if (item.type == ItemID.IronHelmet)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.IronChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.IronGreaves)
                {
                    item.defense = 4;

                }
                //
                if (item.type == ItemID.LeadHelmet)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.LeadChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.LeadGreaves)
                {
                    item.defense = 4;

                }
                //
                if (item.type == ItemID.SilverHelmet)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.SilverChainmail)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.SilverGreaves)
                {
                    item.defense = 5;

                }
                //
                if (item.type == ItemID.TungstenHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.TungstenChainmail)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.TungstenGreaves)
                {
                    item.defense = 5;

                }
                //
                if (item.type == ItemID.GoldHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.GoldChainmail)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.GoldGreaves)
                {
                    item.defense = 6;

                }
                //
                if (item.type == ItemID.PlatinumHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.PlatinumChainmail)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.PlatinumGreaves)
                {
                    item.defense = 6;

                }


                if (item.type == ItemID.NecroHelmet)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.NecroBreastplate)
                {
                    item.defense = 7;

                }
                if (item.type == ItemID.NecroGreaves)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.FrozenTurtleShell)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.RainHat)
                {
                    item.defense = 2;
                }
                if (item.type == ItemID.RainCoat)
                {
                    item.defense = 3;
                }
                if (item.type == ItemID.EskimoHood)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.EskimoPants)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.EskimoPants)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.PinkEskimoHood)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.PinkEskimoCoat)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.PinkEskimoPants)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.GladiatorHelmet)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.GladiatorBreastplate)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.GladiatorLeggings)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.ObsidianHelm)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.ObsidianShirt)
                {
                    item.defense = 6;
                }
                if (item.type == ItemID.ObsidianPants)
                {
                    item.defense = 5;
                }

                if (item.type == ItemID.FrostLeggings)
                {
                    item.defense = 15;
                }
                if (item.type == ItemID.AncientBattleArmorHat)
                {
                    item.defense = 8;
                }
                if (item.type == ItemID.AncientBattleArmorPants)
                {
                    item.defense = 10;
                }
                if (item.type == ItemID.CobaltLeggings)
                {
                    item.defense = 10;
                }
                if (item.type == ItemID.CobaltBreastplate)
                {
                    item.defense = 12;
                }
                if (item.type == ItemID.CobaltHat)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.CobaltMask)
                {
                    item.defense = 6;
                }
                if (item.type == ItemID.CobaltHelmet)
                {
                    item.defense = 15;
                }
                if (item.type == ItemID.MythrilGreaves)
                {
                    item.defense = 12;
                }
                if (item.type == ItemID.MythrilChainmail)
                {
                    item.defense = 15;
                }
                if (item.type == ItemID.MythrilHood)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.MythrilHat)
                {
                    item.defense = 8;
                }
                if (item.type == ItemID.MythrilHelmet)
                {
                    item.defense = 20;
                }
                if (item.type == ItemID.AdamantiteLeggings)
                {
                    item.defense = 13;
                }
                if (item.type == ItemID.AdamantiteBreastplate)
                {
                    item.defense = 17;
                }
                if (item.type == ItemID.AdamantiteHelmet)
                {
                    item.defense = 24;
                }
                if (item.type == ItemID.AdamantiteMask)
                {
                    item.defense = 9;
                }
                if (item.type == ItemID.AdamantiteHeadgear)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.HallowedGreaves)
                {
                    item.defense = 14;
                }
                if (item.type == ItemID.HallowedPlateMail)
                {
                    item.defense = 18;
                }
                if (item.type == ItemID.HallowedHelmet)
                {
                    item.defense = 10;
                }
                if (item.type == ItemID.HallowedMask)
                {
                    item.defense = 25;
                }
                if (item.type == ItemID.HallowedHeadgear)
                {
                    item.defense = 6;
                }

                if (item.type == ItemID.ChlorophyteHelmet)
                {
                    item.defense = 14;
                }
                if (item.type == ItemID.ChlorophyteMask)
                {
                    item.defense = 26;
                }
                if (item.type == ItemID.ChlorophyteHeadgear)
                {
                    item.defense = 8;
                }
                if (item.type == ItemID.ChlorophytePlateMail)
                {
                    item.defense = 19;
                }
                if (item.type == ItemID.ChlorophyteGreaves)
                {
                    item.defense = 15;
                }


            }

        }

        //======================================================================STATBUFFS=========================================================


        public override void UpdateEquip(Item item, Player player)
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {
                if (item.type == ItemID.GladiatorHelmet)
                {
                    player.rangedDamage += 0.05f;
                }
                if (item.type == ItemID.GladiatorBreastplate)
                {
                    player.rangedCrit += 5;
                }
                if (item.type == ItemID.GladiatorLeggings)
                {
                    player.moveSpeed += 0.1f;
                }
                if (item.type == ItemID.FrostsparkBoots)
                {
                    player.moveSpeed += 0.18f;

                }
                if (item.type == ItemID.NecroBreastplate)
                {
                    player.rangedCrit += 5;
                }



                if (item.type == ItemID.FrostBreastplate)
                {
                    player.meleeCrit += 4;
                    player.rangedCrit += 4;

                }
                if (item.type == ItemID.FrostLeggings)
                {
                    player.moveSpeed += 0.12f;
                    player.ammoCost80 = true;
                    player.meleeSpeed += 0.13f;
                }


                if (item.type == ItemID.AncientBattleArmorShirt)
                {
                    player.magicCrit += 8;
                    player.minionDamage += 0.08f;
                }
                if (item.type == ItemID.AncientBattleArmorPants)
                {

                    player.manaCost -= 0.12f;
                }



                if (item.type == ItemID.SolarFlareHelmet)
                {
                    player.meleeCrit += 13;
                    player.statLifeMax2 += 30;
                }
                if (item.type == ItemID.SolarFlareBreastplate)
                {
                    player.meleeDamage += 0.13f;
                    player.statLifeMax2 += 40;
                }
                if (item.type == ItemID.SolarFlareLeggings)
                {
                    player.meleeSpeed += 0.2f;
                    player.moveSpeed += 0.35f;
                    player.statLifeMax2 += 30;
                }
                if (item.type == ItemID.VortexHelmet)
                {
                    player.rangedCrit += 9;
                    player.nightVision = true;
                    player.dangerSense = true;

                }
                if (item.type == ItemID.VortexBreastplate)
                {

                }
                if (item.type == ItemID.VortexLeggings)
                {
                    player.moveSpeed += 0.5f;

                }

                if (item.type == ItemID.ShroomiteHeadgear)
                {
                    player.arrowDamage /= 1.15f;
                    player.rangedDamage += 0.15f;
                }
                if (item.type == ItemID.ShroomiteHelmet)
                {
                    player.rocketDamage /= 1.15f;
                    player.rangedDamage += 0.15f;
                }
                if (item.type == ItemID.ShroomiteMask)
                {
                    player.bulletDamage /= 1.15f;
                    player.rangedDamage += 0.15f;
                }
            }
        }
    }

    //================================================================SETBOUNSES==========================================================

    public class Changes : ModPlayer
    {
        // Credit to qwerty3.14
        public override void PostUpdateEquips()
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {
                if (player.armor[0].type == ItemID.GoldHelmet && player.armor[1].type == ItemID.GoldChainmail && player.armor[2].type == ItemID.GoldGreaves)
                {
                    player.statDefense -= 3; // cancel out the vanilla bonus
                    player.meleeCrit += 6;
                    player.rangedCrit += 6;
                    player.magicCrit += 6;
                    player.thrownCrit += 6;
                    player.setBonus = "6% increased critical strike chance";
                }
                if (player.armor[0].type == ItemID.SilverHelmet && player.armor[1].type == ItemID.SilverChainmail && player.armor[2].type == ItemID.SilverGreaves)
                {
                    player.statDefense -= 3; // cancel out the vanilla bonus
                    player.moveSpeed *= 1.10f;
                    player.setBonus = "10% increased movement speed";
                }
                if (player.armor[0].type == ItemID.IronHelmet && player.armor[1].type == ItemID.IronChainmail && player.armor[2].type == ItemID.IronGreaves)
                {
                    player.statDefense -= 2; // cancel out the vanilla bonus
                    player.allDamage *= 1.06f;
                    player.setBonus = "6% increased damage";
                }
                if (player.armor[0].type == ItemID.CopperHelmet && player.armor[1].type == ItemID.CopperChainmail && player.armor[2].type == ItemID.CopperGreaves)
                {
                    player.statDefense -= 2; // cancel out the vanilla bonus
                    player.meleeSpeed *= 1.1f;
                    player.setBonus = "10% increased melee speed";
                }
                if (player.armor[0].type == ItemID.RainHat && player.armor[1].type == ItemID.RainCoat)
                {
                    if (Main.raining)
                    {

                        player.AddBuff(mod.BuffType("RainBuff"), 1);
                    }
                    player.setBonus = "60% increased Movement Speed while raining";
                }
                if (player.armor[0].type == ItemID.ObsidianHelm && player.armor[1].type == ItemID.ObsidianShirt && player.armor[2].type == ItemID.ObsidianPants)
                {


                    player.fireWalk = true;
                    player.buffImmune[BuffID.OnFire] = true;
                    player.lavaRose = true;
                    player.setBonus = "Immunity to fire blocks and onfire";
                }
                /* if (player.armor[0].type == ItemID.EskimoHood && player.armor[1].type == ItemID.EskimoCoat && player.armor[2].type == ItemID.EskimoPants)
                 {

                     player.resistCold = true;

                     player.setBonus = "Reduced damage from cold themed enemies";
                 }*/
                if (player.armor[0].type == ItemID.PinkEskimoHood || player.armor[0].type == ItemID.EskimoHood && player.armor[1].type == ItemID.PinkEskimoCoat || player.armor[0].type == ItemID.EskimoCoat && player.armor[2].type == ItemID.PinkEskimoPants || player.armor[0].type == ItemID.EskimoPants)
                {

                    player.resistCold = true;
                    player.buffImmune[BuffID.Chilled] = true;
                    player.setBonus = "Reduced damage from cold themed enemies and immunity to Chilled";
                }
                if (player.armor[0].type == ItemID.GladiatorHelmet && player.armor[1].type == ItemID.GladiatorBreastplate && player.armor[2].type == ItemID.GladiatorLeggings)
                {


                    if (Main.rand.Next(2) == 0)
                    {
                        player.ammoCost80 = true;
                    }
                    player.setBonus = "10% chance not to consume ammo";

                }
                if (player.armor[0].type == ItemID.FrostHelmet && player.armor[1].type == ItemID.FrostBreastplate && player.armor[2].type == ItemID.FrostLeggings)
                {


                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;


                    player.setBonus = "Melee and ranged attacks cause frostburn\nImmunity to Chilled and Frozen";

                }
                if (player.armor[0].type == ItemID.AncientBattleArmorHat && player.armor[1].type == ItemID.AncientBattleArmorShirt && player.armor[2].type == ItemID.AncientBattleArmorPants)
                {


                    player.buffImmune[BuffID.Suffocation] = true;
                    player.buffImmune[BuffID.WindPushed] = true;


                    player.setBonus = "Double tap Down/Up to call an ancient storm to the cursor location\nImmunity to Suffocation and Mighty wind";

                }
                if (player.armor[0].type == ItemID.MythrilHelmet && player.armor[1].type == ItemID.MythrilChainmail && player.armor[2].type == ItemID.MythrilGreaves)
                {

                    player.meleeCrit += 7;
                    player.setBonus = "12% increased melee critical strike chance";

                }
            }

        }

    }

    
    public class MiningArmour : GlobalItem
    {
        public override void AddRecipes()
        {
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 25);
                recipe.AddIngredient(ItemID.GoldOre, 35);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningShirt);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 25);
                recipe.AddIngredient(ItemID.PlatinumOre, 35);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningShirt);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddIngredient(ItemID.GoldOre, 30);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningPants);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddIngredient(ItemID.PlatinumOre, 30);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningPants);
                recipe.AddRecipe();
            }
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Merchant:


                        if (Main.LocalPlayer.HasItem(ItemID.MiningHelmet))

                        {
                            shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
                            nextSlot++;
                            shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
}