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
            Tooltip.SetDefault("33% Chance not to consume Ammo\nBuilds up accuracy over several seconds, dealing extra damage at full accuracy\nRight Click to zoom out");
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

            //item.UseSound = SoundID.Item40;

            item.damage = 65;
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
                        if (type == ProjectileID.Bullet)
                            {
                                type = ProjectileID.BulletHighVelocity;
                            }
                        Projectile.NewProjectile(position.X, position.Y - 2, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1.15f), knockBack * 2f, player.whoAmI);
                        Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40, 1, 0.5f);

                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y - 2, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                        Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);

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
    //_______________________________________________________________________________
    public class ShroomiteFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Fury");
            Tooltip.SetDefault("Shoots out two super bouncy piercing arrows each shot");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 46;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 72;
            //item.crit = 4;
            item.knockBack = 5f;

            item.shoot = ProjectileID.WoodenArrowFriendly;

            item.shootSpeed = 16f;

            item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1f - (Main.rand.NextFloat() * .2f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MushroomArrowProj"), (int)(damage * 0.75), knockBack, player.whoAmI);
            }

            /* int numberProjectiles = 3 + Main.rand.Next(1); //This defines how many projectiles to shot.
             for (int i = 0; i < numberProjectiles; i++)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20)); // This defines the projectiles random spread . 10 degree spread.
                 Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
             }*/
            return true;
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
    //__________________________________________________________________________________________________________
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
            item.width = 40;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.shoot = ProjectileID.RocketI;
            item.useAmmo = AmmoID.Rocket;
            // item.UseSound = SoundID.Item92;
            item.damage = 47;
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
                Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.8), (float)(perturbedSpeed.Y * 0.8), mod.ProjectileType("ShroomGrenProj"), (int)(damage), knockBack, player.whoAmI);
                Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 61);
            }
            else
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("ShroomRocketProj"), damage, knockBack, player.whoAmI);
                Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 92);
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
            recipe.AddIngredient(ItemID.ShroomiteBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}