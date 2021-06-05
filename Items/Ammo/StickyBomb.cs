using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class StickyBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spikey Bomb");
            Tooltip.SetDefault("Very sticky and explosive\nFor use with the Spikey Bomb Launcher\n'What makes a good Demoman?'");

        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.rare = ItemRarityID.LightPurple;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 50;

            item.knockBack = 1f;
            item.consumable = true;


            item.shoot = mod.ProjectileType("StickyBombProj");
            item.shootSpeed = 3f;
            item.ammo = item.type;
        }
       

        public class GrenadeShop : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("StickyLauncher")))
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("StickyBomb"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
       
    }
}
