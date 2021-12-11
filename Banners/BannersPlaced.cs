using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
 
namespace StormDiversSuggestions.Banners     
{
    public class BabyDerpBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Baby Derpling Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("BabyDerpBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)    //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("BabyDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
        public class VineDerpBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("Camouflaged Derpling Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("VineDerpBannerItem"));//this defines what to drop when this tile is destroyed
            }

            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)      //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("VineDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
        public class ScanDroneBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("ScanDrone Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("ScanDroneBannerItem"));//this defines what to drop when this tile is destroyed
            }

            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)     //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("ScanDrone")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
        public class StormDerpBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("Storm Hopper Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("StormDerpBannerItem"));//this defines what to drop when this tile is destroyed
            }

            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)  //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("StormDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
        public class VortCannonBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("Vortexian Cannon Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("VortCannonBannerItem"));//this defines what to drop when this tile is destroyed
            }

            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)  //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("VortexCannon")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
        public class NebulaDerpBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("Brain Hopper Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("NebulaDerpBannerItem"));//this defines what to drop when this tile is destroyed
            }
    
            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)  //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("NebulaDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
        public class StardustDerpBannerPlace : ModTile
        {
            public override void SetDefaults()
            {
                Main.tileFrameImportant[Type] = true;
                Main.tileNoAttach[Type] = true;
                Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
                TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
                TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
                TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
                TileObjectData.newTile.StyleWrapLimit = 111;
                TileObjectData.addTile(Type);
                disableSmartCursor = true;
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("Star Hopper Banner");
                AddMapEntry(new Color(13, 88, 130), name);
            }

            public override void KillMultiTile(int i, int j, int frameX, int frameY)
            {
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("StardustDerpBannerItem"));//this defines what to drop when this tile is destroyed
            }

            public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
            {
                if (closer)  //so if a player is close to the banner
                {
                    Player player = Main.LocalPlayer;
                    player.NPCBannerBuff[mod.NPCType("StardustDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                    player.hasBanner = true;
                }
            }
        }
    public class SolarDerpBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Blazing Hopper Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("SolarDerpBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("SolarDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class MoonDerpBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Moonling Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("MoonDerpBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("MoonDerp")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class SpaceRockHeadBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Asteroid Orbiter Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("SpaceRockHeadBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("SpaceRockHead")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class SpaceRockHeadLargeBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Asteroid Charger Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("SpaceRockHeadLargeBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("SpaceRockHeadLarge")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class GladiatorMiniBossBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Fallen Champion Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("GladiatorMiniBossBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("GladiatorMiniBoss")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class GraniteMiniBossBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Surged Granite Core Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("GraniteMiniBossBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("GraniteMiniBoss")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class HellSoulBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Heartless Soul Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("HellSoulBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("HellSoul")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class MushroomMiniBossBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Angry Mushroom Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("MushroomMiniBossBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("MushroomMiniBoss")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class GolemMinionBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Temple Guardian Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("GolemMinionBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("GolemMinion")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class HellMiniBossBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Soul Cauldron Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("HellMiniBossBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("HellMiniBoss")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class IceCoreBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Frigid Snowflake Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("IceCoreBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("IceCore")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class SandCoreBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dune Blaster Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }
    
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("SandCoreBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("SandCore")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
    public class MeteorDropperBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Meteor Bomber Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("MeteorDropperBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("MeteorDropper")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }

    public class GolemSentryBannerPlace : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  //This defines if the tile is destroyed by lava
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  //this is how many parts the sprite is devided (height)
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  //this is how many pixels are in each devided part(pink square) (height)   so there are 3 parts with 16 x 16
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Lihzahrd Flametrap Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType("GolemSentryBannerItem"));//this defines what to drop when this tile is destroyed
        }

        public override void NearbyEffects(int i, int j, bool closer)   //this make so the banner give an effect to nearby players
        {
            if (closer)  //so if a player is close to the banner
            {
                Player player = Main.LocalPlayer;
                player.NPCBannerBuff[mod.NPCType("GolemSentry")] = true;  // give to player the npcbannerBuff. for a specific npc. change NpcName to your npc name
                player.hasBanner = true;
            }
        }
    }
}