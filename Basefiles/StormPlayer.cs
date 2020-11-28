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

        public bool boulderDB;
        // player.GetGlobalplayer<Stormplayer>().boulderDB = true; in debuff.cs
        // target.AddBuff(mod.BuffType("BoulderDebuff"), 180)
        public bool superBoulderDB;

        public bool lunarBoulderDB;
        public bool sandBurn;

        public bool superFrost;

        public bool SSBuff;

        public bool goldDerpie;

        public bool stormHelmet;

        public bool turtled;

        public bool shroombuff;

        public bool flameCore;

        public bool frostSpike;

        

        public bool lunarBarrier;

        public bool nebula;
        
        public bool primeSpin;

        public bool bootFall;

        public bool derpJump;

        public bool spectreDebuff;

        public bool frostCube;

        public bool spooked;

        public bool lifeBarrier;

        public bool FrostCryoSet;

        public bool BloodDrop;

        public bool BloodOrb;

       
        public override void ResetEffects()
        {
            boulderDB = false;
            superBoulderDB = false;
            lunarBoulderDB = false;
            sandBurn = false;
            superFrost = false;
            SSBuff = false;
            turtled = false;
            goldDerpie = false;
            stormHelmet = false;
            shroombuff = false;
            flameCore = false;
            frostSpike = false;
            
            lunarBarrier = false;
            nebula = false;
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
           

        }
        public override void UpdateDead()
        {
            bearcool = 0;
            bloodtime = 0;
            frosttime = 0;
            falling = false;
            bloodorbspawn = 0;
        }
        // int shotCount = 0;
        //bool shot;

        bool shot;
        public int skulltime = 0;
        public bool falling;
        public int stopfall;
        public int falldmg;
        public int bearcool;
        public int stomptrail;
        public int bloodtime;
        public int frosttime;
        public int bloodorbspawn;

        public override void PostUpdateEquips()
        {
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
            if (player.statLife < 1)
            {
               
            }
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
            /*if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
            {
                if (player.itemTime > 1 && player.HeldItem.ranged) //ranged item is in use
                {

                    if (!shot)
                    {
                        shotCount++;
                        if (shotCount > 3)
                        {
                            shotCount = 0;
                            float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in
                            float velocity = 14f;
                            int type = mod.ProjectileType("ShroomSetRocketProj");
                            int damage = (int)(player.HeldItem.damage * 1.6f);
                            Projectile.NewProjectile(player.Center, new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * velocity, type, damage, 2f, player.whoAmI);
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 92);
                        }

                    }
                    shot = true;
                }
                else
                {
                    shot = false;
                }

            }*/
            if (frostCube)
            {
                
            }
            if (flameCore)
            {

                player.wingTimeMax *= (int)3f;

                if (player.velocity.Y == 0)
                {
                    //dashstop++;
                    player.dash = 2;
                }
                else
                {
                    player.dash = 3;
                }
               
                
                //player.moveSpeed *= 0.4f;
            }
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
            if (bootFall)
            {


                /* if (derpJump)
                 {
                     if (player.velocity.Y > 11)
                     {


                         falling = true;
                         stopfall = 0;

                     }
                     if (player.velocity.Y == 0 && falling)
                     {


                         for (int i = 0; i < 15; i++)
                         {

                             int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                             Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                             Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                             Main.dust[dustIndex].noGravity = true;
                         }
                         Projectile.NewProjectile(player.Center.X, player.BottomRight.Y - 10, 6, 0, mod.ProjectileType("StompDerpProj"), 60, 10f, player.whoAmI);
                         Projectile.NewProjectile(player.Center.X, player.BottomLeft.Y - 10, -6, 0, mod.ProjectileType("StompDerpProj"), 60, 10f, player.whoAmI);
                         Projectile.NewProjectile(player.Center.X, player.BottomRight.Y - 10, 5, -1, mod.ProjectileType("StompDerpProj"), 60, 10f, player.whoAmI);
                         Projectile.NewProjectile(player.Center.X, player.BottomLeft.Y - 10, -5, -1, mod.ProjectileType("StompDerpProj"), 60, 10f, player.whoAmI);

                         Main.PlaySound(3, (int)player.Center.X, (int)player.Center.Y, 22);
                         falling = false;

                     }
                 }
                 else*/

                player.maxFallSpeed *= 2f;
                
                /*if (player.velocity.Y > 0)
                {
                    player.velocity.Y *= 1.1f;
                }*/


                {
                    if (player.velocity.Y > 8)
                    {


                        falling = true;
                        stopfall = 0;
                        player.noKnockback = true;
                        player.turtleThorns = true;
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
                    if (player.velocity.Y > 1)
                    {
                        //falldmg = ((int)player.velocity.Y * 2) + 25;
                    }
                    
                    if (player.velocity.Y == 0 && falling)
                    {
                       

                        for (int i = 0; i < 30; i++)
                        {

                            int dustIndex = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default, 1f);
                            Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                            Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                            Main.dust[dustIndex].noGravity = true;
                        }
                        Projectile.NewProjectile(player.Center.X, player.Right.Y + 2, 7, 0, mod.ProjectileType("StompBootProj"), 40, 12f, player.whoAmI);
                        Projectile.NewProjectile(player.Center.X, player.Left.Y + 2, -7, 0, mod.ProjectileType("StompBootProj"), 40, 12f, player.whoAmI);
                        Main.PlaySound(2, (int)player.Center.X, (int)player.Center.Y, 14);
                        falling = false;

                    }
                }
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
            if (!bootFall)
            {
                falling = false;
            }
            if (spooked)
            {
                if (player.itemAnimation > 1 && (player.HeldItem.melee || player.HeldItem.ranged || player.HeldItem.magic || player.HeldItem.summon || player.HeldItem.thrown)) //ranged item is in use
                {

                    if (!shot)
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            
                            
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 34);

                            float rotation = player.itemRotation + (player.direction == -1 ? (float)Math.PI : 0); //the direction the item points in
                            float velocity = 0f;
                            int type = mod.ProjectileType("SpookyProj");
                            int damage = (int)(player.HeldItem.damage * 1.5f);
                            Projectile.NewProjectile(player.Top, new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * velocity, type, (int)(damage), 2f, player.whoAmI);
                        }

                    }
                    shot = true;
                    
                }
                else
                {
                    shot = false;
                }

            }
            if (lifeBarrier)
            {
                player.endurance += 0.5f;
                player.noKnockback = true;
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
           
        }
       
        int attackdmg = 0;
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            
        }



        public override void OnHitAnything(float x, float y, Entity victim)
        {
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
            base.OnHitAnything(x, y, victim);
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            player.ClearBuff(mod.BuffType("HeartBarrierBuff"));
            attackdmg = (int)damage;
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
        public override void UpdateLifeRegen()
        {
            if (Main.LocalPlayer.HasBuff(mod.BuffType("CelestialBuff")))
            {
                
                player.lifeRegen += 30;
                
            }
         
        }
      
        public override void UpdateBadLifeRegen()
        {
            {
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
                if (nebula)
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
           
            if (SSBuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 57, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(player.position, 1f, 1f, 0f);
                
            }
           
    
        }
        /*
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Buffs/TurtleBarrier");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }*/
    }
}