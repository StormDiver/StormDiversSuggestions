using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace StormDiversSuggestions.Dusts
{
    public class ShroomDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
           // dust.noLight = true;
            dust.scale = 2f;
            dust.alpha = 2;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
            dust.scale -= 0.2f;
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }
            else
            {
                float strength = dust.scale / 2f;
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 0f * 0.5f * strength, dust.color.G / 0f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
            }
            return false;
        }
    }
    public class BeetleDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            // dust.noLight = true;
            dust.scale = 1.5f;
            dust.alpha = 2;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
            dust.scale -= 0.2f;
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }
            else
            {
                float strength = dust.scale / 2f;
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 0f * 0.5f * strength, dust.color.G / 0f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
            }
            return false;
        }
    }
    public class SpookDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            // dust.noLight = true;
            dust.scale = 1.5f;
            dust.alpha = 50;
            
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
            dust.scale -= 0.1f;
            if (dust.scale < 0.2f)
            {
                dust.active = false;
            }
            else
            {
                float strength = dust.scale / 2f;
                Lighting.AddLight((int)(dust.position.X), (int)(dust.position.Y), dust.color.R / 0f * 0.5f * strength, dust.color.G / 0f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
            }
            return false;
        }
       
    }
}