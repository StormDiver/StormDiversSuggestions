using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class OceanShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Shard");
            Tooltip.SetDefault("For use with the Coral Gun");

        }
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 18;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 2);
            item.rare = 1;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 3;
            
            item.knockBack = 0f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("OceanCoralProj");
            item.shootSpeed = 0f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 1);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.ArmsDealer:

                        if (Main.hardMode && Main.LocalPlayer.HasItem(mod.ItemType("OceanGun"))) //if it's hardmode the NPC will sell this
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("OceanShard"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
}