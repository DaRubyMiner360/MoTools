using MoTools.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Armor.WhiteCelestialArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class WhiteCelestialHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Quasar Helmet");
			Tooltip.SetDefault("The Helmet made of White Celestial Shards."
				+ "\n22% increased Ranged Damage"
				+ "\n22% increased Ranged Critical Chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player) {
			player.AddBuff(BuffID.Archery, 240, true);
			player.rangedCrit += 22;
			player.rangedDamage += .22f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<WhiteCelestialBreastplate>() && legs.type == ItemType<WhiteCelestialLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "trollface.jpg";
			player.AddBuff(BuffID.Archery, 240, true);
			player.rangedCrit += 35;
			player.rangedDamage = .75f;
			/* All class bonuses
			player.allDamage -= 0.2f;
			*/
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 30);
			recipe.AddIngredient(ItemID.VortexHelmet);
			//recipe.AddIngredient(ItemID.DirtBlock);
			recipe.AddTile(TileType<ExtremeForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}