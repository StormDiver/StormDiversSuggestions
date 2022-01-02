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
            DisplayName.SetDefault("Asteroid Helmet");
            Tooltip.SetDefault("15% increased damage\n8% increased critical strike chance");
        }
  
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.15f;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.thrownCrit += 8;
            Lighting.AddLight(player.Center, Color.White.ToVector3() * 0.4f);
        
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
            player.setBonus = "Grants the Orbital Strike buff that causes asteroid fragments to fall upon the next attacked enemy";
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
        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
    //__________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class SpaceRockMask : ModItem
    { //Defence
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Asteroid Mask");
            Tooltip.SetDefault("5% increased damage\n2% increased critical strike chance\nIncreases health regeneration and grants immunity to knockback");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.05f;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;
            player.noKnockback = true;
            player.lifeRegen += 2;
            Lighting.AddLight(player.Center, Color.White.ToVector3() * 0.4f);

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
            player.setBonus = "Grants the Orbital Defense buff that reduces damage of the next attack by 25% while summoning damaging asteroid fragments from the sky";
           
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
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class SpaceRockChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Asteroid Chestplate");
            Tooltip.SetDefault("7% increased damage\n5% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.07f;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
            Lighting.AddLight(player.Center, Color.White.ToVector3() * 0.4f);


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 22);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class SpaceRockLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Asteroid Leggings");
            Tooltip.SetDefault("6% increased damage\n5% increased critical strike chance\n50% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0,  10, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.06f;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;
            player.moveSpeed += 0.5f;
            Lighting.AddLight(player.Center, Color.White.ToVector3() * 0.4f);

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
   

}