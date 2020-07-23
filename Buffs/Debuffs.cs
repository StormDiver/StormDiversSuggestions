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
            DisplayName.SetDefault("Burning sands");
            Description.SetDefault("The ancient sand burns you");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
           
            
            player.GetModPlayer<StormPlayer>().sandBurn = true;


            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 138, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(player.position, 1f, 0.5f, 0f);


            
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

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 1, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
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
            DisplayName.SetDefault("Marked for target");
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

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 55, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(player.position, 1f, 0.5f, 0f);
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
        int particle = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed = 0.2f;
            player.GetModPlayer<StormPlayer>().lunarBoulderDB = true;

            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                particle = 244;
            }
            else if (choice == 1)
            {
                particle = 110;
            }
            else if (choice == 2)
            {
                particle = 111; ;
            }
            else if (choice == 3)
            {
                particle = 112;
            }
            if (Main.rand.Next(3) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, particle, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
            Lighting.AddLight(player.position, 1f, 0.5f, 0.8f);

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
    //___________________________________________________________
    public class NebulaDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nebula Blazed");
            Description.SetDefault("You are being burnt by the full power of a nebula");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().nebula = true;

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 130, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(player.position, 1f, 0.5f, 0.8f);

        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().nebula = true;


        }
    }
}