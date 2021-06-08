using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoTools.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Consumables.Potions
{
	public class UnlimitedHMPotion : ModItem
    {
        public bool used;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unlimited Hard Mode Potions");
            Tooltip.SetDefault("Brings the world to Hard Mode!");
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
			item.consumable = false;
		}


        /*public override bool UseItem(Player player)
        {
            if (Main.hardMode == false && MoToolsWorld.hardMode == false)
            {
                Main.hardMode = true;
                MoToolsWorld.hardMode = true;
                Main.NewText("You are now in Hard Mode", 200, 0, 0);
                return true;
            }
            else
            {
                Main.NewText("You are already in Hard Mode", 200, 0, 0);
                return false;
            }
        }*/

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (Main.hardMode == false && MoToolsWorld.hardMode == false && used == false)
            {
                Main.hardMode = true;
                MoToolsWorld.hardMode = true;
                Main.NewText("You are now in Hard Mode", 200, 0, 0);
                used = true;
            }
            return true;
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