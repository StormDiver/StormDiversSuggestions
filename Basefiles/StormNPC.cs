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
    public class StormNPC : GlobalNPC
    {

        public override bool InstancePerEntity => true;

        public bool lunarBoulderDB;

        public bool superBoulderDB;
        // npc.GetGlobalNPC<StormNPC>().boulderDB = true; in debuff.cs
        // target.AddBuff(mod.BuffType("BoulderDebuff"), 1200)
        public bool boulderDB;

        public bool sandBurn;

        public bool turtled;

        public bool beetled;

        public bool nebula;

        public bool heartDrop;

        public bool spectreDebuff;

        public bool heartDebuff;
        public override void ResetEffects(NPC npc)
        {
            boulderDB = false;
            lunarBoulderDB = false;
            superBoulderDB = false;
            sandBurn = false;
            turtled = false;
            beetled = false;
            nebula = false;
            heartDrop = false;
            spectreDebuff = false;
            heartDebuff = false;
        }
        public override void AI(NPC npc)

        {


            if (beetled && !npc.boss)
            {
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;

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
            if (heartDebuff)
            {
                npc.lifeRegen -= 30;

                damage = 5;

            }
            if (sandBurn)
            {
                npc.lifeRegen -= 30;

                damage = 5;

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
            if (turtled)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 138, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 0, default, 1f);
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
        }
        bool heartSteal = false;
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (Main.LocalPlayer.HasBuff(BuffType<HeartBuff>()))
            {
                if (npc.life <= (npc.lifeMax * 0.25f) && !npc.boss && !npc.friendly)
                {
                    
                    { 
                        if (Main.rand.Next(25) == 0 && !heartSteal)
                        {
                            Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart);
                            Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            npc.AddBuff(mod.BuffType("HeartDebuff"), 1800);
                            heartSteal = true;
                        }
                }
                }
            }
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            
            
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (Main.LocalPlayer.HasBuff(BuffType<HeartBuff>()))
            {
                if (npc.life <= (npc.lifeMax * 0.25f) && !npc.boss && !npc.friendly)
                {
                    
                    {
                        if (Main.rand.Next(25) == 0 && !heartSteal)
                        {
                            Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Heart);
                            Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 7);
                            for (int i = 0; i < 15; i++)
                            {
                                Vector2 vel = new Vector2(Main.rand.NextFloat(-5, -5), Main.rand.NextFloat(5, 5));
                                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 72);
                                //dust.noGravity = true;
                            }
                            npc.AddBuff(mod.BuffType("HeartDebuff"), 1800);
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