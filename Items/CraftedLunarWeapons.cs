using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
	public class SolarSpin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Blazing Star"); 
			Tooltip.SetDefault("Spins around with the force of a star\nKnocks enemies in the direction you're facing\nHas a chance to reflect basic projectiles when spun");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }

		public override void SetDefaults() 
		{
			item.damage = 140;
            item.crit = 0;
			item.melee = true;
			item.width = 70;
			item.height = 82;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 100;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item116;
			item.autoReuse = false;
           item.useTurn = false;
            item.channel = true;
            item.knockBack = 10f;
            item.shootSpeed = 1f;
            item.shoot = mod.ProjectileType("SolarSpinProj");
           
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
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/SolarSpin");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
    }
    //________________________________________________________________
    
    public class VortexLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Launcher");
            Tooltip.SetDefault("Fires out a barrage of vortex rockets\nRight click to fire a single faster, fully accurate, and more damaging rocket");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;

            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item92;

            item.damage = 45;

            item.knockBack = 5f;

            item.shoot = ProjectileID.RocketI;
            item.shootSpeed = 18f;

            item.useAmmo = AmmoID.Rocket;
            item.useTime = 30;
            item.useAnimation = 30;

            item.noMelee = true; //Does the weapon itself inflict damage?

            //item.glowMask = 194;


        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {


            }
            else
            {


            }
            return base.CanUseItem(player);

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            if (player.altFunctionUse == 2)
            {

                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }

                Vector2 perturbedSpeed = new Vector2(speedX, speedY) * 2.5f;
                for (int i = 0; i < 2; i++)
                {
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X), (float)(perturbedSpeed.Y), mod.ProjectileType("VortexRocketProj2"), (int)(damage * 2f), knockBack, player.whoAmI);
                }

            }
            else
            {

                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
                /*if (type == ProjectileID.RocketI || type == ProjectileID.RocketII || type == ProjectileID.RocketIII || type == ProjectileID.RocketIV)
                {
                    type = mod.ProjectileType("VortexRocketProj");
                }*/
                int numberProjectiles = 5;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("VortexRocketProj"), damage, knockBack, player.whoAmI);
                }
            }

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/VortexLauncher_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
        /*public class ItemUseGlow : GlobalItem
        {
            public Texture2D glowTexture = mod.GetTexture("Items/Glowmasks/VortexLauncher_Glow");
            public int glowOffsetY = 0;
            public int glowOffsetX = 0;
            public override bool InstancePerEntity => true;
            public override bool CloneNewInstances => true;
        }*/
    }
    //________________________________________________________________
    public class NebulaStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Storm");
            Tooltip.SetDefault("Summons nebula flame blasts that explode into many homing bolts");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 12;
            item.UseSound = SoundID.Item20;

            item.damage = 75;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("NebulaStaffProj");

            item.shootSpeed = 5f;

            //item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //position = Main.MouseWorld;





            /* for (int l = 0; l < Main.projectile.Length; l++)
              {                                                                  //this make so you can only spawn one of this projectile at the time,
                  Projectile proj = Main.projectile[l];
                  if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                  {
                      proj.active = false;
                  }
              }*/

            return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/NebulaStaff_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
    }
    //________________________________________________________________
    public class StardustSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Invader Staff");
            Tooltip.SetDefault("Summons a floating Stardust Sentry that launches mini Flow Invaders that home into enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.damage = 100;
            item.knockBack = 3f;
            item.mana = 10;
            item.useTurn = false;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StardustSentryProj");
            item.summon = true;
            item.sentry = true;

            item.noMelee = true;
            item.UseSound = SoundID.Item78;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            position = Main.MouseWorld;

            /* for (int l = 0; l < Main.projectile.Length; l++)
              {                                                                  //this make so you can only spawn one of this projectile at the time,
                  Projectile proj = Main.projectile[l];
                  if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                  {
                      proj.active = false;
                  }
              }*/

            return true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StardustSentry_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw
           (
               texture,
               new Vector2
               (
                   item.position.X - Main.screenPosition.X + item.width * 0.5f,
                   item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
               ),
               new Rectangle(0, 0, texture.Width, texture.Height),
               Color.White,
               rotation,
               texture.Size() * 0.5f,
               scale,
               SpriteEffects.None,
               0f
           );
        }
    }
}