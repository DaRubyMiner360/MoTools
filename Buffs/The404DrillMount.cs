using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace MoTools.Buffs
{
    public class The404DrillMount : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("404 Drill Mount");
            Description.SetDefault("Flying through the sky like you just don't care, and mining along the way!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(MountType<Mounts.The404DrillMount>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}