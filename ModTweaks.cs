using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace MoTools
{
    public class ModTweaks : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == ModContent.NPCType<NPCs.PaperCut.PaperCut>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().PaperCutHP;
                npc.life = GetInstance<TweaksConfig>().PaperCutHP;
            }
            else if (npc.type == ModContent.NPCType<NPCs.TheAnnihilator.TheAnnihilator>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().TheAnnihilatorHP;
                npc.life = GetInstance<TweaksConfig>().TheAnnihilatorHP;
            }
        }
    }
}