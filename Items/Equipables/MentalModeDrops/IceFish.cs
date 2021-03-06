﻿using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class IceFish : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Barrier");
            Tooltip.SetDefault("Taking over 180 damage in one hit will encase you in an ice barrier and heal 100 health");
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
            player.GetModPlayer<MoToolsPlayer>().ifEquip = true;
        }


    }
}