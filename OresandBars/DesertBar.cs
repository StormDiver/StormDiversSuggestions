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
    public class DesertBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Bar");
            Tooltip.SetDefault("Used in the creation of some forbidden armour and weapons");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 80;
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            Item.sellPrice(0, 0, 30, 0);
            item.rare = 5;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.createTile = TileType<DesertBarPlaced>();
            item.consumable = true;
            item.autoReuse = true;
        }
     
        //_____________________________________________________________________________________________________________
        public class DesertBarPlaced : ModTile
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

                AddMapEntry(new Color(204, 132, 0), Language.GetText("Arid Bar")); // localized text for "Metal Bar"
            }

            public override bool Drop(int i, int j)
            {
                Tile t = Main.tile[i, j];
                int style = t.frameX / 18;
                if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
                {
                    Item.NewItem(i * 16, j * 16, 16, 16, ItemType<DesertBar>());
                }
                return base.Drop(i, j);
            }
        }
    }
    //____________________________________________________________________________________________________
    public class DesertOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arid Ore");
            Tooltip.SetDefault("Retrived from the deserted caves");

        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            Item.sellPrice(0, 0, 10, 0);
            item.rare = 5;
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.createTile = TileType<DesertOrePlaced>();
            item.consumable = true;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(mod.GetItem("DesertBar"));
            recipe.AddRecipe();

        }


        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (StormWorld.SpawnDesertOre)
                {
                    // if (npc.type == NPCID.DesertBeast || npc.type == NPCID.DesertScorpionWalk || npc.type == NPCID.DesertScorpionWall || npc.type == NPCID.DesertGhoul || npc.type == NPCID.DesertLamiaDark || npc.type == NPCID.DesertLamiaLight || npc.type == NPCID.DesertGhoulHallow || npc.type == NPCID.DesertGhoulCorruption || npc.type == NPCID.DesertGhoulCrimson)
                    if (!Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneOverworldHeight && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUndergroundDesert)
                    {
                        if (Main.rand.Next(3) == 0)

                        {
                            if (Main.expertMode)


                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertOre"), Main.rand.Next(3, 6));
                            }

                            else
                            {

                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertOre"), Main.rand.Next(2, 5));

                            }
                        }
                    }
                }
               
            }
        }
    }
    //____________________________________________________________________________________
    public class DesertOrePlaced : ModTile
    {

        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
            Main.tileValue[Type] = 600; // Metal Detector value
            Main.tileShine2[Type] = true; // Modifies the draw color slightly.
            Main.tileShine[Type] = 700; // How often tiny dust appear off this tile. Larger is less frequently
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Arid Ore");
            AddMapEntry(new Color(204, 132, 0), name);

            dustType = 189;
            drop = ItemType<DesertOre>();
            soundType = 21;
            soundStyle = 1;
            mineResist = 4f;
            minPick = 100;
        }


    }
}