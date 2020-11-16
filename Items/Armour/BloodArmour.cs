using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class BloodHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hemoglobin Helmet");
            Tooltip.SetDefault("7% increased melee critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 2;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {

            player.meleeCrit += 7;
        }

        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;
            if (Main.rand.Next(4) == 0)     //this defines how many dust to spawn
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = player.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, player.width, player.height, 5, 0f, 0f, 0, new Color(255, 255, 255), 1f)];

            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<BloodChainmail>() && legs.type == ItemType<BloodGreaves>();

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Multiple damaging blood orbs explode out of you upon striking an enemy with a melee weapon";

            //player.endurance += 0.1f;

            player.GetModPlayer<StormPlayer>().BloodDrop = true;
   
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class BloodChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hemoglobin Breastplate");
            Tooltip.SetDefault("7% increased melee damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 2;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {

            player.meleeDamage += 0.07f;
         
      
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 18);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 18);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
       
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class BloodGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Hemoglobin Greaves");
            Tooltip.SetDefault("12% increased melee and movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = 2;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.12f;
            player.moveSpeed += 0.12f;
           
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 15);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //__________________________________________________________________________________________________________________________
   

}