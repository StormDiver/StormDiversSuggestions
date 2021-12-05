using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items.Vanitysets
{
    [AutoloadEquip(EquipType.Head)]
    public class ContestArmourHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Mask");
            Tooltip.SetDefault("Cold and Misty");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ContestArmourChestplate>() && legs.type == ItemType<ContestArmourLeggings>();
        }
        int particle = 10;
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;
            {
                particle--;
                if (particle <= 0)
                {
                    int dustIndex = Dust.NewDust(new Vector2(player.position.X + 1f, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;

                    particle = 10;
                }

            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 6);
            recipe.AddIngredient(mod.GetItem("BlueCloth"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/ContestArmourHelmet_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }

    }
    //_________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class ContestArmourChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Chestplate");
            //Tooltip.SetDefault("Concept by Storm Diver");
        }
    
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 10);
            recipe.AddIngredient(mod.GetItem("BlueCloth"), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_________________________________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class ContestArmourLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Greaves");
            //Tooltip.SetDefault("Concept by Storm Diver");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.vanity = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 8);
            recipe.AddIngredient(mod.GetItem("BlueCloth"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

}