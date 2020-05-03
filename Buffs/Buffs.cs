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
    public class CelestialBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Celestial Guardian");
            Description.SetDefault("The powers of the Celestial spirits rapidly regenerates your life");
        }
        int particle = 10;
        public override void Update(Player player, ref int buffIndex)
        {

            particle--;
            if (player.statLife <= ((player.statLifeMax2) * 0.33f))
            {
                player.lifeRegen += 30;

                if (particle <= 0)
                {
                    particle = 10;
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(player.position.X + 5f, player.position.Y + 20f), 5, 5, 110);
                    var dust2 = Dust.NewDustDirect(new Vector2(player.position.X + 5f, player.position.Y + 20f), 5, 5, 111);
                    var dust3 = Dust.NewDustDirect(new Vector2(player.position.X + 5f, player.position.Y + 20f), 5, 5, 112);
                    var dust4 = Dust.NewDustDirect(new Vector2(player.position.X + 5f, player.position.Y + 20f), 5, 5, 244);

                }
            }
        }
    }
    //____________________________________________________________________________________
    public class DerpBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Derpling Jump");
            Description.SetDefault("Grants you the jump power of a true Derpling");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.jumpSpeedBoost += 4f;

            player.autoJump = true;

            player.maxRunSpeed *= 1f;

            //player.runAcceleration += 1f;
        }
    }
    //______________________________________________________________________________
    public class DerpBuffLv2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Super Derpling Jump");
            Description.SetDefault("Grants you the jump power that surpasses that of a true Derpling");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.jumpSpeedBoost += 6.5f;
            player.dash = 2;
            player.autoJump = true;

            player.maxRunSpeed *= 1.5f;

            //player.runAcceleration += 1.5f;
        }
    }
    //_______________________________________________________________________________
    public class DerpBuffLv3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hyper Derpling Jump");
            Description.SetDefault("Grants you the ultimate jump power that no Derpling has ever seen");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.jumpSpeedBoost += 9f;
            player.dash = 1;
            player.autoJump = true;

            player.maxRunSpeed *= 2f;

            //player.runAcceleration += 2f;
        }
    }
    //_______________________________________________________________________________
   
    public class TurtleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shelled");
            Description.SetDefault("The power of the Turtle shell protects you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 30;

            player.GetModPlayer<StormPlayer>().turtled = true;
        }
    }
    //_______________________________________________________________________________
    public class ShroomiteBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroomite Enchancement");
            Description.SetDefault("Allows most ranged projectiles to pierce once\nIncreases the velocity of all ranged projectiles");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            player.GetModPlayer<StormPlayer>().shroombuff = true;
        }
    }
    public class SpectreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spectre Enchancement");
            Description.SetDefault("Greatly reduces Mana usage while under the effect of Mana Sickness");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            if (Main.LocalPlayer.HasBuff(BuffID.ManaSickness))
            {
                player.manaCost *= 0.2f;
            }
        }
    }
    public class BeetleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Beetle Enchancement");
            Description.SetDefault("Melee attacks have a chance to swarm enemies with mini beetles, hindering their movement and defense");
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.meleeSpeed += 0.15f;

        }
    }
    public class RainBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sprinting in the rain");
            Description.SetDefault("Your movement speed is increased");
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.moveSpeed += 0.6f;
        }
    }
}