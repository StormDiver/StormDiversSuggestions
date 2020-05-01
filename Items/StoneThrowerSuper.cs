using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class StoneThrowerSuper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Launcher MKIII");
            Tooltip.SetDefault("Superheats the boulders and fires 3 at a time\nRequires Miniature Boulders to work");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(3, 50, 0, 0);
            item.rare = 8;
            item.useStyle = 5;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useTurn = false;
            item.autoReuse = false;

         

            item.shoot = mod.ProjectileType("StoneSuperProj");
            item.useAmmo = ItemType<Ammo.StoneShot>();
            item.UseSound = SoundID.Item38;

            
            //item.crit = 0;
            item.knockBack = 8f;

            item.shootSpeed = 14f;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 Center, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            for (int i = 0; i < 3; i++)
            {

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(Center.X, Center.Y, (int)(perturbedSpeed.X), (int)(perturbedSpeed.Y), mod.ProjectileType("StoneSuperProj"), (int)(damage * 3f), knockBack, player.whoAmI);
            }

            return false;
        }

        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Demolitionist:

                        if (Main.LocalPlayer.HasItem(mod.ItemType("StoneShot")) && NPC.downedGolemBoss) 
                            
                        {
                            shop.item[nextSlot].SetDefaults(mod.ItemType("StoneThrowerSuper"));
                            nextSlot++;

                        }

                        break;
                }
            }
        }
    }
}