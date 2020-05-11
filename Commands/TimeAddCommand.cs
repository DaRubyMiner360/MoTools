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
	public class TimeAddCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "time-add";

		public override string Usage
			=> "/time-add time";

		public override string Description
			=> "Sets the time";

		int time = 0;

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableTimeCommand)
			{
				if (!GetInstance<ConfigClient>().DisableTimeCommand)
				{
					Main.time = Main.time + time;
					//Main.UpdateTime = Main.time + time;
					throw new UsageException(args[0] + " is currently incomplete");
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableTimeCommand)
				{
					Main.time = Main.time + time;
					//Main.UpdateTime = Main.time + time;
					throw new UsageException(args[0] + " is currently incomplete");
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableTimeCommand)
				{
					Main.time = Main.time + time;
					//Main.UpdateTime = Main.time + time;
					throw new UsageException(args[0] + " is currently incomplete");
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableTimeCommand)
				{
					Main.time = Main.time + time;
					//Main.UpdateTime = Main.time + time;
					throw new UsageException(args[0] + " is currently incomplete");
				}
			}
		}
	}
}
