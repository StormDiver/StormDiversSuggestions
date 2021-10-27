using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    
    //_________________________________________________________________
    public class MushroomSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shrooword");
            Tooltip.SetDefault("Fires out a spinning mushroom each spin\n'There's not mushroom to stand around'");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 38;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 4;
            item.shoot = ProjectileID.Mushroom;
            item.shootSpeed = 35f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)(damage * 1f), knockBack, player.whoAmI);


            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 113, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
           
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
           
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 10);
            recipe.AddIngredient(ItemID.GlowingMushroom, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/MushroomSword_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //______________________________________
    public class MushroomBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroom Bow");
            Tooltip.SetDefault("Fires out 2 arrows at once");

        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 40;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 9;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
       
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            for (int i = 0; i < 2; i++)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                //Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 10);
            recipe.AddIngredient(ItemID.GlowingMushroom, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/MushroomBow_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //__________________________________________________
    public class MushroomStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushy Staff");
            Tooltip.SetDefault("Summons a ricocheting mushroom");
            Item.staff[item.type] = true;
        
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 7;
            item.UseSound = SoundID.Item8;

            item.damage = 19;

            item.knockBack = 5f;

            item.shoot = mod.ProjectileType("MagicMushProj");

            item.shootSpeed = 9f;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 10);
            recipe.AddIngredient(ItemID.GlowingMushroom, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/MushroomStaff_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
}