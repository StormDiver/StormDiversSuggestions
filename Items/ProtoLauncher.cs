using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class ProtoLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prototype Launcher");
            Tooltip.SetDefault("Fires out impact-exploding grenades that have a small chance to prematurely explode into shrapnel\nRequires Prototype Grenades, purchase more from the Demolitionist");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 3;
            item.useStyle = 5;
            item.useTime = 30;
            item.useAnimation = 30;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;

            item.shoot = mod.ProjectileType("ProtoGrenadeProj");
            item.useAmmo = ItemType<Ammo.ProtoGrenade>();
            item.UseSound = SoundID.Item61;

            item.damage = 30;
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
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.PlaySound(2, (int)position.X, (int)position.Y, 61);

            }

           
            
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.Bone, 100);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
       
       /* public class VanillaShops : GlobalNPC
       {
           public override void SetupShop(int type, Chest shop, ref int nextSlot)
           {
               switch (type)
               {
                   case NPCID.Demolitionist:

                       if (Main.LocalPlayer.HasItem(mod.ItemType("ProtoLauncher")))
                       {
                           shop.item[nextSlot].SetDefaults(mod.ItemType("ProtoLauncher"));
                           nextSlot++;

                       }

                       break;
               }
           }
       }*/
   }
}
 