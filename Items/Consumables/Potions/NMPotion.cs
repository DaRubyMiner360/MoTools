using MoTools.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Consumables.Potions
{
	public class NMPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Normal Mode Potion");
            Tooltip.SetDefault("Brings the world to Normal Mode!");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}
        

        public override bool UseItem(Player player)
        {
            if (Main.expertMode == true)
            {
                Main.expertMode = false;
                Main.NewText("You are now in Normal Mode", 200, 0, 0);
                return true;
            }
            else
            {
                Main.NewText("You are already in Normal Mode", 200, 0, 0);
                return false;
            }
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            //recipe.AddIngredient(null, "The404Ore", 1);
            recipe.AddIngredient(null, "The404Essence", 500);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            //recipe.AddIngredient(null, "The404Ore", 1);
            recipe.AddIngredient(null, "The404Essence", 500);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.FragmentVortex, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            //recipe.AddIngredient(null, "The404Ore", 1);
            recipe.AddIngredient(null, "The404Essence", 500);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.FragmentNebula, 5);
            recipe.AddIngredient(ItemID.FragmentSolar, 5);
            recipe.AddIngredient(ItemID.FragmentStardust, 5);
            //recipe.AddIngredient(null, "The404Ore", 1);
            recipe.AddIngredient(null, "The404Essence", 500);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}