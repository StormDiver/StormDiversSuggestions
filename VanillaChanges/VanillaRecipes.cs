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
    public class VanillaRecipes : GlobalItem
    {

        public override void AddRecipes()
        {
            if (GetInstance<Configurations>().EnableAltRecipes)
            {



                //==================================================SOULRECIPES==========================================

                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SoulofSight, 20);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddIngredient(ItemID.HallowedBar, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.Flamethrower);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Minishark, 1);
                recipe.AddIngredient(ItemID.SoulofSight, 20);
                recipe.AddIngredient(ItemID.IllegalGunParts, 1);
                recipe.AddIngredient(ItemID.SharkFin, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.Megashark);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Pumpkin, 30);
                recipe.AddIngredient(ItemID.Ectoplasm, 5);
                recipe.AddIngredient(ItemID.SoulofFright, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.PumpkinMoonMedallion);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Lens, 1);
                recipe.AddIngredient(ItemID.HallowedBar, 1);
                recipe.AddIngredient(ItemID.Wire, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.LogicSensor_Above);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Harp, 1);
                recipe.AddIngredient(ItemID.CrystalShard, 20);
                recipe.AddIngredient(ItemID.SoulofNight, 8);
                recipe.AddIngredient(ItemID.SoulofFright, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.MagicalHarp);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CrystalShard, 10);
                recipe.AddIngredient(ItemID.UnicornHorn, 2);
                recipe.AddIngredient(ItemID.PixieDust, 10);
                recipe.AddIngredient(ItemID.SoulofLight, 5);
                recipe.AddIngredient(ItemID.SoulofFright, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.RainbowRod);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.BlackLens, 1);
                recipe.AddIngredient(ItemID.Lens, 2);
                recipe.AddIngredient(ItemID.HallowedBar, 12);
                recipe.AddIngredient(ItemID.SoulofSight, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.OpticStaff);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddIngredient(ItemID.Ectoplasm, 5);
                recipe.AddIngredient(ItemID.SoulofMight, 5);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.NaughtyPresent);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Bell, 1);
                recipe.AddIngredient(ItemID.PixieDust, 25);
                recipe.AddIngredient(ItemID.SoulofMight, 1);
                recipe.AddIngredient(ItemID.SoulofFright, 1);
                recipe.AddIngredient(ItemID.SoulofSight, 1);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FairyBell);
                recipe.AddRecipe();

                //========================================ARMOURS================================

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CopperBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CopperBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CopperBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 18);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 18);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumGreaves);
                recipe.AddRecipe();
                //==========================================OTHER==========================================

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GreaterHealingPotion, 5);
                //recipe.anyFragment = true;
                recipe.AddRecipeGroup("Fragment", 1);
                // recipe.AddIngredient(ItemID.FragmentVortex);
                recipe.AddTile(TileID.Bottles);
                recipe.SetResult(ItemID.SuperHealingPotion, 5);
                recipe.AddRecipe();
            }


        }
    }

    

        public class Newrecipes : GlobalItem
    {
        public override void AddRecipes()
        {
            
            //I consider these to be additions and therefore will always be enabled 
            {


                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 25);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldOres", 35); 
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningShirt);
                recipe.AddRecipe();

               

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldOres", 30);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.MiningPants);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 10);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 15);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 20);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorBreastplate);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 10);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 15);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorLeggings);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("BlueCloth"), 10);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoHood);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("BlueCloth"), 20);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoCoat);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("BlueCloth"), 15);
                recipe.AddIngredient(ItemID.Silk, 15);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoPants);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("ChaosShard"), 12);
                recipe.AddIngredient(ItemID.CrystalShard, 30);
                recipe.AddIngredient(ItemID.SoulofLight, 25);
                recipe.AddIngredient(ItemID.HallowedBar, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.RodofDiscord);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("ChaosShard"), 2);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.SoulofLight);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.FallenStar, 1);
                recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.LihzahrdPowerCell);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod)
                {
                    anyWood = true
                };
                recipe.AddIngredient(ItemID.Wood, 50);
                recipe.AddIngredient(ItemID.Gel, 100);
                recipe.AddTile(TileID.WorkBenches);
                recipe.SetResult(ItemID.SlimeStaff);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.StoneBlock, 50);
                recipe.AddTile(TileID.HeavyWorkBench);
                recipe.SetResult(ItemID.Tombstone);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                // recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddIngredient(mod, "IceBar", 10);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "IceBar", 18);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostBreastplate);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "IceBar", 14);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostLeggings);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 10);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorHat);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 18);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorShirt);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 14);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorPants);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                // recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddIngredient(mod, "IceBar", 10);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "IceBar", 18);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostBreastplate);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "IceBar", 14);
                recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostLeggings);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 10);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorHat);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 18);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorShirt);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod, "DesertBar", 14);
                recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorPants);
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
                        
                        {

                            if (Main.LocalPlayer.HasItem(ItemID.MiningHelmet))

                            {
                                shop.item[nextSlot].SetDefaults(ItemID.MiningShirt);
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ItemID.MiningPants);
                                nextSlot++;

                            }
                        }

                        break;
                }
            }
        }
    }
}
