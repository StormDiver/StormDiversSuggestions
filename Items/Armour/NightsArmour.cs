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
            Tooltip.SetDefault("3% increased damage and critical strike chance\n8% reduced mana usage");
        }
   
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.03f;
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.magicCrit += 3;
            player.thrownCrit += 3;
            player.manaCost -= 0.08f;
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
            player.setBonus = "Press the 'Armor Special Ability' hotkey to teleport to the cursor's location within a limited range\nRequires a direct line of sight to work and has a 15 second cooldown"; 

            //player.endurance += 0.1f;
            //player.blackBelt = true;
            player.GetModPlayer<StormPlayer>().twilightSet = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 10);
            recipe.AddIngredient(ItemID.JungleSpores, 6);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(TileID.DemonAltar);
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
            Tooltip.SetDefault("4% increased damage\nSlighlty increased health regeneration");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.04f;
            /*player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.magicCrit += 3;
            player.thrownCrit += 3;*/
            player.lifeRegen += 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 15);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.Bone, 50);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.DemonAltar);
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
            Tooltip.SetDefault("3% increased damage and critical strike chance\n10% increased melee and movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 1 ,0, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            
            player.moveSpeed += 0.1f;
            player.meleeSpeed += 0.1f;
            player.allDamage += 0.03f;
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.magicCrit += 3;
            player.thrownCrit += 3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 12);
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.HellstoneBar, 12);

            recipe.AddTile(TileID.DemonAltar);
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