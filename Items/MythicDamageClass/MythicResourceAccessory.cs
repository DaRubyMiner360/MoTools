using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.MythicDamageClass
{
	public class MythicResourceAccessory : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\nDrastically increased mythic resource regen rate");
		}

		public override void SetDefaults() {
			item.Size = new Vector2(22);
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			var modPlayer = MythicDamagePlayer.ModPlayer(player);
			modPlayer.mythicResourceMax2 += 50; // add 50 to the mythicResourceMax2, which is our max for mythic resource.
			modPlayer.mythicResourceRegenRate -= 0.5f; // subtract 0.5f from the resourceRegenRate, halving the speed it takes for it to regen once.
		}
	}
}
