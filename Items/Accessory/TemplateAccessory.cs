using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class TemplateAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of the Dungeon");
            Tooltip.SetDefault("Increased critical strike chance by 8%");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = 2;

            item.defense = 2;
            item.accessory = true;
        }


        //int skulltime = 200;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.statLife = 1;
            
           
            
            player.rangedCrit += 8;
            player.magicCrit += 8;
            player.meleeCrit += 8;
            player.thrownCrit += 8;

           /* if (skulltime <=0)
            {
                skulltime = 200;
                int damage = 40;
                float speedX = 0f;
                float speedY = 0f;

                Projectile.NewProjectile(player.position.X, player.position.Y, speedX, speedY, mod.ProjectileType("Primeheadspin"), (int)(damage * 1.25), 0f);
            }*/
        }
        /*
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            float speedX = -player.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
            float speedY = -player.velocity.Y * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-16f, 16f);
            

            Projectile.NewProjectile(player.position.X + speedX, player.position.Y + speedY, speedX, speedY, mod.ProjectileType("Rangedmushroom"), (int)(damage * 1.25), 0f);
        }
        */
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.DarkCaster)
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(15) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TemplateAccessory"));
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(20) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TemplateAccessory"));
                        }
                    }
            }
        }
    }
}