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
	public class SummonCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "summon";

		public override string Usage
			=> "/summon type [x] [y] [number]\nx and y may be preceded by ~ to use position relative to player";

		public override string Description
			=> "Spawn an npc";

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableSummonCommand)
			{
				if (!GetInstance<ConfigClient>().DisableSummonCommand)
				{
					if (!int.TryParse(args[0], out int type))
				{
					throw new UsageException(args[0] + " is not an integer");
				}

				int x;
				int y;
				var num = 1;
					if (args.Length > 2)
					{
						var relativeX = false;
						var relativeY = false;
						if (args[1][0] == '~')
						{
							relativeX = true;
							args[1] = args[1].Substring(1);
						}
						if (args[2][0] == '~')
						{
							relativeY = true;
							args[2] = args[2].Substring(1);
						}
						if (!int.TryParse(args[1], out x))
						{
							x = 0;
							relativeX = true;
						}
						if (!int.TryParse(args[2], out y))
						{
							y = 0;
							relativeY = true;
						}
						if (relativeX)
						{
							x += (int)caller.Player.Bottom.X;
						}

						if (relativeY)
						{
							y += (int)caller.Player.Bottom.Y;
						}

						if (args.Length > 3)
						{
							if (!int.TryParse(args[3], out num))
							{
								num = 1;
							}
						}
						else
						{
							x = (int)caller.Player.Bottom.X;
							y = (int)caller.Player.Bottom.Y;
						}
						for (var k = 0; k < num; k++)
						{
							int slot = NPC.NewNPC(x, y, type);
							//if (Main.netMode == 2 && slot < 200)
							//	NetMessage.SendData(MessageID.SyncNPC, -1, -1, "", slot);
						}
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableSummonCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					int x;
					int y;
					var num = 1;
					if (args.Length > 2)
					{
						var relativeX = false;
						var relativeY = false;
						if (args[1][0] == '~')
						{
							relativeX = true;
							args[1] = args[1].Substring(1);
						}
						if (args[2][0] == '~')
						{
							relativeY = true;
							args[2] = args[2].Substring(1);
						}
						if (!int.TryParse(args[1], out x))
						{
							x = 0;
							relativeX = true;
						}
						if (!int.TryParse(args[2], out y))
						{
							y = 0;
							relativeY = true;
						}
						if (relativeX)
						{
							x += (int)caller.Player.Bottom.X;
						}

						if (relativeY)
						{
							y += (int)caller.Player.Bottom.Y;
						}

						if (args.Length > 3)
						{
							if (!int.TryParse(args[3], out num))
							{
								num = 1;
							}
						}
						else
						{
							x = (int)caller.Player.Bottom.X;
							y = (int)caller.Player.Bottom.Y;
						}
						for (var k = 0; k < num; k++)
						{
							int slot = NPC.NewNPC(x, y, type);
							//if (Main.netMode == 2 && slot < 200)
							//	NetMessage.SendData(MessageID.SyncNPC, -1, -1, "", slot);
						}
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableSummonCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					int x;
					int y;
					var num = 1;
					if (args.Length > 2)
					{
						var relativeX = false;
						var relativeY = false;
						if (args[1][0] == '~')
						{
							relativeX = true;
							args[1] = args[1].Substring(1);
						}
						if (args[2][0] == '~')
						{
							relativeY = true;
							args[2] = args[2].Substring(1);
						}
						if (!int.TryParse(args[1], out x))
						{
							x = 0;
							relativeX = true;
						}
						if (!int.TryParse(args[2], out y))
						{
							y = 0;
							relativeY = true;
						}
						if (relativeX)
						{
							x += (int)caller.Player.Bottom.X;
						}

						if (relativeY)
						{
							y += (int)caller.Player.Bottom.Y;
						}

						if (args.Length > 3)
						{
							if (!int.TryParse(args[3], out num))
							{
								num = 1;
							}
						}
						else
						{
							x = (int)caller.Player.Bottom.X;
							y = (int)caller.Player.Bottom.Y;
						}
						for (var k = 0; k < num; k++)
						{
							int slot = NPC.NewNPC(x, y, type);
							//if (Main.netMode == 2 && slot < 200)
							//	NetMessage.SendData(MessageID.SyncNPC, -1, -1, "", slot);
						}
					}
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableSummonCommand)
				{
					if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}

					int x;
					int y;
					var num = 1;
					if (args.Length > 2)
					{
						var relativeX = false;
						var relativeY = false;
						if (args[1][0] == '~')
						{
							relativeX = true;
							args[1] = args[1].Substring(1);
						}
						if (args[2][0] == '~')
						{
							relativeY = true;
							args[2] = args[2].Substring(1);
						}
						if (!int.TryParse(args[1], out x))
						{
							x = 0;
							relativeX = true;
						}
						if (!int.TryParse(args[2], out y))
						{
							y = 0;
							relativeY = true;
						}
						if (relativeX)
						{
							x += (int)caller.Player.Bottom.X;
						}

						if (relativeY)
						{
							y += (int)caller.Player.Bottom.Y;
						}

						if (args.Length > 3)
						{
							if (!int.TryParse(args[3], out num))
							{
								num = 1;
							}
						}
						else
						{
							x = (int)caller.Player.Bottom.X;
							y = (int)caller.Player.Bottom.Y;
						}
						for (var k = 0; k < num; k++)
						{
							int slot = NPC.NewNPC(x, y, type);
							//if (Main.netMode == 2 && slot < 200)
							//	NetMessage.SendData(MessageID.SyncNPC, -1, -1, "", slot);
						}
					}
				}
			}
		}
	}
}
