using MoTools.Tiles;
using MoTools.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools
{
    class WorldGeneration
    {
        public static void Spread(string biome, int i, int j)
        {
			if (biome == "The 404 Realm")
            {
				int direction = Main.rand.Next(8);
				int block = 0;
				bool found = false;
				Vector2Int position = new Vector2Int(i, j);
				if (direction == 0)
				{
					position = new Vector2Int(i + 1, j);
				}
				else if (direction == 1)
				{
					position = new Vector2Int(i - 1, j);
				}
				else if (direction == 2)
				{
					position = new Vector2Int(i, j + 1);
				}
				else if (direction == 3)
				{
					position = new Vector2Int(i, j - 1);
				}
				else if (direction == 4)
				{
					position = new Vector2Int(i + 1, j + 1);
				}
				else if (direction == 5)
				{
					position = new Vector2Int(i + 1, j - 1);
				}
				else if (direction == 6)
				{
					position = new Vector2Int(i - 1, j + 1);
				}
				else if (direction == 7)
				{
					position = new Vector2Int(i - 1, j - 1);
				}
				var type = Main.tile[position.X, position.Y].type;
				var wall = Main.tile[position.X, position.Y].wall;

				if (wall != 0)
				{
					Main.tile[position.X, position.Y].wall = (ushort)WallType<The404Wall>();
					WorldGen.SquareWallFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					WorldGen.PlaceWall(position.X, position.Y, WallType<The404Wall>());

					return;
				}

				//If the tile is stone, convert to The404Block
				if (TileID.Sets.Conversion.Stone[type])
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Block>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Block>();
					found = true;
				}
				//If the tile is sand, convert to The404Sand
				else if (TileID.Sets.Conversion.Sand[type])
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Sand>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Sand>();
					found = true;
				}
				//If the tile is hardened sand, convert to The404HardenedSand
				else if (TileID.Sets.Conversion.HardenedSand[type])
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404HardenedSand>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404HardenedSand>();
				}
				//If the tile is ice, convert to The404Ice
				else if (TileID.Sets.Conversion.Ice[type])
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Ice>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Ice>();
					found = true;
				}
				//If the tile is snow, convert to The404Snow
				else if (type == TileID.SnowBlock)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Snow>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Snow>();
					found = true;
				}
				//If the tile is sandstone, convert to The404Sandstone
				else if (TileID.Sets.Conversion.Sandstone[type])
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Sandstone>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Sandstone>();
					found = true;
				}
				//If the tile is dirt, convert to The404Dirt
				else if (TileID.Sets.Conversion.Grass[type] || type == TileID.Dirt)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Dirt>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Dirt>();
					found = true;
				}
				//If the tile is clay, convert to The404Clay
				else if (type == TileID.ClayBlock)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Clay>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Clay>();
					found = true;
				}
				//If the tile is mud, convert to The404Mud
				else if (type == TileID.Mud)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Mud>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Mud>();
					found = true;
				}
				//If the tile is a chair, convert to The404Chair
				else if (type == TileID.Chairs && Main.tile[position.X, position.Y - 1].type == TileID.Chairs)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Chair>();
					Main.tile[position.X, position.Y - 1].type = (ushort)TileType<The404Chair>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Chair>();
					found = true;
				}
				//If the tile is a workbench, convert to The404Workbench
				else if (type == TileID.WorkBenches && Main.tile[position.X - 1, position.Y].type == TileID.WorkBenches)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Workbench>();
					Main.tile[position.X - 1, position.Y].type = (ushort)TileType<The404Workbench>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Workbench>();
					found = true;
				}
				//If the tile is a chest, convert to The404Chest
				else if (type == TileID.Containers && Main.tile[position.X - 1, position.Y].type == TileID.Containers && Main.tile[position.X, position.Y - 1].type == TileID.Containers && Main.tile[position.X - 1, position.Y - 1].type == TileID.Containers)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Chest>();
					Main.tile[position.X - 1, position.Y].type = (ushort)TileType<The404Chest>();
					Main.tile[position.X, position.Y - 1].type = (ushort)TileType<The404Chest>();
					Main.tile[position.X - 1, position.Y - 1].type = (ushort)TileType<The404Chest>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Chest>();
					found = true;
				}
				//If the tile is a platform, convert to The404Platform
				else if (type == TileID.Platforms)
				{
					Main.tile[position.X, position.Y].type = (ushort)TileType<The404Platform>();
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);

					block = TileType<The404Platform>();
					found = true;
				}
				//If the tile is a platform, convert to The404Platform
				else if (type == TileID.Trees)
				{
					Tile tile = Framing.GetTileSafely(position.X, position.Y); // Safely get the tile at the given coordinates
					if (tile.frameX < 54)
						WorldGen.GrowTree(position.X, position.Y);
					else
						WorldGen.GrowPalmTree(position.X, position.Y);
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);
				}
				//If the tile is a platform, convert to The404Platform
				else if (type == TileID.PalmTree)
				{
					Tile tile = Framing.GetTileSafely(position.X, position.Y); // Safely get the tile at the given coordinates
					if (tile.frameX < 54)
						WorldGen.GrowTree(position.X, position.Y);
					else
						WorldGen.GrowPalmTree(position.X, position.Y);
					WorldGen.SquareTileFrame(position.X, position.Y, true);
					NetMessage.SendTileSquare(-1, position.X, position.Y, 1);
				}
                else
                {
					found = false;
                }

				Tile tile2 = Framing.GetTileSafely(position.X, position.Y);
				if (found && tile2.active())
				{
					WorldGen.PlaceTile(position.X, position.Y, block);
					//Main.NewText(position.X);
					//Main.NewText(position.Y);
					//Main.NewText(Main.tile[position.X, position.Y]);
				}
			}
		}
    }
}
