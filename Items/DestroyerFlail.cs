using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DestroyerFlail : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Vaporiser");
            Tooltip.SetDefault("Launches out an unchained ball every throw");
        }

        public override void SetDefaults()
        {
   
            item.width = 30;
            item.height = 10;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.crit = 4;
           
            item.knockBack = 6f;
            item.damage = 65;
            item.useStyle = 5;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("DestroyerFlailProj");
            item.shootSpeed = 24f;
            item.channel = true;
            item.noUseGraphic = true;
        }
      
       
       
        //int shoot = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //Vector2 perturbedSpeed = new Vector2(speedX, speedY);
            //Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.4), (float)(perturbedSpeed.Y * 0.4), mod.ProjectileType("DestroyerFlailProj2"), (int)(damage * 1.4), knockBack, player.whoAmI);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DaoofPow, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}