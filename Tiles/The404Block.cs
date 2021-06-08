using MoTools.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Tiles
{
	public class The404Block : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			dustType = DustType<Sparkle>();
			drop = ItemType<Items.Placeable.The404Block>();
			AddMapEntry(new Color(200, 200, 200));
			SetModTree(new Trees.The404Tree());
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

		/*public override void ChangeWaterfallStyle(ref int style) {
			style = mod.GetWaterfallStyleSlot("ExampleWaterfallStyle");
		}*/

		public override int SaplingGrowthType(ref int style) {
			style = 0;
			return TileType<The404Sapling>();
		}

		public override void RandomUpdate(int i, int j)
		{
			WorldGeneration.Spread("The 404 Realm", i, j);
		}
	}
}