using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items.Potions
{
    public class ShroomitePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Potion");
            Tooltip.SetDefault("Enchances your Ranged skills");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.buffType = BuffType<Buffs.ShroomiteBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    public class SpectrePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Potion");
            Tooltip.SetDefault("Enchances your Magic skills");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.buffType = BuffType<Buffs.SpectreBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ectoplasm, 4);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    public class BeetlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Potion");
            Tooltip.SetDefault("Enchances your Melee skills");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.buffType = BuffType<Buffs.BeetleBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BeetleHusk, 3);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}