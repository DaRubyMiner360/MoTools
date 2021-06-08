using MoTools;
using MoTools.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Consumables
{
	public class Mental : ModItem
    {
        int a = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mental");
            Tooltip.SetDefault("Brings the world to Mental Mode!");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 30;
			item.rare = ItemRarityID.Purple;
            item.useAnimation = 15;
            item.useTime = 100;
            item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}
        
        public override bool UseItem(Player player)
        {
            if (Main.expertMode)
            {
                if (a == 14)
                    a = 0;
                a++;
                if (a == 1)
                {
                    if (!MoToolsWorld.MentalMode)
                    {
                        MoToolsWorld.MentalMode = true;
                        Main.NewText("Mental Mode Has Been Enabled!", 200, 0, 0);
                        //return true;
                    }
                    else
                    {
                        MoToolsWorld.MentalMode = false;
                        Main.NewText("Mental Mode Has Been Disabled!", 200, 0, 0);
                        //return true;
                    }
                }
            }
            return false;
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