using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class The404Chest : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Chest");
			Tooltip.SetDefault("A chest that is infused with Error 404!");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 500;
			item.createTile = TileType<Tiles.The404Chest>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chest);
			recipe.AddIngredient(ItemType<The404Block>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}