using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoTools.Items.Placeable
{
    public class AncientEnchanter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Combines Stones into Relics");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = ModContent.TileType<Tiles.AncientEnchanter>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "ExtremeForge");
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddIngredient(2766, 8);
            recipe.AddIngredient(1508, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}