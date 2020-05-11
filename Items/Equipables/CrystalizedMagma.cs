using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Equipables
{
    public class CrystalizedMagma : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystallized Magma");
            Tooltip.SetDefault("Leave a trail of fire as you run");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MoToolsPlayer modPlayer = MoToolsPlayer.Get(player);
            modPlayer.FireTrail = true;
        }
    }
}