using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MoTools.Walls
{
	public class SteamBrickWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			dustType = 1;
			AddMapEntry(new Color(11, 22, 33));
            drop = ModContent.ItemType<Items.Placeable.SteamBrickWall>();
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
	}
}