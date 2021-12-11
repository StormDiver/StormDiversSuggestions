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
            Description.SetDefault("The powers of the Celestial spirits rapidly regenerate your life and grant additional defense");
        }
        int particle = 10;
        public override void Update(Player player, ref int buffIndex)
        {

            particle--;
           
            {
                player.statDefense += 50;
  
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
   
    //______________________________________________________________________________
    
    public class TurtleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shelled");
            Description.SetDefault("The power of the Turtle shell protects you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 25;

            player.GetModPlayer<StormPlayer>().turtled = true;

            if (Main.rand.Next(10) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 273, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_______________________________________________________________________________
    public class ShroomiteBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroomite Enhancement");
            Description.SetDefault("75% Chance not to consume ammo");
        }
        // code in StormPlayer.cs
    }
    //_______________________________________________________________________________

    public class SpectreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spectre Enhancement");
            Description.SetDefault("Maximum mana increased by 60");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.statManaMax2 += 60;
        }
    }
    //_______________________________________________________________________________

    public class BeetleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Beetle Enhancement");
            Description.SetDefault("25 armour penetration for melee weapons");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HeldItem.melee)
            {
                player.armorPenetration = 25;
            
              
            }

        }
    }
    //_______________________________________________________________________________
    public class SpookyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Spooky Enhancement");
            Description.SetDefault("Increases Minion damage and knockback by 10%");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.minionDamage += 0.1f;
            player.minionKB += 0.1f;
        }
    }
    //_______________________________________________________________________________

    public class RainBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sprinting in the rain");
            Description.SetDefault("Your movement speed is increased");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.moveSpeed += 0.5f;
        }
    }
    //_______________________________________________________________________________

    public class FrozenBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frost Spiked");
            Description.SetDefault("Your movement speed and critical strike chance are greatly increased");
            //Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.runAcceleration *= 1.5f;
            player.maxRunSpeed += 2f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
      
            player.thrownCrit += 10;
            
            
        }
    }
    //____________________________________________
    public class JarBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Heart Collector");
            Description.SetDefault("RIP");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            /*if (Main.rand.Next(10) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 273, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }*/
        }
    }
    //___________________________________________________________________
    public class HeartBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Up");
            Description.SetDefault("Max life is increased by 40");

        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            player.statLifeMax2 += 40;
        }
    }
    //___________________________________________________________________
    public class FruitHeartBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Fruit Up");
            Description.SetDefault("Max life is increased by 50");

        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.statLifeMax2 += 50;
        }
    }
    //___________________________________________________________________
    public class HeartBarrierBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Barrier");
            Description.SetDefault("The next incoming attack will be reduced by 25% and will deal no knockback");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().lifeBarrier = true;
            if (Main.rand.Next(10) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 72, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_____________________________________________
    public class TeddyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Teddy Bear Love");
            Description.SetDefault("The love of the Teddy bear increases life regen");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 3;
            player.loveStruck = true; 
            //player.moveSpeed = 0.1f;
        }
    }
    //_____________________________________________

    public class BloodBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Decayer");
            Description.SetDefault("Attacking enemies has a chance to decay their life");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().BloodOrb = true;

         
        }
    }
   
    //_____________________________________________
    public class GraniteBuff : ModBuff 
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Granite Barrier");
            Description.SetDefault("Reduces damage taken by by 15% and grants immunity to knockback");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.X *= 0.94f;
            player.endurance += 0.15f;
            player.noKnockback = true;
            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 65, player.velocity.X, player.velocity.Y, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_____________________________________________
    public class GraniteAccessBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Granite Surge");
            Description.SetDefault("50% increased damage");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.5f;
            player.rangedDamage += 0.5f;
            player.magicDamage += 0.5f;
            player.thrownDamage += 0.5f;

            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 70, player.velocity.X, player.velocity.Y, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y = 1f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_____________________________________________
    public class GladiatorAccessBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warrior's Gift");
            Description.SetDefault("20% increased critical strike chance");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.magicCrit += 20;
            player.thrownCrit += 20;

            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 57, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_____________________________________________
    public class SpaceRockDefence : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Orbital Defense");
            Description.SetDefault("25% damage reduction from the next attack\nTaking damage summons asteroid fragments from the sky");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.endurance += .25f;
            player.longInvince = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 6, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_____________________________________________
    public class SpaceRockOffence : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Orbital Strike");
            Description.SetDefault("Your next attack will cause asteroid fragments to fall upon the attacked enemy");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 6, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
    //_______________________________________________________
    public class DerpBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Derpling Launch");
            Description.SetDefault("In Terraria, Derpling launch you");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {


           
        }
    }

    //_______________________________________________________
    //Mushroom Buffs
    public class MushBuff1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroom Power");
            Description.SetDefault("Increases damage by 2%");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.02f;

            if (Main.rand.Next(16) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }

        }
    }
    public class MushBuff2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroom Power");
            Description.SetDefault("Increases damage by 5%");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.05f;

            if (Main.rand.Next(8) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }

        }
    }
    public class MushBuff3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroom Power");
            Description.SetDefault("Increases damage by 10%");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.1f;

            if (Main.rand.Next(4) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }

        }
    }
    public class MushBuff4 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shroom Power");
            Description.SetDefault("Increases damage by 16%");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 0.16f;

            if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 113, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }

        }
    }
    public class SkyKnightSentryBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Star Warrior's Sentry");
            Description.SetDefault("A Star sentry attacks for you");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            
        }
    }
    public class SantankBuff1 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ho-Ho-Homing Missile");
            Description.SetDefault("Some of your missiles are ready to launch");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
    public class SantankBuff2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ho-Ho-Homing Missile");
            Description.SetDefault("Most of your missiles are ready to launch");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
    public class SantankBuff3 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ho-Ho-Homing Missile");
            Description.SetDefault("All of your missiles are ready to launch");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

        }
    }
}