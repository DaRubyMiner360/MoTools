using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MoTools.NPCs.Enemies;

namespace MoTools.Items.Consumables
{
	public class WhiteCelestialSummon : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("White Celestial");
			Tooltip.SetDefault("The wrath of the white sky");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			//item.value = 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			item.value = Item.buyPrice(gold: 5);
			item.value = Item.sellPrice(gold: 2, silver: 50);
		}

		public override bool CanUseItem(Player player) {
			return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(NPCID.Plantera);
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<WhiteCelestial>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<WhiteCelestial>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<WhiteCelestial>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<WhiteCelestial>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<WhiteCelestial>());
			//NPCID.PirateShip
			//(mod, "WhiteCelestial")
			//NPCType<WhiteCelestial>
			//Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "WhiteCelestialShard", 999);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}