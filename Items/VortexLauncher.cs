using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class VortexLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Launcher");
            Tooltip.SetDefault("Fires out a barrage of vortex rockets, right click to fire a single more damaging rocket");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }
        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.useStyle = 5;
           
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item92;

            item.damage = 65;
            
            item.knockBack = 5f;

            item.shoot = ProjectileID.RocketI;
            item.shootSpeed = 9f;
           
            item.useAmmo = AmmoID.Rocket;
            item.useTime = 28;
            item.useAnimation = 28;

            item.noMelee = true; //Does the weapon itself inflict damage?
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
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 55f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
                if (type == ProjectileID.RocketI || type == ProjectileID.RocketII || type == ProjectileID.RocketIII || type == ProjectileID.RocketIV)
                {
                    type = mod.ProjectileType("VortexRocketProj2");
                }
                Vector2 perturbedSpeed = new Vector2(speedX, speedY) * 4f;
                   
                    Projectile.NewProjectile(position.X, position.Y, (int) (perturbedSpeed.X), (int)(perturbedSpeed.Y), type, (int)(damage * 2.5f), knockBack, player.whoAmI);
                
            }
            else
            {
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
                if (type == ProjectileID.RocketI || type == ProjectileID.RocketII || type == ProjectileID.RocketIII || type == ProjectileID.RocketIV)
                {
                    type = mod.ProjectileType("VortexRocketProj");
                }
               
                for (int i = 0; i < 2; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
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
    }
    
}