﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using StormDiversSuggestions.Items.Accessory;
using StormDiversSuggestions.Items.Armour;
using StormDiversSuggestions.Items;
using StormDiversSuggestions.Items.Ammo;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.OresandBars;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.TreasureBags
{
    public class NewTreasureBags : GlobalItem
    {


        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.BossBagBetsy)
            {
                player.QuickSpawnItem(ItemType<FlameCore>(), Main.rand.Next(1, 1));
            }

            if (context == "bossBag" && Main.hardMode)
            {
                if (Main.rand.Next(35) == 0)

                {
                    player.QuickSpawnItem(ItemType<ContestArmourHelmet>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ContestArmourChestplate>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ContestArmourLeggings>(), Main.rand.Next(1, 1));
                }

            }
            if (context == "lockBox")
            {
                if (Main.rand.Next(5) == 0)
                {
                    player.QuickSpawnItem(ItemType<ProtoLauncher>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ProtoGrenade>(), Main.rand.Next(52, 80));
                }
            }


            if (context == "crate" && arg == ItemID.WoodenCrate)
            {
                // if (StormWorld.iceOreCrate)
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneSnow && Main.hardMode)
                {
                    if (Main.rand.Next(16) == 0)
                    {
                        player.QuickSpawnItem(ItemType<IceOre>(), Main.rand.Next(8, 16));
                    }
                }
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert && Main.hardMode)
                {
                    if (Main.rand.Next(16) == 0)
                    {
                        player.QuickSpawnItem(ItemType<DesertOre>(), Main.rand.Next(8, 16));
                    }
                }
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneSnow && Main.hardMode)
                {
                    if (Main.rand.Next(20) == 0)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(1, 4));
                    }
                }
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert && Main.hardMode)
                {
                    if (Main.rand.Next(20) == 0)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(1, 4));
                    }
                }
            }

            if (context == "crate" && arg == ItemID.IronCrate)
            {
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneSnow && Main.hardMode)
                {
                    if (Main.rand.Next(12) == 0)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(5, 12));
                    }
                }
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert && Main.hardMode)
                {
                    if (Main.rand.Next(12) == 0)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(5, 12));
                    }
                }
            }
            if (context == "crate" && arg == ItemID.GoldenCrate)
            {
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneSnow && Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(15, 20));
                    }
                }
                if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert && Main.hardMode)
                {
                    if (Main.rand.Next(7) == 0)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(15, 20));
                    }
                }
            }
        }


    }

}
   


