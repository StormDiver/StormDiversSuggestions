using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Items
{
    public class QuackStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duck Fracture");
            Tooltip.SetDefault("Fires out mini ducks to attack your foes\n'May be prone to quacking'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 9;
            

            item.damage = 27;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("QuackProj");

            item.shootSpeed = 5f;
            
            //item.useAmmo = AmmoID.Arrow;
                

            item.noMelee = true; //Does the weapon itself inflict damage?
        }
        /* public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }*/
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 3; i++)
            {
                float posX = position.X + Main.rand.NextFloat(35f, -35f);
                float posY = position.Y + Main.rand.NextFloat(10f, -40f);

                Projectile.NewProjectile(posX, posY, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            Main.PlaySound(SoundID.Duck, (int)player.position.X, (int)player.position.Y);


            return false;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("Quack"), 1);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
   
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(100) < 5)
                {
                    if (NPC.downedMechBossAny && !NPC.downedMoonlord)
                    {
                        if (npc.type == NPCID.Duck || npc.type == NPCID.Duck2 || npc.type == NPCID.DuckWhite || npc.type == NPCID.DuckWhite2)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("QuackStaff"));
                        }
                    }
                }
            }
        }
    }
    //____________________________________________________________________________________________________
    public class QuackStaffSuper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duck Quackture");
            Tooltip.SetDefault("Summons a bunch of ducks enhanced by lunar energy\n'Incredibly prone to quacking'");
            ItemID.Sets.SortingPriorityMaterials[item.type] = 100;
            Item.staff[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useTurn = false;
            item.autoReuse = true;

            item.magic = true;
            item.mana = 4;
        

            item.damage = 120;
            //item.crit = 4;
            item.knockBack = 1f;

            item.shoot = mod.ProjectileType("QuackProj");

            item.shootSpeed = 15f;

            //item.useAmmo = AmmoID.Arrow;


            item.noMelee = true; //Does the weapon itself inflict damage?
        }
         public override Vector2? HoldoutOffset()
         {
             return new Vector2(5, 0);
         }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 1f;
           
            int choice = Main.rand.Next(4);
            if (choice == 0)
                {
                type = mod.ProjectileType("QuackSolarProj");
                }
            else if (choice == 1)
            {
                type = mod.ProjectileType("QuackVortexProj");
                damage = damage / 10 * 12;
            }
            else if (choice == 2)
            {
                type = mod.ProjectileType("QuackNebulaProj");
            }
            else if (choice == 3)
            {
                type = mod.ProjectileType("QuackStardustProj");
            }
           
                float posX = position.X + Main.rand.NextFloat(50f, -50f);
                float posY = position.Y + Main.rand.NextFloat(10f, -50f);
            if (Collision.CanHitLine(position, 0, 0, player.Center, 0, 0))
            {

                Projectile.NewProjectile(posX, posY, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Main.PlaySound(SoundID.Duck, (int)player.Center.X, (int)player.Center.Y, 0, 0.5f, -0.25f);

            }


            return false;
        
        }

       
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (!Main.expertMode)
                {
                    if (Main.rand.Next(100) < 10)
                    {

                        if (npc.type == NPCID.MoonLordCore)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("QuackStaffSuper"));
                        }

                    }
                }
            }
        }
    }
}