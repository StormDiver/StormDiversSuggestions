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
    public class DerplingMask : ModItem
    {
        //melee
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Mask");
            Tooltip.SetDefault("16% increased melee damage\n6% increased melee critical strike chance\n15% increased melee speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {

            player.meleeDamage += 0.16f;
            player.meleeCrit += 6;
            player.meleeSpeed += 0.15f;
        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.velocity.Y == 0)
            {
                player.armorEffectDrawShadow = false;
            }
            else
            {
                player.armorEffectDrawShadow = true;

            }

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
            player.setBonus = "Greatly increases jump, ascent, and max falling speed, and grants immunity to fall damage\nCreates a large shockwave upon jumping that launches nearby enemies into the air";

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
    //______________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class DerplingHelmet : ModItem
    {
        //ranged
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Helmet");
            Tooltip.SetDefault("12% increased ranged damage\n10% increased ranged critical strike chance\n20% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {

            player.rangedDamage += 0.12f;
            player.rangedCrit += 10;
            player.ammoCost80 = true;
        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.velocity.Y == 0)
            {
                player.armorEffectDrawShadow = false;
            }
            else
            {
                player.armorEffectDrawShadow = true;

            }
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
            player.setBonus = "Greatly increases jump, ascent, and max falling speed, and grants immunity to fall damage\nCreates a large shockwave upon jumping that launches nearby enemies into the air";

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

    //__________________________________________________________________________________________________________________________

    [AutoloadEquip(EquipType.Head)]
    public class DerplingHeadgear : ModItem
    {
        //magic
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Headgear");
            Tooltip.SetDefault("14% increased magic damage\n7% increased magic critical strike chance\nIncreases maximum mana by 60");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {

            player.magicDamage += 0.14f;
            player.magicCrit += 7;
            player.statManaMax2 += 60;
        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.velocity.Y == 0)
            {
                player.armorEffectDrawShadow = false;
            }
            else
            {
                player.armorEffectDrawShadow = true;

            }
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
            player.setBonus = "Greatly increases jump, ascent, and max falling speed, and grants immunity to fall damage\nCreates a large shockwave upon jumping that launches nearby enemies into the air";

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
    //______________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class DerplingCrown : ModItem
    {
        //summon
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Crown");
            Tooltip.SetDefault("17% increased summoner damage\nIncreases your max number of minions by 1");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {

            player.maxMinions += 1;
            player.minionDamage += 0.17f;

        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.velocity.Y == 0)
            {
                player.armorEffectDrawShadow = false;
            }
            else
            {
                player.armorEffectDrawShadow = true;

            }
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
            player.setBonus = "Greatly increases jump, ascent, and max falling speed, and grants immunity to fall damage\nCreates a large shockwave upon jumping that launches nearby enemies into the air\nIncreases your max number of minions by 2";

            player.maxMinions += 2;

            player.GetModPlayer<StormPlayer>().derpJump = true;


        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
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
            Tooltip.SetDefault("7% increased damage\n6% increased critical strike chance");
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

            player.allDamage += 0.07f;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;

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
            Tooltip.SetDefault("6% increased damage and critical strike chance\n25% increased movement speed");
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
            player.allDamage += 0.06f;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;
            player.moveSpeed += 0.25f;

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
   
}