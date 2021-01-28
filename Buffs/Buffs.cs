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
            Description.SetDefault("The next incoming attack will be reduced by 33% and will deal no knockback");
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
            DisplayName.SetDefault("Blood Drainer");
            Description.SetDefault("Enemies within the orbs of blood have their lives drained");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<StormPlayer>().BloodOrb = true;

            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 5, player.velocity.X, player.velocity.Y, 100, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1f;
                Main.dust[dust].velocity.Y -= 0.5f;
                Main.playerDrawDust.Add(dust);
            }
        }
    }
   
    //_____________________________________________
    public class GraniteBuff : ModBuff 
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Granite Barrier");
            Description.SetDefault("Reduces damage taken by by 12% and immunity to knockback");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.velocity.X *= 0.94f;
            player.endurance += 0.12f;
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
            Description.SetDefault("Damage of the next attack is doubled");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage += 1f;
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
            DisplayName.SetDefault("Champion's Gift");
            Description.SetDefault("Increases critical strike chance by 12%");
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.meleeCrit += 12;
            player.rangedCrit += 12;
            player.magicCrit += 12;
            player.thrownCrit += 12;

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
            DisplayName.SetDefault("Orbital Defence");
            Description.SetDefault("Damage taken from the next is reduced by 22% and will grant longer invincibility frames\nTaking damage summons defense-piercing meteors from the sky");
        }

        public override void Update(Player player, ref int buffIndex)
        {

            player.endurance += .22f;
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
            Description.SetDefault("Your next attack will cause defense-piercing meteors to fall upon the attacked enemy");
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
}