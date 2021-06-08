using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class Golem : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Protective rock");
            Tooltip.SetDefault("Increases armor pen by 15 and lifesteal by 0.05% " + "\nGrants the shiny stone ability");
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
            player.GetModPlayer<MoToolsPlayer>().gmEquip = true;
        }


    }
}