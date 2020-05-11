using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.WhiteCelestialArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class WhiteCelestialBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Quasar Breastplate");
			Tooltip.SetDefault("The breastplate made of White Celestial Shards."
				+ "\n18% increased Ranged Damage"
				+ "\n18% increased Ranged Critical Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 34;
		}

		public override void UpdateEquip(Player player) {
			player.AddBuff(BuffID.Archery, 240, true);
			player.rangedCrit += 18;
			player.rangedDamage += .18f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 60);
			recipe.AddIngredient(ItemID.VortexBreastplate);
			//recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}