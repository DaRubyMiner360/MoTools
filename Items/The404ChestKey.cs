using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items
{
	class The404ChestKey : ModItem
	{
		public override void SetDefaults() {
			//item.CloneDefaults(ItemID.GoldenKey);
			item.width = 14;
			item.height = 20;
			item.maxStack = 99;
		}
	}
}
