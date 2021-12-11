using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items
{
    public class StickyLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Bomb Launcher");
            Tooltip.SetDefault("Fires out up to 16 Spiky Bombs that stick to surfaces can be detonated by right clicking while holding the weapon\nRight clicking while holding down will unstick all bombs and make them explode on enemy impact" +
                "\nShoots further depending on your cursor location\nRequires Spiky Bombs, purchase more from the Demolitionist");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 20;
            item.useAnimation = 20;
            //item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = false;
        
            item.ranged = true;
            item.shoot = mod.ProjectileType("StickyBombProj");
            item.useAmmo = ItemType<Ammo.StickyBomb>();
            item.UseSound = SoundID.Item61;
        
            item.damage = 80;
            //item.crit = 4;
            item.knockBack = 3f;
            item.shootSpeed = 10;
            item.noMelee = true; //Does the weapon itself inflict damage?
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than 16 bombs
            return player.ownedProjectileCounts[item.shoot] < 16;
        }
        float shootvelo = 1; //Speed multiplers

        public override bool UseItem(Player player)
        {

            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            float shootToX = Main.MouseWorld.X - player.Center.X;
            float shootToY = Main.MouseWorld.Y - player.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            shootvelo = distance / 500f + 0.2f; //Faster shoot speed at further distances
            if (shootvelo > 1.5f) //Caps the speed multipler at 1.5x
            {
                shootvelo = 1.5f;
            }
            if (shootvelo < 0.5f) // Caps low end at 0.5x
            {
                shootvelo = 0.5f;
            }

            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * shootvelo, speedY * shootvelo, mod.ProjectileType("StickyBombProj"), damage, knockBack, player.whoAmI);
                Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 61);

            }

           
            
            return false;
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("ProtoLauncher"), 1);
            recipe.AddIngredient(ItemID.SoulofMight, 12);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddIngredient(ItemID.SoulofSight, 12);
            recipe.AddIngredient(ItemID.Gel, 25);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)

                {
                    if (npc.type == NPCID.SkeletonCommando || npc.type == NPCID.SkeletonSniper || npc.type == NPCID.TacticalSkeleton) //Not 100% sure when to drop yet
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StickyLauncher"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StickyBomb"), Main.rand.Next(25, 41));

                    }
                }
            }
        }

    }
}
 