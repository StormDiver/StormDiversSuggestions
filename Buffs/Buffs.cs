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
            Description.SetDefault("The powers of the Celestial spirits rapidly regenerate your life and grant additonal defense");
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
    //____________________________________________________________________________________
    public class DerpBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Derpling Legs");
            Description.SetDefault("Grants you the jump power of a true Derpling");
        }
        public override void Update(Player player, ref int buffIndex)
        {

            player.jumpSpeedBoost += 10f;

            player.autoJump = true;

          

            player.noFallDmg = true;

            //player.runAcceleration += 1f;
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
            player.statDefense += 30;

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
            DisplayName.SetDefault("Ranged Enchancement");
            Description.SetDefault("Increased ranged projectile velocity and knockback");
        }
        //Increase extra updates of all ranaged projectiles?
        public override void Update(Player player, ref int buffIndex)
        {
            
            
            if (player.HeldItem.ranged)
            {
                
                
            }
        }
    }
    //_______________________________________________________________________________

    public class SpectreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Magic Enchancement");
            Description.SetDefault("Magic projectiles inflict a damaging debuff on enemies");
        }
        //Maybe move the spectre orbitor abiltiy here??
        public override void Update(Player player, ref int buffIndex)
        {

            if (player.HeldItem.magic)
            {
                
               
            }
        }
    }
    //_______________________________________________________________________________

    public class BeetleBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Melee Enchancement");
            Description.SetDefault("Increases armour penetration for melee weapons");
        }
        //Perhaps an on hit effect, inflicts beetled?
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.HeldItem.melee)
            {
                player.armorPenetration = 40;
             
                
            }

        }
    }
    //_______________________________________________________________________________

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
    //_______________________________________________________________________________

    public class FrozenBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frost Spiked");
            Description.SetDefault("Your movement speed and critical strike chance are greatly increased");
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.runAcceleration *= 1.5f;
            player.maxRunSpeed *= 1.5f;
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
            Description.SetDefault("Steal the hearts of your enemies, literally");
           
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
            DisplayName.SetDefault("Life Vial");
            Description.SetDefault("Max life increased by 20");

        }

        public override void Update(Player player, ref int buffIndex)
        {
            
            player.statLifeMax2 += 20;
        }
    }
    //___________________________________________________________________
    public class FruitHeartBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Fruit Vial");
            Description.SetDefault("Max life increased by 25");

        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.statLifeMax2 += 25;
        }
    }
    //___________________________________________________________________
    public class HeartBarrierBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Life Barrier");
            Description.SetDefault("The next incoming attack will be reduced by 50% and will deal no knockback");
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
}