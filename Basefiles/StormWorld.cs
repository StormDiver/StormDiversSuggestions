
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


namespace StormDiversSuggestions.Basefiles
{
    public class StormWorld : ModWorld
    {
        public static bool SpawnIceOre;
        public static bool SpawnDesertOre;

        public override void Initialize()
        {
            SpawnIceOre = false;
            SpawnDesertOre = false;
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"SpawnIceOre", SpawnIceOre },
                {"SpawnDesertOre", SpawnDesertOre }
            };
        }
        public override void Load(TagCompound tag)
        {
            SpawnIceOre = tag.GetBool("SpawnIceOre");
            SpawnDesertOre = tag.GetBool("SpawnDesertOre");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = SpawnIceOre;
            flags[1] = SpawnDesertOre;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            SpawnIceOre = flags[0];
            SpawnDesertOre = flags[1];
        }
        public override void PostWorldGen()
        {

            int[] ChestLauncher = { ItemType<ProtoLauncher>() };
            int[] ChestAmmo = { ItemType<ProtoGrenade>() };
            int ChestLauncherCount = 0;
            int ChestAmmoCount = 0;

            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                // If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == 0)
                        {
                            if (WorldGen.genRand.NextBool(4))
                            {

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestLauncher));
                                ChestLauncherCount = (ChestLauncherCount + 1) % ChestLauncher.Length;
                                inventoryIndex++;

                                chest.item[inventoryIndex].SetDefaults(Main.rand.Next(ChestAmmo));
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(52, 80);
                                ChestAmmoCount = (ChestAmmoCount + 1) % ChestAmmo.Length;

                            }

                            break;
                        }
                    }

                }

            }
        


    }

    }
    public class WorldOre : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.IceGolem) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                if (!StormWorld.SpawnIceOre)
                {
                    Main.NewText("Frozen ores can now be obtained from the depths of the Ice biome", 0, 255, 255);

                    for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 300E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 100);
                        //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.IceBlock)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(15, 28), mod.TileType("IceOrePlaced"));   // is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                    StormWorld.SpawnIceOre = true;
                }
            }
                if (npc.type == NPCID.SandElemental) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
                {
                    if (!StormWorld.SpawnDesertOre)
                {

                    Main.NewText("Arid ores can now be obtained from the depths of the Desert biome", 204, 132, 0);

                    for (int k = 0; k < (int)((double)(WorldGen.worldSurfaceLow * Main.maxTilesY) * 2800E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next((int)0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.HardenedSand)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(10, 18), mod.TileType("DesertOrePlaced"));   //is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                    StormWorld.SpawnDesertOre = true;
                }

                //so the message and the ore spawn does not proc(show) when you kill EoC/npc again



            }
        }
    
    }
}