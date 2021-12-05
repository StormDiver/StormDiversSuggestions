using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;


namespace StormDiversSuggestions.Items
{
	public class MoltenDagger : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Molten Dagger"); 
			Tooltip.SetDefault("Rapidly stab your foes");
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = ItemUseStyleID.Stabbing;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 3;
            item.scale = 1.2f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 2)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 127, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
       
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
    //_______________________________________________________________________________
    public class FlamingSeedLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Seed Launcher");
            Tooltip.SetDefault("Sets seeds ablaze\nObtain more from the Witch Doctor");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 22;
            item.useAnimation = 22;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            //item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.shoot = ProjectileID.Seed;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item64;

            item.damage = 18;
            //item.crit = 4;
            item.knockBack = 3f;
            item.shootSpeed = 13f;
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override void HoldItem(Player player)
        {

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            if (type == ProjectileID.Seed)
            {
                type = mod.ProjectileType("FlamingSeed");
                damage += (damage / 2);
            }

            for (int i = 0; i < 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            }

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public class SeedShop : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.WitchDoctor:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("FlamingSeedLauncher")))
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.Seed);
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
    //_______________________________________________________________________________
    public class LavaSpell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Blast");
            Tooltip.SetDefault("Summons an orb of lava that splashes on impact");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 13;
            item.UseSound = SoundID.Item20;

            item.damage = 24;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("LavaSpellProj");
            item.scale = 0.9f;
            item.shootSpeed = 14f;

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
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    //_______________________________________________________________
    public class FireSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Orb Staff");
            Tooltip.SetDefault("Summons a magma orb sentry that launches bouncing fireballs at enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
            //Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.summon = true;
            item.sentry = true;
            item.mana = 10;
            item.UseSound = SoundID.Item45;

            item.damage = 20;
            //item.crit = 4;
            item.knockBack = 1.5f;

            item.shoot = mod.ProjectileType("MagmaSentryProj");

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
            position.ToTileCoordinates();
            while (!WorldUtils.Find(position.ToTileCoordinates(), Searches.Chain(new Searches.Down(1), new GenCondition[] { new Conditions.IsSolid() }), out _))
            {
                position.Y++;
                position.ToTileCoordinates();
            }
            position.Y -= 34;
            return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}