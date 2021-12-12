using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Banners;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.NPCs

{
    public class DerpMimic : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Perfectly Normal Derpling"); 
            Main.npcFrameCount[npc.type] = 18; 
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 80;

            //npc.aiStyle = 3; 
            //aiType = NPCID.VortexSoldier;

            npc.damage = 666;

            npc.defense = 666;
            npc.lifeMax = 666;
            npc.noGravity = false;


            npc.HitSound = SoundID.NPCHit6;
            npc.DeathSound = SoundID.NPCDeath8;
            npc.knockBackResist = 0f;
            Item.buyPrice(0, 0, 0, 0);

            npc.gfxOffY = -4;

            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }

        /* public override float SpawnChance(NPCSpawnInfo spawnInfo)
         {

         }*/
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f);
            npc.damage = (int)(npc.damage * 0.5f);
        }
        int feartime; //Cooldown before ai starts

        bool fear;// running aniamtion 
       
        bool death; //Vctory animation

        bool jump; //If it has jumped

        float distancefear = 500; //Detection ranged

        bool attackmode; //Wheter it is cahsign a player

        int dociletime; //cooldown until stops attacking
        public override void AI()
        {
            

            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            float distanceX = player.Center.X - npc.Center.X;
            float distanceY = player.Center.Y - npc.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));
            feartime ++;
            npc.spriteDirection = npc.direction;

            if (feartime > 120)
            {
                if (!player.dead)
                {
                    if (distance <= distancefear && Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                    {
                        if (!attackmode)
                        {
                            Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 2);
                        }
                        death = false;
                        distancefear = 1000f; //increase detection range once triggered
                        attackmode = true;
                        dociletime = 300;


                    }
                    else //if cannot detetc player begin docile cooldown
                    {
                      
                        dociletime--;
                    }
                    if (attackmode) //When taregting the player
                    {
                       
                        fear = true;


                        if (distanceX <= -25)
                        {
                            npc.velocity.X = -9;
                        }
                        if (distanceX >= 25)
                        {
                            npc.velocity.X = 9;
                        }
                        if (distanceX < 25 && distanceX > -25)
                        {
                            npc.velocity.X *= 0.5f;
                        }

                        if ((distanceX >= -50 && distanceX <= 50) && !jump && npc.velocity.Y == 0 && player.position.Y + 50 < npc.position.Y) //jump to attack player
                        {
                            npc.velocity.Y = -15;
                            jump = true;
                        }
                        if (player.position.Y > npc.Bottom.Y && Collision.CanHitLine(npc.Bottom, npc.width, npc.height, player.position, player.width, player.height)) // fall through platforms is player is below
                        {
                            npc.noTileCollide = true;
                        }
                        else
                        {
                            npc.noTileCollide = false;
                        }

                        if (!jump && npc.velocity.Y == 0 && !Collision.CanHitLine(npc.position, npc.width, npc.height, player.position, player.width, player.height) && player.position.Y - 10 < npc.position.Y) //Jump if cannot detect player
                       {
                           npc.velocity.Y = -10;
                           jump = true;
                       }

                        if (npc.collideX && !jump && npc.velocity.Y == 0 && (distanceX <= -50 || distanceX >= 50)) //Jump over obstacles in the way
                        {
                            npc.velocity.Y = -10;
                            jump = true;
                        }
                        
                    }
                }
                if (dociletime <= 0 && npc.velocity.Y == 0) //After 5 seconds of not being in player range return to docile
                {
                    attackmode = false;
                    fear = false;
                    distancefear = 500; //reset orignal trigger range

                }
                if (npc.velocity.Y == 0)
                {
                    jump = false;
                }
                if (player.dead) //victory
                {
                    fear = false;
                    death = true;
                    npc.velocity.X = 0;
                    distancefear = 500;
                    npc.noTileCollide = false;

                }
            }
        }
        int npcframe = 0;
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (target.dead)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 2, 1, -1f);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            if (fear)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 2)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe <= 7 || npcframe >= 18) //Cycles through frames 8-17 when FEAR
                {
                    npcframe = 8;
                }
            }
            if (death)
            {
                npc.frame.Y = npcframe * frameHeight;
                npc.frameCounter++;
                if (npc.frameCounter > 5)
                {
                    npcframe++;
                    npc.frameCounter = 0;
                }
                if (npcframe <= 0 || npcframe >= 9) //Cycles through frames 1-8 when DEAD
                {
                    npcframe = 1;
                }
            }
            if (!fear && !death)
            {
                npc.frame.Y = npcframe * frameHeight;
                npcframe = 0; //Stays on frame 0 if no fear
            }

        }

        public override void HitEffect(int hitDirection, double damage)
        {
            //attacking make it hostile
            if (!attackmode)
            {
                Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 2);
            }
            feartime = 120; //ignore startup cooldown
            distancefear = 2000; //Grealty increase aggro range
            attackmode = true; //Enable attack mode
            dociletime = 300; //Reset docile time

            //shoottime = 100;
            for (int i = 0; i < 10; i++)
            {
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X - 10, npc.Center.Y - 20), 20, 20, 5);
               

            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {

                /* Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                 Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore2"), 1f);     
                 Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore3"), 1f);
                 Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore4"), 1f);
                 Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/VortCannonGore5"), 1f);
                */

                NPC.NewNPC((int)Math.Round(npc.Center.X), (int)Math.Round(npc.Center.Y), mod.NPCType("BabyDerp"));

                for (int i = 0; i < 100; i++)
                {
                    var dust = Dust.NewDustDirect(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5);
                    dust.scale = 1.5f;
                    dust.velocity *= 2;
                }
               
            }
        }
        

    }
}