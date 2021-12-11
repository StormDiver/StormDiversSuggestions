using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class CultistSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Spear of Fire");
            Tooltip.SetDefault("Striking an enemy summons a bunch of fireballs");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 46;
        }

        public override void SetDefaults()
        {
            item.damage = 95;
            item.crit = 16;
            item.melee = true;
            item.width = 50;
            item.height = 64;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = false;
            item.knockBack = 5f;
            item.shoot = mod.ProjectileType("CultistSpearProj");
            item.shootSpeed = 7.5f;
            item.noMelee = true;
            item.noUseGraphic = true;

        }
        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            return true;
        }

       //Drop rate in StormNPC/ Luantic Cultist treasure bag
    }
    //________________________________________________________________________________
    public class CultistBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Bow of Ice");
            Tooltip.SetDefault("Fires out an ice arrow that rains down icicles on impact");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 46;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.UseSound = SoundID.Item5;

            item.damage = 65;
            //item.crit = 4;
            item.knockBack = 2f;

            item.shoot = ProjectileID.WoodenArrowFriendly;

            item.shootSpeed = 10f;

            item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 30);


            int numberProjectiles = 2 + Main.rand.Next(2); ; //This defines how many projectiles to shot.
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed2.X, perturbedSpeed2.Y, type, (int)(damage * 1f), knockBack, player.whoAmI);
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));

            Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * 1.2f, perturbedSpeed.Y * 1.2f, mod.ProjectileType("CultistBowProj"), damage, knockBack, player.whoAmI); 


            return false;

        }
        //Drop rate in StormNPC/ Luantic Cultist treasure bag


    }
    //__________________________________________________________________________________________________________
    //__________________________________________________
    public class CultistTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Spell of Ancient Light");
            Tooltip.SetDefault("Summons ancient light that seeks out enemies");

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 15;
            item.UseSound = SoundID.Item9;

            item.damage = 60;

            item.knockBack = 4f;

            item.shoot = mod.ProjectileType("CultistTomeProj"); 

            item.shootSpeed = 15f;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            for (int i = 0; i < 20; i++) //this i a for loop tham make the dust spawn , the higher is the value the more dust will spawn
            {
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 135, 0, 0, 120, default, 1.5f);   //this make so when this projectile disappear will spawn dust, change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 2.5f;
            }
            return true;
            

           
        }
        //Drop rate in StormNPC/ Luantic Cultist treasure bag

    }
    //_______________________________________________________________________
    public class CultistStaff : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lunatic Staff of Lightning");
            Tooltip.SetDefault("Rapidly shoots out bolts of piercing lightning"); 
            Item.staff[item.type] = true;

        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 5;
            //item.UseSound = SoundID.Item9;

            item.damage = 100;

            item.knockBack = 1f;

            item.shoot = 466;

            item.shootSpeed = 15f;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {



            //Code for lighting,

            Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 122);

            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            Vector2 rotation = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
                float ai = Main.rand.Next(100);
                Vector2 speed = Vector2.Normalize(rotation) * item.shootSpeed;
                int projID = Projectile.NewProjectile(position.X, position.Y, speed.X, speed.Y, ProjectileID.CultistBossLightningOrbArc, damage, .5f, player.whoAmI, rotation.ToRotation(), ai);
                Main.projectile[projID].hostile = false;
                Main.projectile[projID].friendly = true;
                Main.projectile[projID].penetrate = 10;
                Main.projectile[projID].usesLocalNPCImmunity = true;
                Main.projectile[projID].localNPCHitCooldown = -1;
                Main.projectile[projID].scale = 0.5f;
            Main.projectile[projID].timeLeft = 100;
            Main.projectile[projID].magic = true;


            return false;
        }
        //Drop rate in StormNPC/ Luantic Cultist treasure bag

    }
}