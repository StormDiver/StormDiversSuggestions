using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class ContestArmourHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Mask");
            Tooltip.SetDefault("Created by Storm Diver Omega");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 50, 0, 0);
            item.rare = -12;

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ContestArmourChestplate>() && legs.type == ItemType<ContestArmourLeggings>();
        }
        int particle = 10;
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;
            {
                particle--;
                if (particle <= 0)
                {
                    int dustIndex = Dust.NewDust(new Vector2(player.position.X + 1f, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                    Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;

                    particle = 10;
                }

            }
        }

        
       
    }
    //_________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class ContestArmourChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Chestplate");
            Tooltip.SetDefault("Created by Storm Diver Omega");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(1, 0, 0, 0);
            item.rare = -12;

        }
        
    }
    //_________________________________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class ContestArmourLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryogenic Greaves");
            Tooltip.SetDefault("Created by Storm Diver Omega");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            Item.sellPrice(0, 75, 0, 0);
            item.rare = -12;

        }
      
    }
}