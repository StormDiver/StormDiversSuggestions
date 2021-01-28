using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;




namespace StormDiversSuggestions.Basefiles
{
    public class StormPlayer : ModPlayer
    {
        //Bools activated from Armours and accessories

        public bool boulderDB; //The player has the Boulder Debuff
        // player.GetGlobalplayer<Stormplayer>().boulderDB = true; in debuff.cs
        // target.AddBuff(mod.BuffType("BoulderDebuff"), 180)
        public bool superBoulderDB;//The player has the Super Boulder Debuff

        public bool lunarBoulderDB; //The player has the Lunar Boulder Debuff

        public bool sandBurn; //The player has the Aridburn Debuff

        public bool superFrost; //The player has the CryoBurn Debuff

        public bool goldDerpie; //The player has the Golden Derpie Pet

        public bool stormHelmet; //The player has the Storm Diver Pet

        public bool turtled; //The Player has the turtled Buff

        public bool shroombuff; //The Player has the Ranged enhancement potion buff

        public bool flameCore; //The player has Betsy's Flame equipped

        public bool frostSpike; //The PLayer has the Cryo Core equipped

        public bool lunarBarrier; //The player has the Celestial Barrier equipped

        public bool nebulaBurn; //The player has the nebula Blaze Debuff
        
        public bool primeSpin; //The player has the Mech Spikes equipped

        public bool bootFall; //The player has either heavy boots equipped

        public bool derpJump; //The player has a full set of Derpling armour equipped

        public bool spectreDebuff; //Player has the Spectre Debuff

        public bool frostCube; //Player has the Summoners Core equipped

        public bool spooked; //Player has the Spooky Core equipped

        public bool lifeBarrier;  //Player has the life barrier buff from the endurance potion

        public bool FrostCryoSet; //Was for when you had a full set of frost armour, now unused

        public bool BloodDrop; //The player has a full set of hemo Armour

        public bool BloodOrb; //Player has taken a Blood potion

        public bool SpectreSkull; //Player has the Spectre Skull equipped

        public bool desertJar; //Player has the Pharoh's Urn equipped

        public bool graniteBuff; //Player has the granite accessory equipped

        public bool spaceRockOffence; //Player has the Space armour with helmet equipped

        public bool spaceRockDefence; //Player has the Space armour with mask equipped


        //Ints and Bools activated from this file

        public bool shotflame; //Indicates whether the SPooky Core has fired its flames or not
        public int skulltime = 0; //Time for the mechanical spikes to spawn
        public bool falling; //Wheter the player is falling at speed
        public int stopfall; //If the player has stopped falling
        public int bearcool; //Cooldown for the Teddy Bear
        public int stomptrail; //Delay of the projectuiles of the trail when falling with the boots
        public int bloodtime; //Cooldown for the orbs from the Hemo Armour set bonus
        public int frosttime; //Cooldown of the forst shards from the Cryo Core
        public int bloodorbspawn; //How often the blood orbs spawn from the potion
        public int desertdusttime; //Cooldown for the sand balst from the Phar0oh's Urn
        public int granitebufftime; //Cooldown for the granite Accessory Buff to be reapplied
        public bool granitesurge; //Makes it so the granite accessory cooldown can start and makes it so the next attack removes the buff
        public int spaceStrikecooldown; //Cooldown for the Offensive Space Armour set bonus
        public int spaceBarriercooldown; //Cooldown for the Defensive Space Armour set bonus

        public override void ResetEffects() //Resets bools if the item is unequipped
        {
            boulderDB = false;
            superBoulderDB = false;
            lunarBoulderDB = false;
            sandBurn = false;
            superFrost = false;
            turtled = false;
            goldDerpie = false;
            stormHelmet = false;
            shroombuff = false;
            flameCore = false;
            frostSpike = false;
            lunarBarrier = false;
            nebulaBurn = false;
            primeSpin = false;
            bootFall = false;
            derpJump = false;
            spectreDebuff = false;
            frostCube = false;
            spooked = false;
            lifeBarrier = false;
            FrostCryoSet = false;
            BloodDrop = false;
            BloodOrb = false;
            SpectreSkull = false;
            desertJar = false;
            graniteBuff = false;
            spaceRockOffence = false;
            spaceRockDefence = false;
        }
        public override void UpdateDead()//Reset all ints and bools if dead======================
        {
            bearcool = 0;
            bloodtime = 0;
            frosttime = 0;
            falling = false;
            bloodorbspawn = 0;
            desertdusttime = 0;
            granitebufftime = 0;
            granitesurge = false;
            spaceStrikecooldown = 0;
            spaceBarriercooldown = 0;
        }
     
       
        public override void PostUpdateEquips() //Updates every frame
        {
            //Reduces ints if they are above 0======================
            if (bloodtime > 0)
            {
                bloodtime--;
            }
            if (frosttime > 0)
            {
                frosttime--;
            }
            if (bearcool > 0)
            {
                bearcool--;
            }
            if (desertdusttime > 0)
            {
                desertdusttime--;
            }
            
            if (spaceBarriercooldown < 480 && spaceRockDefence) // counts up and when it reaches int the buff is applied, so players must wait after equipping armour
            {
                spaceBarriercooldown++;
            }
            if (spaceBarriercooldown == 480)
            {
                player.AddBuff(mod.BuffType("SpaceRockDefence"), 1);

            }
            if (!spaceRockDefence) //Clears buff if player removes armour
            {
                player.ClearBuff(mod.BuffType("SpaceRockDefence"));
                spaceBarriercooldown = 0;
            }
            if (spaceStrikecooldown < 300) //Ditto for offence
            {
                spaceStrikecooldown++;
            }
            if (spaceStrikecooldown == 300)
            {
                player.AddBuff(mod.BuffType("SpaceRockOffence"), 1);

            }
            if (!spaceRockOffence)
            {
                player.ClearBuff(mod.BuffType("SpaceRockOffence"));
                spaceStrikecooldown = 0;
            }
           

            //Spawns the blood ring around the player======================
            if (BloodOrb)
            {
                bloodorbspawn++;
                if (bloodorbspawn > 10)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("BloodOrbitProj"), 0, 0, player.whoAmI);

                    bloodorbspawn = 0;
                }
            } 
            if (!BloodOrb)
            {
                bloodorbspawn = 0;
            }

            //For Betsy's Flame======================
            if (flameCore)
            {

                player.wingTimeMax *= (int)3f;

                
                    player.dash = 3;
               
              /* if (player.controlUp) Maybe add to new item in 1.7
                {
                    player.jumpSpeedBoost += 3;
                    if (player.velocity.Y < 1)
                    {


                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 6);
                        dust.scale = 1.5f;
                        dust.noGravity = true;


                    }
                }*/
               
                //player.moveSpeed *= 0.4f;
            }
            //For the Mechanical Spikes===========================
            if (primeSpin)
            {
                if (!player.dead)
                {
                    skulltime++;
                }
                if (skulltime == 24)
                {

                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("PrimeAccessProj"), 75, 0f, player.whoAmI);

                    skulltime = 0;
                }

              
            }
            if (!primeSpin || player.dead)
            {
                skulltime = 0;
            }

            //For the Heavy Boots===========================
            if (bootFall) 
            {

                if (player.controlDown && player.velocity.Y != 0)
                {
                   
                    //Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 15, 2, -0.5f);
                    player.gravity += 5;
                    player.maxFallSpeed *= 1.5f;

                    if (player.velocity.Y > 12)
                    {


                        falling = true;
                        stopfall = 0;
                        player.noKnockback = true;
                        Vector2 position = player.position;
                        int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1.5f);
                        Main.dust[dustIndex].noGravity = true;

                        stomptrail++;
                        if (stomptrail > 2)
                        {

                            Projectile.NewProjectile(player.Center.X, player.BottomRight.Y - 10, 0, 5, mod.ProjectileType("StompBootProj2"), 50, 6f, player.whoAmI);
                            stomptrail = 0;
                        }


                    }

                }
                //For impacting the ground at speed
                    if (player.velocity.Y == 0 && falling && player.controlDown)
                    {
                       

                        for (int i = 0; i < 30; i++)
                        {

                            int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                            Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                            Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                            Main.dust[dustIndex].noGravity = true;
                        }
                        Projectile.NewProjectile(player.Center.X, player.Right.Y + 2, 5, 0, mod.ProjectileType("StompBootProj"), 40, 12f, player.whoAmI);
                        Projectile.NewProjectile(player.Center.X, player.Left.Y + 2, -5, 0, mod.ProjectileType("StompBootProj"), 40, 12f, player.whoAmI);
                        Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 14);
                        falling = false;

                    }
                    
                //If the player slows down too much then the stomp bool is cancelled
                if (player.velocity.Y <= 2)
                {
                    
                    stopfall++;
                }
                else
                {
                    stopfall = 0;
                }
                if (stopfall > 1)
                {
                    falling = false;
                }

            }
            //If boots are unequipped then cancel the bool
            if (!bootFall)
            {
                falling = false;
            }
            //For the Spooky Core ======================
            if (spooked)
            {
                if (player.itemAnimation > 1 && (player.HeldItem.melee || player.HeldItem.ranged || player.HeldItem.magic || player.HeldItem.summon || player.HeldItem.thrown)) //ranged item is in use
                {

                    if (!shotflame)
                    {
                        if (Main.rand.Next(7) == 0)
                        {
                            for (int i = 0; i < 20; i++)
                            {

                                Vector2 vel = new Vector2(Main.rand.NextFloat(-10, -10), Main.rand.NextFloat(10, 10));
                                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 244);

                                dust.noGravity = true;
                                
                            }

                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 34);

                            float numberProjectiles = 2 + Main.rand.Next(2);

                            for (int i = 0; i < numberProjectiles; i++)
                            {
                                float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in


                                float speedX = 0f;
                                float speedY = -2f;
                                int damage = (int)(player.HeldItem.damage * 1f);
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(90));
                                float scale = 1f - (Main.rand.NextFloat() * .5f);
                                perturbedSpeed = perturbedSpeed * scale;
                                Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SpookyProj"), damage, 1f, player.whoAmI);

                                
                            }
                        }

                    }
                    shotflame = true;
                    
                }
                else
                {
                    shotflame = false;
                }

            }
            //For the Celestial Barrier ======================
            if (lifeBarrier)
            {
                player.endurance += 0.33f;
                player.noKnockback = true;
            }
            //for Derpling armour
            if (derpJump)
            {
                player.jumpSpeedBoost += 5;

                player.autoJump = true;
                player.maxFallSpeed *= 1.5f;
                player.noKnockback = true;
            }
            //For the granite accessory cooldown
            if (granitesurge)//This bool is set to true when you take damage and begins the cooldown timer
            {
                granitebufftime++;
            }
            if (granitebufftime >= 1200) //The cooldown for when the buff can be applied again, 20 seconds
            {
            
                granitesurge = false; // Allows the buff to be applied again
                granitebufftime = 0;
            }
            if (!graniteBuff)//If the player removes the accessory the buff is gone
            {
                player.ClearBuff(mod.BuffType("GraniteAccessBuff"));
            }
           
        }
       //=====================For attacking an enemy with anything===========================================
        public override void OnHitAnything(float x, float y, Entity victim) 
        {
            
            if (granitesurge)//Clear the buff when attacking an enemy
            {
                player.ClearBuff(mod.BuffType("GraniteAccessBuff"));
            }

            //For the SpaceArmour with the helmet (offence)
            if (spaceRockOffence && spaceStrikecooldown == 300)
            {
                Projectile.NewProjectile(victim.Center.X, victim.Top.Y - 350, 0, 8f, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned directly above and goes stright down
                Projectile.NewProjectile(victim.Center.X - 0, victim.Top.Y - 450, -0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned directly above and moves slighly left
                Projectile.NewProjectile(victim.Center.X + 0, victim.Top.Y - 450, 0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI);  //Summoned directly above and moves slighly right
                Projectile.NewProjectile(victim.Center.X - 60, victim.Top.Y - 550, -0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned to the left and slighlty moves left
                Projectile.NewProjectile(victim.Center.X + 60, victim.Top.Y - 550, 0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned to the right and slightly moves right
                Projectile.NewProjectile(victim.Center.X - 250, victim.Top.Y - 500, 3f, 6, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned far to the left and moves right
                Projectile.NewProjectile(victim.Center.X + 250, victim.Top.Y - 500, -3f, 6, mod.ProjectileType("SpaceArmourProj"), 90, 6f, player.whoAmI); //Summoned far to the right and moves left
                for (int i = 0; i < 30; i++)
                {

                    float speedX = Main.rand.NextFloat(-5f, 5f);
                    float speedY = Main.rand.NextFloat(-5f, 5f);
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 6, speedX, speedY, 130, default, 1.5f);
                    dust.noGravity = true;
                    dust.velocity *= 2;
                    dust.noGravity = true;
                    dust.velocity *= 2;

                }
                Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 45);
                spaceStrikecooldown = 0;

            }
            //For the Hemogoblin armour setbonus ======================

            if (player.HeldItem.melee)
            {
                if (BloodDrop)
                {

                    if (bloodtime < 1 && !player.dead)
                    {

                        Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 9);

                        float numberProjectiles = 7 + Main.rand.Next(3);

                        for (int i = 0; i < numberProjectiles; i++)
                        {
                            float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in


                            float speedX = 0f;
                            float speedY = -6f;
                            int blooddamage = (int)(player.HeldItem.damage * 0.8f);
                            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(135));
                            float scale = 1f - (Main.rand.NextFloat() * .5f);
                            perturbedSpeed = perturbedSpeed * scale;
                            Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BloodDropProj"), blooddamage, 1f, player.whoAmI);

                            bloodtime = 300;
                        }
                    }
                }
            }
            //For the Desert urn
            if (desertJar)
            {

                if (desertdusttime < 1 && !player.dead)
                {

                    Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 20);

                    
                    float numberProjectiles = 8 + Main.rand.Next(0);
                    float rotation = MathHelper.ToRadians(180);
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        float speedX = -1f;
                        float speedY = 0f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles)));
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DesertSpellProj"), 35, 0f, player.whoAmI);

                        desertdusttime = 240;

                    }
                }
            }
           
            base.OnHitAnything(x, y, victim);
        }

        //=====================For taking damage from any source===========================================

        int attackdmg = 0;//This is for how much damage the player takes
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) //When you take damage for whatever reason
        {
            player.ClearBuff(mod.BuffType("HeartBarrierBuff")); //Removes buff on hit
            attackdmg = (int)damage; //Int for the damage taken

            //First trigger for the granite accessory buff for 20 seconds
            if (graniteBuff && !granitesurge)
            {
                player.AddBuff(mod.BuffType("GraniteAccessBuff"), 1200);
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 41, 1, -0.3f);
                for (int i = 0; i < 25; i++)
                {

                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 65);
                    dust.noGravity = true;
                    dust.scale = 2f;
                    dust.velocity *= 2;
                }
                granitesurge = true; //Prevents the buff from being refreshed
            }
            
            //For Space Armour with Mask (Defence)
            if (spaceRockDefence && spaceBarriercooldown == 480)
            {
                Projectile.NewProjectile(player.Center.X, player.Top.Y - 350, 0, 8f, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned above and goes straight down
                Projectile.NewProjectile(player.Center.X - 0, player.Top.Y - 450, 0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned above and moves slighly right
                Projectile.NewProjectile(player.Center.X + 0, player.Top.Y - 450, -0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI);  //Summoned above and moves slightly left
                Projectile.NewProjectile(player.Center.X - 60, player.Top.Y - 550, -0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned to the left and moves slightly left
                Projectile.NewProjectile(player.Center.X + 60, player.Top.Y - 550, 0.8f, 8, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned to the right and moves slightly right
                Projectile.NewProjectile(player.Center.X - 250, player.Top.Y - 500, 3f, 6, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned far to the left and moves quickly right
                Projectile.NewProjectile(player.Center.X + 250, player.Top.Y - 500, -3f, 6, mod.ProjectileType("SpaceArmourProj"), 180, 6f, player.whoAmI); //Summoned far to the right and moves quickly left
                for (int i = 0; i < 30; i++)
                {

                    float speedX =  Main.rand.NextFloat(-5f, 5f);
                    float speedY =  Main.rand.NextFloat(-5f, 5f);
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 6, speedX, speedY, 130, default, 1.5f);
                    dust.noGravity = true;
                    dust.velocity *= 2;
                }
                Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 45);

                spaceBarriercooldown = 0;
            }

            //Grant buff for celestial barrier based on incoming damage======================
            if (lunarBarrier)
            {
                
           
                if ((attackdmg >= 90 && Main.expertMode))
                {
                   
                    
                        //if (!Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
                        {
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 122);
                            player.AddBuff(mod.BuffType("CelestialBuff"), (int)(attackdmg * 4f));

                        }
                    
                }
                if (attackdmg >= 60 && !Main.expertMode)
                {
                    //if (!Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
                    {
                        Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 122);
                        player.AddBuff(mod.BuffType("CelestialBuff"), (int)(attackdmg * 4f));
                    }
                }
            }
            //Creates the shards for the frost core when hit ======================
            if (frostSpike)
            {
                if (frosttime < 1)
                {
                    Main.PlaySound(4, (int)player.position.X, (int)player.position.Y, 56);
                    float numberProjectiles = 10 + Main.rand.Next(4);
                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -9f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(150));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostAccessProj"), (int)((attackdmg * 1f)), 3f, player.whoAmI);


                    }
                    for (int i = 0; i < 30; i++)
                    {

                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = Main.LocalPlayer.position;
                        dust = Main.dust[Terraria.Dust.NewDust(position, player.width, player.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                        dust.noGravity = true;
                    }
                    frosttime = 360;
                    player.AddBuff(mod.BuffType("FrozenBuff"), 360);
                }
            }

        }
        //===================================Other hooks======================================
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //True Melee Only
        {

        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit) //Hit by melee only
        {

        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) //Hit by any projectile
        {

        }

        public override void UpdateLifeRegen()
        {
            //Regeneration, can also be done in buffs.cs
            if (Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
            {
                
                player.lifeRegen += 30;
                
            }
         
        }
      
        public override void UpdateBadLifeRegen()
        {
            { //For DoT debuffs
                if (boulderDB)
                {
                   
                    player.lifeRegen = -10;
                    
                }
                if (superBoulderDB)
                {

                    
                    player.lifeRegen = -20;
                }
                if (lunarBoulderDB)
                {

                    
                    player.lifeRegen = -30;
                }
                if (sandBurn)
                {

                    
                    player.lifeRegen = -16;
                }
                if (superFrost)
                {


                    player.lifeRegen = -16;
                }
                if (nebulaBurn)
                {
                    player.lifeRegen = -30;
                    
                }
                if (spectreDebuff)
                {


                    player.lifeRegen = -18;
                }
            }
        }

        
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
           
            //This is done in buffs.cs
           
    
        }
      
    }
}