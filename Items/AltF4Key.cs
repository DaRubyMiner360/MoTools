using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items
{
	public class AltF4Key : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alt F4 Key");
			Tooltip.SetDefault("'Didn't know it had it's own button but ok'\nInstantly freezes your game\nWARNING: This item will actually cause your game to completely stop running.");
		}
		
		public override void SetDefaults()
		{
			item.value = 100;
			item.rare = 10;
			item.useAnimation = 12;
			item.useTime = 12;
			item.useStyle = 4;
			item.UseSound = SoundID.Item4;
		}
		
		public override bool UseItem(Player player)
		{
			while (true) {}
			return true;
		}
	}
}