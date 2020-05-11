using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class RainbowWings : ModItem
	{

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The wings for every class, made of RAINBOW CELESTIAL SHARDS!");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 500;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.30f;
			maxCanAscendMultiplier = 1.5f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.270f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 10.5f;
			acceleration *= 3.0f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<RainbowCelestialShard>(), 1998);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}