using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace StormDiversSuggestions.Items
{
    public class MeteorSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Saucer Staff");
            Tooltip.SetDefault("Summons a floating saucer that rains down lasers upon enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            //Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.summon = true;
            item.sentry = true;
            item.mana = 10;
            item.UseSound = SoundID.Item60;

            item.damage = 20;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("MeteorSentryProj");

            //item.shootSpeed = 3.5f;
            
           

            item.noMelee = true; 
        }
        public override bool CanUseItem(Player player)
        {
            /*if (Collision.CanHitLine(Main.MouseWorld, 1, 1, player.position, player.width, player.height))
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = Main.MouseWorld;
            
            return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);
         
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //______________________________________
    public class MeteorBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Bow");
            Tooltip.SetDefault("Rains arrows from the sky\nAllows Meteor Arrows to pass through tiles");

        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 40;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useTurn = true;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item9;
            
            item.damage = 20;
            //item.crit = 4;
            item.knockBack = 3f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int index = 0; index < 1; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-20, 20) * 0.02f;  //this defines the projectile X position speed and randomnes
                float SpeedY = num17 + (float)Main.rand.Next(-20, 20) * 0.02f;  //this defines the projectile Y position speed and randomnes
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //_____________________________________________
    //____________________________________________________________________________
    public class MeteorSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Spear");
            Tooltip.SetDefault("Striking an enemy summons 2 meteor fragments from the sky");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.crit = 0;
            item.melee = true;
            item.width = 50;
            item.height = 64;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 0, 40, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("MeteorSpearProj");
            item.shootSpeed = 4f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}