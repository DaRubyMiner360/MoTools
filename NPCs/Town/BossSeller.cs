using System;
using MoTools.Dusts;
using MoTools.Items;
using MoTools.Items.Consumables;
using MoTools.Items.Weapons;
using MoTools.Projectiles.Town;
using MoTools.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.NPCs.Town
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class BossSeller : ModNPC
	{
		public override string Texture => "MoTools/NPCs/Town/BossSeller";

		public override string[] AltTextures => new[] { "MoTools/NPCs/Town/BossSeller_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Boss Market";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Boss Market");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 45;
			npc.defense = 15;
			npc.lifeMax = 2500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Smoke>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == ItemID.CelestialSigil || item.type == ItemID.PortalGun) {
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Bob";
				case 1:
					return "EASTEREGG!";
				case 2:
					return "Bosses! Get your bosses here!";
				default:
					return "Jerry";
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
			}
			switch (Main.rand.Next(4))
			{
				case 0:
					return "Sometimes I feel like I'm different from everyone else here.";
				case 1:
					return "I love fighting bosses!";
				case 2:
					return "My fists are my weapons!";
				default:
					return "What? I don't have any arms or legs? Oh, don't be ridiculous!";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
				button = "Shop";
			{
			}
		}

			public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
				{
					return;
				}
				//shop = true;
			}


		/*public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
			else {*/
			}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemType<MechanicalMonitor>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<PaperEgg>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<WhiteCelestialSummon>());
			 nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<RainbowCelestialSummon>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<DeathlyLookingEye>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<DeathlyMechanicalMonitor>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<DeathlyPaperEgg>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.LihzahrdAltar);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.MechanicalWorm);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.MechanicalSkull);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.MechanicalEye);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Abeemination);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.BloodySpine);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SolarTablet);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TargetDummy);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.CelestialSigil);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
			nextSlot++;
			/*if (Main.moonPhase < 2) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleSword>());
				nextSlot++;
			}
			else if (Main.moonPhase < 4) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleGun>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.ExampleBullet>());
				nextSlot++;
			}
			else if (Main.moonPhase < 6) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleStaff>());
				nextSlot++;
			}
			else {
			}*/
		}

		public override void NPCLoot() {
			//Item.NewItem(npc.getRect(), ItemType<PaperEgg>(), 5);
			Item.NewItem(npc.getRect(), ItemType<The404Essence>(), 1);
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 45;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileType<SparklingBall>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
