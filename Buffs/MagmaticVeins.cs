using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Buffs
{
	public class MagmaticVeins : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Magmatic Veins");
			Description.SetDefault("Power flows through you!");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MoToolsPlayer>().DamageBoost(.15f);
            player.statDefense += 10;

            player.moveSpeed += 3f;
            player.maxRunSpeed += 3f;
            player.jumpSpeedBoost += 3f;
        }
	}
}
