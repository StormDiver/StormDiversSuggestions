using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class LightDarkSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Equinox"); 
			Tooltip.SetDefault("Left Click to fire out an essence of light that travels towards enemies at high speed\nRight click to fire out an essence of dark that surrounds enemies in darkness\n'Lightness and Darkness in equilibrium'");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
         
			item.melee = true;
			item.width = 40;
			item.height = 50;
			item.useTime = 27;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 6;
            item.shoot = mod.ProjectileType("SwordLightProj");
            item.shootSpeed = 16f;
            item.scale = 1.3f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {

           
            return true;
        }
        int dusttype;
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.altFunctionUse == 2)
            {

                dusttype = 54;
               
            }
            else
            {
                dusttype = 66;
            }
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, dusttype, 0f, 0f, 100, default, 1.5f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2) //Right Click
            {
                type = mod.ProjectileType("SwordDarkProj");
                for (int i = 0; i < 1; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 0.5f, perturbedSpeed.Y * 0.5f, mod.ProjectileType("SwordDarkProj"), (int)(damage * 1f), knockBack, player.whoAmI);
                }
                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 73);
            }
            else //left Click
            {
                type = mod.ProjectileType("SwordLightProj");
                
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 1.5f, perturbedSpeed.Y * 1.5f, mod.ProjectileType("SwordLightProj"), (int)(damage * 1.6f), knockBack, player.whoAmI);
                
                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 9, 1, -0.5f);
            }

           
            
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddRecipeGroup("StormDiversSuggestions:T3HMBars", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
  
}