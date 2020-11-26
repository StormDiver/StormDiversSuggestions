using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using StormDiversSuggestions.Basefiles;

namespace StormDiversSuggestions.Items.Accessory
{
   
    public class PrimeAccess : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Spikes");
            Tooltip.SetDefault("Three spike balls will orbit you, damaging enemies within reach\nHas a small chance to destroy almost any projectile that comes near");
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 5));
        }
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 40;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = 5;

            item.defense = 7;
            item.accessory = true;
            item.expert = true;
        }


        //int skulltime = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            
            player.GetModPlayer<StormPlayer>().primeSpin = true;
            //skulltime++;

            /*
            if (skulltime >=20)
            {
                
               
                int damage = 20;
                float speedX = 0f;
                float speedY = -24f;
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                float scale = 1f - (Main.rand.NextFloat() * .5f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("PrimeAccessProj"), damage, 3f, player.whoAmI);
                
                skulltime = 0;
            }*/
           
        }


    }
}