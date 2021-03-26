using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StormDiversSuggestions.Items.Tools
{
	public class BloodPax : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Pax"); 
			Tooltip.SetDefault("'Try not to make a mess with this'");
		}
    
		public override void SetDefaults() 
		{
			item.damage = 15;
            item.crit = 0;
			item.melee = true;
			item.width = 40;
			item.height = 42;
			item.useTime = 14;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.rare = ItemRarityID.Green;
            item.pick = 65;
            item.axe = 20;
			item.UseSound = SoundID.NPCHit9;
			item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 3;
            item.scale = 1.1f;
            
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 2)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 16);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
    public class BloodHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Hammer");
            Tooltip.SetDefault("'Try not to leave blood stains on the wall'");
        }
   
        public override void SetDefaults()
        {
            item.damage = 22;
        
            item.melee = true;
            item.width = 40;
            item.height = 48;
            item.useTime = 19;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 75, 0);
            item.rare = ItemRarityID.Green;
            item.hammer = 55;
            item.UseSound = SoundID.NPCHit9;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 7;
            item.scale = 1.25f;

        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) < 2)
            {
                int dustIndex = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5, 0f, 0f, 100, default, 1f);
                Main.dust[dustIndex].scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[dustIndex].noGravity = true;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.NPCHit, (int)player.position.X, (int)player.position.Y, 9);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("StormDiversSuggestions:EvilBars", 16);
            recipe.AddIngredient(mod.GetItem("BloodDrop"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}