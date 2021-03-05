using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;

namespace StormDiversSuggestions.Items.Potions
{
    public class BloodPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Decay Potion");
            Tooltip.SetDefault("Decays the life of nearby enemies");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 2, 50);
            item.buffType = BuffType<Buffs.BloodBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 18000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 2);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
            
        }
    }
    //____________________________________________________

    public class ShroomitePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Reservation Potion");
            Tooltip.SetDefault("Grants a 50% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.ShroomiteBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
            recipe.AddIngredient(ItemID.Moonglow, 2);
            recipe.AddIngredient(ItemID.DoubleCod);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    public class SpectrePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Empowerment Potion");
            Tooltip.SetDefault("Increases maximum mana by 60");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.SpectreBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Ectoplasm, 3);
            recipe.AddIngredient(ItemID.Waterleaf, 2);
            recipe.AddIngredient(ItemID.PrincessFish);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override Color? GetAlpha(Color lightColor)
        {

            Color color = Color.White;
            color.A = 150;
            return color;

        }
    }
    public class BeetlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Penetration Potion");
            Tooltip.SetDefault("Increases armor penetration of all melee weapons by 30");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 8;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.buffType = BuffType<Buffs.BeetleBuff>(); //Specify an existing buff to be applied when used.
            item.buffTime = 14400; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.AddIngredient(ItemID.Fireblossom, 2);
            recipe.AddIngredient(ItemID.Hemopiranha);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.AddIngredient(ItemID.Fireblossom, 2);
            recipe.AddIngredient(ItemID.Ebonkoi);

            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class BuffedProjs : GlobalProjectile
    {
        /*
        public override bool InstancePerEntity => true;
        int rangedincrease;
        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];
            if (projectile.melee && projectile.friendly)
            {


                if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()) && projectile.owner == Main.myPlayer)
                {
                   
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 98, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                        dust.noGravity = true;

                        
                    }
                }
            }
            if (projectile.ranged && projectile.friendly)
            {
                rangedincrease++;
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()) && projectile.owner == Main.myPlayer)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 59, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                        dust.noGravity = true;
                    }


                    if (rangedincrease == 1)
                    {
                       
                        projectile.knockBack *= 1.5f;
                        projectile.extraUpdates += (int)1f;
                    }
                }
            }
            if (projectile.magic && projectile.friendly)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()) && projectile.owner == Main.myPlayer)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 16, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                        dust.noGravity = true;
                    }
                }
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockBack, bool crit)
        {
            if (projectile.magic && projectile.friendly)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()) && projectile.owner == Main.myPlayer)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        target.AddBuff(mod.BuffType("SpectreDebuff"), 600);
                    }

                }
            }
        }
        public override void OnHitPvp(Projectile projectile, Player target, int damage, bool crit)
        {
            if (projectile.magic && projectile.friendly)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()) && projectile.owner == Main.myPlayer)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        target.AddBuff(mod.BuffType("SpectreDebuff"), 600);
                    }

                }
            }
        }*/

    }
    
}