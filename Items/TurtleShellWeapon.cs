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
            Tooltip.SetDefault("Toss the shells back at your foes");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }
        public override void SetDefaults()
        {
            
            item.damage = 65;
            item.melee = true;
            item.width = 30;
            item.height = 30;
           
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 8;
            item.shootSpeed = 12f;
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
            Main.PlaySound(2, (int)position.X, (int)position.Y, 1);
            for (int i = 0; i < 3; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }
                return false;
           
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