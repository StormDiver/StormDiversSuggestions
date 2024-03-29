﻿using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class EnchantedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Blade of Light");
            Tooltip.SetDefault("Summons mini Enchanted Swords that charge and ricochet towards the cursor and pierce\n'Not to be confused with The Blade of Night'");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.LightRed;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 44;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("EnchantedSwordProj");
            
            item.shootSpeed = 1f;

            item.mana = 10;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
           
            return false;
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 4)

                {
                    if (npc.type == NPCID.EnchantedSword)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnchantedSword"));
                        
                    }
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.CrystalShard, 25);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_______________________________________________________________________________
    public class CrimsonAxeMagic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Soul Splitter");
            Tooltip.SetDefault("Summons mini Crimson Axes that split into multiple axes\n'Split the souls of your foes'");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.LightRed;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 37;
            //item.crit = 4;
            item.knockBack = 2f;

            item.shoot = mod.ProjectileType("CrimsonAxeProj");

            item.shootSpeed = 1f;

            item.mana = 12;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 4)
                {
                    if (npc.type == NPCID.CrimsonAxe)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrimsonAxeMagic"));

                    }
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.Ichor, 15);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_______________________________________________________________________________
    public class CursedHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Dream Crusher");
            Tooltip.SetDefault("Summons mini Cursed Hammers that rain down more hammers\n'Crush the dreams of your enemies'");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 40;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.LightRed;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 38;
            //item.crit = 4;
            item.knockBack = 2f;

            item.shoot = mod.ProjectileType("CursedHammerProj");

            item.shootSpeed = 1f;

            item.mana = 12;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 4)

                {
                    if (npc.type == NPCID.CursedHammer)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedHammer"));

                    }
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.CursedFlame, 15);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}