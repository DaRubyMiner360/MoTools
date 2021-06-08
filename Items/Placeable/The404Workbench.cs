using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class The404Workbench : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Workbench");
			Tooltip.SetDefault("A workbench that is infused with Error 404!");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.The404Workbench>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(ItemType<The404Block>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}