using Terraria.ModLoader;
using Terraria.ID;

namespace MoTools.Items.Placeable
{
	public class The404Snow : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("This is a modded snow block.");
			DisplayName.SetDefault("404 Snow");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.The404Snow>();
			//item.ammo = AmmoID.Sand; Using this Sand in the Sandgun would require PickAmmo code and changes to The404SandProjectile or a new ModProjectile.
		}

		public override void AddRecipes() {
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleItem>());
			recipe.SetResult(this, 10);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleWall>(), 4);
			recipe.AddTile(ModContent.TileType<Tiles.ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExamplePlatform>(), 2);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
}