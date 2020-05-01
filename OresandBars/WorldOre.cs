using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.TreasureBags;

namespace StormDiversSuggestions.OresandBars
{


    public class WorldOre : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {

            if (npc.type == NPCID.WallofFlesh) //this is where you choose what vanilla npc you want  , for a modded npc add this instead  if (npc.type == mod.NPCType("ModdedNpcName"))
            {
                if (!StormWorld.spawnIceOre)
                {
                    // Main.NewText("Rare pockets of frost have spread throughout your world", 0, 255, 255);

                    for (int k = 0; k < (int)((double)(WorldGen.rockLayer * Main.maxTilesY) * 250E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 100);
                        //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.IceBlock)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(7, 9), (ushort)mod.TileType("IceOrePlaced"));   // is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                }
                StormWorld.spawnIceOre = true;

                if (!StormWorld.spawnDesertOre)
                {
                    // Main.NewText("Rare pockets of arid have spread throughout your world", 204, 132, 0);

                    for (int k = 0; k < (int)((double)(WorldGen.worldSurfaceLow * Main.maxTilesY) * 3000E-05); k++)   //40E-05 is how many veins ore is going to spawn , change 40 to a lover value if you want less vains ore or higher value for more veins ore
                    {
                        int X = WorldGen.genRand.Next((int)0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); //this is the coordinates where the veins ore will spawn, so in Cavern layer
                        Tile tile = Framing.GetTileSafely(X, Y);
                        if (tile.type == TileID.HardenedSand)
                        {
                            WorldGen.TileRunner(X, Y, WorldGen.genRand.Next(3, 4), WorldGen.genRand.Next(6, 8), (ushort)mod.TileType("DesertOrePlaced"));   //is the vein ore sizes, so 9 to 15 blocks or 5 to 9 blocks, 
                        }
                    }
                }
                StormWorld.spawnDesertOre = true;   //so the message and the ore spawn does not proc(show) when you kill EoC/npc again


               
            }
        }
    }
}