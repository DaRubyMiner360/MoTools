using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class Cultists : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devotion");
            Tooltip.SetDefault("While the pillar event is active grants 1% life steal, ability to dodge and longer invincibilty");
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
            player.GetModPlayer<MoToolsPlayer>().lcEquip = true;
        }


    }
}