using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Pets
{

    public class TwilightPetItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Twilight Hood");
            Tooltip.SetDefault("Summons a mysterious figure to light your way");
    
        }

        public override void SetDefaults()
        {
            item.useStyle = 3;
            item.UseSound = SoundID.Item2;
            item.useAnimation = 20;
            item.useTime = 20;
            item.noMelee = true;


            item.width = 24;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 3, 0, 0);
            
            item.shoot = ProjectileType<TwilightPetProj>();
            item.buffType = BuffType<TwilightPetBuff>();
            item.rare = ItemRarityID.Orange;

        }



        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
     
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
                {

                    if (!npc.friendly && npc.lifeMax > 5 && npc.type != NPCID.TheHungry && npc.type != NPCID.TheHungryII)

                    {
                        if (Main.expertMode)
                        {
                            if (Main.rand.Next(150) < 1)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TwilightPetItem"));
                            }
                        }
                        else
                        {
                            if (Main.rand.Next(200) < 1)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TwilightPetItem"));
                            }

                        }
                    }
                }
            }
        }
    }

    public class TwilightPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            
            DisplayName.SetDefault("Twilight Figure");
            Description.SetDefault("A strange hooded figure lights your way");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<StormPlayer>().twilightPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<TwilightPetProj>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<TwilightPetProj>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
    public class TwilightPetProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twilight light");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.DD2PetGato);
            //aiType = ProjectileID.DD2PetGato;
            projectile.aiStyle = -1;
            projectile.width = 22;
           projectile.height = 42;
            projectile.scale = 1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            //player.petFlagDD2Gato = false; 
            return true;
        }


        float movespeed = 12f; //Speed of the pet

        float xpostion = 50; // The picked x postion
        float ypostion = -60f;
        bool teleport;
        bool yAssend;
        bool teleanimation;
        public override void AI()
        {

            Player player = Main.player[projectile.owner];

            Lighting.AddLight(projectile.Center, (255 - projectile.alpha) * 0.3f / 255f, (255 - projectile.alpha) * 0f / 255f, (255 - projectile.alpha) * 0.3f / 255f); //light

            StormPlayer modPlayer = player.GetModPlayer<StormPlayer>();
            if (!player.active)
            {
                projectile.active = false;
                return;
            }
            if (player.dead)
            {
                modPlayer.twilightPet = false;
            }
            if (modPlayer.twilightPet)
            {
                projectile.timeLeft = 2;
            }
            


            float distanceX = player.Center.X - projectile.Center.X;
            float distanceY = player.Center.Y - projectile.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            projectile.rotation = projectile.velocity.X / 13;


            xpostion = 50 * player.direction; //Moves to the front of the player
            projectile.spriteDirection = player.direction; //Flips sprite
            movespeed = distance / 15 + 0.5f; //Moves faster the further away it is

            //To make bop up and down
            if (yAssend)
            {
                ypostion -= 0.1f;
            }
            else
            {
                ypostion += 0.1f;
            }
            if (ypostion <= -65f)
            {
                yAssend = false;
            }
            if (ypostion >= -55f)
            {
                yAssend = true;
            }

            if (distance <= 250) //Movement
            {
                Vector2 moveTo = player.Center;
                Vector2 move = moveTo - projectile.Center + new Vector2(xpostion, ypostion); //Postion around player
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                if (magnitude > movespeed)
                {
                    move *= movespeed / magnitude;
                }
                projectile.velocity = move;

                if (teleport) //Post teleport
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8, 2f, 0.5f);

                    for (int i = 0; i < 30; i++) //Dust post-teleport
                    {
                        var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 62);
                        dust.scale = 1.1f;
                        dust.velocity *= 2;
                        dust.noGravity = true;

                    }
                    teleport = false;
                }
            }
            else //teleports if too far away from player
            {
                for (int i = 0; i < 30; i++) //Dust pre-teleport
                {
                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 62);
                    dust.scale = 1.1f;
                    dust.velocity *= 2;
                    dust.noGravity = true;

                }

                teleanimation = true;
                projectile.frame = 4;

                teleport = true;
                projectile.position.X = player.Center.X + xpostion - projectile.width / 2;
                projectile.position.Y = player.Center.Y + ypostion - projectile.height / 2;
               
            }
            //dust
            if (Main.rand.Next(4) == 0)
            {
                var dust = Dust.NewDustDirect(new Vector2(projectile.Center.X - 5, projectile.Center.Y + 6), 10, 6, 58, 0, 3);
                dust.scale = 1f;
                dust.velocity.X *= 0.5f;
                dust.fadeIn = 0.5f;
                dust.noGravity = true;
                dust.noLight = true;
            }

         


            AnimateProjectile();

        }
         public void AnimateProjectile() // Call this every frame, for example in the AI method.
         {
            if (!teleanimation)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 8)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;

                }
            }
            if (teleanimation)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 8)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 8)
                {
                    teleanimation = false;
                    projectile.frame = 0;

                }
            }
        }


        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++) //Dust post-teleport
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 62);
                dust.scale = 1.1f;
                dust.velocity *= 2;
                dust.noGravity = true;

            }
        }
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)//Doesn't work >:(
        {
            Texture2D texture = mod.GetTexture("Pets/StormLightProj_Glowmask");

            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, new Rectangle(0, projectile.frame * (Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height)
           , Color.White, projectile.rotation, projectile.Center, projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 100);
           

        }*/

        public override Color? GetAlpha(Color lightColor)
         {
             return Color.White;
         }
    }
}

