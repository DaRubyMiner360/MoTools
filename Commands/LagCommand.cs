using System.Threading;
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
	public class LagCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "lag";

		public override string Usage
			=> "/lag duration (ms)";

		public override string Description
			=> "Pause the main thread for a period of time";

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableLagCommand)
			{
				if (!GetInstance<ConfigClient>().DisableLagCommand)
				{
					Thread.Sleep(int.Parse(args[0]));
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableLagCommand)
				{
					Thread.Sleep(int.Parse(args[0]));
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableLagCommand)
				{
					Thread.Sleep(int.Parse(args[0]));
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableLagCommand)
				{
					Thread.Sleep(int.Parse(args[0]));
				}
			}
		}
	}
}