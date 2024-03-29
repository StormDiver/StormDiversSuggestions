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
            DisplayName.SetDefault("Forbidden Burn");
            Description.SetDefault("The forbidden sand burns you");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
           
            
            player.GetModPlayer<StormPlayer>().sandBurn = true;


            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 10, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
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
    //___________________________________________________________
    public class SuperFrostBurn : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("CryoBurn");
            Description.SetDefault("It's like FrostBurn, but it hurts even more");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().superFrost = true;
            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 156, player.velocity.X, player.velocity.Y, 135, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                
                int dust2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 156, player.velocity.X, player.velocity.Y, 135, default, .3f);
                Main.dust[dust2].velocity *= 0.5f;
            }
            Lighting.AddLight(player.position, 0f, 1f, 1f);
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().superFrost = true;

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
            Description.SetDefault("All your defense has been taken away");
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 500;
            
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
    public class BeetleDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Beetle Swarm");
            Description.SetDefault("Beetles have greatly reduced your speed");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {


        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().beetled = true;
            

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
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().nebulaBurn = true;

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
    //___________________________________________________________
    public class SpectreDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Soul Drain");
            Description.SetDefault("You have been hit by an enhanced magic projectile");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().spectreDebuff = true;

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 16, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default, 1f);
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
            npc.GetGlobalNPC<StormNPC>().spectreDebuff = true;
            
           

        }
    }
    //___________________________________________________________
    public class HeartDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stolen Heart");
            Description.SetDefault("You cannot live without a heart");
            Main.debuff[Type] = true;
            // Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {


        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().heartDebuff = true;

            

        }
    }
    //________________________________________________
    public class BloodDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Decayed");
            Description.SetDefault("Your life is slowing decaying away");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().bloodDebuff = true;



        }
    }
    //________________________________________________
    public class SuperBurnDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Blazing Fire");
            Description.SetDefault("This is fine");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().superBurn = true;

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 6, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default, 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
            }

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().superburnDebuff = true;



        }
    }
    //________________________________________________
    public class HellSoulFireDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("SoulBurn");
            Description.SetDefault("This might not be fine");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.GetModPlayer<StormPlayer>().hellSoulFire = true;

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4,173, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default, 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;

            }
            player.GetModPlayer<StormPlayer>().hellSoulDebuff = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<StormNPC>().hellSoulFire = true;



        }
    }
    //________________________________________________
    public class TwilightDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Twilight Warped");
            Description.SetDefault("You are unable to perform another Twilight Warp");
            Main.debuff[Type] = true;
            
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //player.GetModPlayer<StormPlayer>().hellSoulFire = true;

            if (Main.rand.Next(4) < 2)
            {
                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 179, 0, -3);
                dust.scale = 1.25f;
                dust.noGravity = true;
                dust.velocity *= 0.75f;
            }
            //player.GetModPlayer<StormPlayer>().hellSoulDebuff = true;

        }
        public override void Update(NPC npc, ref int buffIndex)
        {
           



        }
    }
    //_______________________________________________
    public class DerpDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Launched");
            Description.SetDefault("You have been launched into the air by the power of the Derplings");
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            

        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().derplaunched = true;



        }
    }
    //_______________________________________________
    public class DarkShardDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Essence of Dark");
            Description.SetDefault("You have been surrounded by the darkness");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {


        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().darknessDebuff = true;



        }
    }
    //_______________________________________________
    public class UltraBurnDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("UltraBurn");
            Description.SetDefault("This most certainly is NOT fine!!!!");
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().ultraBurn = true;

            
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 6, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default, 2.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 2f;
            


        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().ultraburnDebuff = true;



        }
    }
    //_______________________________________________
    public class UltraFrostDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("UltraFreeze");
            Description.SetDefault("This really really REALLY hurts!!!!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().ultraFrost = true;


            int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 135, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 0, default, 2.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 1f;
            Main.dust[dust].velocity.Y -= 2f;



        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().ultrafrostDebuff = true;


        }
    }
    //_________________________________________________________________
    public class SpookedDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spooked");
            Description.SetDefault("You are overwhelmed by fear");
            Main.debuff[Type] = true;

        }

        public override void Update(Player player, ref int buffIndex)
        {
          


        }
        public override void Update(NPC npc, ref int buffIndex)
        {

            npc.GetGlobalNPC<StormNPC>().spookedDebuff = true;


        }
    }
}