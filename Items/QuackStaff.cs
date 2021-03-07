using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class QuackStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duck Fracture");
            Tooltip.SetDefault("Fires out mini ducks to attack your foes\n'May be prone to quacking'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 9;
            

            item.damage = 44;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("QuackProj");

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
            for (int i = 0; i < 3; i++)
            {
                float posX = position.X + Main.rand.NextFloat(35f, -35f);
                float posY = position.Y + Main.rand.NextFloat(10f, -40f);

                Projectile.NewProjectile(posX, posY, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            Main.PlaySound(SoundID.Duck, (int)player.position.X, (int)player.position.Y);


            return false;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("Quack"), 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 8);
            recipe.AddIngredient(ItemID.SoulofSight, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 8);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
       
    }
}