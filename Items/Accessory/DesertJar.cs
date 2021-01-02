using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.Items.Accessory
{
   
    public class DesertJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pharaoh's Urn");
            Tooltip.SetDefault("Leaves behind a damaging trail of sand when moving fast enough\nAttacking enemies makes you create a small sand blast");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 34;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;


            item.accessory = true;
        }


        int dropdust = 0;
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<StormPlayer>().desertJar = true;

            
            if ((player.velocity.X > 3.5f || player.velocity.X < -3.5f) || (player.velocity.Y > 3.5f || player.velocity.Y < -3.5f))
            {

                dropdust++;
                if (dropdust == 2)
                {
                    
                        //float speedX = 0f;
                        //float speedY = 0f;
                        //Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(180));
                        //float scale = 1f - (Main.rand.NextFloat() * .5f);
                        //perturbedSpeed = perturbedSpeed * scale;

                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("DesertJarProj"), 35, 0f, player.whoAmI);
                        dropdust = 0;

                        //Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 13);
                    
                }
               
               
            }
        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
   
            recipe.AddIngredient(mod, "DesertBar", 10);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}