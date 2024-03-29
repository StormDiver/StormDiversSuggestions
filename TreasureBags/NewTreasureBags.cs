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
using StormDiversSuggestions.Items.Materials;
using StormDiversSuggestions.Pets;
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
            if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
            {
                if (Main.rand.Next(100) < 15)
                {
                    player.QuickSpawnItem(ItemType<QuackStaffSuper>(), Main.rand.Next(1, 1));
                }
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag || arg == ItemID.TwinsBossBag || arg == ItemID.DestroyerBossBag)
                {
                    player.QuickSpawnItem(ItemType<PrimeAccess>(), Main.rand.Next(1, 1));
                }
            }
            if (context == "bossBag" && arg == ItemID.GolemBossBag)
            {
                if (Main.rand.Next(100) < 15)
                {
                    player.QuickSpawnItem(ItemType<LizardFlame>(), Main.rand.Next(1, 1));
                }
            }
            if (context == "bossBag" && arg == ItemID.CultistBossBag)
            {
                player.QuickSpawnItem(ItemType<LunaticHood>(), Main.rand.Next(1, 1));

                if (Main.rand.Next(100) < 5)

                {
                    player.QuickSpawnItem(ItemType<CultistLazor>(), Main.rand.Next(1, 1));
                   

                }
                int choice = Main.rand.Next(4);

                if (choice == 0)
                {
                    player.QuickSpawnItem(ItemType<CultistBow>(), Main.rand.Next(1, 1));
                }
                if (choice == 1)
                {
                    player.QuickSpawnItem(ItemType<CultistSpear>(), Main.rand.Next(1, 1));
                }
                if (choice == 2)
                {
                    player.QuickSpawnItem(ItemType<CultistTome>(), Main.rand.Next(1, 1));
                }
                if (choice == 3)
                {
                    player.QuickSpawnItem(ItemType<CultistStaff>(), Main.rand.Next(1, 1));

                }
            }
            /*if (context == "bossBag" && Main.hardMode)
            {
                if (Main.rand.Next(100) < 2)

                {
                    player.QuickSpawnItem(ItemType<ContestArmourHelmet>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ContestArmourChestplate>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ContestArmourLeggings>(), Main.rand.Next(1, 1));
                }

            }*/
            if (context == "lockBox")
            {
                if (Main.rand.Next(100) < 20)
                {
                    player.QuickSpawnItem(ItemType<ProtoLauncher>(), Main.rand.Next(1, 1));
                    player.QuickSpawnItem(ItemType<ProtoGrenade>(), Main.rand.Next(52, 80));
                }
                if (Main.rand.Next(100) < 20)
                {
                    player.QuickSpawnItem(ItemType<TwilightPetItem>(), Main.rand.Next(1, 1));
                }
            }


            if (context == "crate" && arg == ItemID.WoodenCrate)
            {
                if (Main.hardMode)
                {
                    // if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneSnow && Main.hardMode)

                    if (Main.rand.Next(100) < 7)
                    {
                        player.QuickSpawnItem(ItemType<IceOre>(), Main.rand.Next(8, 16));
                    }
                }
                if (Main.hardMode)
                    //if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert && Main.hardMode)
                {
                    if (Main.rand.Next(100) < 7)
                    {
                        player.QuickSpawnItem(ItemType<DesertOre>(), Main.rand.Next(8, 16));
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 5)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(1, 4));
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 5)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(1, 4));
                    }
                }
            }

            if (context == "crate" && arg == ItemID.IronCrate)
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 7)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(5, 10));
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 7)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(5, 10));
                    }
                }
            }
            if (context == "crate" && arg == ItemID.GoldenCrate)
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 10)
                    {
                        player.QuickSpawnItem(ItemType<IceBar>(), Main.rand.Next(10, 14));
                    }
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) < 10)
                    {
                        player.QuickSpawnItem(ItemType<DesertBar>(), Main.rand.Next(10, 14));
                    }
                }
            }
        }


    }

}
   


