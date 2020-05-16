using MoTools.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.Error666DevArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class Error666Helm : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Error 666 Helmet");
			Tooltip.SetDefault("The best at impersonating devs!!");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.vanity = true;
		}
		
		/*public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
			player.allDamage += 0.025f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<PaperBreastplate>() && legs.type == ItemType<PaperLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Reinforced Paper!";
			//player.meleeDamage += 0.3f;
			player.allDamage += 0.2f;
			player.moveSpeed += 0.10f;
			// Here are the individual weapon class bonuses.
			//player.meleeDamage -= 0.2f;
			//player.thrownDamage -= 0.2f;
			//player.rangedDamage -= 0.2f;
			//player.magicDamage -= 0.2f;
			//player.minionDamage -= 0.2f;
			
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 30);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}