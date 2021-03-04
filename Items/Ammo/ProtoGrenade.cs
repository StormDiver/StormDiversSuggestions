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
            Tooltip.SetDefault("For use with certain launchers");

        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 6);
            item.rare = 3;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 30;

            item.knockBack = 1f;
            item.consumable = true;


            item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.shootSpeed = 3f;
            item.ammo = item.type;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 50);
            recipe.AddIngredient(ItemID.ExplosivePowder, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();

           
        }

        public class GrenadeShop : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("ProtoLauncher")) || Main.LocalPlayer.HasItem(mod.ItemType("FrostLauncher")))
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
