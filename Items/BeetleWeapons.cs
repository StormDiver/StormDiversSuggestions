using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class BeetleShellWeapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Beetle Shell");
            Tooltip.SetDefault("Summons beetles on impact that attack and swarm your foes");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }
        public override void SetDefaults()
        {
            
            item.damage = 70;
            item.melee = true;
            item.width = 20;
            item.height = 22;
           
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("BeetleShellProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noMelee = true;

        }
        /* public override bool AltFunctionUse(Player player)
         {
             return true;
         }
         public override bool CanUseItem(Player player)       
         {

             if (player.altFunctionUse == 2)
             {
                 item.useTime = 30;
                 item.useAnimation = 30;

             }
             else
             {
                 item.useTime = 12;
                 item.useAnimation = 12;

             }
             return player.ownedProjectileCounts[item.shoot] < 8;
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);
            /*for (int i = 0; i < 3; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(18)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }*/
                return true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("TurtleShellWeapon"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //__________________________________________________________________
    public class BeetleSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Lance");
            Tooltip.SetDefault("Summons beetles that attack and swarm your foes");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            //item.crit = 0;
            item.melee = true;
            item.width = 40;
            item.height = 60;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("BeetleSpearProj");
            item.shootSpeed = 8f;
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
            /* projshoot++;
             if (projshoot >= 2)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                 Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("TurtleProj"), (int)(damage * 1.5), knockBack, player.whoAmI);
                 Main.PlaySound(SoundID.NPCHit, (int)player.Center.X, (int)player.Center.Y, 24);
                 projshoot = 0;
             }*/
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("TurtleSpear"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //___________________________________________________________________________________
    public class BeetleYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Thorax");
            Tooltip.SetDefault("Summons beetles that attack and swarm your foes");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 30;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.damage = 85;
            //item.crit = 0;
            item.melee = true;
            item.width = 20;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.channel = true;
            item.useTurn = true;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("BeetleYoyoProj");
            // item.shootSpeed = 9f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }



        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /* projshoot++;
             if (projshoot >= 2)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                 Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("TurtleProj"), (int)(damage * 1.5), knockBack, player.whoAmI);
                 Main.PlaySound(SoundID.NPCHit, (int)player.Center.X, (int)player.Center.Y, 24);
                 projshoot = 0;
             }*/
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("TurtleYoyo"));
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}