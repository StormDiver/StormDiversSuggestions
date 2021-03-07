using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class TurtleShellWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Turtle Shell");
            Tooltip.SetDefault("Toss the shells back at your foes\nGrants extra defense while attacking enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }
        public override void SetDefaults()
        {
            
            item.damage = 55;
            item.melee = true;
            item.width = 20;
            item.height = 24;
           
            item.useTime = 18;
            item.useAnimation = 18;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 2, 40, 0);
                     item.rare = ItemRarityID.Lime;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("TurtleShellProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        /*public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)       
        {
            
            if (player.altFunctionUse == 2)
            {
                item.useTime = 35;
                item.useAnimation = 35;

            }
            else
            {
                item.useTime = 13;
                item.useAnimation = 13;
                
            }
            return player.ownedProjectileCounts[item.shoot] < 3;
        }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);
           
                
                return true;
           
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 16);
            recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}