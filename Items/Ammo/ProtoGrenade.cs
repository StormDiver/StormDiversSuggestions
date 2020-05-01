using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class ProtoGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prototype Grenade");
            Tooltip.SetDefault("For use with The Prototype Launcher");

        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 30);
            item.rare = 3;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 28;

            item.knockBack = 1f;
            item.consumable = true;


            item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.shootSpeed = 3f;
            item.ammo = item.type;
        }


        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("ProtoLauncher")) || Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("ProtoGrenade"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
       
    }
}
