using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class FrostPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Pickaxe");
            Tooltip.SetDefault("Can mine Adamantite and Titanium");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 0;
            item.melee = true;
            item.width = 40;
            item.height = 44;
            item.useTime = 8;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.pick = 160;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 5;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 16);
            //recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    public class FrostHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Hamaxe");
            Tooltip.SetDefault("Strong enough to destroy Altars");
        }

        public override void SetDefaults()
        {
            item.damage = 45;

            item.melee = true;
            item.width = 40;
            item.height = 50;
            item.useTime = 16;
            item.useAnimation = 35;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.axe = 30;
            item.hammer = 80;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 7;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 16);
            
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}