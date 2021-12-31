using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    [AutoloadEquip(EquipType.HandsOn)]

    public class BeetleBoot : ModItem //Now Beetle gauntlet
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Gauntlet");
            Tooltip.SetDefault("Critical striking an enemy with a melee weapon causes mini beetles to burst out of them and swarm nearby enemies\n15% increased melee speed and increases melee knockback");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.accessory = true;
            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().beetleFist = true;
            player.meleeSpeed += 0.15f;
            player.kbGlove = true;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddIngredient(ItemID.PowerGlove, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}