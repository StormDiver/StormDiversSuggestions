using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class StoneThrowerHard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Launcher MKII");
            Tooltip.SetDefault("An upgraded stone launcher which makes stone far more deadly\nRequires Miniature Boulders to work");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 45, 0, 0);
            item.rare = 6;
            item.useStyle = 5;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;
            item.damage = 50;
            item.ranged = true;
            item.shoot = mod.ProjectileType("StoneHardProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item61;

            
            //item.crit = 0;
            item.knockBack = 8f;

            item.shootSpeed = 13f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X), (int)(perturbedSpeed.Y), mod.ProjectileType("StoneHardProj"), damage, knockBack, player.whoAmI);
            

            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StoneThrower"), 1);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        /*public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("StoneShot")) && NPC.downedMechBoss3 && NPC.downedMechBoss2 && NPC.downedMechBoss1) 
                            
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("StoneThrowerHard"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }*/
    }
}