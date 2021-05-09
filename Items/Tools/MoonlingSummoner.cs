using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.NPCs;
using Terraria.DataStructures;


namespace StormDiversSuggestions.Items.Tools
{
    public class MoonlingSummoner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling Core");
            Tooltip.SetDefault("Summons a Moonling that will try to kill you\nSafer to use near solid ground");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 6));

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
            item.noUseGraphic = true;

            ItemID.Sets.ItemNoGravity[item.type] = true;
            //ItemID.Sets.ItemIconPulse[item.type] = true;
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
            for (int i = 0; i < 50; i++)
            {

                Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                int dust2 = Dust.NewDust(new Vector2(player.Center.X - 5, player.Top.Y), 10, 10, 229, 0f, 0f, 200, default, 0.8f);
                Main.dust[dust2].velocity *= 2f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].scale = 1.5f;
            }
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
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 255;
            return color;

        }
    }
}