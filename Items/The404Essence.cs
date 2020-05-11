using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoTools.Items
{
    public class The404Essence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("404 Essence");
            Tooltip.SetDefault("From the world beyond.");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TruffleWorm);
            recipe.AddRecipe();
        }*/
    }
}