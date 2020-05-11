using MoTools.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Buffs
{
	public class Steamy : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Steamy");
			Description.SetDefault("Smokin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		/*public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).Electrified = true;
		}*/

		/*public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().eFied = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.1f;
        }*/
	}
}
