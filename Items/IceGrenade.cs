using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class IceGrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Grenade");
            Tooltip.SetDefault("Inflicts frostburn on enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 69;
        }
        public override void SetDefaults()
        {
            
            item.damage = 75;
            item.thrown = true;
            item.width = 10;
            item.height = 14;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 40;
            item.useAnimation = 40;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 0, 0, 16);
            item.rare = ItemRarityID.Blue;
            item.shootSpeed = 7f;
            item.shoot = mod.ProjectileType("IceGrenadeProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
       
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);
           
                return true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 10);
            recipe.AddIngredient(ItemID.IceTorch);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}