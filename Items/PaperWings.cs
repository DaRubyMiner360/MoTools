using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class PaperWings : ModItem
	{

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The wings for speed!\nMade of PAPER!!");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 40;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 2.0f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 12f;
			acceleration *= 3.25f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 60);
			recipe.AddTile(mod, "PaperWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}