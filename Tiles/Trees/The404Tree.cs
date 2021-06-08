using MoTools.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Tiles.Trees
{
	public class The404Tree : ModTree
	{
		private Mod mod => ModLoader.GetMod("MoTools");

		public override int CreateDust() {
			return DustType<Sparkle>();
		}

		public override int GrowthFXGore() {
			return mod.GetGoreSlot("Gores/The404TreeFX");
		}

		public override int DropWood() {
			return ItemType<Items.Placeable.The404Block>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/Trees/The404Tree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/Trees/The404Tree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/Trees/The404Tree_Branches");
		}
	}
} 