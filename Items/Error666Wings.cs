using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class Error666Wings : ModItem
	{
		/*public ModHotKey DevSpeed { get; }

		public Error666Wings(Mod mod, string name, string key)
		{
			name = "Dev's Speed";
			key = GetInstance<KeybindsConfig>().DevSpeed;
			DevSpeed = mod.RegisterHotKey(name, key);
		}*/

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Error 666 Wings");
			Tooltip.SetDefault("THE BEST AT IMPERSONATING ALL THE DEVS!!!\nEVEN BETTER AT FLYING!!");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			MoToolsPlayer modPlayer = MoToolsPlayer.Get(player);
			modPlayer.Error666Wings = true;
			player.wingTimeMax = 999999999;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 5f;
			ascentWhenRising = 3f;
			maxCanAscendMultiplier = 3f;
			maxAscentMultiplier = 3f;
			constantAscend = 3f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			//if (MoTools.KeyPressed(this.DevSpeed))
			/*if (DevSpeed.JustPressed)
			{
				speed = 50f;
				acceleration *= 30.0f;
			}
				speed = 10.5f;
				acceleration *= 3.0f;*/
			//speed = 50f;
			//acceleration *= 30.0f;
			if (MoTools.DevSpeedHotKey.Current)
			{
				//Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).speed = 50f;
				//Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).acceleration *= 30.0f;

				acceleration *= 30.0f;
				speed = 50f;
			}
			else
			{
				//Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).speed = 10.5f;
				//Error666Wings.HorizontalWingSpeeds(player, ref speed, ref acceleration).acceleration *= 3.0f;

				acceleration *= 3.0f;
				speed = 10.5f;
			}
		}

		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<RainbowCelestialShard>(), 1998);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}