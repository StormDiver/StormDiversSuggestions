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
            
            item.width = 50;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 4, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 4;
            item.useAnimation = 12;
            item.reuseDelay = 13;
            item.useTurn = false;
            item.autoReuse = true;
            //item.UseSound = SoundID.Item38;
            item.ranged = true;


            item.damage = 32;
            item.crit = 6;
            item.knockBack = 2f;
            
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;

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
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;

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