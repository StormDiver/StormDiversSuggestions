using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class MossRepeater : ModItem
    {
        //Actually MechanicalRepeater but can't rename without issues

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mossy Repeater");
            Tooltip.SetDefault("Seems a little old and neglected, but should still work");
        }
        public override void SetDefaults()
        {
            item.width = 45;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            //item.UseSound = SoundID.Item5;
        
            item.damage = 22;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;

            item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        float pitch;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 15;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            float scale = 1f - (Main.rand.NextFloat() * .4f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);

            pitch = scale - 1;
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 5, 1, pitch);
            
            return false;
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)

                {
                    if (npc.type == NPCID.Hornet || npc.type == NPCID.HornetFatty || npc.type == NPCID.HornetHoney || npc.type == NPCID.HornetLeafy || npc.type == NPCID.HornetSpikey || npc.type == NPCID.HornetStingy)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MossRepeater"));
                    }
                }
            }
        }
    }
}