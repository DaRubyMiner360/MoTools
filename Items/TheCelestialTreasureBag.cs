using MoTools.NPCs.TheCelestial;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items
{
    public class TheCelestialTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = ItemRarityID.Purple;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }


        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ModContent.ItemType<WhiteCelestialShard>(), Main.rand.Next(7, 14));
            player.QuickSpawnItem(ModContent.ItemType<YellowCelestialShard>(), Main.rand.Next(7, 14));
            player.QuickSpawnItem(ModContent.ItemType<BlackCelestialShard>(), Main.rand.Next(7, 14));
            player.QuickSpawnItem(ModContent.ItemType<BlueCelestialShard>(), Main.rand.Next(7, 14));
            player.QuickSpawnItem(ModContent.ItemType<PurpleCelestialShard>(), Main.rand.Next(7, 14));
            player.QuickSpawnItem(ModContent.ItemType<RainbowCelestialShard>(), Main.rand.Next(7, 14));
            //player.QuickSpawnItem(499, Main.rand.Next(10, 15));
        }

        public override int BossBagNPC => ModContent.NPCType<TheCelestial>();
    }
}