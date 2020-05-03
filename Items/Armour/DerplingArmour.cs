using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;

namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class DerplingHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Derpling Mask");
            Tooltip.SetDefault("The true definition of cruelty\n8% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 3, 0, 0);
            item.rare = 7;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.08f;
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
            player.setBonus = "Jump like a true Derpling\nGets stronger the lower your health";

            /*
            player.jumpSpeedBoost += 5;
           
            player.autoJump = true;
            
            player.maxRunSpeed += 2;
            */
            if (player.statLife >= ((player.statLifeMax2) * 0.66f))
            {
                
                player.AddBuff(mod.BuffType("DerpBuff"), 1);
            }
            if (player.statLife <= ((player.statLifeMax2) * 0.66f) && player.statLife >= ((player.statLifeMax2) * 0.33f))
            {

                player.AddBuff(mod.BuffType("DerpBuffLv2"), 1);
            }
            if (player.statLife <= ((player.statLifeMax2) * 0.33f))
            {

                player.AddBuff(mod.BuffType("DerpBuffLv3"), 1);
            }

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
            Tooltip.SetDefault("Hardened shell negates knockback\n7% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.noKnockback = true;
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
            Tooltip.SetDefault("Super bouncy, prevents fall damage\n15% increased melee and movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.noFallDmg = true;
            player.meleeSpeed += 0.15f;
            player.moveSpeed += 0.15f;

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