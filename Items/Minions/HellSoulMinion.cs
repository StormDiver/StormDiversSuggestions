using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Minions
{


	public class HellSoulMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("HellSoul Minion");
			Description.SetDefault("A HellSoul minion will attack enemies for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<HellSoulMinionProj>()] > 0)
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
	//_______________________________________________________________________

	public class HellSoulMinion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HellSoul Staff");
			Tooltip.SetDefault("Summons a HellSoul minion to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item44;
			item.autoReuse = true;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<HellSoulMinionBuff>();
			item.shoot = ModContent.ProjectileType<HellSoulMinionProj>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(item.buffType, 2);

			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("SoulFire"), 14);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

	//_______________________________________________________________________
	public class HellSoulMinionProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HellSoul Minion");
			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;

			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
		}

		public sealed override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			// Makes the minion go through tiles freely
			projectile.tileCollide = false;

			// These below are needed for a minion weapon
			// Only controls if it deals damage to enemies on contact (more on that later)
			projectile.friendly = true;
			// Only determines the damage type
			projectile.minion = true;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			projectile.minionSlots = 1f;
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			projectile.penetrate = -1;

			
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles()
		{
			return false;
		}

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage()
		{
			return false;
		}
		int shootime;
		public override void AI()
		{
			Player player = Main.player[projectile.owner];

		
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<HellSoulMinionBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<HellSoulMinionBuff>()))
			{
				projectile.timeLeft = 2;
			}
		
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

			// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
			// The index is projectile.minionPos
			float minionPositionOffsetX = (10 + projectile.minionPos * 20) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player


			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f)
			{
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

			// If your minion is flying, you want to do this independently of any conditions
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width)
				{
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
		
			// Starting search distance
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				// Reasonable distance away so it doesn't target across multiple screens
				if (between < 2000f)
				{
					targetCenter = npc.Center + new Vector2(0, -120);
					foundTarget = true;
				}
			}
			if (!foundTarget)
			{
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float npcDistance = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > npcDistance;

						if (closest || !foundTarget)
						{
							// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
							// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
							bool closeThroughWall = npcDistance < 50f;
							bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);

							if ((lineOfSight || closeThroughWall) && npcDistance < 750)
							{
								targetCenter = npc.Center + new Vector2(0, -120);
								foundTarget = true;
							}
						}
					}
				}
			}

			
			projectile.friendly = foundTarget;
			

			// Default movement parameters (here for attacking)
			float speed = 8f;
			float inertia = 50f;

			if (foundTarget)
			{
				shootime++;
				// Minion has a target: attack (here, fly towards the enemy)
				if (Vector2.Distance(projectile.Center, targetCenter) > 50f)
				{
					// The immediate range around the target (so it doesn't latch onto it when close)
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;

					/*float shootToX = Main.MouseWorld.X - projectile.Center.X;
					float shootToY = Main.MouseWorld.Y - projectile.Center.Y;
					float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
					bool lineOfSight = Collision.CanHitLine(Main.MouseWorld, 0, 0, projectile.position, projectile.width, projectile.height);


					distance = 3f / distance;
					shootToX *= distance * 7;
					shootToY *= distance * 7;*/
					
				}
				if (shootime > 60 && Vector2.Distance(projectile.Center, targetCenter) < 450f)
				{
					int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("HellSoulMinionProj2"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
					for (int i = 0; i < 10; i++)
					{
						var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 173);
						dust.scale = 1.5f;
						dust.velocity *= 2;
					}
					shootime = 0;
				}
			}
			else
			{
				// Minion doesn't have a target: return to player and idle
				if (distanceToIdlePosition > 300f)
				{
					// Speed up the minion if it's away from the player
					speed = 12f;
					inertia = 60f;
				}
				else
				{
					// Slow down the minion if closer to the player
					speed = 4f;
					inertia = 80f;
				}
				if (distanceToIdlePosition > 10f)
				{
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero)
				{
					// If there is a case where it's not moving at all, give it a little "poke"
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
	
		
			// So it will lean slightly towards the direction it's moving
			projectile.rotation = projectile.velocity.X * 0.05f;

			// This is a simple "loop through all frames from top to bottom" animation
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}

			// Some visuals here
			Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 0.78f);
			if (Main.rand.Next(8) == 0)
			{

				var dust2 = Dust.NewDustDirect(new Vector2(projectile.position.X, projectile.Top.Y), projectile.width, projectile.height / 2, 135, 0, -2);
				dust2.scale = 1f;
				dust2.noGravity = true;

			}
			if (Main.rand.Next(6) == 0)
			{

				var dust3 = Dust.NewDustDirect(new Vector2(projectile.Center.X - 8, projectile.Bottom.Y - 10), 16, 6, 173, 0, 5);
				dust3.noGravity = true;

			}
		}
		public override void Kill(int timeLeft)
		{
			if (projectile.owner == Main.myPlayer)
			{

				Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

				for (int i = 0; i < 25; i++)
				{
					var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 173);
					dust.scale = 1;
					dust.velocity *= 2;
				}

			}
		}
	}
	//__________________________________________________________________________________________________________

	public class HellSoulMinionProj2 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("HellSoul Minion projectile");
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
			projectile.light = 0.4f;
			projectile.scale = 1f;
			projectile.aiStyle = 0;
			//drawOffsetX = -9;
			//drawOriginOffsetY = -9;

		}
		int homein = 0;
		Vector2 newMove;

		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

			AnimateProjectile();
			Dust dust;
			// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = projectile.position;
			dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 173, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f, 0, new Color(255, 255, 255), 1f)];
			dust.noGravity = true;
			dust.scale = 0.8f;
			homein++;
			Player player = Main.player[projectile.owner];
			if (homein < 10)
			{
				if (projectile.localAI[0] == 0f)
				{
					AdjustMagnitude(ref projectile.velocity);
					projectile.localAI[0] = 1f;
				}
				Vector2 move = Vector2.Zero;
				float distance = 1000f;
				bool target = false;

				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && Main.npc[k].type != NPCID.TargetDummy)
					{
						if (player.HasMinionAttackTargetNPC)
						{

							newMove = Main.npc[player.MinionAttackTargetNPC].Center - projectile.Center;
						}
						else
						{
							newMove = Main.npc[k].Center - projectile.Center;
						}


						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							move = newMove;
							distance = distanceTo;
							target = true;
						}

					}
				}
				if (target)
				{
					AdjustMagnitude(ref move);
					projectile.velocity = (20 * projectile.velocity + move) / 20f;
					AdjustMagnitude(ref projectile.velocity);
				}
			}
		}
		private void AdjustMagnitude(ref Vector2 vector)
		{
			if (homein < 10)
			{
				float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
				if (magnitude > 40f)
				{
					vector *= 40f / magnitude;
				}
			}
		}
		

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{

			target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 120);

			projectile.Kill();
		}
		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("HellSoulFireDebuff"), 120);
		}
		public override void Kill(int timeLeft)
		{
			if (projectile.owner == Main.myPlayer)
			{

				Main.PlaySound(SoundID.NPCKilled, (int)projectile.position.X, (int)projectile.position.Y, 6, 0.5f);

				for (int i = 0; i < 10; i++)
				{
					var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 173);
					dust.scale = 1;
					dust.velocity *= 2;
				}

			}
		}

		public void AnimateProjectile() // Call this every frame, for example in the AI method.
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 5) // This will change the sprite every 8 frames (0.13 seconds). Feel free to experiment.
			{
				projectile.frame++;
				projectile.frame %= 4; // Will reset to the first frame if you've gone through them all.
				projectile.frameCounter = 0;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{

			Color color = Color.White;
			color.A = 150;
			return color;

		}

	}
}