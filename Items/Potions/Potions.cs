using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;

namespace StormDiversSuggestions.Items.Potions
{
    public class BloodPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Decay Potion");
            Tooltip.SetDefault("Decays the life of nearby enemies");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.buffType = BuffType<Buffs.BloodBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 18000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
    //____________________________________________________

    public class ShroomitePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Reservation Potion");
            Tooltip.SetDefault("Grants a 75% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.ShroomiteBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.Moonglow, 2);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //______________________________________________________________________
    public class SpectrePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Empowerment Potion");
            Tooltip.SetDefault("Increases maximum mana by 60");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.SpectreBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ectoplasm, 3);
            recipe.AddIngredient(ItemID.Waterleaf, 2);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    //______________________________________________________________________
    public class BeetlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Penetration Potion");
            Tooltip.SetDefault("Increases armor penetration of all melee weapons by 25");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.BeetleBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.AddIngredient(ItemID.Fireblossom, 2);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
    

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //____________________________________________________

    public class SpookyPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spooky Curse Potion");
            Tooltip.SetDefault("Increases Minion damage and knockback by 10%");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.SpookyBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.SpookyWood, 40);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }


}