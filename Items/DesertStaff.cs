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
            Tooltip.SetDefault("Summons a floating Ancient Sentry that blasts sand in all directions");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            //Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.summon = true;
            item.sentry = true;
            item.mana = 10;
            item.UseSound = SoundID.Item78;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("DesertStaffProj");

            //item.shootSpeed = 3.5f;
            
           

            item.noMelee = true; 
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = Main.MouseWorld;

            /* for (int l = 0; l < Main.projectile.Length; l++)
              {                                                                  //this make so you can only spawn one of this projectile at the time,
                  Projectile proj = Main.projectile[l];
                  if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                  {
                      proj.active = false;
                  }
              }*/

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