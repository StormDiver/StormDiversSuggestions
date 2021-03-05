using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class StargazerLaser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stargazer Core");
            Tooltip.SetDefault("Summons a floating Stardust Portal that fires piercing projectiles at nearby enemies in bursts");
            
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useTurn = false;
            //item.channel = true;
            item.summon = true;

            item.UseSound = SoundID.Item78;

            item.damage = 75;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("StargazerCoreProj");
            
            item.shootSpeed = 0f;

            item.mana = 10;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;

            return true;
        }
       
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.StardustSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StargazerLaser"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerLaser_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);


            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}