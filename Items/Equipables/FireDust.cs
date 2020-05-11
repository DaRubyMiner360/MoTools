using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Equipables
{
    public class FireDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Dust");
            Tooltip.SetDefault("All attacks inflict 'On Fire!'");
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
            modPlayer.Steam = true;
        }
    }
}