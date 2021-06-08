using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class EyeOfCthulu : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("All seeing eye");
            Tooltip.SetDefault("10% increased critical strike chance and greatly increased vision");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 10000;
            item.rare = ItemRarities.Mental;
            item.accessory = true;

        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MoToolsPlayer>().eocEquip = true;
        }


    }
}