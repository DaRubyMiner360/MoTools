using MoTools.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoTools.Items.Placeable
{
    public class LavaGemLantern : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType<LavaGemLanternTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<SteamRock>(), 6);
            //recipe.AddIngredient(ModContent.ItemType<LavaGem>(), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}