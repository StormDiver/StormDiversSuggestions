using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	
    public class BloodBoomerang : ModItem
        //Actually BoneBoomerang but can't rename without issues
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Femurang");
            Tooltip.SetDefault("3 can be thrown out at a time\n'What, you thought this was Humerus?'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
    
        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 0;
            item.melee = true;
            item.width = 20;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.value = Item.sellPrice(0, 0, 18, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.useTurn = false;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("BoneBoomerangProj");
            item.shootSpeed = 8f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;

        }
       
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                if (Main.expertMode)
                {
                    if (Main.rand.Next(100) < 1)

                    {
                        if (npc.type == NPCID.Skeleton || npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.HeadacheSkeleton)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodBoomerang"));
                        }
                    }
                }
                else
                {
                    if (Main.rand.Next(200) < 1)

                    {
                        if (npc.type == NPCID.Skeleton || npc.type == NPCID.MisassembledSkeleton || npc.type == NPCID.PantlessSkeleton || npc.type == NPCID.HeadacheSkeleton)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodBoomerang"));
                        }
                    }
                }
            }

        }
        
    }
    
}