using MoTools.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Consumables.Potions
{
	public class The404CursePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("404 Curse Potion");
            Tooltip.SetDefault("Gives the 404 Curse!\nWARNING!\nHIGHLY UNSTABLE!");
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
            if (player.GetModPlayer<MoToolsPlayer>().immuneTo404Curse == false)
            {
                player.GetModPlayer<MoToolsPlayer>().had404Curse = true;
                Main.NewText("You have had the 404 Curse", 200, 0, 0);
                player.AddBuff(ModContent.BuffType<The404Curse>(), 5 * 60 * 60, true);
            }
            else
            {
                Main.NewText("You are immune to the 404 Curse", 200, 0, 0);
            }
            return true;
        }

        public override void AddRecipes()
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
        }
    }
}