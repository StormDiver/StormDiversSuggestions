using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
    public class WebStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Web Staff");
            Tooltip.SetDefault("Fires out a blob of web that sticks to surfaces");
            Item.staff[item.type] = true;


        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 34;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 8;
            //item.UseSound = SoundID.Item8;

            item.damage = 18;
         
            item.knockBack = 4f;
            
            item.shoot = mod.ProjectileType("WebProj");

            item.shootSpeed = 10f;
   
            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            
            
                Main.PlaySound(SoundID.NPCKilled, (int)player.Center.X, (int)player.Center.Y, 9);

                {


                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                    Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 1f), (float)(perturbedSpeed.Y * 1f), type, (int)(damage * 1f), knockBack, player.whoAmI);


                }

           
            return false;
        }
        //Also generates in web covered chests
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {

                if (npc.type == NPCID.WallCreeper || npc.type == NPCID.WallCreeperWall)
                {

                    if (Main.rand.Next(200) < 1)

                    {

                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WebStaff"));

                    }


                }
                
            }
        }
    }
    //_____________________________________________________________________________________________________________________________
   
}