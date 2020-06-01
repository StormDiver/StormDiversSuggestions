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
            Tooltip.SetDefault("The true definition of cruelty\n20% increased damage");
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

            player.allDamage += 0.2f;
         
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
            player.setBonus = "Jump like a true Derpling\nGreatly increases take off speed";

            /*
            player.jumpSpeedBoost += 5;
           
            player.autoJump = true;
            
            player.maxRunSpeed += 2;
            */
            //if (!(player.wingTime < player.wingTimeMax))
                if (player.velocity.Y == 0 || player.sliding)
            {
                
                player.AddBuff(mod.BuffType("DerpBuff"), 60);
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
            Tooltip.SetDefault("Hardened shell negates knockback\n21% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.noKnockback = true;
            player.meleeCrit += 21;
            player.rangedCrit += 21;
            player.magicCrit += 21;
            player.thrownCrit += 21;
           
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
            Tooltip.SetDefault("Prevents fall damage\n25% increased melee and movement speed");
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
            player.noFallDmg = true;
            player.meleeSpeed += 0.25f;
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