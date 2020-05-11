﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Equipables
{
    public class Ragnashia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ragnashia");
            Tooltip.SetDefault("+5% Crit Chance\nSet nearby enemies ablaze");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 0 + 0 * 100 + 5 * 10000;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
            item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MoToolsPlayer>().CritBoost(5);
            player.GetModPlayer<MoToolsPlayer>().Blaze = true;
        }
    }
}