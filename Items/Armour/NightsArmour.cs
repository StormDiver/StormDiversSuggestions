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
    public class NightsHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Twilight Hood");
            Tooltip.SetDefault("6% increased damage\n10% increased critical strike chance");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.06f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            //player.armorEffectDrawOutlines = true;
           

            
            if (player.GetModPlayer<StormPlayer>().twilightcharged == true)
            {
                player.armorEffectDrawOutlines = true;
                if (Main.rand.Next(4) == 0)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 62, 0, -5);
                    dust.scale = 0.8f;
                    dust.noGravity = true;
                }
            }
            else
            {
                player.armorEffectDrawOutlines = false;
            }
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<NightsChainmail>() && legs.type == ItemType<NightsGreaves>();

        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Press the 'Armor Special Ability' hotkey to teleport to the cursor's location within a limited range\nWarping has a hard 12 second cooldown"; 

            //player.endurance += 0.1f;
            //player.blackBelt = true;
            player.GetModPlayer<StormPlayer>().twilightSet = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(mod.GetItem("ChaosShard"), 2);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();

          

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/NightsHelmet_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class NightsChainmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Twilight Robe");
            Tooltip.SetDefault("6% increased damage\nSlighlty increases player acceleration");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 11;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.06f;
            player.runAcceleration += 0.1f;
            //player.lifeRegen += 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 9);
            recipe.AddIngredient(mod.GetItem("ChaosShard"), 3);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/NightsChainmail_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class NightsGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Twilight Leggings");
            Tooltip.SetDefault("2% increased damage and critical strike chance\nSlightly increases jump speed and height");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1 ,50, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 9;
        }

        public override void UpdateEquip(Player player)
        {

            player.jumpSpeedBoost += 0.75f;
            player.allDamage += 0.02f;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 18);
            recipe.AddIngredient(ItemID.SoulofNight, 7);
            recipe.AddIngredient(mod.GetItem("ChaosShard"), 2);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/NightsGreaves_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //__________________________________________________________________________________________________________________________
   

}