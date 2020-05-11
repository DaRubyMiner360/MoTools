using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.PaperArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PaperLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Paper Leggings");
			Tooltip.SetDefault("A pair of leggings made of reinforced paper!\nWhat could go wrong?\n5% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
			player.allDamage += 0.025f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 45);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}