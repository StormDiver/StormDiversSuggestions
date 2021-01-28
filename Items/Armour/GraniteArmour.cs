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
    public class GraniteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Mask");
            Tooltip.SetDefault("Increases critical strike chance by 2%");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 1;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;

        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.HasBuff(mod.BuffType("GraniteBuff")))
            {

                player.armorEffectDrawOutlines = true;
            }
            else
            {
                player.armorEffectDrawOutlines = false;

            }

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<GraniteChestplate>() && legs.type == ItemType<GraniteGreaves>();

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Holding down while grounded grants damage resistance but lowers movement speed";

            if (player.controlDown && player.velocity.Y == 0)
            {
                         
                player.AddBuff(mod.BuffType("GraniteBuff"), 1);

            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class GraniteChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Chestplate");
            Tooltip.SetDefault("Increases damage and critical strike chance by 2%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 1;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 18);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
      
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class GraniteGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Greaves");
            Tooltip.SetDefault("Increases damage by 2%");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 1;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
           
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 15);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
    //__________________________________________________________________________________________________________________________
   

}