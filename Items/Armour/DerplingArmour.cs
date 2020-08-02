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
            Tooltip.SetDefault("7% increased damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.07f;
            player.meleeCrit += 7;
            player.rangedCrit += 7;
            player.magicCrit += 7;
            player.thrownCrit += 7;

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
            player.setBonus = "Greatly increases take off speed, plus immunity to fall damage";


            //if (!(player.wingTime < player.wingTimeMax))
           
            player.jumpSpeedBoost += 7f;

            player.autoJump = true;
            player.noFallDmg = true;


            player.noFallDmg = true;
    
        
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

        /*
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                    if (npc.type == NPCID.Derpling)
                {
                    if (Main.rand.Next(50) == 0)
                    {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingHelmet"));
                    }
                }
            }
        }*/
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class DerplingBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Breastplate");
            Tooltip.SetDefault("7% increased damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 20;
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
            Tooltip.SetDefault("6% increased damage and critical strike chance\n50% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.06f;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;
            player.moveSpeed += 0.5f;
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
            Tooltip.SetDefault("'The true definition of cruelty'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            //item.defense = 1;
        }

        public override void UpdateEquip(Player player)
        {

           

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DerplingBreastplate>() && legs.type == ItemType<DerplingGreaves>();
        }

        /*public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increases take off speed, plus immunity to fall damage";

     
            //if (!(player.wingTime < player.wingTimeMax))

            player.jumpSpeedBoost += 7f;

            player.autoJump = true;
            player.noFallDmg = true;


            player.noFallDmg = true;


        }*/
       

        
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                    if (npc.type == NPCID.Derpling)
                {
                    if (Main.rand.Next(50) == 0)
                    {

                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DerplingMask"));
                    }
                }
            }
        }
    }

}