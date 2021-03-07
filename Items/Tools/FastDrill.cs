using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class FastDrill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Drill");
            Tooltip.SetDefault("'Speeds up your mining experience'");
        }

        public override void SetDefaults()
        {
            
            item.damage = 5;
            item.melee = true;
            item.width = 40;
            item.height = 22;
        
            item.useTime = 5;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.knockBack = 1f;
           
            item.useTurn = true;
            item.shoot = mod.ProjectileType("FastDrillProj");
            item.shootSpeed = 25f;
            item.pick = 55;
            item.tileBoost = -2;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true; 
            item.channel = true; 
            item.autoReuse = true;
            
            
        }
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                       
                            shop.item[nextSlot].SetDefaults(mod.ItemType("FastDrill"));
                            nextSlot++;

                        

                        break;
                }
            }
        }
    }
   
}