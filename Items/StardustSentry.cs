using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class StardustSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Invader Staff");
            Tooltip.SetDefault("Summons a floating Sentry that launches mini homing Flow Invaders at enemies\nEvery 5th shot fires a much faster and more damaging piercing projectile that does not home");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;

        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 15;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.damage = 100;
            item.knockBack = 3f;
            item.mana = 10;
            item.useTurn = false;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("StardustSentryProj");
            item.summon = true;
            item.sentry = true;
           
            item.noMelee = true;
            item.UseSound = SoundID.Item78;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

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
           
            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
}