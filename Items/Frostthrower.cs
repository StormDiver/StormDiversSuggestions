﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class Frostthrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Freezer");
            Tooltip.SetDefault("Fires out frozen gas which inflicts CryoBurn\nUses gel as ammo");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            
            item.width = 40;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 8;
            item.useAnimation = 26;
            
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item20;

            item.damage = 25;
            item.crit = 6;
            item.knockBack = 0.5f;
            item.shoot = mod.ProjectileType("Frostthrowerproj"); ;
            
            item.shootSpeed = 3f;

            item.useAmmo = AmmoID.Gel;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 0);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .50f;
        }
    }
}