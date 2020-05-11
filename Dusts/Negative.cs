using Terraria;
using Terraria.ModLoader;

namespace MoTools.Dusts
{
	public class Negative : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
		}
	}
}