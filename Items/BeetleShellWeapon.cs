using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class BeetleShellWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Beetle Shell");
            Tooltip.SetDefault("Summons beetles to attack and swarm your foes on impact\nRight click to throw 4 at once");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }
        public override void SetDefaults()
        {
            
            item.damage = 90;
            item.melee = true;
            item.width = 30;
            item.height = 30;
           
            //item.useTime = 13;
            //item.useAnimation = 13;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.buyPrice(0, 8, 0, 0);
            item.rare = 8;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("BeetleShellProj");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)       
        {
            
            if (player.altFunctionUse == 2)
            {
                item.useTime = 40;
                item.useAnimation = 40;

            }
            else
            {
                item.useTime = 15;
                item.useAnimation = 15;
                
            }
            return player.ownedProjectileCounts[item.shoot] < 6;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                
                for (int i = 0; i < 4; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("TurtleShellWeapon"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}