using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using Terraria.Localization;

namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class MushroomMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Shroom Mask");
            Tooltip.SetDefault("3% increased ranged damage\nThere's not mushroom in there");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.03f;
       
        }

        public override void ArmorSetShadows(Player player)
        {
    
                player.armorEffectDrawShadowSubtle = true;
      
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<MushroomChestplate>() && legs.type == ItemType<MushroomGreaves>();

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Has a chance to summon a damaging mushroom into attacked enemies";

            player.GetModPlayer<StormPlayer>().mushset = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(ItemID.GlowingMushroom, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class MushroomChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Shroom Chestplate");
            Tooltip.SetDefault("2% increased ranged damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.02f;
            player.rangedCrit += 2;
       
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 18);
            recipe.AddIngredient(ItemID.GlowingMushroom, 40);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
       
        }
   
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class MushroomGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Shroom Greaves");
            Tooltip.SetDefault("3% increased ranged critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 3;           
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 15);
            recipe.AddIngredient(ItemID.GlowingMushroom, 35);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
    //__________________________________________________________________________________________________________________________
   

}