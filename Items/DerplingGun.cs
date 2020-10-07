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
            DisplayName.SetDefault("Derpling Rifle");
            Tooltip.SetDefault("I know it looks cruel, but it had to be done\nThree round burst, only the first shot consumes ammo");
        }
        public override void SetDefaults()
        {
            
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 7;
            item.useStyle = 5;
            item.useTime = 4;
            item.useAnimation = 12;
            item.reuseDelay = 12;
            item.useTurn = false;
            item.autoReuse = true;
            //item.UseSound = SoundID.Item38;
            item.ranged = true;


            item.damage = 38;
            item.crit = 6;
            item.knockBack = 2f;
            
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 13f;

            item.useAmmo = AmmoID.Bullet;
            
            item.noMelee = true; //Does the weapon itself inflict damage?
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, -3);
        }
        
        //int secondfire = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(2, (int)position.X, (int)position.Y, 40);
            /* int numberProjectiles = 4; //This defines how many projectiles to shot.
             for (int i = 0; i < numberProjectiles; i++)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 3 degree spread.
                 Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
             }
            secondfire++;
            if (secondfire >= 2)
            {
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 0.4), (int)(perturbedSpeed.Y * 0.4), mod.ProjectileType("DerpRangedProj"), (int)(damage * 1.25), knockBack, player.whoAmI);
                secondfire = 0;
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 22);
            }*/
            

            return true;

        }
       
public override bool ConsumeAmmo(Player player)
        {
            // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
            // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}