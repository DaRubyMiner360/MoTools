using System;
using MoTools.Dusts;
using MoTools.Items;
using MoTools.Items.Weapons;
using MoTools.Tiles;
using MoTools.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class The404Tinkerer : ModNPC
	{
		public override string Texture => "MoTools/NPCs/Town/The404Tinkerer";

		public override string[] AltTextures => new[] { "MoTools/NPCs/Town/The404Tinkerer_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "404 Tinkerer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("404 Tinkerer");
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
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Sparkle>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == ItemType<Items.Placeable.The404Ore>() || item.type == ItemType<Items.The404Essence>()) {
						return true;
					}
				}
			}
			return false;
		}

		// Example Person needs a house built out of MoTools tiles. You can delete this whole method in your townNPC for the regular house conditions.
		/*public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].type;
					if (type == TileType<ExampleBlock>() || type == TileType<ExampleChair>() || type == TileType<ExampleWorkbench>() || type == TileType<ExampleBed>() || type == TileType<ExampleDoorOpen>() || type == TileType<ExampleDoorClosed>()) {
						score++;
					}
					if (Main.tile[x, y].wall == WallType<ExampleWall>()) {
						score++;
					}
				}
			}
			return score >= (right - left) * (bottom - top) / 2;
		}*/

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "Arback";
				case 1:
					return "Dalek";
				case 2:
					return "Darz";
				case 3:
					return "Durnok";
				case 4:
					return "Fahd";
				case 5:
					return "Fjell";
				case 6:
					return "Gnudar";
				case 7:
					return "Grodax";
				case 8:
					return "Knogs";
				case 9:
					return "Knub";
				case 10:
					return "Mobart";
				case 11:
					return "Mrunok";
				case 12:
					return "Negurk";
				case 13:
					return "Nort";
				case 14:
					return "Nuxatk";
				case 15:
					return "Ragz";
				case 16:
					return "Sarx";
				case 17:
					return "Smador";
				case 18:
					return "Stazen";
				case 19:
					return "Stezom";
				case 20:
					return "Tgerd";
				case 21:
					return "Tkanus";
				case 22:
					return "Trogem";
				case 23:
					return "Xanos";
				default:
					return "Xon";
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
			int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
			//int stylist = NPC.FindFirstNPC(NPCID.Stylist);
			if (mechanic >= 0 && Main.rand.NextBool(4))
			{
				return "Hey...what's " + Main.npc[mechanic].GivenName + " up to? Have you...have you talked to her, by chance?";
			}
			/*if (stylist >= 0 && Main.rand.NextBool(4))
			{
				return "I tried to visit " + Main.npc[stylist].GivenName + " one time. She just looked at me and said 'nope.'";
			}*/
			if (Main.dayTime == true)
			{
				switch (Main.rand.Next(4))
				{
					case 0:
						return "Goblins are suprisingly easy to anger. In fact, they could start a war over cloth!";
					case 1:
						return "To be honest, most goblins aren't exactly rocket scientists. Well, some are.";
					case 2:
						return "Do you know why we all carry around these spiked balls? Because I don't.";
					case 3:
						return "I just finished my newest creation! This version doesn't explode violently if you breathe on it too hard.";
					default:
						return "Goblin thieves aren't very good at their job. They can't even steal from an unlocked chest!";
				}
			}
			else
			{
				switch (Main.rand.Next(4))
				{
					case 0:
						return "Hey, does your hat need a motor? I think I have a motor that would fit exactly in that hat.";
					case 1:
						return "Yo, I heard you like rockets and running boots, so I put some rockets in your running boots.";
					case 2:
						return "Silence is golden. Duct tape is silver.";
					case 3:
						return "YES, gold is stronger than iron. What are they teaching these humans nowadays?";
					default:
						return "You know, that mining helmet-flipper combination was a much better idea on paper.";
				}
			}
			/*if (NPC.homeless)
			{
				switch (Main.rand.Next(5))
				{
					case 0:
						return "I can't believe they tied my brother up and left him there just for pointing out that they weren't going east!";
					case 1:
						return "Now that I'm an outcast, can I throw away the spiked balls? My pockets hurt.";
					case 2:
						return "Looking for a gadgets expert? I'm your goblin!";
					case 3:
						return "Thanks for your help. Now, I have to finish pacing around aimlessly here. I'm sure we'll meet again.";
					default:
						return "I thought you'd be taller.";
				}
			}*/
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

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "404 Reforge";
			/*if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);*/
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				/*if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ItemType<Items.Accessories.WaspNest>())}";
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ItemType<Items.Accessories.WaspNest>());
					return;
				}*/
				shop = true;
			}
			else {
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				GetInstance<MoTools>().The404TinkererUserInterface.SetState(new UI.The404TinkererUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemID.RocketBoots);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Ruler);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TinkerersWorkshop);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GrapplingHook);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Toolbelt);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SpikyBall);
			nextSlot++;
			// Here is an example of how your npc can sell items from other mods.
			/*var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			if (modSummonersAssociation != null) {
				shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
				nextSlot++;
			}

			if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().The404TinkererGiftReceived && GetInstance<ExampleConfigServer>().The404TinkererFreeGiftList != null)
			{
				foreach (var item in GetInstance<ExampleConfigServer>().The404TinkererFreeGiftList)
				{
					if (item.IsUnloaded)
						continue;
					shop.item[nextSlot].SetDefaults(item.Type);
					shop.item[nextSlot].shopCustomPrice = 0;
					shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().The404TinkererFreeGift = true;
					nextSlot++;
					// TODO: Have tModLoader handle index issues.
				}
			}*/
		}

		public override void NPCLoot() {
			//Item.NewItem(npc.getRect(), ItemType<Items.Placable.The404Ore>());
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				Dust.NewDustPerfect(npc.Center + position, DustType<Pixel>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.SpikyBall;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
