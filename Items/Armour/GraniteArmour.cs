using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class GraniteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Mask");
            Tooltip.SetDefault("2% increased melee damage and critical strike chance");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 2;
            player.meleeDamage += 0.02f;

        }

        public override void ArmorSetShadows(Player player)
        {
            if (player.HasBuff(mod.BuffType("GraniteBuff")))
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
            return body.type == ItemType<GraniteChestplate>() && legs.type == ItemType<GraniteGreaves>();

        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Holding down the 'Armor Special Ability' hotkey while grounded grants damage resistance but lowers movement speed";

            if (StormDiversSuggestions.ArmourSpecialHotkey.Current && player.velocity.Y == 0)
            {
                         
                player.AddBuff(mod.BuffType("GraniteBuff"), 2);

            }

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/GraniteMask_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class GraniteChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Chestplate");
            Tooltip.SetDefault("4% increased melee damage\n10% increased melee speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 18);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
      
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class GraniteGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Granite Greaves");
            Tooltip.SetDefault("2% increased damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.02f;
            player.meleeCrit += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 15);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
    //__________________________________________________________________________________________________________________________
   

}