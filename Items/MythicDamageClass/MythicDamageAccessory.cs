using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.MythicDamageClass
{
	public class MythicDamageAccessory : ModItem
	{
		public override string Texture => "Terraria/Item_" + ItemID.AnglerEarring;

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mythic Power");
			Tooltip.SetDefault("20% increased additive mythic damage" +
							   "\n20% more multiplicative mythic damage" +
							   "\n15% increased mythic critical strike chance" +
							   "\n5 increased increased mythic knockback");
		}

		public override void SetDefaults() {
			item.Size = new Vector2(34);
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			MythicDamagePlayer modPlayer = MythicDamagePlayer.ModPlayer(player);
			modPlayer.mythicDamageAdd += 0.2f; // add 20% to the additive bonus
			modPlayer.mythicDamageMult *= 1.2f; // add 20% to the multiplicative bonus
			modPlayer.mythicCrit += 15; // add 15% crit
			modPlayer.mythicKnockback += 5; // add 5 knockback
		}
	}
}
