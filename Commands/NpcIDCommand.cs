using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using System.IO;

namespace MoTools.Commands
{
	public class NpcIDCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "npcID";

		public override string Usage
			=> "/npcID modName npcName";

		public override string Description
			=> "Find mod NPC IDs";

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableNpcIDCommand)
			{
				if (!GetInstance<ConfigClient>().DisableNpcIDCommand)
				{
					var theMod = ModLoader.GetMod(args[0]);
					var type = theMod?.NPCType(args[1]) ?? 0;
					caller.Reply(type.ToString(), Color.Yellow);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableNpcIDCommand)
				{
					var theMod = ModLoader.GetMod(args[0]);
					var type = theMod?.NPCType(args[1]) ?? 0;
					caller.Reply(type.ToString(), Color.Yellow);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableNpcIDCommand)
				{
					var theMod = ModLoader.GetMod(args[0]);
					var type = theMod?.NPCType(args[1]) ?? 0;
					caller.Reply(type.ToString(), Color.Yellow);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableNpcIDCommand)
				{
					var theMod = ModLoader.GetMod(args[0]);
					var type = theMod?.NPCType(args[1]) ?? 0;
					caller.Reply(type.ToString(), Color.Yellow);
				}
			}
		}
	}
}
