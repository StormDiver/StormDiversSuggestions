using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using StormDiversSuggestions.Buffs;
using StormDiversSuggestions.Basefiles;
using static Terraria.ModLoader.ModContent;

namespace StormDiversSuggestions.Buffs
{
    
    public class BuffEnhance2 : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        int rangedincrease = 0;
        public override void AI(Projectile projectile)
        {
            if (projectile.melee)
            {

                
                if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()))
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 98, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                    dust.noGravity = true;

                    dust.scale = 1.2f;
                    
                }
            }
            if (projectile.ranged)
            {
                
                rangedincrease++;
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = projectile.position;
                    dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 59, 0f, 0f, 0, new Color(255, 255, 255), 1f);
                    dust.noGravity = true;

                    dust.scale = 1.2f;
                    if (rangedincrease == 1)
                    {
                        if (projectile.penetrate >= 1)
                        {
                            projectile.penetrate = (projectile.penetrate + 1);
                        }
                        projectile.knockBack *= 2f;
                        projectile.usesLocalNPCImmunity = true;
                        projectile.localNPCHitCooldown = 10;
                        projectile.extraUpdates += (int)1.5f;
                    }
                }
            }
            
           
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockBack, bool crit)
        {
            if (projectile.melee)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()))
                {
                    if (Main.rand.Next(5) == 0)
                    {
                        target.AddBuff(mod.BuffType("BeetleDebuff"), 300);
                    }
                    
                }
            }
            if (projectile.ranged)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
                {

                }
                
            }
     
            if (projectile.magic)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
                {
                    
                }
            }
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (projectile.magic)
            {
                
            }
            return true;
        }
    }
    public class BuffEnhance : GlobalItem
    {
        public override void SetDefaults(Item item)
        {


        }
        public override bool ConsumeAmmo(Item item, Player player)
        {
            if (item.ranged)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
                {
                    return Main.rand.NextFloat() >= .30f;
                }
            }
            return true;
        }
        
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /*if (item.ranged)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<ShroomiteBuff>()))
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                        int proj = Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.8), (float)(perturbedSpeed.Y * 0.8), mod.ProjectileType("BuffShroomProj"), 60, knockBack, player.whoAmI);
                    }
                    
                }
            }
            if (item.magic)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<SpectreBuff>()))
                {

                    if (Main.rand.Next(2) == 0)
                    {
                        //Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                        //int proj = Projectile.NewProjectile(position.X, position.Y, (float)(perturbedSpeed.X * 0.4), (float)(perturbedSpeed.Y * 0.4), ProjectileID.LostSoulFriendly, 60, knockBack, player.whoAmI);
                        Vector2 perturbedSpeed = new Vector2(0, 5).RotatedByRandom(MathHelper.ToRadians(360));
                        Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.LostSoulFriendly, damage, knockBack, player.whoAmI);
                        
                    }
                }

            }*/

            return true;

        }
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (item.melee)
            {
                if (Main.LocalPlayer.HasBuff(BuffType<BeetleBuff>()))
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        target.AddBuff(mod.BuffType("BeetleDebuff"), 300);
                    }
                }
            }
            

        }


        
    }
}
