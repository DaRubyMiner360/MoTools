using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class WallOfFlesh : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Screaming Mouth");
            Tooltip.SetDefault("Critical hits deal 15% increased damage and have 10 armor pen"+"\nPermanent");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.value = 10000;
            item.rare = ItemRarities.Mental;
            item.consumable = true;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.maxStack = 1;

        }
        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<MoToolsPlayer>().wofEquip;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<MoToolsPlayer>().wofEquip = true;
            return true;
        }


    }
}