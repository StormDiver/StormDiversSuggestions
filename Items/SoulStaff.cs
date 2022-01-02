using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class SoulStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Storm");
            Tooltip.SetDefault("Summons damaging souls around the cursor");
            Item.staff[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightPurple;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useTurn = false;
            //item.channel = true;
            item.magic = true;
            item.autoReuse = true;
            //item.UseSound = SoundID.Item13;

            item.damage = 50;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("SoulFrightProj");
            
            item.shootSpeed = 1f;

            item.mana = 8;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool CanUseItem(Player player)
        {
            /*if (Collision.CanHitLine(Main.MouseWorld, 1, 1, player.Center, 0, 0))
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return true;
        }
        int dusttype;
        float dustscale;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;

            int choice = Main.rand.Next(3);
            if (choice == 0)
            {
                type = mod.ProjectileType("SoulFrightProj");
                dusttype = 259;
                dustscale = 1.1f;
            }
            else if (choice == 1)
            {
                type = mod.ProjectileType("SoulSightProj");
                dusttype = 110;
                dustscale = 0.9f;

            }
            else if (choice == 2)
            {
                type = mod.ProjectileType("SoulMightProj");
                dusttype = 56;
                dustscale = 1;

            }

            //For the radius
            double deg = Main.rand.Next(0, 360); //The degrees
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 250; //Distance away from the player


            position.X = Main.MouseWorld.X - (int)(Math.Cos(rad) * dist);
            position.Y = Main.MouseWorld.Y - (int)(Math.Sin(rad) * dist);

            //For the direction

            float shootToX = Main.MouseWorld.X - position.X;
            float shootToY = Main.MouseWorld.Y - position.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            distance = 3f / distance;
            shootToX *= distance * 7;
            shootToY *= distance * 7;
            int proj = Projectile.NewProjectile(position.X, position.Y, shootToX, shootToY, type, damage, knockBack, Main.myPlayer, 0f, 0f);

            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 8, 0.5f, 0.5f);

            //For the dust
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 66; 
            for (int i = 0; i < 10; i++)
            {

                var dust = Dust.NewDustDirect((player.Center - new Vector2(15, 15)) + muzzleOffset, 30, 30, dusttype, speedX * 10, speedY * 10, 100, default, dustscale);
                dust.noGravity = true;
                dust.velocity *= 0;
            }

            return false;



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
        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 0);
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 16);
            recipe.AddIngredient(ItemID.SoulofMight, 15);
            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddIngredient(ItemID.SoulofFright, 15);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
   
}