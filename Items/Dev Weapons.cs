using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	
    public class WepKillerRep : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("OP Repeater");
            Tooltip.SetDefault("THIS IS FOR KILLING THINGS");
        }
        public override void SetDefaults()
        {
            item.width = 15;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(127, 99, 3, 65);
            item.rare = -12;
            item.useStyle = 5;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item113;

            item.damage = 99999;
            item.crit = 400;
            item.knockBack = 30f;

            item.shoot = ProjectileID.Bullet;
            //item.shoot = ProjectileID.GrenadeI;
            item.shootSpeed = 200f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 1f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("Weapontester"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class Weapontester : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Weapon tester");
            Tooltip.SetDefault("Used to test new projectiles");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.buyPrice(127, 00, 00, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useTurn = false;
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            //item.melee = true;
            //item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 1;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("BeetleProj");
            //item.shoot = ProjectileID.Meowmere;
            item.shootSpeed = 10f;

            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
                                 //item.noUseGraphic = true; //When uses no graphic is shown
                                 //item.channel = true; //Speical conditons when held down

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(mod.BuffType("TurtleDebuff"), 120);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(mod.GetItem("WepKillerRep"));
            recipe.SetResult(this);
        recipe.AddRecipe();
        }

}
}