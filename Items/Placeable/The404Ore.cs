using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MoTools.Items;

namespace MoTools.Items.Placeable
{
	public class The404Ore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("404 Crystal");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileType<Tiles.The404Ore>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 5);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(mod, "The404Essence");
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 5);
			recipe.AddTile(mod, "The404Forge");
			recipe.SetResult(mod, "The404Essence", 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(ItemID.Hellstone, 2);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 1);
			recipe.AddTile(mod, "The404Forge");
			recipe.SetResult(ItemID.Hellstone, 4);
			recipe.AddRecipe();
		}
	}
}
