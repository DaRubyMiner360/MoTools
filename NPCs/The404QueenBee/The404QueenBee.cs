using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using MoTools.Items.Banners;

namespace MoTools.NPCs.The404QueenBee
{
	[AutoloadBossHead]
	public class The404QueenBee : ModNPC
	{
		public static Random rnd = new Random();

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("404 Infused Queen Bee");
			Main.npcFrameCount[npc.type] = 12;
		}

		public override void SetDefaults()
		{
			npc.width = 400;
			npc.height = 480;
			//npc.aiStyle = 67;
			npc.defense = 14;
			if (Main.expertMode == true)
			{
				npc.lifeMax = 95200;
				npc.damage = 108;
			}
            else
            {
				npc.lifeMax = 68000;
				npc.damage = 60;
			}
			//npc.HitSound = SoundID.NPCHit1;
			//npc.DeathSound = SoundID.NPCDeath1;
			//npc.npcSlots = 0.5f;
			//npc.noGravity = true;
			//npc.catchItem = 2007;

			npc.CloneDefaults(NPCID.QueenBee);
			//npc.aiStyle = 0;
			aiType = NPCID.QueenBee;
			animationType = NPCID.QueenBee;
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType("The404Essence"), 1);

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}

			/*NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.KingSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.KingSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.KingSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.Pinky);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.GreenSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlueSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.YellowSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.RedSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.PurpleSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlackSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BabySlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MotherSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.Pinky);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.GreenSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlueSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.YellowSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.RedSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.PurpleSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlackSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BabySlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MotherSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.Pinky);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.GreenSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlueSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.YellowSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.RedSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.PurpleSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BlackSlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.BabySlime);
			NPC.NewNPC((int)npc.position.X + rnd.Next(0, npc.width), (int)npc.position.Y + rnd.Next(0, npc.height), NPCID.MotherSlime);*/

			/*if (!MoToolsWorld.downedThe404KingSlime && npc.type == ModContent.NPCType<The404KingSlime>())
			{
				Main.NewText("I told you the crown of slime had been lost in the battle, and the slimes were growing restless", 0, 0, 200);
			}*/

			MoToolsWorld.downedThe404QueenBee = true;
		}
	}
}