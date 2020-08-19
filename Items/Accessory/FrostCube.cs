using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;
using StormDiversSuggestions.Buffs;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace StormDiversSuggestions.Items.Accessory
{

    public class FrostCube : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner's Heart");
            Tooltip.SetDefault("Increases your max number of minions by 2 while holding any summoner weapon and for 3 seconds afterwards\nIncreases minion damage by 8%");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 92;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 8;

            item.accessory = true;

        }
        int minioncap = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.HeldItem.summon)
            {
                minioncap = 180;


            }
            else
            {
                minioncap--;
            }
            if (minioncap > 0)
            {
                player.GetModPlayer<StormPlayer>().frostCube = true;
            }
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.IceQueen)
                {
                    if (Main.expertMode)
                    {
                        if (Main.rand.Next(8) == 0)
                        {

                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostCube"));
                        }
                    }
                    if (!Main.expertMode)
                    {
                        if (Main.rand.Next(10) == 0)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostCube"));
                        }
                    }
                }
            }
        }



    }
    public class FrostCubeProjs : GlobalProjectile
    {
        /*public override bool InstancePerEntity => true;
       
        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];
            if (projectile.minion && projectile.friendly)
            {
                if (player.GetModPlayer<StormPlayer>().frostCube == true)
                {



                    if (Main.rand.Next(3) == 0)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = projectile.position;
                        dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 16, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                        dust.noGravity = true;
                    }

                    //projectile.extraUpdates = (int)1f;


                }
                
            
            }
            else
            {
                if (projectile.type != ProjectileID.DeadlySphere &&
                   projectile.type != ProjectileID.Spazmamini)
                {
                    projectile.extraUpdates = 0;
                }
            }
        }*/
    }
}