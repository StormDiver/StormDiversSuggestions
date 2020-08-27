using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.OresandBars
{
    public class IceBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Bar");
            Tooltip.SetDefault("Used in the creation of a frosty armour and weapons");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 79;
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 5;
            item.useStyle = 1;
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
    public class IceOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Ore");
            Tooltip.SetDefault("Retrived from the frozen caves\nVery cold, but strangly mallable");

        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 5;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.createTile = TileType<IceOrePlaced>();
            item.consumable = true;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(mod.GetItem("IceBar"));
            recipe.AddRecipe();

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (StormWorld.SpawnIceOre)
                {
                    //if (npc.type == NPCID.IceTortoise || npc.type == NPCID.IceElemental || npc.type == NPCID.IcyMerman || npc.type == NPCID.ArmoredViking || npc.type == NPCID.PigronHallow || npc.type == NPCID.PigronCorruption || npc.type == NPCID.PigronCrimson)
                    if (!Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneOverworldHeight && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
                    {
                        if (Main.rand.Next(2) == 0)

                        {
                            if (Main.expertMode)

                           
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceOre"), Main.rand.Next(2, 4));
                            }

                            else
                            {
                               
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceOre"), Main.rand.Next(1, 4));
                              
                            }
                        }
                    }
                }
               
            }
        }
    }
    //___________________________________________________________________________
    public class IceOrePlaced : ModTile
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
            soundType = 21;
            soundStyle = 1;
            mineResist = 4f;
            minPick = 100;
        }


    }
}