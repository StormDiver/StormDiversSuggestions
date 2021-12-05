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
    public class SkyKnightMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Star Warrior Visage");
            Tooltip.SetDefault("Increases your max number of sentries by 1\n2% increased damage");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
            player.maxTurrets += 1;
        }

        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;

            player.armorEffectDrawOutlines = true;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SkyKnightChest>() && legs.type == ItemType<SkyKnightGreaves>();

        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Summons a floating star above you that launches mini homing stars at enemies";


            player.GetModPlayer<StormPlayer>().skyKnightSet = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 10);
            recipe.AddIngredient(ItemID.SunplateBlock, 14);  
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool DrawHead()
        {
            return false;
        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class SkyKnightChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Star Warrior Platemail");
            Tooltip.SetDefault("5% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.05f;
         
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 18);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 15);
            recipe.AddIngredient(ItemID.SunplateBlock, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
      
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class SkyKnightGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Star Warrior Greaves");
            Tooltip.SetDefault("Increases your max number of sentries by 1\n3% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1 ,0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {

            player.maxTurrets += 1;

            player.allDamage += 0.03f;
           
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 12);
            recipe.AddIngredient(ItemID.SunplateBlock, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
         
    }
    //__________________________________________________________________________________________________________________________
   

}