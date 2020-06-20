using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class FrostLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo grenade Launcher");
            Tooltip.SetDefault("Fires out impact-exploding grenades that inflict frostburn\nRequires Cryo Grenades");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 24;
            item.useAnimation = 24;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.shoot = mod.ProjectileType("IceGrenadeProj");
            item.useAmmo = ItemType<Ammo.IceGrenade>();
            item.UseSound = SoundID.Item61;

            item.damage = 38;
            //item.crit = 4;
            item.knockBack = 3f;
            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            

            for (int i = 0; i < 1; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                Main.PlaySound(2, (int)position.X, (int)position.Y, 61);

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
}
 