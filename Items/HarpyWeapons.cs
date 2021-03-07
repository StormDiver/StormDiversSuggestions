﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class HarpyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feather Scepter");
            Tooltip.SetDefault("Fires out damaging feathers\nHas a chance to fire out a larger spinning feather");
            Item.staff[item.type] = true;


        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 34;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 8;
            item.UseSound = SoundID.Item8;

            item.damage = 19;
         
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("HarpyProj");

            item.shootSpeed = 8.5f;
   
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1.25f), (float)(perturbedSpeed.Y * 1.25f), mod.ProjectileType("HarpyProj2"), (int)(damage * 1.25f), knockBack, player.whoAmI);

                }
            }
            else 
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("HarpyProj"), damage, knockBack * 2, player.whoAmI);

                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(ItemID.Feather, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        
    }
    //_____________________________________________________________________________________________________________________________
    public class HarpyBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feathered Bow");
            Tooltip.SetDefault("Converts Wooden Arrows into Feather Arrows that ignore gravity");
            
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 40;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 18;
            //item.crit = 4;
            item.knockBack = 3f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = mod.ProjectileType("HarpyArrowProj");
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X), (float)(perturbedSpeed.Y), type, damage, knockBack, player.whoAmI);
            /* if (type == ProjectileID.WoodenArrowFriendly || type == ProjectileID.FlamingArrow) 
             {
                 type = mod.ProjectileType("DesertArrowProj");
             }*/

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(ItemID.Feather, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
    //_______________________________________________________________
    public class HarpyYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Feather Thrower");
            Tooltip.SetDefault("Lighter than most yoyos");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 25;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            //item.crit = 0;
            item.melee = true;
            item.width = 20;
            item.height = 26;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.channel = true;
            item.useTurn = true;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("HarpyYoyoProj");
            // item.shootSpeed = 9f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }



        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /* projshoot++;
             if (projshoot >= 2)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                 Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("TurtleProj"), (int)(damage * 1.5), knockBack, player.whoAmI);
                 Main.PlaySound(SoundID.NPCHit, (int)player.Center.X, (int)player.Center.Y, 24);
                 projshoot = 0;
             }*/
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(ItemID.Feather, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

           
        }
    }
}