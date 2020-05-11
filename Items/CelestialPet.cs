using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class CelestialPet : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Baby Celestial");
			Tooltip.SetDefault("Summons a Baby Celestial to protect you");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ProjectileType<Projectiles.Pets.CelestialPet>();
			item.buffType = BuffType<Buffs.CelestialPet>();
		}

		public override void AddRecipes()
		{
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

		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
