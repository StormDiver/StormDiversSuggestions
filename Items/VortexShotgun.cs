using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class VortexShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Diver Shotgun");
            Tooltip.SetDefault("Stolen from the Legendary Storm Divers");
        }
        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 10;
            item.useStyle = 5;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item36;

            item.damage = 120;
            item.crit = 20;
            item.knockBack = 5f;

            item.shoot = ProjectileID.MoonlordBullet;
            item.shootSpeed = 15f;

            item.useAmmo = AmmoID.Bullet;
          

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(1); ; //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
           {
              Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        
    }
    public class ModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(40) == 0)
            {
                if (npc.type == NPCID.VortexRifleman)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexShotgun"));
                }
            }
        }
    }
}