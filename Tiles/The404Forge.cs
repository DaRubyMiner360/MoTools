using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Tiles
{
	public class The404Forge : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 18 };
			TileObjectData.addTile(Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("404 Forge of Destruction");
			AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[] { TileID.WorkBenches, TileType<Tiles.ExtremeForge>(), TileID.Furnaces, TileID.Hellforge, TileID.Anvils, TileID.MythrilAnvil, TileID.AdamantiteForge, TileID.DefendersForge, TileID.DemonAltar, TileID.LihzahrdAltar, TileID.TinkerersWorkbench, TileID.HeavyWorkBench };
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 16, ItemType<Items.Placeable.The404Forge>());
		}
	}
}