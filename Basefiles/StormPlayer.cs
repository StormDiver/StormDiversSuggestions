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
        public bool flamefalling; //Falling at speed with betsy's flame
        public int stopflamefall; //Player has stoppd falling with flame core
        public bool twilightcharged; //Activates when the player is able to teleport with the twilight armour
        public int derplinglaunchcooldown; //How long until the player can launch enemies in the air with the Derplign armour set
        public bool celestialspin; //Has the spinning projectile fo the celestial shell been summoned?
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
            derplinglaunchcooldown = 60;
            celestialspin = false;
        }


        public override void PostUpdateEquips() //Updates every frame
        {
            //Reduces ints if they are above 0======================
          
            if (bloodtime > 0)
            {
                bloodtime--;
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
            if (spaceStrikecooldown < 210) //Ditto for offence
            {
                spaceStrikecooldown++;
            }
            if (spaceStrikecooldown == 210)
            {
                player.AddBuff(mod.BuffType("SpaceRockOffence"), 2);

            }
            if (!spaceRockOffence)
            {
                player.ClearBuff(mod.BuffType("SpaceRockOffence"));
                spaceStrikecooldown = 0;
            }

            if (derplinglaunchcooldown == 0 && derpJump)
            {
                player.AddBuff(mod.BuffType("DerpBuff"), 2);

            }

            float xWarplimit = 560;
            float yWarplimit = 320;
            //For Twilight Armour
            if (twilightSet)
            {
                float distanceX = player.Center.X - Main.MouseWorld.X;
                float distanceY = player.Center.Y - Main.MouseWorld.Y;
                float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

                if ( Collision.CanHitLine(Main.MouseWorld, 1, 1, player.position, player.width, player.height) && !player.HasBuff(mod.BuffType("TwilightDebuff"))) //Checks if mouse is in valid postion
                {
                   
                    twilightcharged = true; //Activates the outline effect on the armour

                    if (StormDiversSuggestions.ArmourSpecialHotkey.JustPressed) //Activates when player presses button
                    {
                        player.AddBuff(BuffID.Obstructed, 10); //Hopefully this covers up the janky teleport :thePain:
                        player.AddBuff(mod.BuffType("TwilightDebuff"), 1080);


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
                    twilightcharged = false; //Removes the outline effect if the player is unable to charge
                }
            }
         
            //For Betsy's Flame======================
            if (flameCore)
            {

                //player.wingTimeMax *= (int)3f;
                player.wingTime += 1;
                //Create flames upon landing

                if (player.velocity.Y > 10)
                {


                    flamefalling = true;
                    stopflamefall = 0;
                    int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 50, default, 1f);


                }


                //For impacting the ground at speed
                if (player.velocity.Y == 0 && flamefalling)
                {


                    for (int i = 0; i < 30; i++)
                    {

                        int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, 0f, 0f, 50, default, 1.5f);
                        Main.dust[dustIndex].velocity *= 3;
                    }
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 74, 0.5f);
                    float numberProjectiles = 6 + Main.rand.Next(4);
                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -8f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(120));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(player.Center.X, player.Bottom.Y - 7, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.MolotovFire, 30, 3f, player.whoAmI);


                    }
                    flamefalling = false;

                }

                //If the player slows down too much then the falling bool is cancelled
                if (player.velocity.Y <= 2)
                {

                    stopflamefall++;
                }
                else
                {
                    stopflamefall = 0;
                }
                if (stopflamefall > 1)
                {
                    flamefalling = false;
                }
            }
            if (!flameCore)
            {
                flamefalling = false;
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
            //For the Spooky Core ======================
            if (spooked)
            {
                if (player.itemAnimation > 1 && (player.HeldItem.melee || player.HeldItem.ranged || player.HeldItem.magic || player.HeldItem.summon || player.HeldItem.thrown)) //ranged item is in use
                {

                    if (!shotflame)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            for (int i = 0; i < 20; i++)
                            {

                                var dust = Dust.NewDustDirect(player.position, player.width, player.height, 244);

                                dust.noGravity = true;
                                
                            }

                            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 34);

                            float numberProjectiles = 2;

                            for (int i = 0; i < numberProjectiles; i++)
                            {
                                float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in


                                float speedX = 0f;
                                float speedY = -2f;
                                int damage = (int)((player.HeldItem.damage * 0.4f) * player.allDamage);
                                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(180));
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
            //For the Endurance Healing Potion Barrier ======================
            if (lifeBarrier)
            {
                player.endurance += 0.25f;
                player.noKnockback = true;
            }
            //for Derpling armour
            if (derpJump)
            {
                player.jumpSpeedBoost += 6;

                player.autoJump = true;
                player.maxFallSpeed *= 2f;


                if (StormDiversSuggestions.ArmourSpecialHotkey.JustPressed && derplinglaunchcooldown <= 0) //Activates when player presses button
                {

                    player.ClearBuff(mod.BuffType("DerpBuff"));

                    Main.PlaySound(SoundID.NPCKilled, (int)player.Center.X, (int)player.Center.Y, 25, 1.5f, -0.5f);

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
                    
                    Projectile.NewProjectile(player.Center.X, player.Right.Y -15, 7, 0, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Left.Y - 15, -7, 0, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Right.Y - 15, 7, -2.5f, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    Projectile.NewProjectile(player.Center.X, player.Left.Y - 15, -7, -2.5f, mod.ProjectileType("DerpWaveProj"), 75, 0, player.whoAmI);
                    derplinglaunchcooldown = 90;
                }
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
            int offencedmg = (int) (100 * player.allDamage);
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

                    
                    float numberProjectiles = 4 + Main.rand.Next(0);
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
                if (target.life <= (target.lifeMax * 0.50f) && !target.boss && !target.friendly && target.lifeMax > 5) //Rolls to see the outcome when firts hit under 50% life
                {

                    if (!target.GetGlobalNPC<StormNPC>().heartStolen) //Makes sure this only happens once
                    {
                        if (Main.rand.Next(5) == 0) //1 in 5 chance to have the debuff applied and drop a heart
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
                Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HellSoulArmourProj"), 80, 0, player.whoAmI);

                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 3;

                }
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 3;

                }
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 8);

                hellblazetime = 45;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) //Hitting enemy with any projectile
        {
            if (heartSteal) //For the Jar of hearts
            {
                if (target.life <= (target.lifeMax * 0.50f) && !target.boss && !target.friendly && target.lifeMax > 5) //Rolls to see the outcome when firts hit under 50% life
                {

                    if (!target.GetGlobalNPC<StormNPC>().heartStolen)//Makes sure this only happens once
                    {
                        if (Main.rand.Next(5) == 0) //1 in 5 chance to have the debuff applied and drop a heart
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

                //Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, -8, mod.ProjectileType("HellSoulArmourProj"), hellsouldmg, 0, player.whoAmI);
                float speedX = 0f;
                float speedY = -8f;
                
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(100)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("HellSoulArmourProj"), 65, 0, player.whoAmI);
                

                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(player.position, player.width, player.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 3;

                }
                for (int i = 0; i < 20; i++)
                {
                    var dust = Dust.NewDustDirect(target.position, target.width, target.height, 173);
                    dust.scale = 2;
                    dust.velocity *= 3;

                }
                Main.PlaySound(SoundID.Item, (int)target.Center.X, (int)target.Center.Y, 8);

                hellblazetime = 45;
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