using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SpectreStaff2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Staff MKII");
            Tooltip.SetDefault("Summons lost souls that orbit around you");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 1;
            
            
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            
            item.magic = true;
            

            item.damage = 60;
      
            item.knockBack = 0f;

            item.useTime = 40;
            item.useAnimation = 40;
            //item.reuseDelay = 20;
            item.shoot = mod.ProjectileType("SpectreStaffSpinProj");
            item.shootSpeed = 4.5f;
            item.mana = 15;
           


            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
            //item.noUseGraphic = true; //When uses no graphic is shown
            //item.channel = true; //Speical conditons when held down
           
        }
       /*
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 10;
            
        }*/
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}