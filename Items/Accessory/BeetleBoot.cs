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
            Tooltip.SetDefault("Greatly increases movement speed and immunity frames while holding any melee weapon\nGrants 10% damage reduction and immunity to knockback while running on the ground");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;

            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 8;
            item.defense = 10;
            item.accessory = true;
            
        }
        int soundDelay = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
           
            if (player.HeldItem.melee)
            {

                player.longInvince = true;
                player.maxRunSpeed *= 2f;
                player.runAcceleration *= 2f;
                

               if ((player.velocity.X > 5 || player.velocity.X < -5) && (player.velocity.Y == 0 || player.sliding))
                {
                    player.noKnockback = true;
                    player.endurance += 0.1f;
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
            recipe.AddIngredient(ItemID.HermesBoots);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 12);
            recipe.AddIngredient(ItemID.FlurryBoots);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 12);
            recipe.AddIngredient(ItemID.SailfishBoots);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}