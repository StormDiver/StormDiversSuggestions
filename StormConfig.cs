using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;


namespace StormDiversSuggestions
{
    public class Configurations : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Disable Frost and Arid ore Generation")]
        // Similar to Label, this sets the tooltip. Tooltips are useful for slightly longer and more detailed explanations of config options.
        [Tooltip("This will prevent the 2 ores in this mod from generating, but they will still drop from NPCs and crates, Requires a Reload")]
        // ReloadRequired hints that if this value is changed, a reload is required for the mod to properly work. 
        // Failure to properly use ReloadRequired will cause many, many problems including ID desync.
        [ReloadRequired] //Not really needed, but keep it to stop people for finding exploits 
        public bool PreventOreSpawn { get; set; }

        [Label("Prevent modded pillar enemies from spawning")]
        [Tooltip("This will prevent the pillar enemies in this mod from spawning, enabel this if you don't want the pillars to be any more difficult than vanilla")]
        //[ReloadRequired] //No reload required as it just changes the spawn chance and doesn't disable the enemy itself
        public bool PreventPillarEnemies { get; set; }
    }
}