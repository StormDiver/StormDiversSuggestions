using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;

namespace StormDiversSuggestions.Items.Potions
{
    public class ShroomitePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ranged Enhancement Potion");
            Tooltip.SetDefault("Increases the velocity and knockback of most ranged projectiles");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
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
            recipe.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe.AddIngredient(ItemID.Moonglow, 3);
            recipe.AddIngredient(ItemID.DoubleCod);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    public class SpectrePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Enhancement Potion");
            Tooltip.SetDefault("All magic projectiles can inflict a damaging debuff on enemies");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
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
            recipe.AddIngredient(ItemID.Ectoplasm, 4);
            recipe.AddIngredient(ItemID.Waterleaf, 3);
            recipe.AddIngredient(ItemID.PrincessFish);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
    public class BeetlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Melee Enhancement Potion");
            Tooltip.SetDefault("Increases armor penetration of all melee weapons by 40");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
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
            recipe.AddIngredient(ItemID.BeetleHusk, 3);
            recipe.AddIngredient(ItemID.Fireblossom, 3);
            recipe.AddIngredient(ItemID.Hemopiranha);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.BeetleHusk, 3);
            recipe.AddIngredient(ItemID.Fireblossom, 3);
            recipe.AddIngredient(ItemID.Ebonkoi);

            recipe.AddTile(TileID.AlchemyTable);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    public class BuffedProjs : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        int rangedincrease;
        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];
            if (projectile.melee && projectile.friendly)
            {


                if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()))
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
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
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
                        /*if (projectile.penetrate >= 1)
                        {
                            projectile.penetrate = (projectile.penetrate + 1);
                        }

                        projectile.usesLocalNPCImmunity = true;
                        projectile.localNPCHitCooldown = 10;*/
                        projectile.knockBack *= 1.5f;
                        projectile.extraUpdates += (int)1f;
                    }
                }
            }
            if (projectile.magic && projectile.friendly)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
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
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
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
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        target.AddBuff(mod.BuffType("SpectreDebuff"), 600);
                    }

                }
            }
        }

    }
    
}