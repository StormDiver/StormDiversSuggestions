using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);  
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
            item.createTile = mod.TileType("ScanDroneBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class StormDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Hopper Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Storm Hopper");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
            item.createTile = mod.TileType("VortCannonBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class NebulaDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brain Hopper Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Brain Hopper");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
            item.createTile = mod.TileType("NebulaDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class StardustDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Hopper Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Star Hopper");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
            item.createTile = mod.TileType("StardustDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class SolarDerpBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Hopper Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Blazing Hopper");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0); 
            item.createTile = mod.TileType("MoonDerpBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class SpaceRockHeadBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Orbiter Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Asteroid Orbiter");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("SpaceRockHeadBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class SpaceRockHeadLargeBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteroid Charger Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Asteroid Charger");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("SpaceRockHeadLargeBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class GladiatorMiniBossBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Champion Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Fallen Champion");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("GladiatorMiniBossBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class GraniteMiniBossBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Surged Granite Core Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Surged Granite Core");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("GraniteMiniBossBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class HellSoulBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heartless Soul Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Heartless Soul");
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
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("HellSoulBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class MushroomMiniBossBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angry Mushroom Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Angry Mushroom");
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
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("MushroomMiniBossBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
    public class GolemMinionBannerItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temple Guardian Banner");
            Tooltip.SetDefault("Nearby players get a bonus against: Temple Guardian");
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
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("GolemMinionBannerPlace");  //This defines what type of tile this item will place	
            item.placeStyle = 0;
        }
    }
}

////then add this to the custom npc you want to drop the banner and in public override void SetDefaults()
/*  banner = npc.type;
  bannerItem = mod.ItemType("CustomBannerItem"); //this defines what banner this npc will drop       */
