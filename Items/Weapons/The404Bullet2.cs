using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Weapons
{
	public class The404Bullet2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Bullet 2.0");
			Tooltip.SetDefault("The bullet that was infused with Error 404.");
		}

		public override void SetDefaults() {
			item.damage = 25;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.0f;
			item.value = 10;
			item.rare = 2;
			item.shoot = ProjectileType<Projectiles.Ranged.The404Bullet2>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 20f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		/*public override void OnConsumeAmmo(Player player) {
			if (Main.rand.NextBool(5)) {
				player.AddBuff(BuffID.Archery, 300);
			}
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 1);
			recipe.AddIngredient(ItemID.UnholyArrow, 1);
			recipe.AddIngredient(ItemID.JestersArrow, 1);
			recipe.AddIngredient(mod, "The404Essence", 2);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
