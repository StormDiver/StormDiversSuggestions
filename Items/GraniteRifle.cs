using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Buffs;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
    public class GraniteRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Rifle");
            Tooltip.SetDefault("Converts regular bullets into Granite Bullets that pierce once");
            
        }
        public override void SetDefaults()
        {
            
            item.width = 50;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.useStyle = 5;
            
            item.useTurn = false;
            item.autoReuse = false;

            item.ranged = true;
        
            item.UseSound = SoundID.Item40;

            item.damage = 20;
            
            item.knockBack = 2f;
       
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true; 
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }




        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("GraniteBulletProj");
            }


            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            //Main.PlaySound(2, (int)position.X, (int)position.Y, 40);


            return false;
        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(60) == 0)
                {
                    if (npc.type == NPCID.GraniteFlyer || npc.type == NPCID.GraniteGolem)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GraniteRifle"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MusketBall, Main.rand.Next(25, 50));

                    }
                }
            }
        }

    }
}