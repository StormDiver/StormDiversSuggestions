using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Items.Accessory
{

    public class DerpEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of the Derpling");
            Tooltip.SetDefault("Sends most enemies spinning into the air when attacked");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Lime;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().derpEye = true;
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.Derpling && NPC.downedPlantBoss)
                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(100) < 2)

                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerpEye"));
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(100) < 1)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerpEye"));
                        }
                    }
                }
            }
        }
        public class DerpHitProjs : GlobalProjectile
        {
            public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockBack, bool crit) //PvE
            {
                var player = Main.player[projectile.owner];

                if (player.GetModPlayer<StormPlayer>().derpEye == true)
                {
                    if (projectile.owner == Main.myPlayer && projectile.friendly && !projectile.minion && !projectile.sentry && projectile.damage > 0 && projectile.knockBack > 0)
                    {
                        if (!target.friendly && target.lifeMax > 5 && !target.boss && target.knockBackResist != 0f)
                        {
                            target.velocity.Y = (-1.2f * projectile.knockBack) - (target.knockBackResist * 2);
                            target.velocity.X = (0.6f * projectile.knockBack + (target.knockBackResist * 2)) * projectile.direction;
                            if (!target.HasBuff(mod.BuffType("DerpDebuff")))
                            {
                                target.AddBuff(mod.BuffType("DerpDebuff"), 45);
                            }

                        }
                    }
                }
            }
        }
        public class DerpHitMelee : GlobalItem
        {
            public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit) //PvE
            {
                if (player.GetModPlayer<StormPlayer>().derpEye == true)
                {
                    if (!target.friendly && target.lifeMax > 5 && !target.boss && target.knockBackResist != 0f)
                    {
                        target.velocity.Y = (-1f * item.knockBack) - (target.knockBackResist * 2);
                        target.velocity.X = (0.7f * item.knockBack + (target.knockBackResist * 2)) * player.direction;
                        if (!target.HasBuff(mod.BuffType("DerpDebuff")))
                        {
                            target.AddBuff(mod.BuffType("DerpDebuff"), 45);
                        }
                    }
                }
            }
        }
    }
}