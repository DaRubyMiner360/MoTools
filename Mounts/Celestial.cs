using MoTools.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace MoTools.Mounts
{
    public class Celestial : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.buff = BuffType<CelestialMount>();
            mountData.heightBoost = 10;
            mountData.fallDamage = 0.0f;
            mountData.runSpeed = 5f;
            mountData.dashSpeed = 4f;
            mountData.flightTimeMax = 999999999;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 3;
            mountData.acceleration = 0.095f;
            mountData.jumpSpeed = 8f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 4;
            mountData.constantJump = true;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 13;
            mountData.bodyFrame = 3;
            mountData.yOffset = -12;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 4;
            mountData.standingFrameDelay = 12;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 4;
            mountData.runningFrameDelay = 12;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 0;
            mountData.flyingFrameDelay = 0;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 12;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 4;
            mountData.idleFrameDelay = 12;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }


            mountData.textureWidth = mountData.backTexture.Width + 20;
            mountData.textureHeight = mountData.backTexture.Height;
        }


        public override void UpdateEffects(Player player)
        {
            if (!(Math.Abs(player.velocity.X) > 4f))
            {
                return;
            }


            Rectangle rect = player.getRect();
        }
    }
}