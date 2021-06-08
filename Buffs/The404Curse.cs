using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Buffs
{
    public class The404Curse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("The 404 Curse");
            Description.SetDefault("The curse of 404 errors!\nUse a 404 Nullifier to cure it.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            //canBeCleared = false;
            canBeCleared = true;
        }

        int style;

        public override void Update(Player player, ref int buffIndex)
        {
            if (Editor.isEditor || GetInstance<ConfigServer>().DisableThe404Curse)
            {
                return;
            }
            else
            {
                Mod joostMod = ModLoader.GetMod("JoostMod");
                Mod calamityMod = ModLoader.GetMod("CalamityMod");
                Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
                Mod spiritMod = ModLoader.GetMod("SpiritMod");
                Mod antiarisMod = ModLoader.GetMod("Antiaris");
                Mod redemptionMod = ModLoader.GetMod("Redemption");

                player.statDefense -= 15;
                if (player.statDefense < 0)
                {
                    player.statDefense = 0;
                }
                player.statMana -= 15;
                if (player.statMana < 0)
                {
                    player.statMana = 0;
                }
                player.moveSpeed = 0;
                player.poisoned = true;
                player.onFire = true;
                player.dazed = true;
                player.lifeRegen = 0;
                player.lifeRegenTime = 0;
                player.lifeRegen -= 20;
                /*if(player.GetModPlayer<MoToolsPlayer>().had404Curse1 == false)
                {
                    player.GetModPlayer<MoToolsPlayer>().had404Curse1 = true;
                }
                else if (player.GetModPlayer<MoToolsPlayer>().had404Curse1 == true)
                {
                    player.GetModPlayer<MoToolsPlayer>().had404Curse2 = true;
                }
                else if (player.GetModPlayer<MoToolsPlayer>().had404Curse2 == true)
                {
                    player.GetModPlayer<MoToolsPlayer>().had404Curse3 = true;
                }
                else if (player.GetModPlayer<MoToolsPlayer>().had404Curse3 == true)
                {
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;
                }*/
                /*if(player.GetModPlayer<MoToolsPlayer>().had404Curse == true)
                {
                    this.SetDefaults.canBeCleared = true;
                }*/

                if (joostMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(joostMod.BuffType("InfectedBlue"), 240, true);
                    player.AddBuff(joostMod.BuffType("InfectedGreen"), 240, true);
                    player.AddBuff(joostMod.BuffType("InfectedRed"), 240, true);
                    player.AddBuff(joostMod.BuffType("InfectedYellow"), 240, true);
                }
                if (calamityMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(calamityMod.BuffType("AbyssalFlames"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedGreen"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedRed"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedYellow"), 240, true);
                }
                if (thoriumMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(thoriumMod.BuffType("PoisonHeart"), 240, true);
                    player.AddBuff(thoriumMod.BuffType("Destabilized"), 240, true);
                    player.AddBuff(thoriumMod.BuffType("Gouge"), 240, true);
                    player.AddBuff(thoriumMod.BuffType("Wither"), 240, true);
                }
                if (spiritMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(spiritMod.BuffType("Wither"), 240, true);
                    player.AddBuff(spiritMod.BuffType("StarDestiny"), 240, true);
                    player.AddBuff(spiritMod.BuffType("Toxify"), 240, true);
                }
                if (antiarisMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(antiarisMod.BuffType("CursedBlocks"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedGreen"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedRed"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedYellow"), 240, true);
                }
                if (redemptionMod != null)
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    //player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    //player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    //player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;

                    player.AddBuff(redemptionMod.BuffType("BurntHands"), 240, true);
                    player.AddBuff(joostMod.BuffType("HeadacheDebuff"), 240, true);
                    player.AddBuff(joostMod.BuffType("NauseaDebuff"), 240, true);
                    //player.AddBuff(joostMod.BuffType("InfectedYellow"), 240, true);
                }
                else
                {
                    //player.AddBuff(BuffID.Slow, 240, true);
                    //player.AddBuff(BuffID.Poisoned, 240, true);
                    player.AddBuff(BuffID.PotionSickness, 240, true);
                    //player.AddBuff(BuffID.Darkness, 240, true);
                    //player.AddBuff(BuffID.Cursed, 240, true);
                    //player.AddBuff(BuffID.OnFire, 240, true);
                    //player.AddBuff(BuffID.Bleeding, 240, true);
                    //player.AddBuff(BuffID.Confused, 240, true);
                    //player.AddBuff(BuffID.Weak, 240, true);
                    //player.AddBuff(BuffID.Silenced, 240, true);
                    //player.AddBuff(BuffID.BrokenArmor, 240, true);
                    //player.AddBuff(BuffID.Horrified, 240, true);
                    player.AddBuff(BuffID.CursedInferno, 240, true);
                    player.AddBuff(BuffID.Frostburn, 240, true);
                    //player.AddBuff(BuffID.Chilled, 240, true);
                    //player.AddBuff(BuffID.Frozen, 240, true);
                    //player.AddBuff(BuffID.Panic, 240, true);
                    //player.AddBuff(BuffID.Burning, 240, true);
                    //player.AddBuff(BuffID.Suffocation, 240, true);
                    //player.AddBuff(BuffID.Venom, 240, true);
                    // player.AddBuff(BuffID.Blackout, 240, true);
                    player.AddBuff(BuffID.ChaosState, 240, true);
                    player.AddBuff(BuffID.ManaSickness, 240, true);
                    player.AddBuff(BuffID.Electrified, 240, true);
                    //player.AddBuff(BuffID.Rabies, 240, true);
                    //player.AddBuff(BuffID.Webbed, 240, true);
                    player.AddBuff(BuffID.Bewitched, 240, true);
                    player.AddBuff(BuffID.SoulDrain, 240, true);
                    //player.AddBuff(BuffID.Dazed, 240, true);
                    //player.AddBuff(BuffID.VortexDebuff, 240, true);
                    //player.AddBuff(BuffID.DryadsWardDebuff, 240, true);
                    player.AddBuff(BuffID.NoBuilding, 240, true);
                    player.AddBuff(BuffID.BetsysCurse, 240, true);
                    player.AddBuff(BuffID.BallistaPanic, 240, true);
                    //player.AddBuff(BuffID.Stoned, 240, true);
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;
                    player.AddBuff(ModContent.BuffType<The404Curse>(), 240);
                    player.GetModPlayer<MoToolsPlayer>().had404Curse = true;
                }
            }
        }
    }
}
