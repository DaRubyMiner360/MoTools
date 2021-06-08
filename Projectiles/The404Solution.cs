using MoTools.Tiles;
using MoTools.Tiles.Trees;
using MoTools.Walls;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Projectiles
{
	public class The404Solution : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Spray");
		}

		public override void SetDefaults() {
			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
		}

		public override void AI() {
			//Set the dust type to The404Solution
			int dustType = DustType<Dusts.The404Solution>();

			if (projectile.owner == Main.myPlayer)
				Convert((int)(projectile.position.X + projectile.width / 2) / 16, (int)(projectile.position.Y + projectile.height / 2) / 16, 2);

			if (projectile.timeLeft > 133)
				projectile.timeLeft = 133;

			if (projectile.ai[0] > 7f) {
				float dustScale = 1f;

				if (projectile.ai[0] == 8f)
					dustScale = 0.2f;
				else if (projectile.ai[0] == 9f)
					dustScale = 0.4f;
				else if (projectile.ai[0] == 10f)
					dustScale = 0.6f;
				else if (projectile.ai[0] == 11f)
					dustScale = 0.8f;

				projectile.ai[0] += 1f;

				for (int i = 0; i < 1; i++) {
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1.75f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
					dust.scale *= dustScale;
				}
			}
			else
				projectile.ai[0] += 1f;

			projectile.rotation += 0.3f * projectile.direction;
		}

		public void Convert(int i, int j, int size = 4) {
			for (int k = i - size; k <= i + size; k++) {
				for (int l = j - size; l <= j + size; l++) {
					if (WorldGen.InWorld(k, l, 1) && Math.Abs(k - i) + Math.Abs(l - j) < Math.Sqrt(size * size + size * size)) {
						int type = Main.tile[k, l].type;
						int wall = Main.tile[k, l].wall;

						//Convert all walls to The404Wall
						if (wall != 0) {
							Main.tile[k, l].wall = (ushort)WallType<The404Wall>();
							WorldGen.SquareWallFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}

						//If the tile is stone, convert to The404Block
						if (TileID.Sets.Conversion.Stone[type]) {
							Main.tile[k, l].type = (ushort)TileType<The404Block>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is sand, convert to The404Sand
						else if (TileID.Sets.Conversion.Sand[type]) {
							Main.tile[k, l].type = (ushort)TileType<The404Sand>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is hardened sand, convert to The404HardenedSand
						else if (TileID.Sets.Conversion.HardenedSand[type])
						{
							Main.tile[k, l].type = (ushort)TileType<The404HardenedSand>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is ice, convert to The404Ice
						else if (TileID.Sets.Conversion.Ice[type])
						{
							Main.tile[k, l].type = (ushort)TileType<The404Ice>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is snow, convert to The404Snow
						else if (type == TileID.SnowBlock)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Snow>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is sandstone, convert to The404Sandstone
						else if (TileID.Sets.Conversion.Sandstone[type])
						{
							Main.tile[k, l].type = (ushort)TileType<The404Sandstone>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is dirt, convert to The404Dirt
						else if (TileID.Sets.Conversion.Grass[type] || type == TileID.Dirt)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Dirt>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is clay, convert to The404Clay
						else if (type == TileID.ClayBlock)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Clay>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is mud, convert to The404Mud
						else if (type == TileID.Mud)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Mud>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a chair, convert to The404Chair
						else if (type == TileID.Chairs && Main.tile[k, l - 1].type == TileID.Chairs) {
							Main.tile[k, l].type = (ushort)TileType<The404Chair>();
							Main.tile[k, l - 1].type = (ushort)TileType<The404Chair>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a workbench, convert to The404Workbench
						else if (type == TileID.WorkBenches && Main.tile[k - 1, l].type == TileID.WorkBenches) {
							Main.tile[k, l].type = (ushort)TileType<The404Workbench>();
							Main.tile[k - 1, l].type = (ushort)TileType<The404Workbench>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a chest, convert to The404Chest
						else if (type == TileID.Containers && Main.tile[k - 1, l].type == TileID.Containers && Main.tile[k, l - 1].type == TileID.Containers && Main.tile[k - 1, l - 1].type == TileID.Containers)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Chest>();
							Main.tile[k - 1, l].type = (ushort)TileType<The404Chest>();
							Main.tile[k, l - 1].type = (ushort)TileType<The404Chest>();
							Main.tile[k - 1, l - 1].type = (ushort)TileType<The404Chest>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a platform, convert to The404Platform
						else if (type == TileID.Platforms)
						{
							Main.tile[k, l].type = (ushort)TileType<The404Platform>();
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a platform, convert to The404Platform
						else if (type == TileID.Trees)
						{
							Tile tile = Framing.GetTileSafely(i, j); // Safely get the tile at the given coordinates
							if (tile.frameX < 54)
								WorldGen.GrowTree(i, j);
							else
								WorldGen.GrowPalmTree(i, j);
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
						//If the tile is a platform, convert to The404Platform
						else if (type == TileID.PalmTree)
						{
							Tile tile = Framing.GetTileSafely(i, j); // Safely get the tile at the given coordinates
							if (tile.frameX < 54)
								WorldGen.GrowTree(i, j);
							else
								WorldGen.GrowPalmTree(i, j);
							WorldGen.SquareTileFrame(k, l, true);
							NetMessage.SendTileSquare(-1, k, l, 1);
						}
					}
				}
			}
		}
	}
}
