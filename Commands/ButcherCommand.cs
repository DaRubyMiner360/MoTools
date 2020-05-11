using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
//using MoTools.NPCs.Friendly;

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
	public class ButcherCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "butcher";

		public override string Usage
			//=> "/butcher type";
			=> "/butcher power";

		public override string Description
			=> "Damages all npcs other than town npcs";

		int power;

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableButcherCommand)
			{
				if (!GetInstance<ConfigClient>().DisableButcherCommand)
				{
					if (!int.TryParse(args[0], out int power))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					if (power > 5000)
					{
						throw new UsageException(args[0] + " is too large(maximum of 5000)");
					}

					if (power == 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						power = 0;
					}

					while (power > 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						//int newpower = power - 1;
						//power = newpower;
						power = power - 1;
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableButcherCommand)
				{
					if (!int.TryParse(args[0], out int power))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					if (power > 5000)
					{
						throw new UsageException(args[0] + " is too large(maximum of 5000)");
					}

					if (power == 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						power = 0;
					}

					while (power > 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						//int newpower = power - 1;
						//power = newpower;
						power = power - 1;
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableButcherCommand)
				{
					if (!int.TryParse(args[0], out int power))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					if (power > 5000)
					{
						throw new UsageException(args[0] + " is too large(maximum of 5000)");
					}

					if (power == 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						power = 0;
					}

					while (power > 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						//int newpower = power - 1;
						//power = newpower;
						power = power - 1;
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableButcherCommand)
				{
					if (!int.TryParse(args[0], out int power))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					if (power > 5000)
					{
						throw new UsageException(args[0] + " is too large(maximum of 5000)");
					}

					if (power == 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						power = 0;
					}

					while (power > 1)
					{
						throw new UsageException(args[0] + " is currently incomplete");
						//int slot = NPC.NewNPC(ButcherCommandProjectile);
						//int newpower = power - 1;
						//power = newpower;
						power = power - 1;
					}
				}
			}
		}
	}
}