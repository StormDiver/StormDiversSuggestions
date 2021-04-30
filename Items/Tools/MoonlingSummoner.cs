using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.NPCs;

namespace StormDiversSuggestions.Items.Tools
{
    public class MoonlingSummoner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling Core");
            Tooltip.SetDefault("Summons a Moonling that will try to kill you\nSafer to use near solid ground");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useTurn = false;
            item.autoReuse = false;
            item.consumable = true;
            item.noMelee = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
        }
        public override void PostUpdate()
        {
            Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.5f * Main.essScale);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool CanUseItem(Player player)
        {
            return NPC.downedMoonlord && !NPC.AnyNPCs(ModContent.NPCType<NPCs.MoonDerp>());
            //return true;
        }
        public override bool UseItem(Player player)
        {
            //Main.NewText("The Storm God has awoken!", 175, 75, 255);
            NPC.SpawnOnPlayer(player.whoAmI , ModContent.NPCType<NPCs.MoonDerp>());
            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override bool InstancePerEntity => true;
            public override void NPCLoot(NPC npc)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight && NPC.downedMoonlord)
                {
                    if (Main.rand.Next(50) < 1)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MoonlingSummoner"));
                    }

                }
            }
        }
    }
}