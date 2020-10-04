using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DesertStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Staff");
            Tooltip.SetDefault("Fires out a burning sand blast");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 15;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 15;
            item.UseSound = SoundID.Item20;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("DesertStaffProj");

            item.shootSpeed = 3f;
            
                

            item.noMelee = true; 
        }
       /* public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("DesertBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}