using Terraria;
using Terraria.ModLoader;

namespace MoTools.Backgrounds
{
	public class The404RealmUgBgStyle : ModUgBgStyle
	{
		public override bool ChooseBgStyle() {
			return Main.LocalPlayer.GetModPlayer<MoToolsPlayer>().ZoneThe404Realm;
		}

		public override void FillTextureArray(int[] textureSlots) {
			textureSlots[0] = mod.GetBackgroundSlot("Backgrounds/The404RealmBiomeUG0");
			textureSlots[1] = mod.GetBackgroundSlot("Backgrounds/The404RealmBiomeUG1");
			textureSlots[2] = mod.GetBackgroundSlot("Backgrounds/The404RealmBiomeUG2");
			textureSlots[3] = mod.GetBackgroundSlot("Backgrounds/The404RealmBiomeUG3");
		}
	}
}