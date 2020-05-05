using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class IceGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Grenade");
            Tooltip.SetDefault("For use with The Cryo Grenade Launcher");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 1, 50);
            item.rare = 3;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 38;

            item.knockBack = 1f;
            item.consumable = true;


            item.shoot = mod.ProjectileType("IceGrenadeProj");
            item.shootSpeed = 3f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IceBar"), 1);
            recipe.AddIngredient(ItemID.ExplosivePowder, 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 60);
            recipe.AddRecipe();
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("FrostLauncher")) || Main.hardMode)
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("IceGrenade"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
       
    }
}
