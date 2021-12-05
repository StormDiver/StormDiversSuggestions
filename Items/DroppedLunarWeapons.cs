using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class SelenianBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Selenian Blades");
            Tooltip.SetDefault("Can be thrown out and spin in place upon striking an enemy");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }
        public override void SetDefaults()
        {
           
            item.damage = 80;
            item.melee = true;
            item.width = 30;
            item.height = 38;
            item.useTime = 14;
            item.useAnimation = 14;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("SelenianBladeProj");
            item.UseSound = SoundID.Item7;
            item.autoReuse = true;
            item.noMelee = true;

        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item, (int)position.X, (int)position.Y, 1);

            return true;
        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)

                {
                    if (npc.type == NPCID.SolarSolenian)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SelenianBlade"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianBlade_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);


            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
    //__________________________________________________________________________________________
    public class VortexShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Diver Shotgun");
            Tooltip.SetDefault("Stolen from the Legendary Storm Divers\nRight click to convert bullets into luminite bullets");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item36;

            item.damage = 60;
            item.crit = 20;
            item.knockBack = 5f;

            item.shoot = ProjectileID.MoonlordBullet;
            item.shootSpeed = 15f;

            item.useAmmo = AmmoID.Bullet;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {


            }
            else
            {


            }
            return base.CanUseItem(player);

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {

                type = ProjectileID.MoonlordBullet;
                //type = mod.ProjectileType("VortexRocketProj2");

                int numberProjectiles = 3 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }
            }
            else
            {

                int numberProjectiles = 4 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // This defines the projectiles random spread . 10 degree spread.
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
                }
            }
            return false;
        }


        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/VortexShotgun_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);


            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
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
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexShotgun"));
                }
            }
        }
    }

    //__________________________________________________________________________________________
    public class PredictorBrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Predictor Brain");
            Tooltip.SetDefault("Summons projectiles that charge towards the cursor");

            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;

            item.UseSound = SoundID.Item8;

            item.damage = 70;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("PredictorBrainProj");

            item.shootSpeed = 5f;

            item.mana = 13;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 30f;

            /* for (int i = 0; i < 5; i++)
             {
                 Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                 Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
             }*/
            speedX = 0f;
            speedY = -10f;
            for (int i = 0; i < 5; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(135));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, 1f, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.NebulaSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PredictorBrain"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorBrain_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);


            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
    //__________________________________________________________________________________________
    public class StargazerLaser : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stargazer Core");
            Tooltip.SetDefault("Summons a floating Stardust Portal that fires piercing projectiles at nearby enemies in bursts");

            ItemID.Sets.SortingPriorityMaterials[item.type] = 71;
        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useTurn = false;
            item.autoReuse = true;

            //item.channel = true;
            item.summon = true;

            item.UseSound = SoundID.Item78;

            item.damage = 75;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("StargazerCoreProj");

            item.shootSpeed = 0f;

            item.mana = 10;

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;

            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6, 0);
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 2)
                {
                    if (npc.type == NPCID.StardustSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StargazerLaser"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerLaser_Glow");


            //spriteBatch.Draw(texture, item.Center - Main.screenPosition, new Rectangle(0, 0, item.width, item.height), Color.White, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);


            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}