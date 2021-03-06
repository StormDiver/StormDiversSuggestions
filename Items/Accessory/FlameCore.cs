using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    public class FlameCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Betsy's Flame");
            Tooltip.SetDefault("Grants infinite wing flight\nCreates a burst of flames upon landing with enough speed\n'This came before the Soaring Insignia'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = -12;
           
            item.accessory = true;
            item.expert = true;
        }
        //int particle = 5;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
  
            player.GetModPlayer<StormPlayer>().flameCore = true;
            /*particle--;
            if (particle <= 0)
                {
                    particle = 5;
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                    
                    var dust4 = Dust.NewDustDirect(new Vector2(player.Center.X, player.Center.Y), 0, 0, 258);
                   
                }*/
            
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Burning] = true;
            
            
            
        }
        
       
        

       
    }
}