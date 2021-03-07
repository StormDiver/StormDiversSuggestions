using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class SpectreStaff2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Orbiter");
            Tooltip.SetDefault("Summons spectre orbs that orbit around you at varying distances\nRight click to launch any orbs at their maximum orbital distance towards the cursor");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.SwingThrow;  
  
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            
            item.magic = true;
    
            item.damage = 60;
      
            item.knockBack = 0f;

            item.useTime = 14;
            item.useAnimation = 14;
            //item.reuseDelay = 20;
            item.shoot = mod.ProjectileType("SpectreStaffSpinProj");
            item.shootSpeed = 4.5f;
            item.mana = 8;
           


            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
            //item.noUseGraphic = true; //When uses no graphic is shown
            //item.channel = true; //Speical conditons when held down
           
        }
       
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 10;
            
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                
                    //Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(12));
                    //Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SpectreStaffSpinProj2"), (int)(damage * 1f), knockBack, player.whoAmI);

            return true;
            }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
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
}