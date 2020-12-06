using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class EnchantedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Blade of Light");
            Tooltip.SetDefault("Summons mini Enchanted Swords that charge at the cursor and pierce\n'Not to be confused with The Blade of Night'");
            Item.staff[item.type] = true;
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = 5;
            item.useStyle = 5;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = false;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 45;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("EnchantedSwordProj");
            
            item.shootSpeed = 1f;

            item.mana = 10;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
           
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
                if (Main.rand.Next(25) == 0)
                {
                    if (npc.type == NPCID.EnchantedSword)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnchantedSword"));
                        
                    }
                }
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlwoodSword);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddIngredient(ItemID.CrystalShard, 25);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}