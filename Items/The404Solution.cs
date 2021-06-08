using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
	public class The404Solution : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Solution");
			Tooltip.SetDefault("Used by the Clentaminator"
				+ "\nSpreads The 404 Realm");
		}

		public override void SetDefaults() {
			item.shoot = ProjectileType<Projectiles.The404Solution>() - ProjectileID.PureSpray;
			item.ammo = AmmoID.Solution;
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 0, 25, 0);
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<The404Essence>(), 10);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
