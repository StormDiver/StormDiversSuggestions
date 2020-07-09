using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Items.Accessory
{
    public class Celestialshield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial barrier");
            Tooltip.SetDefault("Grants immunity to debuffs inflicted by the strongest of enemies\nProtects you when below 33% life");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            Item.sellPrice(0, 0, 50, 0);
            item.rare = 10;
            item.defense = 10;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            
        }
       
        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.buffImmune[BuffID.VortexDebuff] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Blackout] = true;
            player.buffImmune[BuffID.Electrified] = true;
        
            player.noKnockback = true;
            
            
            if (player.statLife <= ((player.statLifeMax2) * 0.33f))
            {
                player.AddBuff(mod.BuffType("CelestialBuff"), 1);
                
            }
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();

           
        }
        

       
    }
}