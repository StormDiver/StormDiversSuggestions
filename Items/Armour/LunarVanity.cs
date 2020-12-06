using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;


namespace StormDiversSuggestions.Items.Armour
{
    [AutoloadEquip(EquipType.Head)]
    public class StormDiverMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Storm Diver Mask");
            Tooltip.SetDefault("Can you even see out of this thing?");
        }
    
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;
        }
        /*
        public override void UpdateEquip(Player player)
        {
 
           
        }

    */
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
           
           
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<StormDiverBody>() && legs.type == ItemType<StormDiverLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {
            


        }
        
        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(50) == 0)
                {
                    if (npc.type == NPCID.VortexRifleman)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormDiverMask"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormDiverBody"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormDiverLegs"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StormDiverMask_Glow");


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
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class StormDiverBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Storm Diver Body");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StormDiverBody_Glow");


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
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class StormDiverLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Storm Diver legs");

        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StormDiverLegs_Glow");


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
    //_________________________________________________________________
    //_____________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class SelenianMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Selenian Head");
            Tooltip.SetDefault("No, you cannot reflect projectiles!");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;
        }
        /*
        public override void UpdateEquip(Player player)
        {
           
            
        }

    */
        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SelenianBody>() && legs.type == ItemType<SelenianLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {



        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(50) == 0)
                {
                    if (npc.type == NPCID.SolarSolenian)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SelenianMask"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SelenianBody"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SelenianLegs"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianMask_Glow");


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
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class SelenianBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Selenian Body");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }


        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianBody_Glow");


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
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class SelenianLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Selenian legs");

        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianLegs_Glow");


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
    //_________________________________________________________________
    //_____________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class PredictorMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Predictor Head");
            Tooltip.SetDefault("Unfortunately this will not increase your brain power");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;
        }
        /*
        public override void UpdateEquip(Player player)
        {
           
            
            
        }

    */
        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;
            //player.armorEffectDrawOutlines = true;
            player.armorEffectDrawShadowSubtle = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<PredictorBody>() && legs.type == ItemType<PredictorLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {



        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(50) == 0)
                {
                    if (npc.type == NPCID.NebulaSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PredictorMask"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PredictorBody"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PredictorLegs"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorMask_Glow");


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
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class PredictorBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Predictor Body");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorBody_Glow");


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
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class PredictorLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Predictor legs");

        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorLegs_Glow");


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
    //_________________________________________________________________
    //_____________________________________________________________________
    [AutoloadEquip(EquipType.Head)]
    public class StargazerMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Stargazer Head");
            Tooltip.SetDefault("Note, this will not actually allow you to see stars any better");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;
        }
        /*
        public override void UpdateEquip(Player player)
        {
           
       
        }

    */
        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;
            //player.armorEffectDrawOutlines = true;
            //player.armorEffectDrawShadowSubtle = true;
            player.armorEffectDrawShadowLokis = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<StargazerBody>() && legs.type == ItemType<StargazerLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {

            
        }

        public class ModGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (Main.rand.Next(50) == 0)
                {
                    if (npc.type == NPCID.StardustSoldier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StargazerMask"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StargazerBody"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StargazerLegs"));
                    }
                }
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerMask_Glow");


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
    //___________________________________________________________________________________________________________________________
    [AutoloadEquip(EquipType.Body)]
    public class StargazerBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Stargazer Body");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerBody_Glow");


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
    //______________________________________________________________________
    [AutoloadEquip(EquipType.Legs)]
    public class StargazerLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Stargazer legs");

        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 10;
            item.vanity = true;

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerLegs_Glow");


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