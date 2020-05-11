using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items
{
	public class The404Bait : ModItem
	{
		public override void SetDefaults()
		{


			item.value = 1000;
			item.rare = 2;
			item.width = 30;
			item.height = 30;
			item.maxStack = 999;
			item.bait = 1000000000;
			item.consumable = true;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("404 Bait");
      Tooltip.SetDefault("A possesed bait that attracts spirits from the deep waters");
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MasterBait, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 1);
			recipe.AddIngredient(mod, "The404Essence", 5);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

	}
}
