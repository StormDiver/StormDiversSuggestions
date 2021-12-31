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
    public class SoulBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Striders");
            Tooltip.SetDefault("Greatly increases movement speed and acceleration, and allows flight\n'Speed throughout the day and the night'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 4));
            ItemID.Sets.SortingPriorityMaterials[item.type] = 67;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;

        }
        int soundDelay = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //if (player.HeldItem.melee)
            {
                player.maxRunSpeed = (9f);
                player.runAcceleration *= 4f;
                player.rocketBoots = 2;
                player.moveSpeed = 1;
                if (player.moveSpeed > 1)
                {
                    player.moveSpeed = 1;

                }
                if ((player.velocity.X > 5 || player.velocity.X < -5) && (player.velocity.Y == 0) && (player.controlLeft || player.controlRight) && !player.mount.Active)
                {
                    if (Main.dayTime)
                    {
                        if (Main.rand.Next(1) == 0)
                        {
                            Dust dust;
                            dust = Dust.NewDustDirect(new Vector2(player.Center.X - 5, player.Bottom.Y - 6), 10, 0, 58, 0, -1);
                            //dust.noGravity = true;
                            dust.scale = 1.25f;
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(1) == 0)
                        {
                            Dust dust;
                            dust = Dust.NewDustDirect(new Vector2(player.Center.X - 5, player.Bottom.Y - 6), 10, 0, 27, 0, -1);
                            //dust.noGravity = true;
                            dust.scale = 1.25f;
                        }
                    }
                    if (Main.rand.Next(1) == 0)
                    {


                        int dustSmoke = Dust.NewDust(new Vector2(player.Center.X, player.Bottom.Y - 5), 5, 5, 31, 0f, -2f, 0, default, 1f);
                        Main.dust[dustSmoke].scale = 0.5f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustSmoke].fadeIn = 3f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustSmoke].noGravity = true;
                        Main.dust[dustSmoke].velocity *= 0.1f;
                    }

                    soundDelay++;
                    if (soundDelay >= 6)
                    {
                        Main.PlaySound(SoundID.Run, (int)player.Center.X, (int)player.Center.Y);
                        soundDelay = 0;
                    }




                }

            }
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpectreBoots, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }


    }
}