using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace MoTools.Items.Placeable
{
	public class The404Wall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Wall");
			Tooltip.SetDefault("A wall that is infused with Error 404!");
		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 7;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createWall = WallType<Walls.The404Wall>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<The404Block>());
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}