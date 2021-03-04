using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class ShroomiteRepeater : ModItem
    {
        //Actually MechanicalRepeater but can't rename without issues

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Repeater");
            Tooltip.SetDefault("Rapidly fires arrows in bursts of three\nOnly the first shot consumes ammo");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            item.width = 45;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 6;
            item.useAnimation = 18;
            item.reuseDelay = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            //item.UseSound = SoundID.Item5;
        
            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 2f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            //item.shoot = ProjectileID.GrenadeI;
            item.shootSpeed = 10f;

            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(2, (int)position.X, (int)position.Y, 5);
            return true;
        }
        public override bool ConsumeAmmo(Player player)
        {
            // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
            // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Steampunker:

                       
                            shop.item[nextSlot].SetDefaults(mod.ItemType("ShroomiteRepeater"));
                            nextSlot++;

                        

                        break;
                }
            }
        }
    }
}