using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace StormDiversSuggestions.Items
{
	
    public class LizardFlame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lihzahrd Flamer");
            Tooltip.SetDefault("Fires out a stream of super heated flames that ricohet off tiles and are unaffected by water\nUses gel for ammo");
        }
        public override void SetDefaults()
        {

            item.width = 40;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 8;
            item.useAnimation = 24;
        
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item34;

            item.damage = 45;
            item.knockBack = 0.5f;
            item.shoot = mod.ProjectileType("LizardFlameProj");

            item.shootSpeed = 5f;

            item.useAmmo = AmmoID.Gel;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /*if (!NPC.downedPlantBoss)
            {
                for (int i = 0; i < 10; i++)
                {

                    int dustIndex = Dust.NewDust(new Vector2(player.position.X + 1f, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                }

                player.statLife = 1;
                player.statMana = 0;
                player.velocity.X = 0;
                player.statDefense = 0;
                player.endurance = 0;
                player.lifeRegen = 0;
                    Main.NewText("Defeat the Plantera you cheater >:(", 100, 100, 100);
                    Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 16);

               
                return false;
           
            }
            else
            {
                
                return true;
            }*/
            return true;
         }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (!Main.expertMode)
                {
                    if (Main.rand.Next(100) < 10)
                    {

                        if (npc.type == NPCID.Golem)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LizardFlame"));
                        }

                    }
                }
            }
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .50f;
        }
    }
}