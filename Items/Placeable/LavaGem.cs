using Terraria.ModLoader;
using Terraria;

namespace MoTools.Items.Placeable
{
    public class LavaGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grows on Steam Rock\n'Molten Candy'");
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
            item.createTile = ModContent.TileType<Tiles.LavaGem>();
            item.bait = 20;
        }
    }
}