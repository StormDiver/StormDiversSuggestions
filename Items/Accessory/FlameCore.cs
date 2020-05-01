using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items.Accessory
{
    public class FlameCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Betsy's flame");
            Tooltip.SetDefault("Grants infinite flight time");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 6));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
           
            Item.sellPrice(0, 5, 0, 0);
            item.rare = -12;
            item.defense = 5;
            item.accessory = true;
            item.expert = true;
        }
        int particle = 5;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
            player.wingTime *= 2;
            
            //player.AddBuff(BuffID.Inferno, 1);
            
            particle--;
            if (particle <= 0)
                {
                    particle = 5;
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(2, 2));
                    
                    var dust4 = Dust.NewDustDirect(new Vector2(player.position.X + 5f, player.position.Y + 20f), 15, 15, 258);
                   
                }
            /*
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.lavaImmune = true;
            player.magmaStone = true;
            
            if (player.statLife >= (player.statLifeMax2))
            {
                player.allDamage *= 1.5f;
            }
            */
        }
        
       
        

       
    }
}