using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Basefiles
{
    public class Newrecipes : GlobalItem
    {
        public override void AddRecipes()
        {
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
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 2);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 18);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 3);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorBreastplate);
                recipe.AddRecipe();


                recipe = new ModRecipe(mod);
                recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 15);
                recipe.AddIngredient(mod.GetItem("RedSilk"), 2);
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
                recipe.AddIngredient(mod.GetItem("SantankScrap"), 18);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.ChainGun);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(mod.GetItem("SantankScrap"), 18);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.EldMelter);
                recipe.AddRecipe();
            }
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:
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
                switch (type)
                { 
                    case NPCID.Merchant:
                        {
                            if (Main.raining)
                            {
                                shop.item[nextSlot].SetDefaults(ItemID.RainHat);
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ItemID.RainCoat);
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(mod.ItemType("RainBoots"));
                                nextSlot++;

                            }
                        }
                        break;
                }
            }
        }
    }
}
