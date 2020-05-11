using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoTools.NPCs.The404KingSlime;
using MoTools.Buffs;

namespace MoTools
{
    public class VanillaTweaks : GlobalNPC
    {
        public static Random rnd = new Random();

        public override void NPCLoot(NPC npc)
        {
            if (!MoToolsWorld.spawned404Crystals && npc.type == NPCID.MoonLordCore)
            {
                Main.NewText("The moon has fallen, and a new source of power has risen", 0, 200, 0);
                NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), ModContent.NPCType<The404KingSlime>());
                Main.LocalPlayer.AddBuff(ModContent.BuffType<The404Curse>(), 120);
                for (int k = 0; k < (int)((WorldGen.rockLayer * Main.maxTilesY) * 5); k++)
                {
                    int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

                    //WorldGen.TileRunner(X, Y, (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 5), mod.TileType("The404Ore"), false, 0f, 0f, false, true);
                    //WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(5, 9), (ushort)mod.TileType("The404Ore"));//Sadly I found nowhere to put WorldGen.genRand.Next(5, 9)

                    Tile tile = Framing.GetTileSafely(X, Y);
                    if (tile.active() && tile.type == TileID.Hellstone/* || tile.type == TileID.Ash*/)
                    {
                        //WorldGen.OreRunner(X, Y, 5/*idk*/, 5/*idk*/, mod.TileType("The404Ore"));//Sadly I found nowhere to put WorldGen.genRand.Next(5, 9)
                        WorldGen.TileRunner(X, Y, (double)WorldGen.genRand.Next(100, 100), WorldGen.genRand.Next(100, 100), mod.TileType("The404Ore"), false, 0f, 0f, false, true);
                        //WorldGen.OreRunner(X, Y, WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 5), (ushort)mod.TileType("The404Ore"));//Sadly I found nowhere to put WorldGen.genRand.Next(5, 9)
                    }
                }

                MoToolsWorld.spawned404Crystals = true;
            }
            else if (npc.type == NPCID.MoonLordCore)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<The404Curse>(), 120);
            }
            if (!NPC.downedSlimeKing && npc.type == NPCID.KingSlime)
            {
                Main.NewText("The crown of slime has been lost in the battle, and the slimes are growing restless", 0, 0, 200);
            }
            if (!NPC.downedAncientCultist && npc.type == NPCID.CultistBoss)
            {
                Main.NewText("Get prepared for the 404 Curse!!", 200, 0, 0);
            }
            if (Main.hardMode && npc.type == NPCID.WallofFlesh)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    Main.tile[i, Main.maxTilesY / 2].type = TileID.Pearlstone;
                }
            }
            // Addtional if statements here if you would like to add drops to other vanilla npc.
        }
    }
}