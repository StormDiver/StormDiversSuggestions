using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using StormDiversSuggestions.Buffs;
using Terraria.DataStructures;

//Yes I know this is messy and inefficent, but sadly there's barely any glow mask guides, and I can only get this to work with armour, maybe when tmod 1.4 is ever released I'll be able to add glwomaks to held items too 

namespace StormDiversSuggestions.Basefiles
{
    // Storm Diver Vanity________________________________________________________________
    public class ArmourGlowmasks : ModPlayer 
    {
       
        public static readonly PlayerLayer StormDiverMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "StormDiverMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }
        
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("StormDiverMask", EquipType.Head))
            {
                

                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/StormDiverMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader
                

            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer StormDiverBodyGlowmask = new PlayerLayer("StormDiversSuggestions", "StormDiverBodyGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("StormDiverBody", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/StormDiverBody_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/StormDiverBody_Body_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
       
        public static readonly PlayerLayer StormDiverLegsGlowmask = new PlayerLayer("StormDiversSuggestions", "StormDiverLegsGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("StormDiverLegs", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/StormDiverLegs_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //____________________________
        //Selenian Vanity____________
        public static readonly PlayerLayer SelenianMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "SelenianMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("SelenianMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer SelenianBodyGlowmask = new PlayerLayer("StormDiversSuggestions", "SelenianBodyGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("SelenianBody", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/SelenianBody_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/SelenianBody_Body_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________

        public static readonly PlayerLayer SelenianLegsGlowmask = new PlayerLayer("StormDiversSuggestions", "SelenianLegsGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("SelenianLegs", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/SelenianLegs_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //____________________________
        //Predictor Vanity____________
        public static readonly PlayerLayer PredictorMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "PredictorMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("PredictorMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer PredictorBodyGlowmask = new PlayerLayer("StormDiversSuggestions", "PredictorBodyGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("PredictorBody", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/PredictorBody_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/PredictorBody_Body_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________

        public static readonly PlayerLayer PredictorLegsGlowmask = new PlayerLayer("StormDiversSuggestions", "PredictorLegsGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("PredictorLegs", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/PredictorLegs_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //____________________________
        //Stargazer Vanity_________________
        public static readonly PlayerLayer StargazerMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "StargazerMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("StargazerMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer StargazerBodyGlowmask = new PlayerLayer("StormDiversSuggestions", "StargazerBodyGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("StargazerBody", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/StargazerBody_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/StargazerBody_Body_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________

        public static readonly PlayerLayer StargazerLegsGlowmask = new PlayerLayer("StormDiversSuggestions", "StargazerLegsGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("StargazerLegs", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/StargazerLegs_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //______________________
        //Conest Armour visor____
        public static readonly PlayerLayer ContestArmourHelmetGlowmask = new PlayerLayer("StormDiversSuggestions", "ContestArmourHelmetGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("ContestArmourHelmet", EquipType.Head))
            {
           

                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/ContestArmourHelmet_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //______________________
        //Granite Mask visor____
        public static readonly PlayerLayer GraniteMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "GraniteMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("GraniteMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/GraniteMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //____________________________
        //Mushroom Armour_________________
        public static readonly PlayerLayer MushroomMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "MushroomMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("MushroomMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/MushroomMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer MushroomChestplateGlowmask = new PlayerLayer("StormDiversSuggestions", "MushroomChestplateGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("MushroomChestplate", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/MushroomChestplate_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/MushroomChestplate_FemaleBody_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________

        public static readonly PlayerLayer MushroomGreavesGlowmask = new PlayerLayer("StormDiversSuggestions", "MushroomGreavesGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("MushroomGreaves", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/MushroomGreaves_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //____________________________________HellsoulArmour_____________________________________
        //_______________________________________________________________________________________
        public static readonly PlayerLayer HellSoulMaskGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulMaskGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("HellSoulMask", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulMask_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer HellSoulHelmetGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulHelmetGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("HellSoulHelmet", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulHelmet_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer HellSoulHoodGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulHoodGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("HellSoulHood", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulHood_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer HellSoulCrownGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulCrownGlowmask", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.head != mod.GetEquipSlot("HellSoulCrown", EquipType.Head))
            {


                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulCrown_Head_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 - 1f;

            Vector2 origin = drawInfo.headOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.headPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.headArmorShader


            };
            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________
        public static readonly PlayerLayer HellSoulChestplateGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulChestplateGlowmask", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.body != mod.GetEquipSlot("HellSoulChestplate", EquipType.Body))
            {
                return;
            }

            Texture2D texture = drawPlayer.Male ?
                mod.GetTexture("Items/Glowmasks/HellSoulChestplate_Body_Glow") :
                mod.GetTexture("Items/Glowmasks/HellSoulChestplate_FemaleBody_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.bodyFrame.Height / 2 + 4f;

            Vector2 origin = drawInfo.bodyOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.bodyPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.bodyFrame;

            float rotation = drawPlayer.bodyRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.bodyArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //_________________________________________________________________________

        public static readonly PlayerLayer HellSoulLeggingsGlowmask = new PlayerLayer("StormDiversSuggestions", "HellSoulLeggingsGlowmask", PlayerLayer.Legs, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f || drawInfo.drawPlayer.dead)
            {
                return;
            }

            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("StormDiversSuggestions");

            if (drawPlayer.legs != mod.GetEquipSlot("HellSoulLeggings", EquipType.Legs))
            {
                return;
            }

            Texture2D texture = mod.GetTexture("Items/Glowmasks/HellSoulLeggings_Legs_Glow");

            float drawX = (int)drawInfo.position.X + drawPlayer.width / 2;
            float drawY = (int)drawInfo.position.Y + drawPlayer.height - drawPlayer.legFrame.Height / 2 + 17f;

            Vector2 origin = drawInfo.legOrigin;

            Vector2 position = new Vector2(drawX, drawY) + drawPlayer.legPosition - Main.screenPosition;

            float alpha = (255 - drawPlayer.immuneAlpha) / 255f;

            Color color = Color.White;

            Rectangle frame = drawPlayer.legFrame;

            float rotation = drawPlayer.legRotation;

            SpriteEffects spriteEffects = drawInfo.spriteEffects;

            DrawData drawData = new DrawData(texture, position, frame, color * alpha, rotation, origin, 1f, spriteEffects, 0)
            {
                shader = drawInfo.legArmorShader
            };

            Main.playerDrawData.Add(drawData);
        });
        //____________________________
       

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            int headLayer = layers.FindIndex(i => i == PlayerLayer.Head);

            if (headLayer > -1)
            {
                layers.Insert(headLayer + 1, StormDiverMaskGlowmask);
                layers.Insert(headLayer + 1, SelenianMaskGlowmask);
                layers.Insert(headLayer + 1, PredictorMaskGlowmask);
                layers.Insert(headLayer + 1, StargazerMaskGlowmask);
                layers.Insert(headLayer + 1, ContestArmourHelmetGlowmask);
                layers.Insert(headLayer + 1, GraniteMaskGlowmask);
                layers.Insert(headLayer + 1, MushroomMaskGlowmask);
                layers.Insert(headLayer + 1, HellSoulMaskGlowmask);
                layers.Insert(headLayer + 1, HellSoulHelmetGlowmask);
                layers.Insert(headLayer + 1, HellSoulHoodGlowmask);
                layers.Insert(headLayer + 1, HellSoulCrownGlowmask);

                //Main.NewText("HEAD", 204, 132, 0);
            }

            int bodyLayer = layers.FindIndex(l => l == PlayerLayer.Body);

            if (bodyLayer > -1)
            {
                layers.Insert(bodyLayer + 1, StormDiverBodyGlowmask);
                layers.Insert(bodyLayer + 1, SelenianBodyGlowmask);
                layers.Insert(bodyLayer + 1, PredictorBodyGlowmask);
                layers.Insert(bodyLayer + 1, StargazerBodyGlowmask);
                layers.Insert(bodyLayer + 1, MushroomChestplateGlowmask);
                layers.Insert(bodyLayer + 1, HellSoulChestplateGlowmask);

            }
            int legLayer = layers.FindIndex(m => m == PlayerLayer.Legs);

            if (legLayer > -1)
            {
                layers.Insert(legLayer + 1, StormDiverLegsGlowmask);
                layers.Insert(legLayer + 1, SelenianLegsGlowmask);
                layers.Insert(legLayer + 1, PredictorLegsGlowmask);
                layers.Insert(legLayer + 1, StargazerLegsGlowmask);
                layers.Insert(legLayer + 1, MushroomGreavesGlowmask);
                layers.Insert(legLayer + 1, HellSoulLeggingsGlowmask);

            }
        }
    }
}
