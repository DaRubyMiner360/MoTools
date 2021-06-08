using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.MythicDamageClass
{
	public class MythicResourceStaff : MythicDamageItem
	{
		// This is a staff that uses the mythic damage class stuff you've set up before, but uses mythicResource instead of mana.
		// This is a very simple way of doing it, and if you plan on multiple items using mythicResource then I'd suggest making a new abstract ModItem class that inherits MythicDamageItem,
		// and doing the CanUseItem and UseItem in a more generalized way there, so you can just define the resource usage in SetDefaults and it'll do it automatically for you.
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mythic Staff");
			Item.staff[item.type] = true;
		}

		public override void SafeSetDefaults() {
			item.CloneDefaults(ItemID.AmethystStaff);
			item.Size = new Vector2(28, 36);
			item.damage = 32;
			item.knockBack = 3;
			item.rare = ItemRarityID.Red;
			item.mana = 0; // Make sure to nullify the mana usage of the staff here, as it still copies the setdefaults of the amethyst staff.
			item.useStyle = ItemUseStyleID.HoldingOut;

			// mythicResourceCost is a field in the base class MythicDamageItem. This item consumes 10 Mythic Resource to use.
			mythicResourceCost = 10;
		}
	}
}
