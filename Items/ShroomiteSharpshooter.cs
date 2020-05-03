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
            Tooltip.SetDefault("33% Chance not to consume Ammo\nSummons damaging mushrooms while firing");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {
            
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item40;

            item.damage = 65;
            item.crit = 16;
            item.knockBack = 2f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 20f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            for (int i = 0; i < 2; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 1.4), (int)(perturbedSpeed.Y * 1.4), mod.ProjectileType("Rangedmushroom"), damage, knockBack, player.whoAmI);
            }
           

                return true;

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