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
    public class SpaceRockHelmet : ModItem
    { //Offense
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Extra-Terrestrial Helmet");
            Tooltip.SetDefault("12% increased damage and critical strike chance");
        }
  
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.12f;
            player.meleeCrit += 12;
            player.rangedCrit += 12;
            player.magicCrit += 12;
            player.thrownCrit += 12;
          

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            if (player.HasBuff(mod.BuffType("SpaceRockOffence")))
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
            return body.type == ItemType<SpaceRockChestplate>() && legs.type == ItemType<SpaceRockLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Rain down meteors upon attacked foes";
            //player.AddBuff(mod.BuffType("SpaceRockOffence"), 1);
            player.GetModPlayer<StormPlayer>().spaceRockOffence = true;
           

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    //__________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class SpaceRockMask : ModItem
    { //Defence
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Extra-Terrestrial Mask");
            Tooltip.SetDefault("6% increased damage and critical strike chance\nIncreases max life by 25 and grants immunity to knockback");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.06f;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;
            player.noKnockback = true;
            player.statLifeMax2 += 25;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            if (player.HasBuff(mod.BuffType("SpaceRockDefence")))
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
            return body.type == ItemType<SpaceRockChestplate>() && legs.type == ItemType<SpaceRockLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants the Oribtal Barrier buff that reduces damage of the next attack by 22%\nSummons meteors from the sky when damaged";
           
                player.GetModPlayer<StormPlayer>().spaceRockDefence = true;



        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class SpaceRockChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Extra-Terrestrial Chestplate");
            Tooltip.SetDefault("7% increased damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.07f;
            player.meleeCrit += 7;
            player.rangedCrit += 7;
            player.magicCrit += 7;
            player.thrownCrit += 7;
            

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 22);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class SpaceRockLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Extra-Terrestrial Leggings");
            Tooltip.SetDefault("7% increase damage and critical strike chance\n100% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0,  10, 0, 0);
            item.rare = 9;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.07f;
            player.meleeCrit += 7;
            player.rangedCrit += 7;
            player.magicCrit += 7;
            player.thrownCrit += 7;
            player.moveSpeed += 1f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
   

}