using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Tiles.Trees
{
	public class The404PalmTree : ModPalmTree
	{
		public override Texture2D GetTexture() => ModContent.GetTexture("MoTools/Tiles/Trees/The404PalmTree");
		
		public override Texture2D GetTopTextures() => ModContent.GetTexture("MoTools/Tiles/Trees/The404PalmTree_Tops");

		public override int DropWood() => ItemID.SandBlock; // TODO
	}
}