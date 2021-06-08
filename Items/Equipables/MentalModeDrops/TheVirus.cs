using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MoTools.Rarities;

namespace MoTools.Items.Equipables.MentalModeDrops
{

    public class TheVirus : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viral DNA");
            Tooltip.SetDefault("Permanently increases crit damage by 10%");
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
            return !player.GetModPlayer<MoToolsPlayer>().tvEquip;
        }
        public override bool UseItem(Player player)
        {
            player.GetModPlayer<MoToolsPlayer>().tvEquip = true;
            return true;
        }
       


    }
}