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

    public class StormLightItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Helmet");
            Tooltip.SetDefault("Summons something unthinkable");
    
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
            item.value = Item.sellPrice(0, 10, 0, 0);
            
            item.shoot = ProjectileType<StormLightProj>();
            item.buffType = BuffType<StormLightBuff>();
            item.rare = ItemRarityID.Red;

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
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.VortexRifleman)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormLightItem"));
                       
                    }
                }
            }
        }
    }

    public class StormLightBuff : ModBuff
    {
        public override void SetDefaults()
        {
            
            DisplayName.SetDefault("Baby Storm Diver");
            Description.SetDefault("It's not cute, it's not!!!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<StormPlayer>().stormHelmet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<StormLightProj>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<StormLightProj>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
    public class StormLightProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Storm Diver");
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.DD2PetGato);
            //aiType = ProjectileID.DD2PetGato;
            projectile.aiStyle = -1;
            projectile.width = 34;
           projectile.height = 40;
            projectile.scale = 1;
            drawOffsetX = 0;
            drawOriginOffsetY = 0;
            projectile.timeLeft *= 5;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            //player.petFlagDD2Gato = false; 
            return true;
        }
        float movespeed = 10f; //Speed of the pet

        float xpostion = 50; // The picked x postion
        float ypostion = -60f;
        bool yAssend;
        bool animatefast;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            StormPlayer modPlayer = player.GetModPlayer<StormPlayer>();
            if (!player.active)
            {
                projectile.active = false;
                return;
            }
            if (player.dead)
            {
                modPlayer.stormHelmet = false;
            }
            if (modPlayer.stormHelmet)
            {
                projectile.timeLeft = 2;
            }



            float distanceX = player.Center.X - projectile.Center.X;
            float distanceY = player.Center.Y - projectile.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(distanceX * distanceX + distanceY * distanceY));

            projectile.rotation = projectile.velocity.X / 20;


            xpostion = 50 * -player.direction; //Moves to the front of the player
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

            if (distance < 1000)
            {
                Vector2 moveTo = player.Center;
                Vector2 move = moveTo - projectile.Center + new Vector2(xpostion, ypostion); //Postion around player
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                if (magnitude > movespeed)
                {
                    move *= movespeed / magnitude;
                }
                projectile.velocity = move;
            }
            if (distance >= 1000) //Teleports if too far
            {
                projectile.position.X = player.position.X;
                projectile.position.Y = player.position.Y;

            }
            if (distance > 100 && projectile.velocity.Y < 5) //Change aniamtion and speed and faster dust
            {
                //if (projectile.velocity.Y < 5)
                {
                    Dust dust;
                    Vector2 position = (new Vector2(projectile.Center.X - (7 * projectile.spriteDirection) - 4, projectile.Center.Y - 3));
                    dust = Terraria.Dust.NewDustDirect(position, 0, 0, 206, -projectile.spriteDirection * 3f, 3, 0, new Color(255, 255, 255), 1f);
                }
                animatefast = true;
            }
            else
            {
                if (Main.rand.Next(6) == 0)
                {
                    Dust dust;
                    Vector2 position = (new Vector2(projectile.Center.X - (7 * projectile.spriteDirection) - 4, projectile.Center.Y - 3));
                    dust = Terraria.Dust.NewDustDirect(position, 0, 0, 206, -projectile.spriteDirection * 2f, 2, 0, new Color(255, 255, 255), 1f);
                }
                animatefast = false;
            }


            // animate

            if (!animatefast)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;

                }
            }
            if (animatefast)
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 2)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 8 || projectile.frame <= 3)
                {
                    projectile.frame = 4;

                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++) //Dust post-teleport
            {
                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 206);
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

