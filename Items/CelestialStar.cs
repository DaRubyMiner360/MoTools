using MoTools.Mounts;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class CelestialStar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The star that lets you fly through the sky like you just don't care");
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
			item.mountType = MountType<Celestial>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 50);
			recipe.AddIngredient(ItemType<BlackCelestialShard>(), 50);
			recipe.AddIngredient(ItemType<YellowCelestialShard>(), 50);
			recipe.AddIngredient(ItemType<BlueCelestialShard>(), 50);
			recipe.AddIngredient(ItemType<PurpleCelestialShard>(), 50);
			recipe.AddIngredient(ItemType<RainbowCelestialShard>(), 50);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}