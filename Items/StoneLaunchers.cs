using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class StoneThrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Launcher");
            Tooltip.SetDefault("Fire out all your unwanted stone at your foes\nRequires Compact Boulders, craft more with stone");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 23;
            item.ranged = true;

            item.shoot = mod.ProjectileType("StoneProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item61;

            
            //item.crit = 0;
            item.knockBack = 6f;

            item.shootSpeed = 7.5f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            speedX = speedX + player.velocity.X;
            speedY = speedY + player.velocity.Y;

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.StoneBlock, 250);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
           
        }
       
    }
    //_______________________________________________________________________________
    public class StoneThrowerHard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Stone Launcher");
            Tooltip.SetDefault("An upgraded stone launcher which makes stone far more deadly\nRequires Compact Boulders, craft more with stone");
        }
        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 7, 50, 0);
            item.rare = ItemRarityID.LightPurple;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 50;
            item.ranged = true;
            item.shoot = mod.ProjectileType("StoneHardProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item61;


            //item.crit = 0;
            item.knockBack = 8f;

            item.shootSpeed = 13f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X) + player.velocity.X, (float)(perturbedSpeed.Y) + player.velocity.Y, mod.ProjectileType("StoneHardProj"), damage, knockBack, player.whoAmI);


            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StoneThrower"), 1);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    //_______________________________________________________________________________
    public class StoneThrowerSuper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Stone Launcher");
            Tooltip.SetDefault("Superheats the boulders and fires 2 to 3 at a time\nRequires Compact Boulders to work, craft more with stone");
        }
        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 32;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 72;
            item.ranged = true;

            item.shoot = mod.ProjectileType("StoneSuperProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item38;


            //item.crit = 0;
            item.knockBack = 8f;

            item.shootSpeed = 14f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(13));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X + player.velocity.X, perturbedSpeed.Y + player.velocity.Y, mod.ProjectileType("StoneSuperProj"), damage, knockBack, player.whoAmI);
            }

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StoneThrowerHard"), 1);
            recipe.AddIngredient(ItemID.ShroomiteBar, 15);
            recipe.AddIngredient(ItemID.SpectreBar, 15);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

    //_______________________________________________________________________________
    public class StoneThrowerSuperLunar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunar Stone Launcher");
            Tooltip.SetDefault("Empowers boulders with the power of the celestial fragments\nRequires Compact Boulders to work, craft more with stone");
        }
        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 32;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 90;
            item.ranged = true;

            item.shoot = mod.ProjectileType("StoneSuperProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item38;

            item.crit = 12;
            item.knockBack = 8f;

            item.shootSpeed = 17f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f) + player.velocity.X, (float)(perturbedSpeed.Y * 1f) + player.velocity.Y, mod.ProjectileType("StoneSolar"), damage, knockBack, player.whoAmI);
                }
            }
            else if (choice == 1)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1.3f) + player.velocity.X, (float)(perturbedSpeed.Y * 1.3f) + player.velocity.Y, mod.ProjectileType("StoneVortex"), damage, knockBack, player.whoAmI);
                }
            }
            else if (choice == 2)
            {
                for (int i = 0; i < 3; i++)
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X) + player.velocity.X, (float)(perturbedSpeed.Y) + player.velocity.Y, mod.ProjectileType("StoneNebula"), damage, knockBack, player.whoAmI);
                }
            }
            else if (choice == 3)
            {

                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X) + player.velocity.X, (float)(perturbedSpeed.Y) + player.velocity.Y, mod.ProjectileType("StoneStardust"), damage, knockBack, player.whoAmI);
                }
            }
            /*for (int i = 0; i < 3; i++)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X), (float)(perturbedSpeed.Y), mod.ProjectileType("StoneSuperProj"), damage, knockBack, player.whoAmI);
            }*/

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StoneThrowerSuper"), 1);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
            recipe.AddIngredient(ItemID.FragmentVortex, 15);
            recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentStardust, 15);
            recipe.AddIngredient(ItemID.LunarBar, 15);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StoneThrowerSuperLunar_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
    }
}