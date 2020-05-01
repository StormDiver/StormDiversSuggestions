using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class StoneThrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Launcher MKI");
            Tooltip.SetDefault("Fire out all your unwanted stone at your foes\nRequires Miniature Boulders to work");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 15, 0, 0);
            item.rare = 2;
            item.useStyle = 5;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useTurn = false;
            item.autoReuse = false;

            

            item.shoot = mod.ProjectileType("StoneProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item61;

            
            //item.crit = 0;
            item.knockBack = 6f;

            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }



        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("StoneShot")) && NPC.downedBoss2) 
                            
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("StoneThrower"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
}