using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class IceSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Queen's Staff");
            Tooltip.SetDefault("Summons an Ice Sentry that fires out a stream of ice at nearby enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            //Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.summon = true;
            item.sentry = true;
            item.mana = 10;
            item.UseSound = SoundID.Item78;

            item.damage = 44;
            //item.crit = 4;
            item.knockBack = 1.5f;

            item.shoot = mod.ProjectileType("IceSentryProj");

            //item.shootSpeed = 3.5f;
            
           

            item.noMelee = true; 
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = Main.MouseWorld;

            return true;

        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.IceQueen)
                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(8) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSentry"));
                        }
                    }
                    if (!Main.expertMode)
                    {
                        if (Main.rand.Next(10) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceSentry"));
                        }
                    }
                }
            }
        }
    }
}