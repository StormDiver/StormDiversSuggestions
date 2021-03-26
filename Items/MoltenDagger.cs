using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items
{
	public class MoltenDagger : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Molten Dagger"); 
			Tooltip.SetDefault("Rapidly stab your foes");
		}

		public override void SetDefaults() 
		{
			item.damage = 35;
            item.crit = 0;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 4;
           
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 2)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 127, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SuperBurnDebuff"), 300);
        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 16);

            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
   
}