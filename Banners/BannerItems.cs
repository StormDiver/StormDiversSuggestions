using Terraria;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Banners          //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class BabyDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Derpling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: BABY DERPLINGS??!!! YOU MONSTER!!!");
        }
        public override void SetDefaults()
        {
            
            item.width = 10;    
            item.height = 24;  
            item.maxStack = 99;  
            item.useTurn = true;
            item.autoReuse = true;  
            item.useAnimation = 15;  
            item.useTime = 10;  
            item.useStyle = 1;  
            item.consumable = true;  
            item.rare = 1; 
            item.value = Item.buyPrice(0, 0, 10, 0);  
            item.createTile = mod.TileType("BabyDerpBannerPlace"); //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class VineDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Camouflaged Derpling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Camouflaged Derpling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("VineDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class ScanDroneBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ScanDrone Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: ScanDrone");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("ScanDroneBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class StormDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stormling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Stormling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("StormDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class VortCannonBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortexian Cannon Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Vortexian Cannon");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("VortCannonBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class NebulaDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brainling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Brainling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("NebulaDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class StardustDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Starling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("StardustDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class SolarDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Blazling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("SolarDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class MoonDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonling Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Moonling");
        }
        public override void SetDefaults()
        {

            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("MoonDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
}

////then add this to the custom npc you want to drop the banner and in public override void SetDefaults()
/*  banner = npc.type;
  bannerItem = mod.ItemType("CustomBannerItem"); //this defines what banner this npc will drop       */
