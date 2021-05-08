using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class HellSoulPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellSoul Pickaxe");
            Tooltip.SetDefault("Empowered with the burning souls of hell");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.crit = 0;
            item.melee = true;
            item.width = 40;
            item.height = 44;
            item.useTime = 6;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.pick = 200;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 5;
            item.tileBoost = 1;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 173, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173, 0, 0);
                dust.scale = 2;


            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 300);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 480);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 18);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    public class HellSoulHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HellSoul Hamaxe");
            Tooltip.SetDefault("Empowered with the burning souls of hell");
        }

        public override void SetDefaults()
        {
            item.damage = 60;

            item.melee = true;
            item.width = 40;
            item.height = 50;
            item.useTime = 8;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.axe = 32;
            item.hammer = 90;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 7;
            item.tileBoost = 1;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 173, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173, 0, 0);
                dust.scale = 2;


            }
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 300);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 480);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 18);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}