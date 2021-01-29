using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	
    
    public class Weapontester : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("U shudn't have dis");
            Tooltip.SetDefault("Y do U have dis?");
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = -1;
            item.useStyle = 5;
            item.useTime = 1;
            item.useAnimation = 1;
            item.useTurn = false;
            item.autoReuse = true;
            item.UseSound = SoundID.Item43;
            //item.melee = true;
            //item.ranged = true;
            //item.magic = true;
            //item.summon = true;
            //item.thrown = true;

            item.damage = 1;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = ProjectileID.Bullet;
            //item.shoot = ProjectileID.Meowmere;
            item.shootSpeed = 15f;

            //item.useAmmo = AmmoID.Arrow;

            item.noMelee = true; //Does the weapon itself inflict damage?
                                 //item.noUseGraphic = true; //When uses no graphic is shown
                                 //item.channel = true; //Speical conditons when held down

        }
        public override void HoldItem(Player player)
        {
            player.AddBuff(mod.BuffType("SuperFrostBurn"), 1);
            player.AddBuff(mod.BuffType("AridSandDebuff"), 1);
            player.AddBuff(mod.BuffType("BoulderDebuff"), 1);
            player.AddBuff(mod.BuffType("SuperBoulderDebuff"), 1);
            player.AddBuff(mod.BuffType("LunarBoulderDebuff"), 1);
            player.AddBuff(mod.BuffType("SpectreDebuff"), 1);
            player.AddBuff(mod.BuffType("ScanDroneDebuff"), 1);
            player.AddBuff(mod.BuffType("NebulaDebuff"), 1);

            player.AddBuff(mod.BuffType("BloodDebuff"), 1);
            player.AddBuff(mod.BuffType("BeetleDebuff"), 1);
            player.AddBuff(mod.BuffType("HeartDebuff"), 1);



        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            
            //player.AddBuff(BuffID.ManaSickness, 1200);
            return true;
        }
        

}
}