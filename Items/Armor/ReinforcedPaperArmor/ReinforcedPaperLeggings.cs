using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.ReinforcedPaperArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ReinforcedPaperLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Reinforced Paper Leggings");
			Tooltip.SetDefault("A pair of leggings made of reinforced paper!\nWhat could go wrong?\n5% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.075f;
			player.allDamage += 0.05f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 90);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}