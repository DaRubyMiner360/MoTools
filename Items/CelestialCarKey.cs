using MoTools.Mounts;
using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class CelestialCarKey : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Vroom Vroom, and fly through the sky like you just don't care");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 30000;
			item.rare = 2;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = MountType<CelestialCar>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 10);
			recipe.AddIngredient(ItemType<CarKey>(), 1);
			recipe.AddIngredient(ItemType<CelestialStar>(), 1);
			recipe.AddTile(TileType<ExtremeForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}