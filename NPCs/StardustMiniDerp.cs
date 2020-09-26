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
    public class StardustMiniDerp : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starling Minion"); // Automatic from .lang files
            Main.npcFrameCount[npc.type] = 2; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 24;

            npc.aiStyle = 86; 
           // aiType = NPCID.AncientCultistSquidhead;
            animationType = NPCID.DemonEye;

            npc.damage = 100;
            
            npc.defense = 0;
            npc.lifeMax = 100;
            npc.noTileCollide = true;
               

            
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath7;
            npc.knockBackResist = -0.1f;
            Item.buyPrice(0, 0, 0, 0);
            npc.noGravity = true;
            
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            //npc.lifeMax = (int)(npc.lifeMax * 0.75f);
            //npc.damage = (int)(npc.damage * 0.75f);
        }

       
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            npc.life -= 9999;
            Main.PlaySound(4, (int)npc.Center.X, (int)npc.Center.Y, 7);
            for (int i = 0; i < 10; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 111);
            }
            
        }
        int dustnpc = 0;
        public override void AI()
        {
            dustnpc++;
            if (dustnpc >= 3)
            {
                //var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 111);
                int dust = Dust.NewDust(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 111);
                Main.dust[dust].velocity *= -2f;
                Main.dust[dust].noGravity = true;
                dustnpc = 0;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 111);
            }
            if (npc.life <= 0)          //this make so when the npc has 0 life(dead) he will spawn this
            {
                
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpMiniGore1"), 1f);   //make sure you put the right folder name where your gores is located and the right name of gores
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/StarDerpMiniGore2"), 1f);     
                
                for (int i = 0; i < 10; i++)
                {
                    Vector2 vel = new Vector2(Main.rand.NextFloat(-2, -2), Main.rand.NextFloat(2, 2));
                    var dust = Dust.NewDustDirect(new Vector2(npc.Center.X, npc.Center.Y), 5, 5, 111);
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("NPCs/StardustMiniDerp_Glow");

            spriteBatch.Draw(texture, npc.Center - Main.screenPosition, npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2f, npc.scale, npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);

        }
       
    }
}