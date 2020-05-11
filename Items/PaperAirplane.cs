using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class PaperAirplane : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Paper Airplane");
			Tooltip.SetDefault("Summons a Paper Airplane to follow aimlessly behind you");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.PaperAirplane>();
			item.buffType = BuffType<Buffs.PaperAirplane>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 10);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
