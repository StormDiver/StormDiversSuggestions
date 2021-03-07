using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items
{
    public class PredictorBrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Predictor Brain");
            Tooltip.SetDefault("Summons projectiles that charge towards the cursor");
            
            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 80;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("PredictorBrainProj");
            
            item.shootSpeed = 5f;

            item.mana = 13;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
           
           /* for (int i = 0; i < 5; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }*/
            speedX = 0f;
            speedY = -10f;
            for (int i = 0; i < 5; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(135));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 1f, player.whoAmI);
            }
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
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.NebulaSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PredictorBrain"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorBrain_Glow");


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