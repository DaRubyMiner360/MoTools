using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class EgyptianChair : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The chair of the egyptians, not to be confused with the Pharaoh's Throne.");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.EgyptianChair>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenChair);
			recipe.AddIngredient(ItemID.Sandstone, 21);
			recipe.AddTile(TileType<Tiles.ExtremeForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}