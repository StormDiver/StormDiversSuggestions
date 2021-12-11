using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class AncientStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Sandblast Staff");
            Tooltip.SetDefault("Creates an explosive blast of sand at the cursor's location");
            Item.staff[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1 , 0, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useTurn = false;
            //item.channel = true;
            item.magic = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item78;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("AncientStaffProj");
            
            item.shootSpeed = 1f;

            item.mana = 10;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool CanUseItem(Player player)
        {
            if (Collision.CanHitLine(Main.MouseWorld, 1, 1, player.position, player.width, player.height))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 0);
        }*/

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.FossilOre, 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
      

    }
    //______________________________________________________________________________________________________
    public class AncientKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Throwing Knives");
            Tooltip.SetDefault("Throw out serveral knives at once that pierce after spinning");

        }
        public override void SetDefaults()
        {
            item.damage = 18;
            item.melee = true;
            item.width = 10;
            item.height = 10;
            item.maxStack = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("AncientKnivesProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            { 

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                //Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 40);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.FossilOre, 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //_______________________________________________________________________________
    public class AncientFlame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Sandblaster");
            Tooltip.SetDefault("Fires out a stream of burning sand\nUses gel for ammo");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {

            item.width = 40;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 7;
            item.useAnimation = 24;

            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item20;

            item.damage = 16;
            item.knockBack = 0.2f;
            item.shoot = mod.ProjectileType("AncientFlameProj"); 

            item.shootSpeed = 2.5f;

            item.useAmmo = AmmoID.Gel;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override void HoldItem(Player player)
        {
            player.armorPenetration = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.FossilOre, 15);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .50f;
        }
    }
}