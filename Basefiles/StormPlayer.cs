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
    public class NoRoD : GlobalItem
    {
        /*public override bool CanUseItem(Item item, Player player) //use this to disable the RoD if you want 
        {
            if (item.type == ItemID.RodofDiscord)
            {
                if (player.HasBuff(mod.BuffType("TwilightDebuff")))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }*/
    }
    public class StormPlayer : ModPlayer
    {
        //Bools activated from Armours and accessories

        public bool boulderDB; //The player has the Boulder Debuff
        // player.GetGlobalplayer<Stormplayer>().boulderDB = true; in debuff.cs
        // target.AddBuff(mod.BuffType("BoulderDebuff"), 180)
        public bool superBoulderDB;//The player has the Super Boulder Debuff

        public bool lunarBoulderDB; //The player has the Lunar Boulder Debuff

        public bool superBurn; //The player has the Blazing Fire debuff

        public bool sandBurn; //The player has the Aridburn Debuff

        public bool superFrost; //The player has the CryoBurn Debuff

        public bool goldDerpie; //The player has the Golden Derpie Pet

        public bool stormHelmet; //The player has the Storm Diver Pet

        public bool twilightPet; //The player has the Twilight Light Pet


        public bool turtled; //The Player has the turtled Buff

        public bool shroombuff; //The Player has the Ranged enhancement potion buff

        public bool flameCore; //The player has Betsy's Flame equipped

        public bool frostSpike; //The Player has the Cryo Core equipped

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

        public bool shroomaccess; //Player has the Shroomite Accessory equipped

        public bool heartSteal; //Player has the Jar of Hearts equipped

        public bool mushset; //Player has a set of Glowing mushroom armour equipped

        public bool hellSoulSet; //Player has full set of SOul Fire armour eqipped

        public bool hellSoulDebuff; //Player has the Hell Soul debuff

        public bool twilightSet; //Player has full set of Twilight armour

        public bool derpEye; //Player had the Derpling Eye equipped

        public bool skyKnightSet; //Player hasa full set of SkyKnight Armour

        public bool santankSet; //Player had a full set of Santank armour

        public bool blueCuffs; //Player has insulated cuffs equipped

        public bool lunaticHood; //Player has the Luantic Hood equipped

        public bool ultraBurn; //Player ahs the ultra burn debuff

        public bool ultraFrost; //Player has Ultra Frost burn debuff

        public bool beetleFist; //player has the Beetle gauntlet equipped
        //Ints and Bools activated from this file

        public bool shotflame; //Indicates whether the SPooky Core has fired its flames or not
        public int skulltime = 0; //Time for the mechanical spikes to spawn
        public bool falling; //Wheter the player is falling at speed
        public int stopfall; //If the player has stopped falling
        public int bearcool; //Cooldown for the Teddy Bear
        public int stomptrail; //Delay of the projectuiles of the trail when falling with the boots
        public int bloodtime; //Cooldown for the orbs from the Hemo Armour set bonus
        public int frosttime; //Cooldown of the forst shards from the Cryo Core
        public int desertdusttime; //Cooldown for the sand balst from the Phar0oh's Urn
        public int granitebufftime; //Cooldown for the granite Accessory Buff to be reapplied
        public bool granitesurge; //Makes it so the granite accessory cooldown can start and makes it so the next attack removes the buff
        public int spaceStrikecooldown; //Cooldown for the Offensive Space Armour set bonus
        public int spaceBarriercooldown; //Cooldown for the Defensive Space Armour set bonus
        public int shroomshotCount = 0; //Count show many times the player has fired with the shroomite access
        public bool shotrocket; //Wheter the shroomite rocket has been fired or not
        public int hellblazetime; //Cooldown for the flames created from HellSoul armour set
        public int mushtime; //Cooldown for mushrooms summoned with mushroom armour
        public int hellsoultime; //Cooldown for the souls created by hell soul armour
        public bool derpfalling; //Falling at speed with derp leg
        public int stopderpfall; //Player has stoppd falling with derp leg
        public bool twilightcharged; //Activates when the player is able to teleport with the twilight armour
        public int derplinglaunchcooldown; //How long until the player can launch enemies in the air with the Derpling armour set
        public bool celestialspin; //Has the spinning projectile fo the celestial shell been summoned?
        public bool skysentry; //Has the Sky Knight sentry been summoned>
        public int santankcharge; //Charging up the santank missle
        public int santankmissleup; //Adds one to the charge every 10 frames
        public bool santanktrigger; //Has the player triggered the missiles
        public bool lunaticsentry; //Has the lunatic sentry been summoned?
        public int templeWarning; //Warning until Temple Guardians spawn
        public int beetlecooldown; //Cooldown until more beetles can be summoned
        public override void ResetEffects() //Resets bools if the item is unequipped
        {
            boulderDB = false;
            superBoulderDB = false;
            lunarBoulderDB = false;
            superBurn = false;
            sandBurn = false;
            superFrost = false;
            turtled = false;
            goldDerpie = false;
            stormHelmet = false;
            twilightPet = false;
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
            shroomaccess = false;
            hellSoulSet = false;
            heartSteal = false;
            mushset = false;
            hellSoulDebuff = false;
            twilightSet = false;
            derpEye = false;
            skyKnightSet = false;
            santankSet = false;
            blueCuffs = false;
            lunaticHood = false;
            ultraBurn = false;
            ultraFrost = false;
            beetleFist = false;
        }
        public override void UpdateDead()//Reset all ints and bools if dead======================
        {
            bearcool = 0;
            bloodtime = 60;
            frosttime = 0;
            falling = false;
            desertdusttime = 0;
            granitebufftime = 0;
            granitesurge = false;
            spaceStrikecooldown = 0;
            spaceBarriercooldown = 0;
            shroomshotCount = 0;
            shotrocket = false;
            hellblazetime = 45;
            mushtime = 60;
            twilightcharged = false;
            derplinglaunchcooldown = 90;
            celestialspin = false;
            skysentry = false;
            santankcharge = 0;
            santankmissleup = 0;
            santanktrigger = false;
            lunaticsentry = false;
            templeWarning = 0;
            skulltime = 0;
            beetlecooldown = 0;
        }

        public override void PostUpdateEquips() //Updates every frame
        {

            //Detect if player is in Temple and immediatly summon up to 8 Guardians
            int xtilepos = (int)(player.position.X + (float)(player.width / 2)) / 16;
            int ytilepos = (int)(player.position.Y + (float)(player.height / 2)) / 16;
            if (Main.tile[xtilepos, ytilepos].wall == WallID.LihzahrdBrickUnsafe)
            {

                if (!NPC.downedPlantBoss && NPC.CountNPCS(mod.NPCType("GolemMinion")) < 8)
                {
                    templeWarning++;
                    if (templeWarning == 1 && !NPC.AnyNPCs(mod.NPCType("GolemMinion")))
                    {
                        Main.NewText("The ancient temple defenses begin to wake up!!!", 204, 101, 22);
                    }

                    if (templeWarning >= 300)
                    {
                        if (Main.rand.Next(60) == 0)
                        {
                            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.GolemMinion>());
                        }
                    }
                }
            }
            else
            {
                templeWarning = 0;
            }
            


            //Reduces ints if they are above 0======================

            if (bloodtime > 0)
            {
                bloodtime--;
            }
            if (bloodtime <= 0 && BloodDrop)
            {
                player.AddBuff(mod.BuffType("BloodBurstBuff"), 2);

            }
            if (beetlecooldown > 0)
            {
                beetlecooldown--;
            }
            if (hellblazetime > 0)
            {
                hellblazetime--;
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

            if (granitebufftime > 0)
            {
                granitebufftime--;
            }
            if (mushtime > 0)
            {
                mushtime--;
            }
           if (derplinglaunchcooldown > 0)
            {
                derplinglaunchcooldown--;
            }
            if (spaceBarriercooldown < 360 && spaceRockDefence) // counts up and when it reaches int the buff is applied, so players must wait after equipping armour
            {
                spaceBarriercooldown++;
            }
            if (spaceBarriercooldown == 360)
            {
                player.AddBuff(mod.BuffType("SpaceRockDefence"), 2);

            }
            if (!spaceRockDefence) //Clears buff if player removes armour
            {
                player.ClearBuff(mod.BuffType("SpaceRockDefence"));
                spaceBarriercooldown = 0;
            }
            if (spaceStrikecooldown < 240) //Ditto for offence
            {
                spaceStrikecooldown++;
            }
            if (spaceStrikecooldown == 240)
            {
                player.AddBuff(mod.BuffType("SpaceRockOffence"), 2);

            }
            if (!spaceRockOffence)
            {
                player.ClearBuff(mod.BuffType("SpaceRockOffence"));
                spaceStrikecooldown = 0;
            }

            if (derplinglaunchcooldown == 0 && derpJump && player.velocity.Y == 0)
            {
                player.AddBuff(mod.BuffType("DerpBuff"), 2);

            }

            if (beetlecooldown == 0 && beetleFist && player.HeldItem.melee)
            {
                if (Main.rand.Next(10) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(player.position.X - 10, player.position.Y - 5), player.width + 20, player.height + 10, mod.DustType("BeetleDust"));
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.5f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
            }

            //For santank set ======================================================================
            if (santankSet)
            {
                if (santankcharge <= 100 && !santanktrigger) //Charges up the rockets
                {
                    santankmissleup++;
                }
                if (santankmissleup >= 4) //Adds 1 int to the charge every n frames
                {
                    santankcharge++;
                    santankmissleup = 0;
                }
                if (StormDiversSuggestions.ArmourSpecialHotkey.JustPressed && santankcharge >= 10 && !santanktrigger) //Activates when player presses button
                {
                    santanktrigger = true;

                }
                if (santanktrigger) //Drains the rocket charge and clears buffs
                {
                    santankcharge--;
                    player.ClearBuff(mod.BuffType("SantankBuff1"));
                    player.ClearBuff(mod.BuffType("SantankBuff2"));
                    player.ClearBuff(mod.BuffType("SantankBuff3"));
                }
                if (!santanktrigger && santankmissleup == 0 && (santankcharge == 10 || santankcharge == 20 || santankcharge == 30 || santankcharge == 40 || santankcharge == 50 || santankcharge == 60 || santankcharge == 70 || santankcharge == 80 || santankcharge == 90 || santankcharge == 100)) 
                    //Creates a particle and sound effect at these times, times by 4 to get excat frame
                {
                    for (int i = 0; i < 30; i++)
                    {

                        int dustIndex = Dust.NewDust(new Vector2(player.Center.X - (15 * player.direction) -4, player.Center.Y - 8), 0, 0, 6, 0f, 0f, 50, default, 1.5f);
                        Main.dust[dustIndex].velocity *= 2;
                        Main.dust[dustIndex].noGravity = true;
                    }
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 61, 0.5f, 0.5f);
                }
                else if (santanktrigger && (santankcharge == 10 || santankcharge == 20 || santankcharge == 30 || santankcharge == 40 || santankcharge == 50 || santankcharge == 60 || santankcharge == 70 || santankcharge == 80 || santankcharge == 90 || santankcharge == 100))
                //Fires missles at these times
                {
                    for (int i = 0; i < 30; i++)
                    {

                        int dustIndex = Dust.NewDust(new Vector2(player.Center.X - (15 * player.direction) - 4, player.Center.Y - 8), 0, 0, 6, 0f, 0f, 50, default, 1.5f);
                        Main.dust[dustIndex].velocity *= 2;
                        Main.dust[dustIndex].noGravity = true;
                    }
                    for (int i = 0; i < 25; i++)
                    {

                        int dustIndex = Dust.NewDust(new Vector2(player.Center.X - (15 * player.direction) - 4, player.Center.Y - 8), 0, 0, 31, 0, -3, 100, default, 1f);
                        Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[dustIndex].noGravity = true;
                    }
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 92);


                    float speedX = 0f;
                    float speedY = -8f;
                    int damage = (int)(125 * player.rangedDamage);
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(50));
                    float scale = 1f - (Main.rand.NextFloat() * .1f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(player.Center.X - (15 * player.direction), player.Center.Y - 6, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("SantankMissleProj"), damage, 1f, player.whoAmI);

                }

                if (santankcharge <= -20) //Reset trigger once all missile are fired (negative creaets a recharge delay, delay is 1 = 4, so 20 = 80 frames, plus the 10 * 4 (40frame) delay for the first charge (120 frames, 2 seconds))
                {
                    santanktrigger = false;
                    
                }
                //For the buffs, Tier 1 = 1-4 rockets, Tier 2 = 5-9, Tier 3 = 10
                if (santankcharge >= 10 && santankcharge < 50 && !santanktrigger)
                {
                    player.ClearBuff(mod.BuffType("SantankBuff2"));
                    player.ClearBuff(mod.BuffType("SantankBuff3"));

                    player.AddBuff(mod.BuffType("SantankBuff1"), 2);

                }
                else if (santankcharge >= 50 && santankcharge < 100 && !santanktrigger)
                {
                    player.ClearBuff(mod.BuffType("SantankBuff1"));
                    player.ClearBuff(mod.BuffType("SantankBuff3"));

                    player.AddBuff(mod.BuffType("SantankBuff2"), 2);
                }
                else if (santankcharge >= 100 && !santanktrigger)
                {
                    player.ClearBuff(mod.BuffType("SantankBuff1"));
                    player.ClearBuff(mod.BuffType("SantankBuff2"));

                    player.AddBuff(mod.BuffType("SantankBuff3"), 2);
                }
                else
                {
                    player.ClearBuff(mod.BuffType("SantankBuff1"));
                    player.ClearBuff(mod.BuffType("SantankBuff2"));
                    player.ClearBuff(mod.BuffType("SantankBuff3"));

                }

            }
            if (!santankSet) //Reset values if armour is removed
            {
                santankcharge = -10;
                santankmissleup = 0;
                santanktrigger = false;
            }

            //For Twilight Armour ====================================================================

            float xWarplimit = 640;
            float yWarplimit = 400;
            if (twilightSet)
            {
                float distanceX = player.Center.X - Main.MouseWorld.X;
                float distanceY = player.Center.Y - Main.MouseWorld.Y;
                float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

                int xcursor = (int)(Main.MouseWorld.X / 16);
                int ycursor = (int)(Main.MouseWorld.Y / 16);
                Tile tile = Main.tile[xcursor, ycursor];
                if ((tile != null && !tile.nactive() || !Main.tileSolid[tile.type]) && !player.HasBuff(mod.BuffType("TwilightDebuff"))) //Checks if mouse is in valid postion
                {
                    if (((distanceX < -xWarplimit || distanceX > xWarplimit || distanceY < -yWarplimit || distanceY > yWarplimit) && Collision.CanHitLine(Main.MouseWorld, 1, 1, player.position, player.width, player.height)) ||
                        (distanceX > -xWarplimit && distanceX < xWarplimit && distanceY > -yWarplimit && distanceY < yWarplimit)) //If there is no line of sight and cursor is past limit, don't allow teleport to prevent gettign stuck in blocks
                    {
                    

                        twilightcharged = true; //Activates the outline effect on the armour

                        if (StormDiversSuggestions.ArmourSpecialHotkey.JustPressed) //Activates when player presses button
                        {
                            player.AddBuff(BuffID.Obstructed, 10); //Hopefully this covers up the janky teleport :thePain:
                            player.AddBuff(mod.BuffType("TwilightDebuff"), 720);

                            player.grappling[0] = -1; //Remove grapple hooks
                            player.grapCount = 0;
                            for (int p = 0; p < 1000; p++)
                            {
                                if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
                                {
                                    Main.projectile[p].Kill();
                                }
                            }
                            {
                                for (int i = 0; i < 30; i++) //Dust pre-teleport
                                {
                                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 62);
                                    dust.scale = 1.1f;
                                    dust.velocity *= 2;
                                    //dust.noGravity = true;

                                }
                                for (int i = 0; i < 30; i++)
                                {
                                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 179);
                                    dust.scale = 1.5f;
                                    dust.noGravity = true;
                                    dust.fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;


                                }

                                //X postion 
                                {
                                    if (distanceX <= xWarplimit && distanceX >= -xWarplimit)
                                    {
                                        player.position.X = Main.MouseWorld.X - (player.width / 2);
                                        //Main.NewText("Little mouse X", 0, 146, 0);
                                    }
                                    else
                                    {
                                        if (distanceX < -xWarplimit)
                                        {
                                            player.position.X = (Main.MouseWorld.X - (player.width / 2)) + (distanceX + xWarplimit);
                                            //Main.NewText("Mouse it to the right", 146, 0, 0);
                                        }
                                        else if (distanceX > xWarplimit)
                                        {
                                            player.position.X = (Main.MouseWorld.X - (player.width / 2)) + (distanceX - xWarplimit);
                                            //Main.NewText("Mouse it to the left", 146, 0, 0);
                                        }
                                    }
                                }
                                //Y postion 
                                {
                                    if (distanceY <= yWarplimit && distanceY >= -yWarplimit)
                                    {
                                        player.position.Y = Main.MouseWorld.Y - (player.height);
                                        //Main.NewText("Little mouse Y", 0, 146, 0);
                                    }
                                    else
                                    {
                                        if (distanceY < -yWarplimit)
                                        {
                                            player.position.Y = (Main.MouseWorld.Y - (player.height)) + (distanceY + yWarplimit);
                                            //Main.NewText("Mouse it to the down", 0, 0, 146);

                                        }
                                        else if (distanceY > yWarplimit)
                                        {
                                            player.position.Y = (Main.MouseWorld.Y - (player.height)) + (distanceY - yWarplimit);
                                            //Main.NewText("Mouse it to the up", 0, 0, 146);
                                        }
                                    }
                                }

                                for (int i = 0; i < 30; i++) //Dust post-teleport
                                {
                                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 62);
                                    dust.scale = 1.1f;
                                    dust.velocity *= 2;
                                    //dust.noGravity = true;

                                }
                                for (int i = 0; i < 30; i++)
                                {
                                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 179);
                                    dust.scale = 1.5f;
                                    dust.noGravity = true;
                                    dust.fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;

                                }
                                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 8, 2f, -0.5f);



                            }
                        }
                      

                    }
                    else
                    {
                        twilightcharged = false; 

                    }
                }

            else
            {
                twilightcharged = false; //Removes the outline effect if the player is unable to charge
            }
            }

            //For Spooky Core======================
            if (spooked)
            {
                float distancehealth = 350 + ((player.statLifeMax2 - player.statLife) / 2);
                if (distancehealth > 650)
                {
                    distancehealth = 650;
                }
                if (Main.rand.Next(5) == 0)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 259, 0, -3);
                    dust.noGravity = true;
                    dust.scale = 1f;
                }

                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    var player = Main.LocalPlayer;

                    float shootToX = target.position.X + (float)target.width * 0.5f - player.Center.X;
                    float shootToY = target.position.Y + (float)target.height * 0.5f - player.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));


                    /*float distanceX = player.Center.X - target.Center.X;
                    float distanceY = player.Center.Y - target.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));*/
                    if (distance < distancehealth && !target.friendly && target.lifeMax > 5 && !target.dontTakeDamage && target.active && target.type != NPCID.TargetDummy && Collision.CanHit(player.Center, 0, 0, target.Center, 0, 0))
                    {
                        if (!target.buffImmune[(BuffType<SpookedDebuff>())])
                        {
                            distance = 1.6f / distance;

                            //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
                            shootToX *= distance * (12f + (distancehealth / 50));
                            shootToY *= distance * (12f + (distancehealth / 50));
                            if (Main.rand.Next(4) == 0)
                            {
                                Vector2 perturbedSpeed = new Vector2(shootToX, shootToY).RotatedByRandom(MathHelper.ToRadians(8));

                                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 259, perturbedSpeed.X, perturbedSpeed.Y);
                                dust.fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                                dust.noGravity = true;
                                dust.scale = 1.5f;
                            }


                            target.AddBuff(mod.BuffType("SpookedDebuff"), 2);
                        }
                    }
                    
                }

            }


            //For the Mechanical Spikes===========================
            if (primeSpin)
            {
                if (!player.dead && skulltime <= 50)
                {
                    skulltime++;
                }
                if (skulltime == 1 || skulltime == 25 || skulltime == 49) //24 frames between spawns
                {

                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("PrimeAccessProj"), 75, 0f, player.whoAmI);

                    
                }

              
            }
            if (!primeSpin)//reset timer
            {
                skulltime = 0;
            }

            //For the Heavy Boots===========================
            if (bootFall) 
            {

                if (player.controlDown && !player.controlJump && player.velocity.Y != 0 && !player.mount.Active)
                {
                   
                    //Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 15, 2, -0.5f);
                    player.gravity += 4;
                    player.maxFallSpeed *= 1.4f;
                    player.dash = 0;
                    player.velocity.X *= 0.75f;
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
                        Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 14);
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
            // For the Shroomite Launcher Accessory
            if (shroomaccess)
            {
                if (player.itemTime > 1 && player.HeldItem.ranged && player.HeldItem.useAmmo == AmmoID.Bullet) //If the player is holding a ranged weapon and usetime cooldown is above 1
                {
                    
                    
                    if (!shotrocket) //If the rocket hasn't already been fired this use then it it fire it
                    {
                        shroomshotCount++;
                        if (shroomshotCount >= 5) //Every 5 shots fires a rocket
                        {

                            shroomshotCount = 0; //Resets the shot count
                            float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in
                            float velocity = 13f;
                            int type = mod.ProjectileType("ShroomSetRocketProj");
                            int damage = (int)((player.HeldItem.damage * 2f) * player.rangedDamage * player.allDamage);
                            Projectile.NewProjectile(player.Center, new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * velocity, type, damage, 2f, player.whoAmI);
                            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 92);
                        }

                    }
                    shotrocket = true; //This prevents a rocket from spawning every frame
                }
                else
                {
                    shotrocket = false; //Once the usetime is back to 0 this bool can be set to false again
                }
            }
            //For betsy's Flame ======================
            if (flameCore)
            {

                player.runAcceleration += 0.25f;

                if (player.itemAnimation > 1 && (player.HeldItem.melee || player.HeldItem.ranged || player.HeldItem.magic || player.HeldItem.summon || player.HeldItem.thrown)) //weapon is in use
                {

                    if (!shotflame)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            for (int i = 0; i < 20; i++)
                            {

                                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 244);

                                dust.noGravity = true;
                               
                            }

                            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 34);

                            float numberProjectiles = 2 + Main.rand.Next(2);

                            for (int i = 0; i < numberProjectiles; i++)
                            {
                                float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in


                                float speedX = 0f;
                                float speedY = -6f;
                                int damage = (int)((player.HeldItem.damage * 0.5f) * player.allDamage);
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(90));
                                float scale = 1f - (Main.rand.NextFloat() * .5f);
                                perturbedSpeed = perturbedSpeed * scale;
                                Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BetsyFlameProj"), damage, 1f, player.whoAmI);

                                
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
            //For the Endurance Healing Potion Barrier ======================
            if (lifeBarrier)
            {
                player.endurance += 0.25f;
                player.noKnockback = true;
            }
            //for Derpling armour
            if (derpJump)
            {
                player.jumpSpeedBoost += 4.5f;
                player.noFallDmg = true;

                player.autoJump = true;
                player.maxFallSpeed *= 1.5f;
                //Creates the wave upon jumping
                if (player.velocity.Y == 0 && player.controlJump && derplinglaunchcooldown <= 0)
                {

                    player.ClearBuff(mod.BuffType("DerpBuff"));

                    Main.PlaySound(SoundID.NPCHit, (int)player.Center.X, (int)player.Center.Y, 22, 1.5f, -0.5f);

                    for (int i = 0; i < 40; i++)
                    {
                        float speedX = Main.rand.NextFloat(-2f, 2f);
                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 68, speedX, -3, 130, default, 1.5f);
                        dust.noGravity = true;
                        dust.velocity *= 2;

                    }
                    for (int i = 0; i < 20; i++)
                    {

                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 68, -5, 0, 130, default, 1.5f);
                        dust.noGravity = true;
                        dust.velocity *= 2;
                        var dust2 = Dust.NewDustDirect(player.position, player.width, player.height, 68, 5, 0, 130, default, 1.5f);
                        dust2.noGravity = true;
                        dust2.velocity *= 2;
                    }

                    Projectile.NewProjectile(player.Center.X, player.Right.Y - 12, 7, 0, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Left.Y - 12, -7, 0, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Right.Y - 12, 7, -2.5f, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Left.Y - 12, -7, -2.5f, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    derplinglaunchcooldown = 60;
                }
            }
            if (!derpJump)
            {
                derplinglaunchcooldown = 60;
            }
           
            if (!graniteBuff)//If the player removes the accessory the buff is gone
            {
                player.ClearBuff(mod.BuffType("GraniteAccessBuff"));
            }
            //For the Celestial Barrier Projectile
            if (lunarBarrier)
            {
                if (!celestialspin)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("CelestialShieldProj"), 0, 0f, player.whoAmI);
                    celestialspin = true;
                }
            }
            if (!lunarBarrier)
            {
                celestialspin = false;
            }
            //For the Sky Knight set
            if (skyKnightSet)
            {
                player.AddBuff(mod.BuffType("SkyKnightSentryBuff"), 2);

                if (!skysentry)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("SkyKnightSentryProj"), 0, 0f, player.whoAmI);
                    skysentry = true;

                }
            }
            if (!skyKnightSet)
            {
                skysentry = false;
                player.ClearBuff(mod.BuffType("SkyKnightSentryBuff"));

            }
            //For the Lunatic Cultist accessory
            if (lunaticHood)
            {
                //player.AddBuff(mod.BuffType("SkyKnightSentryBuff"), 2);

                if (!lunaticsentry)
                {
                    Projectile.NewProjectile(player.Center.X - 80, player.Center.Y - 40, 0, 0, mod.ProjectileType("LunaticExpertSentryProj"), 0, 0f, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X + 80, player.Center.Y - 40, 0, 0, mod.ProjectileType("LunaticExpertSentryProj"), 0, 0f, player.whoAmI);

                    lunaticsentry = true;

                }
            }
            if (!lunaticHood)
            {
                lunaticsentry = false;
                //player.ClearBuff(mod.BuffType("SkyKnightSentryBuff"));

            }
        }
       //=====================For attacking an enemy with anything===========================================
        public override void OnHitAnything(float x, float y, Entity victim) 
        {
            int mushdamage = (int)(16 * player.rangedDamage); //Looks like you didn't deal mush damage with this 
            if (mushset && mushtime == 0)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Projectile.NewProjectile(victim.Center.X - 100, victim.Center.Y - 100, 12, 12f, mod.ProjectileType("MagicMushArmourProj"), mushdamage, 0, player.whoAmI); //Summoned directly above and goes straight down
                }
                else
                {
                    Projectile.NewProjectile(victim.Center.X + 100, victim.Center.Y - 100, -12, +12f, mod.ProjectileType("MagicMushArmourProj"), mushdamage, 0, player.whoAmI); //Summoned directly above and goes straight down

                }

                mushtime = 90;
            }
            //For the SpaceArmour with the helmet (offence)
            int offencedmg = (int) (90 * player.allDamage);
            int offenceknb = 5;
            float offenceveloX = victim.velocity.X * 0.6f;
            
            if (spaceRockOffence && player.HasBuff(mod.BuffType("SpaceRockOffence")))
            {
                Projectile.NewProjectile(victim.Center.X - 0, victim.Center.Y - 350, 0 + offenceveloX, 8f, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned directly above and goes straight down
                Projectile.NewProjectile(victim.Center.X - 50, victim.Center.Y - 450, 0 + offenceveloX, 8, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned slightly left and moves straight down
                Projectile.NewProjectile(victim.Center.X + 50, victim.Center.Y - 450, 0 + offenceveloX, 8, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI);  //Summoned slightly right and moves straight down
                Projectile.NewProjectile(victim.Center.X - 150, victim.Center.Y - 500, 2f + offenceveloX, 8, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned to the left and moves left
                Projectile.NewProjectile(victim.Center.X + 150, victim.Center.Y - 500, -2f + offenceveloX, 8, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned to the right and moves right
                Projectile.NewProjectile(victim.Center.X - 200, victim.Center.Y - 450, 4 + offenceveloX, 6, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned further to the left and moves right
                Projectile.NewProjectile(victim.Center.X + 200, victim.Center.Y - 450, -4 + offenceveloX, 6, mod.ProjectileType("SpaceArmourProj"), offencedmg, offenceknb, player.whoAmI); //Summoned further to the right and moves left
                for (int i = 0; i < 30; i++)
                {

                    float speedX = Main.rand.NextFloat(-5f, 5f);
                    float speedY = Main.rand.NextFloat(-5f, 5f);
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 6, speedX, speedY, 130, default, 1.5f);
                    dust.noGravity = true;
                    dust.velocity *= 2;

                }
                Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 45);
                spaceStrikecooldown = 0;
                player.ClearBuff(mod.BuffType("SpaceRockOffence"));

            }

            //For the Hemogoblin armour setbonus ======================

            if (player.HeldItem.melee)
            {
                if (BloodDrop)
                {

                    if (bloodtime < 1 && !player.dead)
                    {

                        Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 9);

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

                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 20);

                    
                    float numberProjectiles = 6 + Main.rand.Next(0);
                    float rotation = MathHelper.ToRadians(180);
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        float speedX = -1f;
                        float speedY = 0f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles)));
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("DesertSpellProj"), 15, 0f, player.whoAmI);

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

            //triggers the granite accessory buff for 5 seconds, and it cannot be refreshed until the 10 second timer hjas ran out
            if (graniteBuff && !player.HasBuff(mod.BuffType("GraniteAccessBuff"))  && granitebufftime == 0 && damage > 1)
            {
                player.AddBuff(mod.BuffType("GraniteAccessBuff"), 240);
                Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 41, 1, -0.3f);
                for (int i = 0; i < 25; i++)
                {

                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 65);
                    dust.noGravity = true;
                    dust.scale = 2f;
                    dust.velocity *= 2;
                }
                granitebufftime = 600; //Activates the 10 second cooldown
            }
            //For Space Armour with Mask (Defence)
            int defencedmg = 100 + (attackdmg * 2); //Boulder damage
            int defenceknb = 6; //Boulder Knockback
            float defenceVeloX = player.velocity.X * 0.25f;

            if (spaceRockDefence && player.HasBuff(mod.BuffType("SpaceRockDefence")) && damage >= 2)
            {
                
                    Projectile.NewProjectile(player.Center.X + 0, player.Top.Y - 350, 0 + defenceVeloX, 8f, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned above and goes straight down
                    Projectile.NewProjectile(player.Center.X - 0, player.Top.Y - 400, -1 + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned above and moves slighly left
                    Projectile.NewProjectile(player.Center.X + 0, player.Top.Y - 400, 1 + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI);  //Summoned above and moves slightly right
                    Projectile.NewProjectile(player.Center.X - 60, player.Top.Y - 450, -1 + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned to the left and moves  left
                    Projectile.NewProjectile(player.Center.X + 60, player.Top.Y - 450, 1 + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned to the right and moves  right
                    Projectile.NewProjectile(player.Center.X - 120, player.Top.Y - 500, -1f + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned far to the left and moves left
                    Projectile.NewProjectile(player.Center.X + 120, player.Top.Y - 500, 1f + defenceVeloX, 8, mod.ProjectileType("SpaceArmourProj"), defencedmg, defenceknb, player.whoAmI); //Summoned far to the right and moves right
                    for (int i = 0; i < 30; i++)
                    {

                        float speedX = Main.rand.NextFloat(-5f, 5f);
                        float speedY = Main.rand.NextFloat(-5f, 5f);
                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 6, speedX, speedY, 130, default, 1.5f);
                        dust.noGravity = true;
                        dust.velocity *= 2;
                    }
                    Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 45);

                    spaceBarriercooldown = 0;
                    player.ClearBuff(mod.BuffType("SpaceRockDefence"));
                 
            }

            //Grant buff for celestial barrier based on incoming damage======================
            if (lunarBarrier)
            {
              

                if ((attackdmg >= 90 && Main.expertMode))
                {
                   
                    
                        //if (!Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
                        {
                            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 122);
                            player.AddBuff(mod.BuffType("CelestialBuff"), (int)(attackdmg * 4f));

                        }
                    
                }
                if (attackdmg >= 60 && !Main.expertMode)
                {
                    //if (!Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
                    {
                        Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 122);
                        player.AddBuff(mod.BuffType("CelestialBuff"), (int)(attackdmg * 4f));
                    }
                }
            }
            //Creates the shards for the frost core when hit ======================
            if (frostSpike)
            {
                if (frosttime < 1 && damage > 1)
                {
                    Main.PlaySound(SoundID.NPCKilled, (int)player.position.X, (int)player.position.Y, 56, 0.5f);
                    float numberProjectiles = 10 + Main.rand.Next(4);
                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -9f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(150));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostAccessProj"), (int)((attackdmg * .75f)), 3f, player.whoAmI);


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
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //Hitting enemies with True Melee Only
        {
            if (heartSteal) //For the Jar of hearts 
            {
                if (!target.SpawnedFromStatue && target.life <= (target.lifeMax * 0.50f) && !target.boss && !target.friendly && target.lifeMax > 5 && !target.buffImmune[(BuffType<HeartDebuff>())]) //Rolls to see the outcome when firts hit under 50% life
                {

                    if (!target.GetGlobalNPC<StormNPC>().heartStolen) //Makes sure this only happens once
                    {
                        if (Main.rand.Next(6) == 0) //1 in 6 chance to have the debuff applied and drop a heart
                        {
                            Item.NewItem((int)target.Center.X, (int)target.Center.Y, target.width, target.height, mod.ItemType("SuperHeartPickup"));
                            Main.PlaySound(SoundID.NPCKilled, (int)target.Center.X, (int)target.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                var dust = Dust.NewDustDirect(new Vector2(target.Center.X, target.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            target.AddBuff(mod.BuffType("HeartDebuff"), 3600);
                            target.GetGlobalNPC<StormNPC>().heartStolen = true; //prevents more hearts from being dropped

                        }
                        else //Otherwise it just prevents the roll from happening again
                        {
                            target.GetGlobalNPC<StormNPC>().heartStolen = true;
                        }
                    }
                }
            }
            //For the Soul Fire armour setbonus with true melee
            if (hellSoulSet && hellblazetime == 0)
            {
                /*float numberProjectiles = 9;

                float rotation = MathHelper.ToRadians(140);
                //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    float speedX = 8f;
                    float speedY = 0f;
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles) - 0.27f));
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HellSoulArmourProj"), hellsouldmg, 0, player.whoAmI);
                }*/
                float speedX = 0f;
                float speedY = -8f;

                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(100)); // This defines the projectiles random spread . 10 degree spread.
                Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HellSoulArmourProj"), 75, 0, player.whoAmI);

                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                    dust.scale = 1.5f;
                    dust.velocity *= 3;

                }
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173);
                    dust.scale = 1.5f;
                    dust.velocity *= 3;

                }
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 8);

                hellblazetime = 30;
            }

            //For the Blood potion
            if (BloodOrb)
            {
                if (Main.rand.Next(3) == 0)
                {
                    target.AddBuff(mod.BuffType("BloodDebuff"), 300);
                }
            }
            //for the Beetle Gauntlet
            if (beetleFist)
            {
                if (!player.dead && beetlecooldown == 0 && crit)
                {

                    Main.PlaySound(SoundID.Zombie, (int)target.Center.X, (int)target.Center.Y, 50, 2, -0.5f);

                    float numberProjectiles = 3 + Main.rand.Next(3);

                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -12f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(135));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleGloveProj"), 40, 1f, player.whoAmI);

                    }
                    for (int i = 0; i < 25; i++)
                    {

                        var dust = Dust.NewDustDirect(target.position, target.width, target.height, 186);
                        dust.velocity *= 2;
                        dust.noGravity = true;
                        dust.scale = 1.5f;

                    }
                    for (int i = 0; i < 25; i++)
                    {

                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 186);
                        dust.velocity *= 2;
                        dust.noGravity = true;
                        dust.scale = 1;

                    }

                    beetlecooldown = 10;

                }
                
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) //Hitting enemy with any projectile
        {
            if (heartSteal) //For the Jar of hearts
            {
                if (!target.SpawnedFromStatue && target.life <= (target.lifeMax * 0.50f) && !target.boss && !target.friendly && target.lifeMax > 5 && !target.buffImmune[(BuffType<HeartDebuff>())]) //Rolls to see the outcome when firts hit under 50% life
                {

                    if (!target.GetGlobalNPC<StormNPC>().heartStolen)//Makes sure this only happens once
                    {
                        if (Main.rand.Next(7) == 0) //1 in 7 chance to have the debuff applied and drop a heart
                        {
                            Item.NewItem((int)target.Center.X, (int)target.Center.Y, target.width, target.height, mod.ItemType("SuperHeartPickup"));
                            
                            Main.PlaySound(SoundID.NPCKilled, (int)target.Center.X, (int)target.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                var dust = Dust.NewDustDirect(new Vector2(target.Center.X, target.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            target.AddBuff(mod.BuffType("HeartDebuff"), 3600);
                            target.GetGlobalNPC<StormNPC>().heartStolen = true; //prevents more hearts from being dropped

                        }
                        else //Otherwise it just prevents the roll from happening again
                        {
                            target.GetGlobalNPC<StormNPC>().heartStolen = true;
                        }
                    }
                }
            }
            //For the Soul Fire armour setbonus with projectiles ======================
           
            if (hellSoulSet && hellblazetime == 0 && (proj.melee || proj.ranged || proj.magic || proj.thrown))
            {
               
                float speedX = 0f;
                float speedY = -8f;
                
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(100)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HellSoulArmourProj"), 65, 0, player.whoAmI);
                

                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                    dust.scale = 1.5f;
                    dust.velocity *= 3;

                }
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173);
                    dust.scale = 1.5f;
                    dust.velocity *= 3;

                }
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 8);

                hellblazetime = 30;
            }
            //Blood potion
            if (BloodOrb)
            {
                if (Main.rand.Next(4) == 0)
                {
                    target.AddBuff(mod.BuffType("BloodDebuff"), 300);
                }
            }

            //for the Beetle Gauntlet
            if (beetleFist)
            {

                if (!player.dead && proj.melee && beetlecooldown == 0 && crit)
                {
                    Main.PlaySound(SoundID.Zombie, (int)target.Center.X, (int)target.Center.Y, 50, 2, -0.5f);

                    float numberProjectiles = 3 + Main.rand.Next(3);

                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -12f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(135));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("BeetleGloveProj"), 40, 1f, player.whoAmI);

                    }
                    for (int i = 0; i < 25; i++)
                    {

                        var dust = Dust.NewDustDirect(target.position, target.width, target.height, 186);
                        dust.velocity *= 2;
                        dust.noGravity = true;
                        dust.scale = 1.5f;

                    }
                    for (int i = 0; i < 25; i++)
                    {

                        var dust = Dust.NewDustDirect(player.position, player.width, player.height, 186);
                        dust.velocity *= 2;
                        dust.noGravity = true;
                        dust.scale = 1;

                    }

                    beetlecooldown = 10;

                }
            }
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
            if (player.HasBuff(BuffType<CelestialBuff>()))
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
                if (superBurn)
                {


                    player.lifeRegen = -8;
                }
               
                if (hellSoulDebuff)
                {
                    player.lifeRegen = -14;
                }
                if (ultraBurn)
                {

                    player.lifeRegen = -25;
                }
                if (ultraFrost)
                {
                    player.lifeRegen = -25;

                }
            }
        }

        
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
           
            //This is done in buffs.cs
           
    
        }
        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            if (player.HasBuff(BuffType<ShroomiteBuff>()) && Main.rand.Next(100) <= 75)//If the player has the shroomite potion then 50% chance not to consume ammo
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}