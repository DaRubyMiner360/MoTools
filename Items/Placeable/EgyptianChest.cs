using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class EgyptianChest : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("This is the chest the egyptians used to store their treasures in.");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = TileType<Tiles.EgyptianChest>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Chest);
			recipe.AddIngredient(ItemID.Sandstone, 21);
			recipe.AddTile(TileType<Tiles.ExtremeForge>());
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}