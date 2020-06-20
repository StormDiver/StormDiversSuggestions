using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;


//buff effects for npcs are in StormNPC.cs, effects for player are in StormPlayer.cs
namespace StormDiversSuggestions.Buffs
{
    public class AridSandDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Buring sands");
            Description.SetDefault("The ancient sand burns you");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
           
            
            player.GetModPlayer<StormPlayer>().sandBurn = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().sandBurn = true;
        }
    }
    //________________________________________
    public class BoulderDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bouldered");
            Description.SetDefault("That really hurt, reduced movement speed");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.moveSpeed = 0.25f;
            player.GetModPlayer<StormPlayer>().boulderDB = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().boulderDB = true;
        }
    }
    //_____________________________________________________________
    public class ScanDroneDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("ScanDroned");
            Description.SetDefault("All your defense and damage resistance has been taken away");
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 500;
            player.endurance = 0;
            // player.wingTime = 0;
            //player.wings = 0;
        }

    }
    //___________________________________________________________
    public class SuperBoulderDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Super Bouldered");
            Description.SetDefault("Now it REALLY hurts, reduced movement speed and constant burning");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed = 0.2f;
            player.GetModPlayer<StormPlayer>().superBoulderDB = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().superBoulderDB = true;
        }
        
       
    }
    //____________________________________________________________
    public class LunarBoulderDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lunar Bouldered");
            Description.SetDefault("Inflicts unimaginable pain, reduced movement speed and constant burning");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed = 0.2f;
            player.GetModPlayer<StormPlayer>().lunarBoulderDB = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().lunarBoulderDB = true;
        }


    }
    //___________________________________________________________
    public class TurtleDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("De-Shelled");
            Description.SetDefault("Lowered Defense");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {


        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().turtled = true;
            npc.defense -= 60;
            //npc.damage *= (int)0.8;

        }
    }
    //___________________________________________________________
    public class BeetleDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Beetle Swarm");
            Description.SetDefault("Lowered Defense and speed");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {


        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().beetled = true;
            npc.defense -= 60;
            

        }
    }
}