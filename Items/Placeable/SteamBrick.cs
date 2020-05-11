using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MoTools.Items.Placeable
{
    public class SteamBrick : ModItem
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
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 0;
            item.createTile = ModContent.TileType<Tiles.SteamBrick>();
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(mod, "ExtremeForge");
            recipe.AddIngredient(null, "SteamRock", 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
    }
}