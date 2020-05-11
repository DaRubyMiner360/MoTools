using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MoTools.NPCs.Critters;

namespace MoTools.Items.Consumables
{
	public class RainbowCelestialSummon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Celestial");
			Tooltip.SetDefault("The wrath of the White, Black, Purple, Yellow, and Blue skies\nThe wrath of the RAINBOW SKIES!");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults()
		{
			//item.useStyle = 1;
			//item.autoReuse = true;
			//item.useTurn = true;
			//item.useAnimation = 15;
			//item.useTime = 10;
			//item.maxStack = 999;
			//item.consumable = true;
			//item.width = 12;
			//item.height = 12;
			//item.makeNPC = 360;
			//item.noUseGraphic = true;
			//item.bait = 15;

			item.maxStack = 20;
			item.rare = 1;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			item.value = Item.buyPrice(gold: 25);
			item.value = Item.sellPrice(gold: 12, silver: 50);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RainbowCelestialNPC>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RainbowCelestialNPC>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RainbowCelestialNPC>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RainbowCelestialNPC>());
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<RainbowCelestialNPC>());
			//NPCID.PirateShip
			//(mod, "WhiteCelestial")
			//NPCType<WhiteCelestial>
			//Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "RainbowCelestialShard", 999);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}