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
            Tooltip.SetDefault("33% Chance not to consume Ammo\nBuilds up accuracy over several seconds, with extra damage at max accuracy\nRight Click to zoom out");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            
            item.width = 50;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item40;

            item.damage = 70;
            item.crit = 16;
            item.knockBack = 2f;
       
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 15f;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; 
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }

        int accuracy = 20; //The amount of spread
        int resetaccuracy = 15; //How long to not fire for the accuracy to reset
        public override void HoldItem(Player player)
        {
            player.scope = true;
            if (resetaccuracy == 0) //Resets accuracy when not firing
            {
                accuracy = 20;
               
            }
            resetaccuracy--;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (accuracy > 0)//Increases accuracy every shot
            {
                accuracy -= 1;

            }

            resetaccuracy = 15; //Prevents the accuracy from reseting while firing

            {
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(accuracy));
                    if (accuracy == 0)//When at full accuracy damage and knockback of the projectile is increased by 10%
                    {
                        Projectile.NewProjectile(position.X, position.Y - 2, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1.1f), knockBack * 1.1f, player.whoAmI);

                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y - 2, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

                    }
                    //Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);
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
            recipe.AddIngredient(ItemID.ShroomiteBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
    }
}