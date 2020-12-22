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
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Basefiles
{
    public class StormNPC : GlobalNPC
    {

       
    

        public override bool InstancePerEntity => true;

        public bool lunarBoulderDB;

        public bool superBoulderDB;
        // npc.GetGlobalNPC<StormNPC>().boulderDB = true; in debuff.cs
        // target.AddBuff(mod.BuffType("BoulderDebuff"), 1200)
        public bool boulderDB;

        public bool sandBurn;


        public bool beetled;

        public bool nebula;

        public bool heartDrop;

        public bool spectreDebuff;

        public bool heartDebuff;

        public bool superFrost;

        public bool bloodDebuff;

        public override void ResetEffects(NPC npc)
        {
            boulderDB = false;
            lunarBoulderDB = false;
            superBoulderDB = false;
            sandBurn = false;
           
            beetled = false;
            nebula = false;
            heartDrop = false;
            spectreDebuff = false;
            heartDebuff = false;
            superFrost = false;
            bloodDebuff = false;
        }
        public override void AI(NPC npc)

        {

           

            if (beetled && !npc.boss)
            {
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;

            }
            if (Main.LocalPlayer.HasBuff(BuffType<BloodBuff>()) && !npc.friendly && npc.lifeMax > 5)
            {
                var player = Main.LocalPlayer;
                float distanceX = player.Center.X - npc.Center.X;
                float distanceY = player.Center.Y - npc.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
                bool lineOfSight = Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height);
                if (distance < 110 && lineOfSight)
                {
                    npc.AddBuff(mod.BuffType("BloodDebuff"), 1);
                }
            }

        }
        public override void SetDefaults(NPC npc)
        {

            if (npc.boss)
            {
                npc.buffImmune[(BuffType<BeetleDebuff>())] = true;
            }
        }
        
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (bloodDebuff)
            {
                npc.lifeRegen -= 12;

                damage = 2;

            }
            if (heartDebuff)
            {
                npc.lifeRegen -= 100;

                damage = 10;

            }
            if (sandBurn)
            {
                npc.lifeRegen -= 50;

                damage = 6;

            }
            if (superFrost)
            {
                npc.lifeRegen -= 50;

                damage = 6;

            }
            if (boulderDB)
            {
                npc.lifeRegen -= 60;

                damage = 8;

            }
           
            if (spectreDebuff)
            {
                npc.lifeRegen -= 120;

                damage = 14;

            }
            
            if (superBoulderDB)
            {
                npc.lifeRegen -= 160;

                damage = 18;

            }
           
            if (nebula)
            {
                npc.lifeRegen -= 180;
                damage = 20;
            }
            if (lunarBoulderDB)
            {
                npc.lifeRegen -= 400;

                damage = 40;

            }
           
           

        }
        int particle = 0;
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (boulderDB)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 1, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (superBoulderDB)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 55, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 1f, 0.5f, 0f);
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
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, particle, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 1f, 0.5f, 0f);
            }
            if (nebula)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 130, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 1f, 0.5f, 0.8f);
            }
            if (sandBurn)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 138, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
            

            if (beetled)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, mod.DustType("BeetleDust"), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (spectreDebuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 16, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (heartDebuff)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 72, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }

            }
            if (superFrost)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, npc.velocity.X * 1.2f, npc.velocity.Y * 1.2f, 130, default, 1f);   //this defines the flames dust and color, change DustID to wat dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                    Main.dust[dust].noGravity = true; //this make so the dust has no gravity
                    
                    int dust2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 156, npc.velocity.X, npc.velocity.Y, 130, default, .3f);
                    Main.dust[dust].velocity *= 0.5f;
                }

            }
            if (bloodDebuff)
            {
                if (Main.rand.Next(4) < 3)
                /*{
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 5, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 5f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }*/
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(20, 20), Main.rand.NextFloat(-20, -20));
                    var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 5);
                }
            }
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {


        }
        bool heartSteal = false;
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (Main.LocalPlayer.HasBuff(BuffType<JarBuff>()))
            {
                if (npc.life <= (npc.lifeMax * 0.30f) && !npc.boss && !npc.friendly && !heartSteal && npc.lifeMax > 5)
                {
                    
                    { 
                        if (Main.rand.Next(8) == 0 )
                        {
                            Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart);
                            Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            npc.AddBuff(mod.BuffType("HeartDebuff"), 3600);
                            heartSteal = true;
                        }
                        else
                        {
                            heartSteal = true;
                        }
                }
                }
            }
        }
       
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (Main.LocalPlayer.HasBuff(BuffType<JarBuff>()))
            {
                if (npc.life <= (npc.lifeMax * 0.30f) && !npc.boss && !npc.friendly && !heartSteal && npc.lifeMax > 5)
                {
                    
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart);
                            Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            npc.AddBuff(mod.BuffType("HeartDebuff"), 3600);
                            heartSteal = true;
                        }
                        else
                        {
                            heartSteal = true;
                        }
                    }
                }
            }
        }
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            
        }
        

    }
        
}