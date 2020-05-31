using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    [AutoloadEquip(EquipType.Shoes)]
    public class BeetleBoot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beetle Boots");
            Tooltip.SetDefault("Greatly Increased movement speed and flight time while holding any melee weapon\n25% increased melee speed");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;

            Item.sellPrice(0, 20, 0, 0);
            item.rare = 8;
            item.defense = 12;
            item.accessory = true;
            
        }
        int soundDelay = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 0.25f;
            if (player.HeldItem.melee)
            {

                
                player.maxRunSpeed *= 2.5f;
                player.runAcceleration *= 4;
                player.wingTimeMax += (int)0.5f;

               if ((player.velocity.X > 5 || player.velocity.X < -5) && (player.velocity.Y == 0 || player.sliding))
                {
                  

                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = Main.LocalPlayer.Bottom;
                    dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 179, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;



                    soundDelay++;
                    if (soundDelay >= 5 )
                    {
                        Main.PlaySound(17, (int)player.Center.X, (int)player.Center.Y);
                        soundDelay = 0;
                    }
                }
            }

        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 12);
            recipe.AddIngredient(ItemID.TurtleShell, 2);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}