using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
    public class LavaSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Tome");
            Tooltip.SetDefault("Summons an orb of lava that splashes on impact");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 3;
            item.useStyle = 5;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 13;
            item.UseSound = SoundID.Item20;

            item.damage = 26;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("LavaSpellProj");
            item.scale = 0.9f;
            item.shootSpeed = 12f;

            //item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
         public override Vector2? HoldoutOffset()
         {
             return new Vector2(2, 0);
         }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(ItemID.Book, 1);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    
}