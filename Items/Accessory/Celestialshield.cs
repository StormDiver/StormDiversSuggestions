using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
    public class Celestialshield : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Celestial Barrier");
            Tooltip.SetDefault("Grants immunity to debuffs inflicted by extra-terrestrial creatures\nTaking heavy damage greatly increases health regeneration while protecting you\nDuration depends on the amount of damage received");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {

            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
           
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            
        }
       
        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.buffImmune[BuffID.VortexDebuff] = true;
            player.buffImmune[BuffID.Obstructed] = true;
            player.buffImmune[BuffID.Electrified] = true;
            player.buffImmune[mod.BuffType("ScanDroneDebuff")] = true;
            player.buffImmune[mod.BuffType("NebulaDebuff")] = true;
            player.noKnockback = true;
            player.GetModPlayer<StormPlayer>().lunarBarrier = true;

            if (player.statLife <= ((player.statLifeMax2) * 0.5f))
            { 
                
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