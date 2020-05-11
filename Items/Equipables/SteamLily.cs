using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoTools.Items.Equipables
{
    public class SteamLily : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steam Lily");
            //Tooltip.SetDefault("Immunity to Lava, Burning, and 'On Fire!'\n+10% Damage and +5 Defense in the Obsidium and Underworld");
            Tooltip.SetDefault("Immunity to Lava, Burning, and 'On Fire!'\n+10% Damage and +5 Defense in the Underworld");
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
            MoToolsPlayer modPlayer = player.GetModPlayer<MoToolsPlayer>();
            if(player.ZoneUnderworldHeight/* || modPlayer.zoneObsidium*/)
            {
                modPlayer.DamageBoost(.1f);
                player.statDefense += 5;
            }
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}