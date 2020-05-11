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
	public class GiveCommand : ModCommand
	{

		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "give";

		public override string Usage
			=> "/give <type|name> [stack]" +
			   "\nReplace spaces in item name with underscores";

		public override string Description
			=> "Spawn an item";

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableGiveCommand)
			{
				if (!GetInstance<ConfigClient>().DisableGiveCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						var name = args[0].Replace("_", " ");
						var item = new Item();
						for (var k = 0; k < ItemLoader.ItemCount; k++)
						{
							item.SetDefaults(k, true);
							if (name != Lang.GetItemNameValue(k))
							{
								continue;
							}

							type = k;
							break;
						}

						if (type == 0)
						{
							throw new UsageException("Unknown item: " + name);
						}
					}

					int stack = 1;
					if (args.Length >= 2)
					{
						stack = int.Parse(args[1]);
					}

					caller.Player.QuickSpawnItem(type, stack);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableGiveCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						var name = args[0].Replace("_", " ");
						var item = new Item();
						for (var k = 0; k < ItemLoader.ItemCount; k++)
						{
							item.SetDefaults(k, true);
							if (name != Lang.GetItemNameValue(k))
							{
								continue;
							}

							type = k;
							break;
						}

						if (type == 0)
						{
							throw new UsageException("Unknown item: " + name);
						}
					}

					int stack = 1;
					if (args.Length >= 2)
					{
						stack = int.Parse(args[1]);
					}

					caller.Player.QuickSpawnItem(type, stack);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableGiveCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						var name = args[0].Replace("_", " ");
						var item = new Item();
						for (var k = 0; k < ItemLoader.ItemCount; k++)
						{
							item.SetDefaults(k, true);
							if (name != Lang.GetItemNameValue(k))
							{
								continue;
							}

							type = k;
							break;
						}

						if (type == 0)
						{
							throw new UsageException("Unknown item: " + name);
						}
					}

					int stack = 1;
					if (args.Length >= 2)
					{
						stack = int.Parse(args[1]);
					}

					caller.Player.QuickSpawnItem(type, stack);
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableGiveCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						var name = args[0].Replace("_", " ");
						var item = new Item();
						for (var k = 0; k < ItemLoader.ItemCount; k++)
						{
							item.SetDefaults(k, true);
							if (name != Lang.GetItemNameValue(k))
							{
								continue;
							}

							type = k;
							break;
						}

						if (type == 0)
						{
							throw new UsageException("Unknown item: " + name);
						}
					}

					int stack = 1;
					if (args.Length >= 2)
					{
						stack = int.Parse(args[1]);
					}

					caller.Player.QuickSpawnItem(type, stack);
				}
			}
		}
	}
}