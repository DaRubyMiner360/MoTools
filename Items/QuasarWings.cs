using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class QuasarWings : ModItem
	{

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The wings for the ranged class, made of white celestial shards.");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 210;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WingsVortex, 1);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 60);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}