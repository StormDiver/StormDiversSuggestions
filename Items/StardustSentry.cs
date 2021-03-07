using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class StardustSentry : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Invader Staff");
            Tooltip.SetDefault("Summons a floating Stardust Sentry that launches mini Flow Invaders that home into enemies");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 50;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.useTime = 30;
            item.useAnimation = 30;
            item.damage = 100;
            item.knockBack = 3f;
            item.mana = 10;
            item.useTurn = false;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("StardustSentryProj");
            item.summon = true;
            item.sentry = true;
           
            item.noMelee = true;
            item.UseSound = SoundID.Item78;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
                position = Main.MouseWorld;   
               
               /* for (int l = 0; l < Main.projectile.Length; l++)
                 {                                                                  //this make so you can only spawn one of this projectile at the time,
                     Projectile proj = Main.projectile[l];
                     if (proj.active && proj.type == item.shoot && proj.owner == player.whoAmI)
                     {
                         proj.active = false;
                     }
                 }*/
             
                return true;

        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
           
            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();


        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StardustSentry_Glow");


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