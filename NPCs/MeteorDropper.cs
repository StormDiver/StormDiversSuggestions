using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Buffs;


namespace StormDiversSuggestions.NPCs

{
    public class MeteorDropper : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Bomber"); // Automatic from .lang files
                                                 // make sure to set this for your modnpcs.
            
        }
        public override void SetDefaults()
        {
            Main.npcFrameCount[npc.type] = 8;
            
            npc.width = 30;
            npc.height = 20;

            npc.aiStyle = -1; 
            //aiType = NPCID.AngryNimbus;

            npc.damage = 30;
            
            npc.defense = 10;
            npc.lifeMax = 60;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath43;
            npc.knockBackResist = 0.5f;
            npc.value = Item.buyPrice(0, 0, 1, 0);

           banner = npc.type;
            bannerItem = mod.ItemType("MeteorDropperBannerItem");


            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[(BuffType<SuperBurnDebuff>())] = true;
            npc.buffImmune[(BuffType<HellSoulFireDebuff>())] = true;
            npc.buffImmune[(BuffType<UltraBurnDebuff>())] = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

 
                return SpawnCondition.Meteor.Chance * 0.35f;
            
            
        }
        int firerate = 0;
        bool firing;
        float ypos = -150;
        bool yassend;
        float xpos = 0;
        bool xassend;
        float movespeed = 1.5f;

        bool damaged;
        int damagecooldown;
        public override void AI()
        {
            //Ypos Variance
            if (yassend)
            {
                ypos -= 0.1f;
            }
            else
            {
                ypos += 0.1f;
            }
            if (ypos <= -225f)
            {
                yassend = false;
            }
            if (ypos >= -200f)
            {
                yassend = true;
            }
            //Xpos Variance
            if (xassend)
            {
                xpos -= 0.1f;
            }
            else
            {
                xpos += 0.1f;
            }
            if (xpos <= -20f)
            {
                xassend = false;
            }
            if (xpos >= 20f)
            {
                xassend = true;
            }
            Player player = Main.player[npc.target];
            npc.TargetClosest();
            npc.rotation = npc.velocity.X / 25;

            if (!damaged)
            {
                Vector2 moveTo = player.Center;
                Vector2 move = moveTo - npc.Center + new Vector2(xpos, ypos);
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);

                if (magnitude > movespeed)
                {
                    move *= movespeed / magnitude;
                }
                npc.velocity = move;
            }
            if (damaged)
            {
                damagecooldown++;
                npc.velocity *= 0;
            }
          

            if (damagecooldown >= 10)
            {
                damaged = false;
                damagecooldown = 0;
            }

            if (player.dead)
            {
                npc.velocity.Y = -5;

            }




            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            if ((distanceX <= 75f && distanceX >= -75f) && (distanceY <= 500f && distanceY >= 0f) && Collision.CanHitLine(npc.Center, 0, 0, player.Center, 0, 0) && !player.dead)
            {
                
                    int damage = 13; // The damage your projectile deals.
                    float knockBack = 1;
                    int type = mod.ProjectileType("MeteorDropperProj");

                    firerate++;
                float xprojpos = (Main.rand.NextFloat(-10, 10));
                if (firerate >= 25)
                    {

                    //xpos = (Main.rand.NextFloat(-30, 30));
                    //ypos = (Main.rand.NextFloat(-180, -150));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            Projectile.NewProjectile(npc.Center.X + xprojpos, npc.Bottom.Y - 5, xprojpos / 15, 8, type, damage, knockBack);
                        }

                        Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 20);
                        firerate = 0;
                    }

                firing = true;
                movespeed = 0.75f;

            }
            else
            {
                firing = false;
                movespeed = 1.5f;

            }



            if (Main.rand.Next(1) == 0)     //this defines how many dust to spawn
            {

                var dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, 6);
                //int dust2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, 72, projectile.velocity.X, projectile.velocity.Y, 130, default, 1.5f);
                dust2.noGravity = true;
                dust2.scale = 1.25f;
                dust2.velocity *= 2;

            }
            /*if (Main.rand.Next(2) == 0)
            {

                int dust2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 0, npc.velocity.X, npc.velocity.Y, 0, default, 0.5f);
            }*/
        }
        int npcframe = 0;

        public override void FindFrame(int frameHeight)
        {

            if (!firing)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe >= 5) //Cycles through frames 0-5 when  in phase 1
                {
                    npcframe = 0;
                }
            }
            if (firing)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe < 6 || npcframe >= 8) //Cycles through frames 6-7 when firing
                {
                    npcframe = 6;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {

            target.AddBuff(BuffID.OnFire, 600);


        }
        public override void HitEffect(int hitDirection, double damage)
        {
            firerate = -30;
         
            damaged = true;
            for (int i = 0; i < 20; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 0, 0, 0);
                dust.scale = 0.8f;
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MeteorDropperGore1"), 1f);   
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MeteorDropperGore2"), 1f);    
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/MeteorDropperGore3"), 1f);
                for (int i = 0; i < 25; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6);
                    dust.scale = 1.5f;
                    dust.velocity *= 2f;
                }
              

            }
        }
        public override void NPCLoot()
        {

            
                if (Main.rand.Next(100) <= 10)
                {
                    Item.NewItem((int)npc.Center.X, (int)npc.Center.Y, npc.width, npc.height, ItemID.Meteorite, Main.rand.Next(1, 3));
                }
            
           
        }
        public override Color? GetAlpha(Color lightColor)
        {

            return Color.White;

        }

    }
}