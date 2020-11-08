using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class ShroomiteLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Launcher");
            Tooltip.SetDefault("Fires Shroomite Rockets which explode into mushrooms\nRight click to fire Shroomite Grenades");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.shoot = ProjectileID.RocketI;
            item.useAmmo = AmmoID.Rocket;
           // item.UseSound = SoundID.Item92;
            item.damage = 50;
            //item.crit = 4;
            item.knockBack = 6f;
            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
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

        //int gren = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //gren++;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (player.altFunctionUse == 2)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 0.8), (int)(perturbedSpeed.Y * 0.8), mod.ProjectileType("ShroomGrenProj"), (int)(damage * 0.75), knockBack, player.whoAmI);
                Main.PlaySound(2, (int)position.X, (int)position.Y, 61);
            }
            else
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X ,perturbedSpeed.Y, mod.ProjectileType("ShroomRocketProj"), damage, knockBack, player.whoAmI);
                Main.PlaySound(2, (int)position.X, (int)position.Y, 92);
            }
           

           
            //if (Main.rand.Next(3) == 0)
            //{
                //if (gren >= 3)
                //{
                    
                //gren = 0;
                //}
            //}
            
            
            return false;
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