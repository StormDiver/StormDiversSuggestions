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

        [Label("Disable Vanilla Armour buffs")]
        // Similar to Label, this sets the tooltip. Tooltips are useful for slightly longer and more detailed explanations of config options.
        [Tooltip("Disable the new armour stat buffs and set bonuses, Requires a Reload")]
        // ReloadRequired hints that if this value is changed, a reload is required for the mod to properly work. 
        // Here we use it so if we disable ExampleWings from being loaded, we can properly prevent autoload in ExampleWings.cs
        // Failure to properly use ReloadRequired will cause many, many problems including ID desync.
        [ReloadRequired]
        public bool DisableVanillaBuff{ get; set; }


        [Label("Disable Vanilla recipe modifications")]
        [Tooltip("Disable the modified recipes for vanilla armours, and reverts the soul recipes, Requires a Reload")]
        [ReloadRequired]
        public bool DisableVanillaRecipechanges{ get; set; }

        [Label("Disable New recipes and drops for Vanilla items")]    
        [Tooltip("Disable the new recipes and item drops for certain armour and the Rod of Discord, Requires a Reload")]
        [ReloadRequired]
        public bool DisableNewRecipes{ get; set; }

        [Label("Enable LocalNpcImmunity for most projectiles (EXPERIMENTAL)")]
        [Tooltip("Allows all piercing projectiles to deal their own damage regardless of iframes, may break some weapons so enable at your own risk, Requires a Reload")]
        [ReloadRequired]
        public bool EnableFixedProjs { get; set; }
    }
}