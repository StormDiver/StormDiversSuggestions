using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
    public class OceanSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Tome");
            Tooltip.SetDefault("Summons an orb of water that splashes on impact");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 7;
            item.UseSound = SoundID.Item20;

            item.damage = 16;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("OceanSpellProj");

            item.shootSpeed = 10f;
            item.scale = 0.9f;
            //item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 15);
            //recipe.AddIngredient(ItemID.SharkFin, 1);
            recipe.AddIngredient(ItemID.Starfish, 3);
            recipe.AddIngredient(ItemID.Seashell, 3);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //_________________________________________________________________
    public class OceanSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Blade");
            Tooltip.SetDefault("Fires out a blast of water each swing");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 38;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = true;
            item.knockBack = 4;
            item.shoot = mod.ProjectileType("OceanSmallProj");
            

            item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), knockBack, player.whoAmI);
            }
            Main.PlaySound(19, (int)player.Center.X, (int)player.Center.Y, 1);


            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 33, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Wet, 300);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Wet, 300);
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 15);
            //recipe.AddIngredient(ItemID.SharkFin, 1);
            recipe.AddIngredient(ItemID.Starfish, 3);
            recipe.AddIngredient(ItemID.Seashell, 3);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    //____________________________________________________________________________________________________________________
    public class OceanGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Gun");
            Tooltip.SetDefault("Fires out pieces of coral that are not affected by water\nRequires Coral Shards");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 9;
            item.useAnimation = 9;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.shoot = mod.ProjectileType("OceanCoralProj");
            item.useAmmo = ItemType<Ammo.OceanShard>();
            item.UseSound = SoundID.Item85;

            item.damage = 9;
            //item.crit = 0;
            item.knockBack = 1f;

            item.shootSpeed = 12f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage), knockBack, player.whoAmI);
            }
            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 15);
            //recipe.AddIngredient(ItemID.SharkFin, 1);
            recipe.AddIngredient(ItemID.Starfish, 3);
            recipe.AddIngredient(ItemID.Seashell, 3);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //__________________________________________________________________
    
}