
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

using StormDiversSuggestions.Items;
using StormDiversSuggestions.Items.Ammo;
using StormDiversSuggestions.Items.Accessory;
using StormDiversSuggestions.Pets;


namespace StormDiversSuggestions.Basefiles
{
    public class StormWorld : ModWorld
    {
        //All of this is to save a boolean for ever per world

        
        public static bool PlanteraMessage; //For the message that appears when plantera is defeated
        public static bool EocMessage; //For the message when the eoc is defeated
        public static bool MechMessage; //For the message when a mech boss is defeated
        public static bool GolemMessage; //For the message when the Golem is defeated


        public override void Initialize()
        {
          
            PlanteraMessage = false;
            EocMessage = false;
            MechMessage = false;
            GolemMessage = false;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
       
                {"PlanteraMessage", PlanteraMessage },
                {"EocMessage", EocMessage },
                {"MechMessage", MechMessage },
                {"GolemMessage", GolemMessage }
            };
        }
        public override void Load(TagCompound tag)
        {
      
            PlanteraMessage = tag.GetBool("PlanteraMessage");
            EocMessage = tag.GetBool("EocMessage");
            MechMessage = tag.GetBool("MechMessage");
            GolemMessage = tag.GetBool("GolemMessage");

        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
    
            flags[4] = PlanteraMessage;
            flags[5] = EocMessage;
            flags[6] = MechMessage;
            flags[7] = GolemMessage;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
  
            PlanteraMessage = flags[4];
            EocMessage = flags[5];
            MechMessage = flags[6];
            GolemMessage = flags[7];

        }

        public override void PostWorldGen()
        {
            //Make items appears in chests

            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];

                //For the Mossy Repeater in Jungle Chest
                int[] ChestMossyRep = { ItemType<MossRepeater>() };
                int ChestMossyRepCount = 0;


                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 10 * 36) //Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            if (WorldGen.genRand.NextBool(4))
                            {

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMossyRep));
                                ChestMossyRepCount = (ChestMossyRepCount + 1) % ChestMossyRep.Length;
                               
                            }

                            break;
                        }
                    }

                }


                //For Dungeon Chests
                int[] ChestLauncher = { ItemType<ProtoLauncher>() };
                int ChestLauncherCount = 0;

                int[] ChestLauncherAmmo = { ItemType<ProtoGrenade>() };
                int ChestLauncherAmmoCount = 0;

                int[] ChestTwilightPet = { ItemType<TwilightPetItem>() };
                int ChestTwilightPetCount = 0;


                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36) //Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            if (WorldGen.genRand.NextBool(4))
                            {

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestLauncher));
                                ChestLauncherCount = (ChestLauncherCount + 1) % ChestLauncher.Length;
                                inventoryIndex++;

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestLauncherAmmo));
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(52, 80);
                                ChestLauncherAmmoCount = (ChestLauncherAmmoCount + 1) % ChestLauncherAmmo.Length;

                            }
                            if (WorldGen.genRand.NextBool(5))
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestTwilightPet));
                                ChestTwilightPetCount = (ChestTwilightPetCount + 1) % ChestTwilightPet.Length;

                            }

                                break;
                        }
                    }

                }

                //For the Jar of Hearts in shadwo chests
                int[] ChestHeart = { ItemType<HeartJar>() };
                int ChestHeartCount = 0;

                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 4 * 36)//Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            if (WorldGen.genRand.NextBool(3))
                            {

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestHeart));
                                ChestHeartCount = (ChestHeartCount + 1) % ChestHeart.Length;



                            }

                            break;
                        }
                    }

                }

                //For the Webstaff in Web chests
                int[] ChestWeb = { ItemType<WebStaff>() };
                int ChestWebCount = 0;
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 15 * 36)//Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            if (WorldGen.genRand.NextBool(1))
                            {

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestWeb));
                                ChestWebCount = (ChestWebCount + 1) % ChestWeb.Length;



                            }

                            break;
                        }
                    }

                }

                //For the Granite weapons
                int[] ChestGraniteRanged = { ItemType<GraniteRifle>() };
                int ChestGraniteRangedCount = 0;
                int[] ChestGraniteAmmo = { ItemID.MusketBall };
                int ChestGraniteCountAmmo = 0;
                int[] ChestGraniteMelee = { ItemType<GraniteSpear>() };
                int ChestGraniteMeleeCount = 0;
                int[] ChestGraniteMage = { ItemType<GraniteStaff>() };
                int ChestGraniteMageCount = 0;

                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 50 * 36)//Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            int choice = Main.rand.Next(3);

                            //if (WorldGen.genRand.NextBool(2))
                            if (choice == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestGraniteRanged));
                                ChestGraniteRangedCount = (ChestGraniteRangedCount + 1) % ChestGraniteRanged.Length;
                                inventoryIndex++;

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestGraniteAmmo));
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(35, 60);
                                ChestGraniteCountAmmo = (ChestGraniteCountAmmo + 1) % ChestGraniteAmmo.Length;

                            }
                            if (choice == 1)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestGraniteMelee));
                                ChestGraniteMeleeCount = (ChestGraniteMeleeCount + 1) % ChestGraniteMelee.Length;
                            }
                            if (choice == 2)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestGraniteMage));
                                ChestGraniteMageCount = (ChestGraniteMageCount + 1) % ChestGraniteMage.Length;
                            }

                            break;
                        }
                    }

                }
                //For the Marble weapons
                int[] ChestMarbleRanged = { ItemType<GladiatorBow>() };
                int ChestMarbleRangedCount = 0;
                int[] ChestMarbleMelee = { ItemType<GladiatorSword>() };
                int ChestMarbleMeleeCount = 0;
                int[] ChestMarbleMage = { ItemType<GladiatorStaff>() };
                int ChestMarbleMageCount = 0;
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 51 * 36)//Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            int choice = Main.rand.Next(3);

                            //if (WorldGen.genRand.NextBool(2))
                            if (choice == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMarbleRanged));
                                ChestMarbleRangedCount = (ChestMarbleRangedCount + 1) % ChestMarbleRanged.Length;
                               

                            }
                            if (choice == 1)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMarbleMelee));
                                ChestMarbleMeleeCount = (ChestMarbleMeleeCount + 1) % ChestMarbleMelee.Length;
                            }
                            if (choice == 2)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMarbleMage));
                                ChestMarbleMageCount = (ChestMarbleMageCount + 1) % ChestMarbleMage.Length;
                            }

                            break;
                        }
                    }

                }
                //For the Mushroom weapons
                int[] ChestMushroomRanged = { ItemType<MushroomBow>() };
                int ChestMushroomRangedCount = 0;
                int[] ChestMushroomMelee = { ItemType<MushroomSword>() };
                int ChestMushroomMeleeCount = 0;
                int[] ChestMushroomMage = { ItemType<MushroomStaff>() };
                int ChestMushroomMageCount = 0;
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 32 * 36)//Look in Tiles_21 for the tile, start from 0
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            int choice = Main.rand.Next(3);

                            //if (WorldGen.genRand.NextBool(2))
                            if (choice == 0)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMushroomRanged));
                                ChestMushroomRangedCount = (ChestMushroomRangedCount + 1) % ChestMushroomRanged.Length;


                            }
                            if (choice == 1)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMushroomMelee));
                                ChestMushroomMeleeCount = (ChestMushroomMeleeCount + 1) % ChestMushroomMelee.Length;
                            }
                            if (choice == 2)
                            {
                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestMushroomMage));
                                ChestMushroomMageCount = (ChestMushroomMageCount + 1) % ChestMushroomMage.Length;
                            }

                            break;
                        }
                    }

                }


            }



        }
        
            public override void PreUpdate()
        {
            //For the messages when a boss is defeated
            if (NPC.downedPlantBoss && !PlanteraMessage)
            {
                Main.NewText("The Derplings begin to shed their shells", 47, 86, 146);

                Main.NewText("The ancient temple defenses have greatly weakened", 204, 101, 22);

                PlanteraMessage = true;
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !MechMessage)
            {
                Main.NewText("Fiery souls infect those trapped in the underworld", 224, 141, 255);

                MechMessage = true;
            }
            if (NPC.downedBoss1 && !EocMessage)
            {
                Main.NewText("A stronger life force radiates from the minor underground biomes", 96, 211, 255);
                EocMessage = true;
            }
            if (NPC.downedGolemBoss && !GolemMessage)
            {
                Main.NewText("Sentient asteroids have entered the atmosphere", 179, 151, 238);
                GolemMessage = true;
            }
            //To spawn the ores
            /*if (SpawnIceOre && !IceSpawned)
            {
                if (!GetInstance<Configurations>().PreventOreSpawn) 
                {
                    Main.NewText("Frozen ores can now be obtained from the depths of the Frozen Caves", 0, 255, 255);
                }
                else  //If generating ore is disabled
                {
                    Main.NewText("Frozen ores now drop from the creatures in the depths of the Frozen Caves", 0, 255, 255);

                }

                if (!GetInstance<Configurations>().PreventOreSpawn)
                {
                    for (int k = 0; k < (int)((WorldGen.rockLayer * Main.maxTilesY) * 200E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 100);
                        //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.IceBlock)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(15, 22), mod.TileType("IceOrePlaced"));   // is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                }
                IceSpawned = true;
            }
            if (SpawnDesertOre && !DesertSpawned)
            {
                if (!GetInstance<Configurations>().PreventOreSpawn)
                {
                    Main.NewText("Arid ores can now be obtained from the depths of the Sandy Tunnels", 204, 132, 0);
                }
                else //If generating ore is disabled
                {
                    Main.NewText("Arid ores now drop from creatures in the depths of the Sandy Tunnels", 204, 132, 0);

                }

                if (!GetInstance<Configurations>().PreventOreSpawn)
                {
                    for (int k = 0; k < (int)((WorldGen.worldSurfaceLow * Main.maxTilesY) * 2000E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next((int)0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.HardenedSand)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(10, 16), mod.TileType("DesertOrePlaced"));   //is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                }
                DesertSpawned = true;
            }*/

        }
    }
    public class WorldOre : GlobalNPC
    {
        /*public override void NPCLoot(NPC npc)
        {
            //set bools when the enemy is killed for the first time, these are saved at the top
            if (npc.type == NPCID.IceGolem) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                if (!StormWorld.SpawnIceOre)
                {
                    StormWorld.SpawnIceOre = true;
                }
            }
            if (npc.type == NPCID.SandElemental) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                if (!StormWorld.SpawnDesertOre)
                {

                    StormWorld.SpawnDesertOre = true;
                }

            }
        }*/
    }
}