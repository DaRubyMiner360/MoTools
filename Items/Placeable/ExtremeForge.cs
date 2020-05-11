using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class ExtremeForge : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The most EXTREME of forges.");
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
			item.createTile = TileType<Tiles.ExtremeForge>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench, 1);
			recipe.AddIngredient(ItemID.Hellforge, 1);
			recipe.AddIngredient(ItemID.HellstoneBrick, 20);
			recipe.AddIngredient(ItemID.Hellstone, 20);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}