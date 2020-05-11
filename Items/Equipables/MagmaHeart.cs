using MoTools.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Equipables
{
    public class MagmaHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Heart");
            Tooltip.SetDefault("+15% Damage, +10 Defense, and Increased Mobility for a time after being submerged in Lava");
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
            if(player.lavaWet)
                player.AddBuff(ModContent.BuffType<MagmaticVeins>(), 60 * 15);
        }
    }
}