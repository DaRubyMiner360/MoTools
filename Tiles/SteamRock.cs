using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MoTools.Tiles
{
    public class SteamRock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[56][ModContent.TileType<Tiles.SteamRock>()] = true;
            Main.tileMerge[ModContent.TileType<Tiles.SteamRock>()][56] = true;
            Main.tileMerge[ModContent.TileType<Tiles.SteamRock>()][ModContent.TileType<SteamOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<SteamOreBlock>()][ModContent.TileType<Tiles.SteamRock>()] = true;
            Main.tileMerge[ModContent.TileType<Tiles.SteamRock>()][ModContent.TileType<SteamBrick>()] = true;
            Main.tileMerge[ModContent.TileType<SteamBrick>()][ModContent.TileType<Tiles.SteamRock>()] = true;
            Main.tileMerge[ModContent.TileType<SteamOreBlock>()][ModContent.TileType<SteamBrick>()] = true;
            Main.tileMerge[ModContent.TileType<SteamBrick>()][ModContent.TileType<SteamOreBlock>()] = true;
            Main.tileMerge[56][ModContent.TileType<SteamBrick>()] = true;
            Main.tileMerge[ModContent.TileType<SteamBrick>()][56] = true;
            Main.tileMerge[ModContent.TileType<SteamBrick>()][58] = true;
            Main.tileMerge[ModContent.TileType<SteamOreBlock>()][58] = true;
            Main.tileMerge[ModContent.TileType<Tiles.SteamRock>()][58] = true;
            Main.tileMerge[58][ModContent.TileType<SteamBrick>()] = true;
            Main.tileMerge[58][ModContent.TileType<SteamOreBlock>()] = true;
            Main.tileMerge[58][ModContent.TileType<Tiles.SteamRock>()] = true;
            Main.tileLighted[Type] = false;
            AddMapEntry(new Color(50, 50, 50));
            mineResist = 1f;
            minPick = 20;
            drop = ModContent.ItemType<Items.Placeable.SteamRock>();
            soundType = 21;
            dustType = 1;
            //soundStyle = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}