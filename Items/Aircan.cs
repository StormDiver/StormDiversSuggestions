using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class Aircan : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compressed Air Can");
            Tooltip.SetDefault("Fires out a blast of air that blows enemies away and clears cobwebs");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
            
            item.width = 15;
            item.height = 20;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 0, 50);
            item.rare = 1;
            item.useStyle = 5;
            item.useTime = 8;
            item.useAnimation = 8;
            item.consumable = true;
            item.useTurn = false;
            item.autoReuse = true;

           
            item.UseSound = SoundID.Item13;

            item.damage = 5;
            
            item.knockBack = 4;
            item.shoot = mod.ProjectileType("StompBootProj");
            
            item.shootSpeed = 10f;

            //item.useAmmo = AmmoID.Gel;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override void HoldItem(Player player)
        {
            player.armorPenetration = 20;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 8);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position.X, position.Y, (int)(perturbedSpeed.X * 1), (int)(perturbedSpeed.Y * 1), type, (int)(damage * 1), knockBack * 10, player.whoAmI);
            }

            return false;
        }
        
        public class VanillaShops : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Mechanic:

                        
                            shop.item[nextSlot].SetDefaults(mod.ItemType("Aircan"));
                            nextSlot++;
 

                        break;
                }
            }
        }

    }
}