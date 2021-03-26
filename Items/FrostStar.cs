using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class FrostStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Frizbee");
            Tooltip.SetDefault("Throws out a frizbee that shatters on impact");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            
            item.damage = 44;
            item.melee = true;
            item.width = 30;
            item.height = 38;
            item.useTime = 18;
            item.useAnimation = 18;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("FrostStarProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}