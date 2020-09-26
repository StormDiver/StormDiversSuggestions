using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Buffs;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
    public class ShroomiteSharpshooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Sharpshooter");
            Tooltip.SetDefault("33% Chance not to consume Ammo\nRight click to fire bullets with increased damage but less accurately");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            //item.UseSound = SoundID.Item40;

            item.damage = 60;
            item.crit = 16;
            item.knockBack = 2f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 15f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
        
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
               
            }
            else
            {
                
            }
            
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            if (player.altFunctionUse == 2)
            {
                if (type == ProjectileID.ChlorophyteBullet)
                {
                    type = ProjectileID.Bullet;
                    
                }
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int) (damage * 1.25f), knockBack, player.whoAmI);
                    Main.PlaySound(2, (int)position.X, (int)position.Y, 40);
                }
            }
            else
            {
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    Main.PlaySound(2, (int)position.X, (int)position.Y, 40);
                }
            }

                return false;

        }
       

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
    }
}