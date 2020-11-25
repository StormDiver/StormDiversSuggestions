using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class HarpyStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Staff");
            Tooltip.SetDefault("Fires out damaging feathers\nHas a chance to fire out a larger spinning feather");
            Item.staff[item.type] = true;


        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 7;
            item.UseSound = SoundID.Item8;

            item.damage = 15;
         
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("HarpyProj");

            item.shootSpeed = 7f;
   
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1.25f), (float)(perturbedSpeed.Y * 1.25f), mod.ProjectileType("HarpyProj2"), (int)(damage * 1.25f), knockBack, player.whoAmI);

                }
            }
            else 
            {
                {

                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), mod.ProjectileType("HarpyProj"), damage, knockBack * 2, player.whoAmI);

                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.GoldBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        /*public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                
                    if (npc.type == NPCID.Harpy )
                    {

                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(25) == 0)

                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HarpyStaff"));
                        }
                    }

                    else
                     if (Main.rand.Next(35) == 0)

                    {
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HarpyStaff"));

                        }
                    
                        
                    }
                }
            }
        }*/
    }
    //_____________________________________________________________________________________________________________________________
    public class HarpyBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Feathered Bow");
            Tooltip.SetDefault("Converts Wooden Arrows into Feather Arrows that ignore gravity");
            
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 16;
            //item.crit = 4;
            item.knockBack = 3f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = mod.ProjectileType("HarpyArrowProj");
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X), (float)(perturbedSpeed.Y), type, damage, knockBack, player.whoAmI);
            /* if (type == ProjectileID.WoodenArrowFriendly || type == ProjectileID.FlamingArrow) 
             {
                 type = mod.ProjectileType("DesertArrowProj");
             }*/

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.GoldBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //_______________________________________________________________
    public class HarpyYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Feather Thrower");
            Tooltip.SetDefault("Lighter than most yoyos");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 25;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            //item.crit = 0;
            item.melee = true;
            item.width = 30;
            item.height = 30;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.channel = true;
            item.useTurn = true;
            item.knockBack = 4f;
            item.shoot = mod.ProjectileType("HarpyYoyoProj");
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
                 Main.PlaySound(3, (int)player.Center.X, (int)player.Center.Y, 24);
                 projshoot = 0;
             }*/
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.GoldBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.PlatinumBar, 8);

            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}