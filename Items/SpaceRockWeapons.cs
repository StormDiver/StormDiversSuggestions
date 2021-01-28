using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    //Actually SpaceGlobe but can't rename without issues
    public class SpectreGlobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteorite Globe");
            Tooltip.SetDefault("Summons a meteorite at the cursor's location that explodes into fragments");
            
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.useStyle = 4;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            //item.channel = true;
            item.magic = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item78;

            item.damage = 55;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("SpaceGlobeProj");
            
            item.shootSpeed = 0f;

            item.mana = 14;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;

            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 14); 
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    //________________________________________________________________
    public class SpaceRockSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comet Blade");
            Tooltip.SetDefault("Rains down meteor fragments from the sky");
        }

        public override void SetDefaults()
        {
            item.damage = 75;

            item.melee = true;
            item.width = 40;
            item.height = 50;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
            item.scale = 1.3f;
            item.knockBack = 6;
            item.shoot = mod.ProjectileType("SpaceSwordProj");
            item.shootSpeed = 8f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(1) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 100, default, 1.5f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1 + Main.rand.Next(2);

            for (int index = 0; index < numberProjectiles; ++index)
                {
                    Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(150) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                    vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-250, 251); //Spawn Spread
                    vector2_1.Y -= (float)(100 * index);
                    float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                    float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                    if ((double)num13 < 0.0) num13 *= -1f;
                    if ((double)num13 < 20.0) num13 = 20f;
                    float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                    float num15 = item.shootSpeed / num14;
                    float num16 = num12 * num15;
                    float num17 = num13 * num15;
                    float SpeedX = num16 + (float)Main.rand.Next(-10, 10) * 0.02f;  //this defines the projectile X position speed and randomnes
                    float SpeedY = num17 + (float)Main.rand.Next(-10, 10) * 0.02f;  //this defines the projectile Y position speed and randomnes
                    Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX * 1.5f, SpeedY * 1.5f, type, (int)(damage * 0.75f), 0.5f, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
                }
                Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 13);
              
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    //____________________________________________________________________
    public class SpaceRockGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Blaster");
            Tooltip.SetDefault("50% Chance not to consume Ammo\nFires out 2 bullets per shot");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }
        public override void SetDefaults()
        {

            item.width = 50;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.useStyle = 5;

            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item40;

            item.damage = 32;
            
            item.knockBack = 2f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 15f;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

      

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            for (int i = 0; i < 2; i++)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                //Main.PlaySound(2, (int)position.X, (int)position.Y, 40);
            }
    
            return false;

        }


        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .5f;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("SpaceRockBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}