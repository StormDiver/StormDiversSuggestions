using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace StormDiversSuggestions.Items.Potions
{
    public class BarrierPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endurance Healing Potion");
            Tooltip.SetDefault("Reduces the damage of the next incoming attack by 50%");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 4;
            item.healLife = 99;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.potion = true;
           
        }
        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(mod.BuffType("HeartBarrierBuff"), 1800);
        }
        /* public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
         {

             healValue = 75;
         }*/
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreaterHealingPotion, 3);
            recipe.AddIngredient(mod.GetItem("CrackedHeart"), 1);
            recipe.AddIngredient(ItemID.UnicornHorn);
           

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }

    }
    public class DoubleHealingPotion : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enhanced Healing Potion");
            Tooltip.SetDefault("Potion sickness lasts longer than normal");

        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.mod == "Terraria" && line.Name == "HealLife")
                {
                    line.text = "Restores 50% of your maximum life";
                }

            }
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = 7;
            item.healLife = 90;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.potion = true;

        }
        public override void OnConsumeItem(Player player)
        {
            if (player.pStone)
            {
                player.AddBuff(BuffID.PotionSickness, 4500);
                
            }
            else
            {
                player.AddBuff(BuffID.PotionSickness, 6000);
                
            }
            
        }
         public override void GetHealLife(Player player, bool quickHeal, ref int healValue)
         {
             healValue = (player.statLifeMax2 / 2);
         }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreaterHealingPotion, 3);
            recipe.AddIngredient(mod.GetItem("CrackedHeart"), 1);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }

    }
    public class HeartPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Vial");
            Tooltip.SetDefault("Temporarily increases maximum health by 20");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 3;

            item.value = Item.sellPrice(0, 0, 2, 0);
            item.buffType = BuffType<Buffs.HeartBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 4);
            recipe.AddIngredient(mod.GetItem("CrackedHeart"), 1);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }

    }
    public class FruitHeartPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Fruit Vial");
            Tooltip.SetDefault("Temporarily increases maximum health by 25");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 7;

            item.value = Item.sellPrice(0, 0, 5, 0);
            item.buffType = BuffType<Buffs.FruitHeartBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("HeartPotion"), 3);
            recipe.AddIngredient(ItemID.LifeFruit);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();

        }

    }
}