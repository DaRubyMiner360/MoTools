using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace MoTools.Buffs
{
    public class CelestialMount : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Celestial");
            Description.SetDefault("Flying through the sky like you just don't care");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(MountType<Mounts.Celestial>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}