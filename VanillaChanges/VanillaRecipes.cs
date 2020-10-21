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
            if (!GetInstance<Configurations>().DisableVanillaRecipechanges)
            //if (EnableVanillaRecipechanges)

            {
                //=======================================================REMOVINGRECIPES===============================================
                List<Recipe> rec = Main.recipe.ToList();
                int numberRecipesRemoved = 0;
                // The Recipes to remove.
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.Flamethrower);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.Megashark);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.PumpkinMoonMedallion);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.LogicSensor_Above);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.MagicalHarp);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.RainbowRod);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.OpticStaff);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.NaughtyPresent);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.FairyBell);
                //Armours
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.CopperHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.CopperChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.CopperGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TinHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TinChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TinGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.IronHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.IronChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.IronGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.LeadHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.LeadChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.LeadGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.SilverHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.SilverChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.SilverGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TungstenHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TungstenChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.TungstenGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.GoldHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.GoldChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.GoldGreaves);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.PlatinumHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.PlatinumChainmail);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.PlatinumGreaves);
                //misc

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.SuperHealingPotion);
                
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.FrostHelmet);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.FrostBreastplate);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.FrostLeggings);

                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.AncientBattleArmorHat);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.AncientBattleArmorShirt);
                numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.AncientBattleArmorPants);
                



                Main.recipe = rec.ToArray();
                Array.Resize(ref Main.recipe, Recipe.maxRecipes);
                Recipe.numRecipes -= numberRecipesRemoved;

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
                recipe.AddIngredient(ItemID.CopperBar, 6);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CopperBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.CopperBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.CopperGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 6);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TinBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TinGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.IronBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.IronGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.LeadBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.LeadGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.SilverBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.SilverGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 8);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TungstenBar, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.TungstenGreaves);
                recipe.AddRecipe();
                //

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.GoldBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GoldGreaves);
                recipe.AddRecipe();
                //
                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 16);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumChainmail);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.PlatinumBar, 14);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.PlatinumGreaves);
                recipe.AddRecipe();

                //=======================================================NEWBARSARMOUR============================================

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
                // recipe.AddIngredient(ItemID.FrostCore);
                recipe.AddIngredient(mod, "IceBar", 14);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.FrostLeggings);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                //recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
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
                // recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
                recipe.AddIngredient(mod, "DesertBar", 14);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.AncientBattleArmorPants);
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
            }

        }
    }
}
