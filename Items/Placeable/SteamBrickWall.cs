using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MoTools.Items.Placeable
{
    public class SteamBrickWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Grows Lava Gems over time");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 5;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createWall = mod.WallType("SteamBrickWall");
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(18);
            recipe.AddIngredient(null, "SteamBrick");
            recipe.SetResult(this, 4);
            recipe.AddRecipe();
        }
        
    }
}