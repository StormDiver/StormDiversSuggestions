﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Pets;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items.Minions
{
    public class DerplingMinionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Derpling Minion");
            Description.SetDefault("A buffed baby Derpling will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ProjectileType<DerplingMinionProj>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
    public class DerplingMinion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Staff");
            Tooltip.SetDefault("Summons a buffed baby Derpling to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 46;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
                     item.rare = ItemRarityID.Lime;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 36;
            item.useAnimation = 36;
            item.autoReuse = true;
            // item.UseSound = SoundID.Item43;

            item.damage = 32;
            item.knockBack = 3.5f;
            item.UseSound = SoundID.Item43;

            
            item.mana = 10;

            item.noMelee = true; 
            item.summon = true;

            item.UseSound = SoundID.Item44;

            item.buffType = BuffType<DerplingMinionBuff>();
            item.shoot = mod.ProjectileType("DerplingMinionProj");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 8);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            player.AddBuff(item.buffType, 2);

            position = Main.MouseWorld;

            return true;



        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(mod.GetItem("DerplingShell"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    //CCOPY SLIME MINION AI
    public class DerplingMinionProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Derpling Minion");
            // Sets the amount of frames this minion has on its spritesheet
            Main.projFrames[projectile.type] = 6;
            // This is necessary for right-click targeting
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

            // These below are needed for a minion
            // Denotes that this projectile is a pet or minion
            Main.projPet[projectile.type] = true;
            // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;

            
        }

        public sealed override void SetDefaults()
        {
            // Makes the minion go through tiles freely
            projectile.tileCollide = false;
            // Only controls if it deals damage to enemies on contact (more on that later)
            projectile.friendly = true;
            // Only determines the damage type
            projectile.minion = true;
            // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            projectile.minionSlots = 1f;
            // Needed so the minion doesn't despawn on collision with enemies or tiles
            projectile.penetrate = -1;

            projectile.CloneDefaults(266);
            aiType = 266;
        }
        public override bool MinionContactDamage()
        {
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType<DerplingMinionBuff>());
            }
            if (player.HasBuff(BuffType<DerplingMinionBuff>()))
            {
                projectile.timeLeft = 2;
            }
            projectile.width = 32;
            projectile.height = 24;
            projectile.Opacity = 1;
            drawOffsetX = -1;
            drawOriginOffsetY = -6;
            projectile.usesLocalNPCImmunity = true;
           
            //projectile.extraUpdates = 1;
            if (!projectile.tileCollide)
            {
  
                projectile.extraUpdates = 1;
            }
            else
            {
                projectile.extraUpdates = 0;
            }
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 15;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            for (int i = 0; i < 2; i++)
            {


                var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
            }

        }
        public override void Kill(int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {

                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.NPCHit, (int)projectile.position.X, (int)projectile.position.Y, 22);
                for (int i = 0; i < 15; i++)
                {


                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 68);
                }
            }
        }

    }
}