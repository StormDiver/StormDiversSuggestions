using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class EyeofDungeon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of the Dungeon");
            Tooltip.SetDefault("Summons homing spinning bones from where you stand");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;

            item.defense = 2;
            item.accessory = true;
        }


        int skulltime = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.statLife = 1;

            skulltime++;
            
            

            if (skulltime >=40)
            {
                
               
                int damage = 16;
                float speedX = 0f;
                float speedY = -24f;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BoneAcProj"), damage, 3f, player.whoAmI);
                
                skulltime = 0;
            }
        }
       
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.CursedSkull)
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(100) < 8)

                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeofDungeon"));
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(100) < 5)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EyeofDungeon"));
                        }
                    }
            }
        }
    }
}