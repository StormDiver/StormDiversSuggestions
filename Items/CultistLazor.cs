using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class CultistLazor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Cultist Hood");
            Tooltip.SetDefault("Charge up and fire a damaging laser from this strange cultist hood\nWait, What!?");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;
            item.magic = true;
            //item.UseSound = SoundID.Item13;
            item.channel = true;
            item.damage = 85;
            item.knockBack = 2f;
            item.mana = 10;
            item.shoot = mod.ProjectileType("CultistLazorProj");
            item.shootSpeed = 0f;


            item.noMelee = true; 
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, -4);
        }
       

       
       
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 4)

                {
                    if (npc.type == NPCID.CultistArcherBlue || npc.type == NPCID.CultistDevote || npc.type == NPCID.CultistBoss)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CultistLazor"));
                    }
                }
            }
        }
    }
    


}