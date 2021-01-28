using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Buffs;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
    public class GraniteRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Rifle");
            Tooltip.SetDefault("Converts regular bullets into Granite Bullets that pierce once");
            
        }
        public override void SetDefaults()
        {
           
            item.width = 50;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.useStyle = 5;
            
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;
        
            item.UseSound = SoundID.Item40;

            item.damage = 17;
            
            item.knockBack = 2f;
       
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 8f;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; 
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }




        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("GraniteBulletProj");
            }


            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            //Main.PlaySound(2, (int)position.X, (int)position.Y, 40);


            return false;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }

    }
    //___________________________________________
    public class GraniteSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Spear");
            Tooltip.SetDefault("Every third stab sends out a small energy bolt");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.crit = 0;
            item.melee = true;
            item.width = 50;
            item.height = 64;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = false;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("GraniteSpearProj");
            item.shootSpeed = 3.5f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        int fireproj;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            fireproj++;
            if (fireproj >= 3)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 2f), (float)(perturbedSpeed.Y * 2f), mod.ProjectileType("GraniteSpearProj2"), (int)(damage * 1f), knockBack, player.whoAmI);
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 8);
                fireproj = 0;
            }
            //Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);

            return true;
        }
    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
    //__________________________________________________
    public class GraniteStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Scepter");
            Tooltip.SetDefault("Fires out a bunch of energy bolts");
            Item.staff[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 32;
            item.useAnimation = 32;
            item.useTurn = false;
            item.autoReuse = false;

            item.magic = true;
            item.mana = 10;
            item.UseSound = SoundID.Item8;

            item.damage = 19;

            item.knockBack = 3f;

            item.shoot = mod.ProjectileType("GraniteStaffProj");
           
            item.shootSpeed = 10f;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 2 + Main.rand.Next(2);

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:GoldBars", 12);
            recipe.AddIngredient(mod.GetItem("GraniteCore"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}