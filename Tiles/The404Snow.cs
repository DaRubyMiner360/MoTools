using MoTools.Dusts;
using MoTools.Projectiles;
using MoTools.Tiles.Trees;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Tiles
{
	public class The404Snow : ModTile
	{
		//The404Snow (the item) is just used for placing the tile, this isn't needed and can be placed in other ways

		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileBrick[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(200, 200, 200));
			//Set the dust type to Sparkle
			dustType = ModContent.DustType<Sparkle>();
			//Drop the The404SnowBlock
			drop = ModContent.ItemType<Items.Placeable.The404Snow>();
			SetModTree(new The404Tree());
		}

		public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak) {
			if (WorldGen.noTileActions)
				return true;

			Tile above = Main.tile[i, j - 1];
			Tile below = Main.tile[i, j + 1];
			bool canFall = false;

			if (below == null || below.active())
				canFall = false;

			if (above.active() && (TileID.Sets.BasicChest[above.type] || TileID.Sets.BasicChestFake[above.type] || above.type == TileID.Trees || TileLoader.IsDresser(above.type)))
				canFall = false;

			if (canFall) {
				// Set the projectile type to The404SnowProjectile
				int projectileType = ModContent.ProjectileType<The404SandProjectile>();
				float positionX = i * 16 + 8;
				float positionY = j * 16 + 8;

				if (Main.netMode == NetmodeID.SinglePlayer) {
					Main.tile[i, j].ClearTile();
					int proj = Projectile.NewProjectile(positionX, positionY, 0f, 0.41f, projectileType, 10, 0f, Main.myPlayer);
					Main.projectile[proj].ai[0] = 1f;
					WorldGen.SquareTileFrame(i, j);
				}
				else if (Main.netMode == NetmodeID.Server) {
					Main.tile[i, j].active(false);
					bool spawnProj = true;

					for (int k = 0; k < 1000; k++) {
						Projectile otherProj = Main.projectile[k];

						if (otherProj.active && otherProj.owner == Main.myPlayer && otherProj.type == projectileType && Math.Abs(otherProj.timeLeft - 3600) < 60 && otherProj.Distance(new Vector2(positionX, positionY)) < 4f) {
							spawnProj = false;
							break;
						}
					}

					if (spawnProj) {
						int proj = Projectile.NewProjectile(positionX, positionY, 0f, 2.5f, projectileType, 10, 0f, Main.myPlayer);
						Main.projectile[proj].velocity.Y = 0.5f;
						Main.projectile[proj].position.Y += 2f;
						Main.projectile[proj].netUpdate = true;
					}

					NetMessage.SendTileSquare(-1, i, j, 1);
					WorldGen.SquareTileFrame(i, j);
				}
				return false;
			}
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override int SaplingGrowthType(ref int style) {
			style = 1;
			return ModContent.TileType<The404Sapling>();
		}

		public override void RandomUpdate(int i, int j)
		{
			WorldGeneration.Spread("The 404 Realm", i, j);
		}
	}
}