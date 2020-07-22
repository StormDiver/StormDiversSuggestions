using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace StormDiversSuggestions.Items.Ammo
{
    public class SeekerBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seeker Bolts");
            Tooltip.SetDefault("For use with The Seeker");
            
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 80);
            item.rare = 8;

            //item.melee = true;
            item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 20;
            item.crit = 4;
            item.knockBack = 1f;
            item.consumable = true;

            item.shoot = mod.ProjectileType("SeekerBoltProj");
            item.shootSpeed = 5f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 250);
            recipe.AddRecipe();
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.ArmsDealer:  

                        if (Main.hardMode && Main.LocalPlayer.HasItem(mod.ItemType("TheSeeker"))) //if it's hardmode the NPC will sell this
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("SeekerBolt"));  
                            nextSlot++;
                            
                        }
                       
                        break;
                }
            }
        }
    }
}
