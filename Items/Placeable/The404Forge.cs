using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Placeable
{
	public class The404Forge : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("404 Forge of Destruction");
			Tooltip.SetDefault("The REAL most EXTREME of forges.\nEven more EXTREME than the Extreme Forge.\nMade of 404 Crystals.\nMade of 404 Essence.\nMade with the help of the Moonlord.\nRequires Many types of crafters.\nAll put together to create The 404 Forge of Destruction!");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.The404Forge>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "ExtremeForge", 2);
			recipe.AddIngredient(mod, "The404Essence", 40);
			recipe.AddIngredient(mod, "The404Ore", 40);
			recipe.AddIngredient(ItemID.LunarBrick, 40);
			recipe.AddIngredient(ItemID.LunarOre, 40);
			recipe.AddIngredient(ItemID.LunarBar, 40);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.AddTile(mod, "The404Ore");
			recipe.AddTile(TileID.Hellforge);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.AddTile(TileID.DefendersForge);
			recipe.AddTile(TileID.DemonAltar);
			recipe.AddTile(TileID.LihzahrdAltar);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.AddTile(TileID.Anvils);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}