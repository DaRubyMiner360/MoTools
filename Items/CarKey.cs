using MoTools.Mounts;
using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class CarKey : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Vroom Vroom");
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
			item.mountType = MountType<Car>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddIngredient(ItemID.IronBar, 30);
			recipe.AddIngredient(mod, "Tire", 4);
			recipe.AddIngredient(mod, "Wheel", 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddIngredient(ItemID.LeadBar, 30);
			recipe.AddIngredient(mod, "Tire", 4);
			recipe.AddIngredient(mod, "Wheel", 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}