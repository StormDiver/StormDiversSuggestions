using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
	public class FrostSpinner : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blizzard Baton"); 
			Tooltip.SetDefault("Spins with the power of a small blizzard\nKnocks enemies in the direction you're facing and inflicts CryoBurn");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

		public override void SetDefaults() 
		{
			item.damage = 38;
            
			item.melee = true;
			item.width = 50;
			item.height = 74;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 100;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item7;
			item.autoReuse = false;
            item.useTurn = false;
            item.channel = true;
            item.knockBack = 3f;
            item.shoot = mod.ProjectileType("FrostSpinProj");
            item.shootSpeed = 1f;
            item.noMelee = true; 
            item.noUseGraphic = true; 
            
        }
        public override bool UseItemFrame(Player player)     //this defines what frame the player use when this weapon is used
        {
            player.bodyFrame.Y = 3 * player.bodyFrame.Height;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_______________________________________________________________________________
    public class FrostStar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Frizbee");
            Tooltip.SetDefault("Throws out a frizbee that shatters on impact");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {

            item.damage = 44;
            item.melee = true;
            item.width = 30;
            item.height = 38;
            item.useTime = 18;
            item.useAnimation = 18;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.shootSpeed = 14f;
            item.shoot = mod.ProjectileType("FrostStarProj");
            //item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noMelee = true;

        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    //_______________________________________________________________________________
    public class FrostLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Launcher");
            Tooltip.SetDefault("Fires out impact-exploding grenades that inflict CryoBurn\nRequires Prototype Grenades, purchase more from the Demolitionist");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;
            item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.useAmmo = ItemType<Ammo.ProtoGrenade>();
            item.UseSound = SoundID.Item61;

            item.damage = 40;
            //item.crit = 4;
            item.knockBack = 3f;
            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            for (int i = 0; i < 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostGrenadeProj"), (int)(damage * 1f), knockBack, player.whoAmI);
                Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 61);

            }



            return false;
        }

        /* public override bool ConsumeAmmo(Player player)
         {
             return Main.rand.NextFloat() >= .33f;
         }*/
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
    //_______________________________________________________________________________
    public class Frostthrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryofreezer");
            Tooltip.SetDefault("Fires out frozen gas which inflicts CryoBurn\nUses gel for ammo");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {

            item.width = 40;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 8;
            item.useAnimation = 26;

            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item20;

            item.damage = 22;
            item.knockBack = 0.25f;
            item.shoot = mod.ProjectileType("Frostthrowerproj"); ;

            item.shootSpeed = 3f;

            item.useAmmo = AmmoID.Gel;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("IceBar"), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .50f;
        }
    }
}