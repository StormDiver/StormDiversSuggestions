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

        public bool SSBuff;

        public bool goldDerpie;

        public bool stormHelmet;

        public bool turtled;

        public bool shroombuff;

        public bool flameCore;

        public bool frostSpike;

        public bool frostSpikeCooldown;
        
        public override void ResetEffects()
        {
            boulderDB = false;
            superBoulderDB = false;
            lunarBoulderDB = false;
            sandBurn = false;
            SSBuff = false;
            turtled = false;
            goldDerpie = false;
            stormHelmet = false;
            shroombuff = false;
            flameCore = false;
            frostSpike = false;
            frostSpikeCooldown = false;
        }
       // int shotCount = 0;
        //bool shot;
        public override void PostUpdateEquips()
        {
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

            if (flameCore)
            {

                player.wingTimeMax *= (int)3f;
                if (player.velocity.Y != 0)
                {

                    player.dash = 3;
                }
                //player.moveSpeed *= 0.4f;
            }
          
        }
        
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (frostSpike)
            {
                if (!frostSpikeCooldown)
                {
                    Main.PlaySound(4, (int)player.position.X, (int)player.position.Y, 56);
                    float numberProjectiles = 10 + Main.rand.Next(5);
                    for (int i = 0; i < numberProjectiles; i++)
                    {


                        float speedX = 0f;
                        float speedY = -10f;
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(150));
                        float scale = 1f - (Main.rand.NextFloat() * .5f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostAccessProj"), 50, 3f, player.whoAmI);


                    }
                    for (int i = 0; i < 30; i++)
                    {

                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = Main.LocalPlayer.position;
                        dust = Main.dust[Terraria.Dust.NewDust(position, player.width, player.height, 92, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                        dust.noGravity = true;
                    }
                    player.AddBuff(mod.BuffType("FrozenBuff"), 300);
                }
            }
        }
        public override void UpdateBadLifeRegen()
        {
            {
                if (boulderDB)
                {
                    if (player.lifeRegen > 0)
                    {
                        player.lifeRegen = 0;
                    }
                    player.lifeRegen -= 10;

                }
                if (superBoulderDB)
                {

                    if (player.lifeRegen > 0)
                    {
                        player.lifeRegen = 0;
                    }
                    player.lifeRegen -= 30;
                }
                if (lunarBoulderDB)
                {

                    if (player.lifeRegen > 0)
                    {
                        player.lifeRegen = 0;
                    }
                    player.lifeRegen -= 50;
                }
                if (sandBurn)
                {

                    if (player.lifeRegen > 0)
                    {
                        player.lifeRegen = 0;
                    }
                    player.lifeRegen -= 10;
                }
            }
        }

        int particle = 0;
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            {
                if (boulderDB)
                {
                    if (Main.rand.Next(4) < 3)
                    {
                        int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 1, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 1.8f;
                        Main.dust[dust].velocity.Y -= 0.5f;
                        Main.playerDrawDust.Add(dust);
                    }
                    
                }
            }
                if (superBoulderDB)
                {
                    if (Main.rand.Next(3) < 3)
                    {
                        int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 55, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 0.5f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 1.8f;
                        Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 1f;
                g *= 0.5f;
                b *= 0f;
                fullBright = true;
            }
            if (lunarBoulderDB)
            {
                int choice = Main.rand.Next(4);
                if (choice == 0)
                {
                    particle = 244;
                }
                else if (choice == 1)
                {
                    particle = 110;
                }
                else if (choice == 2)
                {
                    particle = 111; ;
                }
                else if (choice == 3)
                {
                    particle = 112;
                }
                if (Main.rand.Next(3) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, particle, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 1f;
                g *= 0.5f;
                b *= 0f;
                fullBright = true;
            }
            if (sandBurn)
            {
                if (Main.rand.Next(3) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 138, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 1f;
                g *= 0.5f;
                b *= 0f;
                fullBright = true;
            }
            if (SSBuff)
            {
                if (Main.rand.Next(10) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 57, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 1f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
            if (turtled)
            {

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
        /*
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Buffs/TurtleBarrier");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);


        }*/
    }
}