using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class DerplingGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Shotgun");
            Tooltip.SetDefault("I know it looks cruel, but it had to be done.");
        }
        public override void SetDefaults()
        {
            
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 7;
            item.useStyle = 5;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useTurn = false;
            item.autoReuse = true;
            item.UseSound = SoundID.Item38;
            item.ranged = true;

           //item.UseSound = SoundID.Item40;

            item.damage = 30;
            item.crit = 6;
            item.knockBack = 4f;
            
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 15f;

            item.useAmmo = AmmoID.Bullet;
            
            item.noMelee = true; //Does the weapon itself inflict damage?
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, -3);
        }

        int secondfire = 3;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4; //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 3 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            secondfire--;
            if (secondfire <= 0)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 0.4), (int)(perturbedSpeed.Y * 0.4), mod.ProjectileType("DerpRangedProj"), (int)(damage * 1.4), knockBack, player.whoAmI);
                secondfire = 3;
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 22);
            }
            

            return false;

        }
        /*
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }
        */

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}