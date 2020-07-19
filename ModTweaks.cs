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
            else if (npc.type == ModContent.NPCType<NPCs.The404KingSlime.The404KingSlime>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().The404KingSlimeHP;
                npc.life = GetInstance<TweaksConfig>().The404KingSlimeHP;
            }
            else if (npc.type == ModContent.NPCType<NPCs.The404EoC.The404EoC>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().The404EoCHP;
                npc.life = GetInstance<TweaksConfig>().The404EoCHP;
            }
            else if (npc.type == ModContent.NPCType<NPCs.The404BoC.The404BoC>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().The404BoCHP;
                npc.life = GetInstance<TweaksConfig>().The404BoCHP;
            }
            else if (npc.type == ModContent.NPCType<NPCs.The404QueenBee.The404QueenBee>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().The404QueenBeeHP;
                npc.life = GetInstance<TweaksConfig>().The404QueenBeeHP;
            }
            else if (npc.type == ModContent.NPCType<NPCs.TheCelestial.TheCelestial>())
            {
                npc.lifeMax = GetInstance<TweaksConfig>().TheCelestialHP;
                npc.life = GetInstance<TweaksConfig>().TheCelestialHP;
            }
        }
    }
}