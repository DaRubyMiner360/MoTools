using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace MoTools.Items.Placeable
{
	public class The404Platform : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Platform");
			Tooltip.SetDefault("A platform that is infused with Error 404!");
		}

		public override void SetDefaults() {
			item.width = 8;
			item.height = 10;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = TileType<Tiles.The404Platform>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<The404Block>());
			recipe.SetResult(this, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddRecipe();
		}
	}
}