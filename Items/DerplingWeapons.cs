using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class DerplingSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Derpling Sword"); 
			Tooltip.SetDefault("Fire out multiple Derpling Shell Shards every other swing");
		}

		public override void SetDefaults() 
		{
			item.damage = 80;
         
			item.melee = true;
			item.width = 40;
			item.height = 50;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 6;
            item.shoot = mod.ProjectileType("DerpMeleeProj");
            item.shootSpeed = 15f;
        }
        int weaponattack = 2;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            weaponattack--;
            if (weaponattack <= 0)
            {
                int numberProjectiles = 2 + Main.rand.Next(3); //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), knockBack, player.whoAmI);
                }
                Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 22);
                weaponattack = 2;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    //_______________________________________________________________________
    public class DerplingGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Rifle");
            Tooltip.SetDefault("I know it looks cruel, but it had to be done\nFour round burst, only the first shot consumes ammo");
        }
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 4;
            item.useAnimation = 16;
            item.reuseDelay = 13;
            item.useTurn = false;
            item.autoReuse = true;
            //item.UseSound = SoundID.Item38;
            item.ranged = true;


            item.damage = 35;
            item.crit = 6;
            item.knockBack = 2f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, -3);
        }

        //int secondfire = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;

        }

        public override bool ConsumeAmmo(Player player)
        {
            // Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
            // We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_________________________________________________________________________
    public class DerplingStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Scepter");
            Tooltip.SetDefault("Rapidly fires out magical Derpling Shell Shards\nHas a small chance to fire out a larger shard that homes and explodes into smaller shards");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 7;
            item.useAnimation = 7;
            item.autoReuse = true;
            // item.UseSound = SoundID.Item43;
            item.magic = true;
            item.damage = 48;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item13;
            item.shoot = mod.ProjectileType("DerpMagicProj2");
            item.shootSpeed = 18f;
            item.mana = 5;

            item.noMelee = true; //Does the weapon itself inflict damage?

        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int choice = Main.rand.Next(10);
            if (choice == 0)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * .6f), (float)(perturbedSpeed.Y * .6f), mod.ProjectileType("DerpMagicProj"), (int)(damage), knockBack, player.whoAmI);
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 20);

                }
            }
            else
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("DerpMagicProj2"), damage, knockBack, player.whoAmI);

                }
            }
            return false;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}