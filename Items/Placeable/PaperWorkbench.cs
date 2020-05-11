using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class PaperWorkbench : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A paper workbench\nMade of paper\nMade to make paper");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.PaperWorkbench>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemType<Paper>(), 33);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
