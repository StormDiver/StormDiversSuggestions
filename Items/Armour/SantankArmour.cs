using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions;


namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class SantankMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Santank Mask");
            Tooltip.SetDefault("15% increased ranged damage\n5% increased ranged critical strike chance");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 5;
            Lighting.AddLight(player.Center, Color.White.ToVector3() * 0.4f);

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            if (player.HasBuff(mod.BuffType("SantankBuff3")))
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
            return body.type == ItemType<SantankChestplate>() && legs.type == ItemType<SantankGreaves>();

        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Charge up to 10 homing missiles over time, pressing the 'Armor Special Ability' hotkey will fire however many are loaded"; 

            player.GetModPlayer<StormPlayer>().santankSet = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class SantankChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Santank Chestplate");
            Tooltip.SetDefault("10% increased ranged damage and critical strike chance\n25% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {

            player.rangedDamage += 0.1f;
            player.rangedCrit += 10;
            player.ammoCost75 = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class SantankGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Santank Greaves");
            Tooltip.SetDefault("8% increased ranged damage\n6% increased ranged critical strike chance\n25% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5 ,0, 0);
            item.rare = ItemRarityID.Yellow;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            
            player.moveSpeed += 0.25f;
            player.rangedDamage += 0.08f;
            player.rangedCrit += 6;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SantankScrap"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    //__________________________________________________________________________________________________________________________
   

}