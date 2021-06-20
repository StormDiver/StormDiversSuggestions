using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
    public class ShieldKiller : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Globe");
            Tooltip.SetDefault("Removes the shields from all active pillars");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 93;

        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useTurn = false;
            item.autoReuse = false;
                item.shoot = ProjectileID.TowerDamageBolt;
                item.shootSpeed = 0f;

            item.noMelee = true; 
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
           // Main.PlaySound(SoundID.NPCKilled, (int)position.X, (int)position.Y, 59);
            //for (int i = 0; i < 15; i++)
            {
                if (NPC.ShieldStrengthTowerVortex > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerStardust > 0)
                {
                    Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 122);
                    //Projectile.NewProjectile(position.X, position.Y, 0, 0, 629, damage, knockBack, player.whoAmI, NPC.FindFirstNPC(422));

                    NPC.ShieldStrengthTowerVortex = 0;
                    
                    NPC.ShieldStrengthTowerSolar = 0;
                    NPC.ShieldStrengthTowerNebula = 0;
                    NPC.ShieldStrengthTowerStardust = 0;
                    //Projectile.NewProjectile(player.Center.X, player.Bottom.Y, 0, 0, ProjectileID.DD2DarkMageHeal, 0, 0, player.whoAmI);
                    Main.NewText("The Shields guarding the Celestial pillars have been stripped away", 0, 204, 170);
                    
                    for (int i = 0; i < 50; i++)
                    {

                        Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                        int dust2 = Dust.NewDust(player.position, player.width, player.height, 229, 0f, 0f, 200, default, 0.8f);
                        Main.dust[dust2].velocity *= -5f;
                        Main.dust[dust2].noGravity = true;
                        Main.dust[dust2].scale = 1.5f;
                    }
                }
                else
                {
                    Main.PlaySound(SoundID.NPCKilled, (int)position.X, (int)position.Y, 6);
                    for (int i = 0; i < 10; i++)
                    {

                        int dustIndex = Dust.NewDust(new Vector2(player.position.X + 1f, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                        Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustIndex].noGravity = true;
                    }

                    Main.NewText("There are no active shields", 150, 75, 76);
                }
                /*if (NPC.ShieldStrengthTowerSolar > 0)
                {
                    //Projectile.NewProjectile(position.X, position.Y, 0, 0, 629, damage, knockBack, player.whoAmI, NPC.FindFirstNPC(517));
                   
                }
                if ()
                {
                    //Projectile.NewProjectile(position.X, position.Y, 0, 0, 629, damage, knockBack, player.whoAmI, NPC.FindFirstNPC(507));
                    
                }
                if ()
                {
                   //Projectile.NewProjectile(position.X, position.Y, 0, 0, 629, damage, knockBack, player.whoAmI, NPC.FindFirstNPC(493));
                    
                }*/
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 45);
            recipe.AddIngredient(ItemID.FragmentVortex, 45);
            recipe.AddIngredient(ItemID.FragmentNebula, 45);
            recipe.AddIngredient(ItemID.FragmentStardust, 45);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
    }
}