using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items.Materials
{
    public class ChaosShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Orb");
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                Tooltip.SetDefault("'Imbued with pure chaos'");
            }
            else
            {
                Tooltip.SetDefault("Enable New recipes in the config to use this item");
            }
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 5;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void AddRecipes()
        {
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 12);
                recipe.AddIngredient(ItemID.CrystalShard, 30);
                recipe.AddIngredient(ItemID.SoulofLight, 25);
                recipe.AddIngredient(ItemID.HallowedBar, 20);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.RodofDiscord);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 2);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.SetResult(ItemID.SoulofLight);
                recipe.AddRecipe();
            }
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.8f * Main.essScale);
        }
        
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (!GetInstance<Configurations>().DisableNewRecipes)

                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            if (npc.type == NPCID.ChaosElemental)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosShard"));
                            }
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(7) == 0)
                        {
                            if (npc.type == NPCID.ChaosElemental)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosShard"));
                            }
                        }
                    }
                }

            }
        }
    }
    //____________________________________________________________________________________
    public class RedSilk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior Cloth");
            
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                Tooltip.SetDefault("Used to create the armour of a fallen Gladiator");
            }
            else
            {
                Tooltip.SetDefault("Enable new recipes in the config to use this item");
            }
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 3, 0);
            item.rare = 1;

        }

        public override void AddRecipes()
        {
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 10);
                recipe.AddIngredient(ItemID.GoldBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 10);
                recipe.AddIngredient(ItemID.PlatinumBar, 10);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorHelmet);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 15);
                recipe.AddIngredient(ItemID.GoldBar, 20);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorBreastplate);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 15);
                recipe.AddIngredient(ItemID.PlatinumBar, 20);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorBreastplate);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 10);
                recipe.AddIngredient(ItemID.GoldBar, 15);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorLeggings);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 10);
                recipe.AddIngredient(ItemID.PlatinumBar, 15);
                recipe.AddTile(TileID.Anvils);
                recipe.SetResult(ItemID.GladiatorLeggings);
                recipe.AddRecipe();
            }


        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (!GetInstance<Configurations>().DisableNewRecipes)

                {
                    if (npc.type == NPCID.GreekSkeleton)
                        if (Main.expertMode)
                        {
                            

                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedSilk"), Main.rand.Next(1, 3));
                            
                        }
                        else
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedSilk"));

                        }
                }
            }
        }
    }
    //____________________________________________________________________________________
    public class BlueCloth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Insulated Fabric");
            
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                Tooltip.SetDefault("Can be used to keep warm");
            }
            else
            {
                Tooltip.SetDefault("Enable new recipes in the config to use this item");
            }
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.maxStack = 999;
            
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            if (!GetInstance<Configurations>().DisableNewRecipes)

            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 10);
                recipe.AddIngredient(ItemID.Silk, 10);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoHood);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 20);
                recipe.AddIngredient(ItemID.Silk, 20);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoCoat);
                recipe.AddRecipe();

                recipe = new ModRecipe(mod);
                recipe.AddIngredient(this, 15);
                recipe.AddIngredient(ItemID.Silk, 15);
                recipe.AddTile(TileID.Loom);
                recipe.SetResult(ItemID.EskimoPants);
                recipe.AddRecipe();

            }
        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (!GetInstance<Configurations>().DisableNewRecipes)

                {
                    if (npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ArmedZombieEskimo)
                        if (Main.expertMode)
                        {


                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueCloth"), Main.rand.Next(1, 3));

                        }
                        else
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueCloth"));

                        }
                }
            }
        }
    }
    //____________________________________________________________________________________
    public class DerplingShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Shell");
            Tooltip.SetDefault("Tough, but malleable");

        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 10, 0);
            
            item.rare = 7;

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.Derpling)
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(2) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingShell"), Main.rand.Next(1, 3));
                        }
                    }
                else
                {
                        if (Main.rand.Next(2) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingShell"));
                        }
                    }
            }
        }
       
    }



    //____________________________________________________________________________________

    public class CrackedHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Heart");

            Tooltip.SetDefault("Almost devoid of life");
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 3;
       
        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
                {
                    if (Main.expertMode && npc.lifeMax >= 80)
                    {
                        if (Main.rand.Next(9) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrackedHeart"));
                        }
                    }
                    if (!Main.expertMode && npc.lifeMax >= 40)
                    {
                        if (Main.rand.Next(10) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrackedHeart"));
                        }
                    }
                }
            }
        }
    }
        //____________________________________________________________________________________
        //____________________________________________________________________________________
    }