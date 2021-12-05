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
    public class DerplingHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Helmet");
            Tooltip.SetDefault("15% increased damage\n10% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.15f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;

            if (player.HasBuff(mod.BuffType("DerpBuff")))
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
            return body.type == ItemType<DerplingBreastplate>() && legs.type == ItemType<DerplingGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increases jump, ascent, and max falling speed\nCreates a large shockwave upon jumping that launches nearby enemies into the air";

            player.GetModPlayer<StormPlayer>().derpJump = true;
         
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

        
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class DerplingBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Breastplate");
            Tooltip.SetDefault("10% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.1f;
            /*player.meleeCrit += 4;
            player.rangedCrit += 4;
            player.magicCrit += 4;
            player.thrownCrit += 4;*/

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
       
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class DerplingGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Greaves");
            Tooltip.SetDefault("10% increased critical strike chance\n25% increased movement speed and immunity to fall damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            //player.allDamage += 0.04f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
            player.moveSpeed += 0.25f;

            player.noFallDmg = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

       
    }
    //__________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class DerplingMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Mask");
            Tooltip.SetDefault("18% increased summoner damage\nIncreases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
       
            player.maxMinions += 1;
            player.minionDamage += 0.18f;

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DerplingBreastplate>() && legs.type == ItemType<DerplingGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increases jump, ascent, and max falling speed\nCreates a large shockwave upon jumping that launches nearby enemies into the air\nIncreases your max number of minions by 2";

            player.maxMinions += 2;

            player.GetModPlayer<StormPlayer>().derpJump = true;


        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

}