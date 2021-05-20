using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class DestroyerFlail : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Vaporiser");
            Tooltip.SetDefault("Launches out an unchained ball every throw");
        }
    
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.crit = 4;
           
            item.knockBack = 6f;
            item.damage = 65;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.noMelee = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("DestroyerFlailProj");
            item.shootSpeed = 24f;
            item.channel = true;
            item.noUseGraphic = true;
        }
      
       
       
        //int shoot = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //Vector2 perturbedSpeed = new Vector2(speedX, speedY);
            //Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.4), (float)(perturbedSpeed.Y * 0.4), mod.ProjectileType("DestroyerFlailProj2"), (int)(damage * 1.4), knockBack, player.whoAmI);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/DestroyerFlail_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }

    //_______________________________________________________________________________
    public class SawBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Shredder");
            Tooltip.SetDefault("Shreds any enemy that it comes into contact with\nEmits sparks that linger on the ground");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.crit = 10;
            item.melee = true;
            item.width = 60;
            item.height = 26;
            item.useTime = 10;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.knockBack = 1.5f;

            item.useTurn = true;
            item.shoot = mod.ProjectileType("SawBladeChain");
            item.shootSpeed = 50f;
            item.axe = 30;
            item.tileBoost = 2;
            item.UseSound = SoundID.Item23;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;


        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Chain, 20);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/SawBlade_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //_______________________________________________________________________________
    public class TheSeeker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Seeker");
            Tooltip.SetDefault("Summons explosive bolts that can be guided towards the cursor when holding right click\nRequires Seeker Bolts, craft more with Souls of Sight");
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.shoot = mod.ProjectileType("SeekerBoltProj");
            item.useAmmo = ItemType<Ammo.SeekerBolt>();
            item.UseSound = SoundID.Item11;

            item.damage = 45;
            //item.crit = 0;
            item.knockBack = 6f;

            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ExplosivePowder, 20);
            recipe.AddIngredient(ItemID.SoulofSight, 20);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/TheSeeker_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
    //_______________________________________________________________________________
    public class PrimeStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Obliterator");
            Tooltip.SetDefault("Fires out spinning skulls that will home onto any enemy they touch");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 52;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;

            item.autoReuse = true;
            item.UseSound = SoundID.Item43;

            item.magic = true;

        
            item.damage = 40;
            item.knockBack = 4f;

            item.useTime = 25;
            item.useAnimation = 25;
            item.mana = 12;
            item.shoot = mod.ProjectileType("SkullSeek");
            item.shootSpeed = 16f;

            item.useStyle = ItemUseStyleID.HoldingOut;

            item.noMelee = true;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 48f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 20);
            recipe.AddIngredient(ItemID.UnicornHorn, 2);
            recipe.AddIngredient(ItemID.SoulofFright, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PrimeStaff_Glow");

            spriteBatch.Draw(texture, new Vector2(item.position.X - Main.screenPosition.X + item.width * 0.5f, item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f),
                new Rectangle(0, 0, texture.Width, texture.Height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
        }
    }
}