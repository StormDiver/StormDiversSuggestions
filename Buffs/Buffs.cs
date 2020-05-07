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

            player.jumpSpeedBoost += 10f;

            player.autoJump = true;

            

            //player.runAcceleration += 1f;
        }
    }
    //______________________________________________________________________________
    
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
            Description.SetDefault("Allows all ranged weapons to fire extra explosive bullets");
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
            Description.SetDefault("While holding any melee weapon; your movement speed, acceleration and invincibility frames are greatly increased");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HeldItem.melee)
            {
 
                player.longInvince = true;
                player.maxRunSpeed *= 2.5f;
                player.runAcceleration *= 4;
            }

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