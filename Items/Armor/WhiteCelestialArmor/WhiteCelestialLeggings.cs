using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.WhiteCelestialArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class WhiteCelestialLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Quasar Leggings");
			Tooltip.SetDefault("The leggings made of White Celestial Shards."
				+ "\n14% increased Ranged Damage"
				+ "\n14% increased Ranged Critical Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 26;
		}

		public override void UpdateEquip(Player player) {
			player.AddBuff(BuffID.Archery, 240, true);
			player.rangedCrit += 14;
			player.rangedDamage = +.14f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 45);
			recipe.AddIngredient(ItemID.VortexLeggings);
			//recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(TileType<ExtremeForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}