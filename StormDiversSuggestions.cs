using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions
{
	public class StormDiversSuggestions : Mod
	{
		public StormDiversSuggestions()
		{

		}
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:EvilBars", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:GoldBars", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Golden Ore", new int[]
            {
                ItemID.GoldOre,
                ItemID.PlatinumOre
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:GoldOres", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Material", new int[]
            {
                ItemID.ShadowScale,
                ItemID.TissueSample
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:EvilMaterial", group);

            group = new RecipeGroup(() => "Ruby or Diamond Staff", new int[]
            {
                ItemID.RubyStaff,
                ItemID.DiamondStaff
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:RDStaffs", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Running Boots", new int[]
            {
                ItemID.HermesBoots,
                ItemID.FlurryBoots,
                ItemID.SailfishBoots
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:RunBoots", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Anvil", new int[]
            {
                ItemID.IronAnvil,
                ItemID.LeadAnvil,
              
            });
            RecipeGroup.RegisterGroup("StormDiversSuggestions:Anvils", group);


        }
    }
}