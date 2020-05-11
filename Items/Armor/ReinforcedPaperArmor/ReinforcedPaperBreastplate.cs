using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.ReinforcedPaperArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class ReinforcedPaperBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Reinforced Paper Breastplate");
			Tooltip.SetDefault("A breastplate made of reinforced paper!\nWhat could go wrong?\n5% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 8;
		}
		
		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.075f;
			player.allDamage += 0.05f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 120);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
			/*recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Paper>(), 60);
			recipe.AddTile(TileType<PaperWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
}