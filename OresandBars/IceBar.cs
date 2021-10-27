using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

using StormDiversSuggestions.Items.Materials;

namespace StormDiversSuggestions.OresandBars
{
    public class IceBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Bar");
            Tooltip.SetDefault("Used in the creation of frozen armour and weapons");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 79;
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 24;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.createTile = TileType<IceBarPlaced>();
            item.consumable = true;
            item.autoReuse = true;
        }
       
    }
    //______________________________________________________________________________
    public class IceBarPlaced : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(0, 255, 255), Language.GetText("Frost Bar")); // localized text for "Metal Bar"
        }

        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            int style = t.frameX / 18;
            if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
            {
                Item.NewItem(i * 16, j * 16, 16, 16, ItemType<IceBar>());
            }
            return base.Drop(i, j);
        }
    }
    //___________________________________________________________________________
    
    //___________________________________________________________________________
    public class IceOrePlaced : ModTile //Legacy item, cannot be generated anymore or placed
    {

        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileValue[Type] = 600; // Metal Detector value, see 
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileShine[Type] = 700; // How often tiny dust appear off this tile. Larger is less frequently
            Main.tileMergeDirt[Type] = true;
            //Main.tileMerge[TileID.IceBlock] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Frost Ore");
            AddMapEntry(new Color(0, 255, 255), name);

            dustType = 92;
            drop = ItemType<IceOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            mineResist = 4f;
            minPick = 100;
        }


    }
}