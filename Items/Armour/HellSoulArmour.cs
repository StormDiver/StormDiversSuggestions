using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)] //melee helmet
    public class HellSoulMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Mask");
            Tooltip.SetDefault("14% increased melee damage\n5% increased melee critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 21;
        }

        public override void UpdateEquip(Player player)
        {

            player.meleeDamage += 0.14f;
            player.meleeCrit += 5;

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
            if (Main.rand.Next(4) == 0)
            {
                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                dust.scale = 1.4f;
            }

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HellSoulChestplate>() && legs.type == ItemType<HellSoulLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases melee speed by 25%\nEnemies struck with any projectile will create a burst of homing souls";

            player.GetModPlayer<StormPlayer>().hellSoulSet = true;
            player.meleeSpeed += 0.25f;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulMask_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)] //Ranged helmet
    public class HellSoulHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Helmet");
            Tooltip.SetDefault("10% increased ranged damage\n8% increased ranged critical strike chance");
        }
    
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
                     item.rare = ItemRarityID.LightPurple;
            item.defense = 10;
        }
   
        public override void UpdateEquip(Player player)
        {
        
            player.rangedDamage += 0.10f;
            player.rangedCrit += 8;

        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
            if (Main.rand.Next(4) == 0)
            {
                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                dust.scale = 1.4f;
            }

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HellSoulChestplate>() && legs.type == ItemType<HellSoulLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "20% chance not to consume ammo\nEnemies struck with any projectile will create a burst of homing souls";

            player.GetModPlayer<StormPlayer>().hellSoulSet = true;
            player.ammoCost80 = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulHelmet_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }

    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)] //magic helmet
    public class HellSoulHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Hood");
            Tooltip.SetDefault("12% increased magic damage\n6% increased critical strike chance\nIncreases maximum mana by 40");
        }
    
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
        
            player.magicDamage += 0.12f;
            player.magicCrit += 6;
            player.statManaMax2 += 40;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
            if (Main.rand.Next(4) == 0)
            {
                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                dust.scale = 1.4f;
            }

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HellSoulChestplate>() && legs.type == ItemType<HellSoulLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "18% reduced mana usage\nEnemies struck with any projectile will create a burst of homing souls";

            player.GetModPlayer<StormPlayer>().hellSoulSet = true;
            player.manaCost -= 0.18f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulHood_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Head)] //summoner helmet
    public class HellSoulCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Crown");
            Tooltip.SetDefault("10% increased summoner damage\nIncreases maximum number of minions by 1");
        }
    
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 2;
        }
    
        public override void UpdateEquip(Player player)
        {

            player.minionDamage += 0.10f;
            player.maxMinions += 1;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
            if (Main.rand.Next(4) == 0)
            {
                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                dust.scale = 1.4f;
            }
       
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<HellSoulChestplate>() && legs.type == ItemType<HellSoulLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases maximum number of minions by 2\nEnemies struck with any projectile will create a burst of homing souls";

            player.GetModPlayer<StormPlayer>().hellSoulSet = true;
            player.maxMinions += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 15);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulCrown_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    
    public class HellSoulChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Breastplate");
            Tooltip.SetDefault("7% increased damage\n6% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 17;
        }

        public override void UpdateEquip(Player player)
        {

            player.allDamage += 0.07f;
            player.rangedCrit += 6;
            player.meleeCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulChestplate_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class HellSoulLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("HellSoul Greaves");
            Tooltip.SetDefault("5% increased damage\n6% increased critical strike chance\n25% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.05f;
            player.rangedCrit += 6;
            player.meleeCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;

            player.moveSpeed += 0.25f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SoulFire"), 17);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulLeggings_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }

    }
    
}