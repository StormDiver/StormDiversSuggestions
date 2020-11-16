using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Basefiles;


namespace StormDiversSuggestions.VanillaChanges
{
    public class VanillaChanges : GlobalItem
    {

       


        //==============================================DEFENSE====================================================




        public override void SetDefaults(Item item)
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {

                if (item.type == ItemID.CopperHelmet)
                {
                    item.defense = 2;


                }
                if (item.type == ItemID.CopperChainmail)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.CopperGreaves)
                {
                    item.defense = 3;

                }
                //
                if (item.type == ItemID.TinHelmet)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.TinChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.TinGreaves)
                {
                    item.defense = 3;

                }
                //
                if (item.type == ItemID.IronHelmet)
                {
                    item.defense = 3;

                }
                if (item.type == ItemID.IronChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.IronGreaves)
                {
                    item.defense = 4;

                }
                //
                if (item.type == ItemID.LeadHelmet)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.LeadChainmail)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.LeadGreaves)
                {
                    item.defense = 4;

                }
                //
                if (item.type == ItemID.SilverHelmet)
                {
                    item.defense = 4;

                }
                if (item.type == ItemID.SilverChainmail)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.SilverGreaves)
                {
                    item.defense = 5;

                }
                //
                if (item.type == ItemID.TungstenHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.TungstenChainmail)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.TungstenGreaves)
                {
                    item.defense = 5;

                }
                //
                if (item.type == ItemID.GoldHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.GoldChainmail)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.GoldGreaves)
                {
                    item.defense = 6;

                }
                //
                if (item.type == ItemID.PlatinumHelmet)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.PlatinumChainmail)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.PlatinumGreaves)
                {
                    item.defense = 6;

                }


                if (item.type == ItemID.NecroHelmet)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.NecroBreastplate)
                {
                    item.defense = 7;

                }
                if (item.type == ItemID.NecroGreaves)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.FrozenTurtleShell)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.RainHat)
                {
                    item.defense = 2;
                }
                if (item.type == ItemID.RainCoat)
                {
                    item.defense = 3;
                }
                if (item.type == ItemID.EskimoHood)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.EskimoPants)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.EskimoPants)
                {
                    item.defense = 2;

                }
                if (item.type == ItemID.PinkEskimoHood)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.PinkEskimoCoat)
                {
                    item.defense = 6;

                }
                if (item.type == ItemID.PinkEskimoPants)
                {
                    item.defense = 5;

                }
                if (item.type == ItemID.GladiatorHelmet)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.GladiatorBreastplate)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.GladiatorLeggings)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.ObsidianHelm)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.ObsidianShirt)
                {
                    item.defense = 6;
                }
                if (item.type == ItemID.ObsidianPants)
                {
                    item.defense = 5;
                }

                
                if (item.type == ItemID.CobaltLeggings)
                {
                    item.defense = 8;
                }
                if (item.type == ItemID.CobaltBreastplate)
                {
                    item.defense = 10;
                }
                if (item.type == ItemID.CobaltHat)
                {
                    item.defense = 3;
                }
                if (item.type == ItemID.CobaltMask)
                {
                    item.defense = 5;
                }
                if (item.type == ItemID.CobaltHelmet)
                {
                    item.defense = 14;
                }
                if (item.type == ItemID.MythrilGreaves)
                {
                    item.defense = 10;
                }
                if (item.type == ItemID.MythrilChainmail)
                {
                    item.defense = 13;
                }
                if (item.type == ItemID.MythrilHood)
                {
                    item.defense = 4;
                }
                if (item.type == ItemID.MythrilHat)
                {
                    item.defense = 7;
                }
                if (item.type == ItemID.MythrilHelmet)
                {
                    item.defense = 19;
                }
                if (item.type == ItemID.AdamantiteLeggings)
                {
                    item.defense = 11;
                }
                if (item.type == ItemID.AdamantiteBreastplate)
                {
                    item.defense = 15;
                }
                if (item.type == ItemID.AdamantiteHelmet)
                {
                    item.defense = 23;
                }
                if (item.type == ItemID.AdamantiteMask)
                {
                    item.defense = 8;
                }
                if (item.type == ItemID.AdamantiteHeadgear)
                {
                    item.defense = 4;
                }
                
                

                
               

            }

        }

        //======================================================================STATBUFFS=========================================================


        public override void UpdateEquip(Item item, Player player)
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)


            {
                if (item.type == ItemID.GladiatorHelmet)
                {
                    player.rangedDamage += 0.03f;
                }
                if (item.type == ItemID.GladiatorBreastplate)
                {
                    player.rangedCrit += 2;
                    player.rangedDamage += 0.02f;
                }
                if (item.type == ItemID.GladiatorLeggings)
                {
                    player.rangedCrit += 3;
                    player.moveSpeed += 0.1f;
                }
                if (item.type == ItemID.FrostsparkBoots)
                {
                    player.moveSpeed += 0.18f;

                }
                if (item.type == ItemID.NecroBreastplate)
                {
                    player.rangedCrit += 5;
                }



                if (item.type == ItemID.FrostBreastplate)
                {
                    player.meleeCrit += 4;
                    player.rangedCrit += 4;

                }
                if (item.type == ItemID.FrostLeggings)
                {
                    player.moveSpeed += 0.17f;
                    
                    player.meleeSpeed += 0.17f;
                    player.meleeDamage += 0.05f;
                    player.rangedDamage += 0.05f;

                }


                if (item.type == ItemID.AncientBattleArmorShirt)
                {
                    player.magicCrit += 8;
                    player.minionDamage += 0.08f;
                }
                if (item.type == ItemID.AncientBattleArmorPants)
                {

                    player.manaCost -= 0.12f;
                }



                if (item.type == ItemID.SolarFlareHelmet)
                {
                    player.meleeCrit += 8;
                    player.statLifeMax2 += 15;
                }
                if (item.type == ItemID.SolarFlareBreastplate)
                {
                    player.meleeDamage += 0.08f;
                    player.statLifeMax2 += 20;
                }
                if (item.type == ItemID.SolarFlareLeggings)
                {
                    player.meleeSpeed += 0.2f;
                    player.moveSpeed += 0.35f;
                    player.statLifeMax2 += 15;
                }
                if (item.type == ItemID.VortexHelmet)
                {
                    
                    player.nightVision = true;
                    player.dangerSense = true;
                   
                }
                if (item.type == ItemID.VortexBreastplate)
                {

                }
                if (item.type == ItemID.VortexLeggings)
                {
                    player.moveSpeed += 0.5f;

                }
               
                if (item.type == ItemID.ShroomiteLeggings)
                {
                    player.rangedCrit += 8;
                    player.moveSpeed += 0.18f;
                }
                if (item.type == ItemID.TurtleHelmet)
                {
                    player.meleeCrit += 6;
                }
                if (item.type == ItemID.TurtleLeggings)
                {
                    player.meleeDamage += 0.04f;
                }
                if (item.type == ItemID.BeetleHelmet)
                {
                    player.meleeDamage += 0.06f;
                }
                if (item.type == ItemID.BeetleLeggings)
                {
                    player.meleeSpeed += 0.14f;
                    player.moveSpeed += 0.14f;
                }
               if (item.type == ItemID.ShadowHelmet)
                {
                    player.meleeSpeed -= 0.07f;
                    player.allDamage += 0.05f;
                }
                if (item.type == ItemID.ShadowScalemail)
                {
                    player.meleeSpeed -= 0.07f;
                    player.allDamage += 0.05f;

                }
                if (item.type == ItemID.ShadowGreaves)
                {
                    player.meleeSpeed -= 0.07f;
                    player.allDamage += 0.05f;

                }
            }
        }
    }

    //================================================================SETBOUNSES==========================================================

    public class Changes : ModPlayer
    {
      

        // Credit to qwerty3.14
        public override void PostUpdateEquips()
        {
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {

          
              
                if (player.armor[0].type == ItemID.GoldHelmet && player.armor[1].type == ItemID.GoldChainmail && player.armor[2].type == ItemID.GoldGreaves)
                {
                    player.statDefense -= 3; // cancel out the vanilla bonus
                    player.meleeCrit += 6;
                    player.rangedCrit += 6;
                    player.magicCrit += 6;
                    player.thrownCrit += 6;
                    player.setBonus = "6% increased critical strike chance";
                }
                if (player.armor[0].type == ItemID.SilverHelmet && player.armor[1].type == ItemID.SilverChainmail && player.armor[2].type == ItemID.SilverGreaves)
                {
                    player.statDefense -= 3; // cancel out the vanilla bonus
                    player.moveSpeed += 0.10f;
                    player.setBonus = "10% increased movement speed";
                }
                if (player.armor[0].type == ItemID.IronHelmet && player.armor[1].type == ItemID.IronChainmail && player.armor[2].type == ItemID.IronGreaves)
                {
                    player.statDefense -= 2; // cancel out the vanilla bonus
                    player.allDamage += 0.06f;
                    player.setBonus = "6% increased damage";
                }
                if (player.armor[0].type == ItemID.CopperHelmet && player.armor[1].type == ItemID.CopperChainmail && player.armor[2].type == ItemID.CopperGreaves)
                {
                    player.statDefense -= 2; // cancel out the vanilla bonus
                    player.meleeSpeed += 0.1f;
                    player.setBonus = "10% increased melee speed";
                }
                if (player.armor[0].type == ItemID.RainHat && player.armor[1].type == ItemID.RainCoat)
                {
                    if (Main.raining)
                    {

                        player.AddBuff(mod.BuffType("RainBuff"), 1);
                    }
                    player.setBonus = "60% increased Movement Speed while raining";
                }
                if (player.armor[0].type == ItemID.ObsidianHelm && player.armor[1].type == ItemID.ObsidianShirt && player.armor[2].type == ItemID.ObsidianPants)
                {


                    player.fireWalk = true;
                    player.buffImmune[BuffID.OnFire] = true;
                    player.lavaRose = true;
                    player.setBonus = "Immunity to fire blocks and onfire";
                }
                 if (player.armor[0].type == ItemID.EskimoHood && player.armor[1].type == ItemID.EskimoCoat && player.armor[2].type == ItemID.EskimoPants)
                 {

                     player.resistCold = true;
                    player.buffImmune[BuffID.Chilled] = true;
                    player.setBonus = "Reduced damage from cold themed enemies and immunity to Chilled";
                 }
                if (player.armor[0].type == ItemID.PinkEskimoHood && player.armor[1].type == ItemID.PinkEskimoCoat && player.armor[2].type == ItemID.PinkEskimoPants)
                {

                    player.resistCold = true;
                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                    player.setBonus = "Reduced damage from cold themed enemies, immunity to Chilled and Frozen";
                }
                if (player.armor[0].type == ItemID.GladiatorHelmet && player.armor[1].type == ItemID.GladiatorBreastplate && player.armor[2].type == ItemID.GladiatorLeggings)
                {


                    
                        player.ammoCost80 = true;
                    
                    player.setBonus = "20% chance not to consume ammo";

                }
                if (player.armor[0].type == ItemID.FrostHelmet && player.armor[1].type == ItemID.FrostBreastplate && player.armor[2].type == ItemID.FrostLeggings)
                {


                    player.buffImmune[BuffID.Chilled] = true;
                    player.buffImmune[BuffID.Frozen] = true;
                    player.resistCold = true;
                   // player.frostArmor = false;
                    player.frostBurn = false;
                    player.GetModPlayer<StormPlayer>().FrostCryoSet = true;
                    player.setBonus = "Melee and ranged attacks inflict CryoBurn\nImmunity to Chilled and Frozen, plus reduced damage from cold themed enemies";

                }
                if (player.armor[0].type == ItemID.AncientBattleArmorHat && player.armor[1].type == ItemID.AncientBattleArmorShirt && player.armor[2].type == ItemID.AncientBattleArmorPants)
                {


                    //player.buffImmune[BuffID.Suffocation] = true;
                    player.buffImmune[BuffID.WindPushed] = true;


                    player.setBonus = "Double tap Down/Up to call an ancient storm to the cursor location\nImmunity to Mighty wind";

                }
               

                if (player.armor[0].type == ItemID.CobaltHelmet && player.armor[1].type == ItemID.CobaltBreastplate && player.armor[2].type == ItemID.CobaltLeggings)
                {

                    player.endurance += 0.2f;
                    player.setBonus = "15% increased melee speed\nReduces damage taken by 20%";

                }
                if (player.armor[0].type == ItemID.CobaltMask && player.armor[1].type == ItemID.CobaltBreastplate && player.armor[2].type == ItemID.CobaltLeggings)
                {

                    player.endurance += 0.2f;
                    player.setBonus = "20% chance to not consume ammo\nReduces damage taken by 20%";

                }
                if (player.armor[0].type == ItemID.CobaltHat && player.armor[1].type == ItemID.CobaltBreastplate && player.armor[2].type == ItemID.CobaltLeggings)
                {

                    player.endurance += 0.2f;
                    player.setBonus = "14% reduced mana usage\nReduces damage taken by 20%";

                }
                if (player.armor[0].type == ItemID.MythrilHelmet && player.armor[1].type == ItemID.MythrilChainmail && player.armor[2].type == ItemID.MythrilGreaves)
                {

                    player.endurance += 0.16f;
                    player.meleeCrit += 7;
                    player.setBonus = "12% increased melee critical strike chance\nReduces damage taken by 16%";

                }
                if (player.armor[0].type == ItemID.MythrilHat && player.armor[1].type == ItemID.MythrilChainmail && player.armor[2].type == ItemID.MythrilGreaves)
                {

                    player.endurance += 0.16f;
                    player.setBonus = "20% chance to not consume ammo\nReduces damage taken by 16%";

                }
                if (player.armor[0].type == ItemID.MythrilHood && player.armor[1].type == ItemID.MythrilChainmail && player.armor[2].type == ItemID.MythrilGreaves)
                {

                    player.endurance += 0.16f;
                    player.setBonus = "17% reduced mana usage\nReduces damage taken by 16%";

                }
                if (player.armor[0].type == ItemID.AdamantiteHelmet && player.armor[1].type == ItemID.AdamantiteBreastplate && player.armor[2].type == ItemID.AdamantiteLeggings)
                {

                    player.endurance += 0.12f;
                    player.setBonus = "18% increased melee and movement speed\nReduces damage taken by 12%";

                }
                if (player.armor[0].type == ItemID.AdamantiteMask && player.armor[1].type == ItemID.AdamantiteBreastplate && player.armor[2].type == ItemID.AdamantiteLeggings)
                {

                    player.endurance += 0.12f;
                    player.setBonus = "25% chance to not consume ammo\nReduces damage taken by 12%";

                }
                if (player.armor[0].type == ItemID.AdamantiteHeadgear && player.armor[1].type == ItemID.AdamantiteBreastplate && player.armor[2].type == ItemID.AdamantiteLeggings)
                {

                    player.endurance += 0.12f;
                    player.setBonus = "19% reduced mana usage\nReduces damage taken by 12%";

                }
                if (player.armor[0].type == ItemID.ChlorophyteMask && player.armor[1].type == ItemID.ChlorophytePlateMail && player.armor[2].type == ItemID.ChlorophyteGreaves)
                {

                    player.meleeSpeed += 0.2f;
                    player.setBonus = "Shoots crystal leaves at nearby enemies\nIncreased melee speed by 20%";

                }
                if (player.armor[0].type == ItemID.ChlorophyteHelmet && player.armor[1].type == ItemID.ChlorophytePlateMail && player.armor[2].type == ItemID.ChlorophyteGreaves)
                {

                    player.rangedCrit += 10;
                    player.setBonus = "Shoots crystal leaves at nearby enemies\nIncreased ranged critical strike chance by 10%";

                }
                if (player.armor[0].type == ItemID.ChlorophyteHeadgear && player.armor[1].type == ItemID.ChlorophytePlateMail && player.armor[2].type == ItemID.ChlorophyteGreaves)
                {

                    player.magicCrit += 10;
                    player.setBonus = "Shoots crystal leaves at nearby enemies\nIncreased magic critical strike chance by 10%";

                }
                if (player.armor[0].type == ItemID.ShadowHelmet && player.armor[1].type == ItemID.ShadowScalemail && player.armor[2].type == ItemID.ShadowGreaves)
                {
                    //player.runAcceleration = 2;
                    //player.maxRunSpeed *= 2;
                    player.moveSpeed -= 0.15f;
                    //player.dash = 1;
                    player.blackBelt = true;
                    player.setBonus = "Gives you a small chance to dodge attacks";

                }
            }

        }

    }

    
   
    public class FrostBurnEx : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {
            var player = Main.player[projectile.owner];
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {
                if ((projectile.melee || projectile.ranged) && projectile.friendly)
                {
                    if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                    {
                        if (Main.rand.Next(4) < 2)
                        {
                            int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 187, 0f, 0f, 100, default, 1f);
                            Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                            Main.dust[dustIndex].noGravity = true;
                        }
                    }
                }
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockBack, bool crit)
        {
            var player = Main.player[projectile.owner];
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {
                if (projectile.melee && projectile.friendly)
                {


                    if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                    {

                       
                        target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);
                    }
                }
                if (projectile.ranged && projectile.friendly)
                {

                    if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                    {

                        
                        target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);
                       
                    }
                }
            }
        }
        public override void OnHitPvp(Projectile projectile, Player target, int damage, bool crit)
        {
            var player = Main.player[projectile.owner];
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {
                if (projectile.melee && projectile.friendly)
                {


                    if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                    {

                        target.ClearBuff(BuffID.Frostburn);
                        target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);
                    }
                }
                if (projectile.ranged && projectile.friendly)
                {

                    if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                    {


                        target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);
                        target.ClearBuff(BuffID.Frostburn);
                    }
                }
            }
        }
        

    }
   
   
    public class FrostburnExMelee2 : GlobalItem
    {
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
           
        
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {
                if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                {


                    target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);

                }
            }
        }
        public override void OnHitPvp(Item item, Player player, Player target, int damage, bool crit)
        {
           
            if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
            {


                target.AddBuff(mod.BuffType("SuperFrostBurn"), 600);

            }
        }
        public override void MeleeEffects(Item item, Player player, Rectangle hitbox)
        {
            
            if (!GetInstance<Configurations>().DisableVanillaBuff)
            {
                if (player.GetModPlayer<StormPlayer>().FrostCryoSet == true)
                {
                    if (Main.rand.Next(4) < 3)
                    {
                        int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 187, 0f, 0f, 100, default, 1f);
                        Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustIndex].noGravity = true;
                    }
                }
            }
        }
       
    }
}