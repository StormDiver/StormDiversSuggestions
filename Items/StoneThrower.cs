using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class StoneThrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Launcher MKI");
            Tooltip.SetDefault("Fire out all your unwanted stone at your foes\nRequires Compact Boulders to work");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 2;
            item.useStyle = 5;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = false;
            item.damage = 18;
            item.ranged = true;

            item.shoot = mod.ProjectileType("StoneProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item61;

            
            //item.crit = 0;
            item.knockBack = 6f;

            item.shootSpeed = 10f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.StoneBlock, 250);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilMaterial", 25);
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

                        if (Main.LocalPlayer.HasItem(mod.ItemType("StoneShot")) && NPC.downedBoss2) 
                            
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("StoneThrower"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }*/
    }
}