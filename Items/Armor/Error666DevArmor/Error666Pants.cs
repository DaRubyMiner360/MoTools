using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.Error666DevArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Error666Pants : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Error 666 Breastplate");
			Tooltip.SetDefault("The best at impersonating devs!!");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.vanity = true;
		}

		/*public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
			player.allDamage += 0.025f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 45);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}