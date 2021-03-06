﻿using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class Skeletron : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exo-Skeleton");
            Tooltip.SetDefault("Grants immunity to lava and the ability to breathe and swim underwater"+"\nGrants increased defense, damage and movement speed while submerged in lava");
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
            player.GetModPlayer<MoToolsPlayer>().skEquip = true;
        }


    }
}