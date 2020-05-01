using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using StormDiversSuggestions.Items;
using StormDiversSuggestions.Items.Ammo;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Basefiles
{
    public class StormWorld : ModWorld
    {
        public static bool spawnIceOre = false;
        public static bool spawnDesertOre = false;
       

        public override void PostWorldGen()
        {
            
            int[] ChestLauncher = {ItemType<ProtoLauncher>()};
            int[] ChestAmmo = {ItemType<ProtoGrenade>()};
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
                                chest.item[inventoryIndex].stack = WorldGen.genRand.Next(52,80);
                                ChestAmmoCount = (ChestAmmoCount + 1) % ChestAmmo.Length;

                            }

                            break;
                        }
                    }
                   
                }
               
            }
        }
    }
}