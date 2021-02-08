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
            
                Tooltip.SetDefault("'Imbued with pure chaos'");
           
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 5;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void AddRecipes()
        {
            

                //VanillaRecipes
            
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override Color? GetAlpha(Color lightColor)
        {



            return Color.White;

        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                

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
    public class GraniteCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Power Cell");

            Tooltip.SetDefault("Seems to be pulsing with energy");

        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 20;
            item.maxStack = 999;
            ItemID.Sets.ItemIconPulse[item.type] = true;

            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override void AddRecipes()
        {

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                if (npc.type == NPCID.GraniteFlyer || npc.type == NPCID.GraniteGolem)
                {

                    if (Main.expertMode)
                    {

                        if (Main.rand.Next(4) == 0)

                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteCore"));
                        }
                    }

                    else
                    {
                        if (Main.rand.Next(5) == 0)

                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteCore"));
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
            
           
                Tooltip.SetDefault("Used to create items of a fallen Gladiator");
            
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;

        }

        public override void AddRecipes()
        {
            
            //NewRecipes

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {



                if (npc.type == NPCID.GreekSkeleton)
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(4) == 0)

                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedSilk"));
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(5) == 0)
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
            
           
                Tooltip.SetDefault("Can be used to keep warm");
           
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 999;
            
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            //VanillaRecipes
        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

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
            Tooltip.SetDefault("'Tough, but malleable'");

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

            Tooltip.SetDefault("'Almost devoid of life'");
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
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
    public class BloodDrop : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Drop");

            Tooltip.SetDefault("A drop of blood that is somehow able to hold its shape");

        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 20;
            item.maxStack = 999;

            item.value = Item.sellPrice(0, 0, 0, 50);
            item.rare = 2;
        }

        public override void AddRecipes()
        {
           
   

            
        }

    
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (NPC.downedBoss1)
                {
                    if (npc.type == NPCID.Drippler || npc.type == NPCID.BloodZombie)
                    {
                       
                            if (Main.expertMode)
                            {

                            if (Main.rand.Next(5) == 0)

                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDrop"), Main.rand.Next(1, 2));
                            }
                            }

                            else
                            {
                            if (Main.rand.Next(6) == 0)

                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDrop"), Main.rand.Next(1, 2));
                            }
                          }
                        
                    }
                }
            }
        }
    }
    //____________________________________________________________________________________
   
    //_____________________________________
    public class SpaceRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Rock");

            Tooltip.SetDefault("Seems to be infused with some strange energy");

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 8;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }

        public override void AddRecipes()
        {
            

        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override Color? GetAlpha(Color lightColor)
        {

            return Color.White;

        }
       
    }
   
}