using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Buffs
{
	public class CelestialCarMount : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Celestial Car");
			Description.SetDefault("Leather seats, 4 cup holders, and you can fly through the sky like you just don't care");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(MountType<Mounts.CelestialCar>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
