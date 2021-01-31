using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Tools
{
    public class Quack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rubber Duck");
            Tooltip.SetDefault("'QUACK!'");

        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 0;
            item.useStyle = 4;
            item.useTime = 70;
            item.useAnimation = 70;
            item.useTurn = true;
            item.autoReuse = false;
            item.holdStyle = 0;
            item.noMelee = true; 
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        float pitch;
        public override bool UseItem(Player player)
        {
            float shootToX = Main.MouseWorld.X - player.Center.X;
            float shootToY = Main.MouseWorld.Y - player.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            pitch = distance / 500 - 0.6f; //Lowest possible pitch is -0.6f;
            if (pitch > 0.8f) //Caps the pitch at 0.8f;
            {
                pitch = 0.8f;
            }
            Main.PlaySound(29, (int)player.Center.X, (int)player.Center.Y, 12, 1, pitch);

            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            return true;
        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(50) == 0)
                {
                    if (npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Quack"));
                    }
                }
            }
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Merchant:

                        if (NPC.downedBoss1)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("Quack"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
}