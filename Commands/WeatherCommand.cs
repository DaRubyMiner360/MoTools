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
	public class WeatherCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "weather";

		public override string Usage
			=> "/weather weather";

		public override string Description
			=> "Sets the weather";

		public override void Action(CommandCaller caller, string input, string[] args) {
			if (!GetInstance<ConfigServer>().DisableWeatherCommand)
			{
				if (!GetInstance<ConfigClient>().DisableWeatherCommand)
				{
					/*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

					//var type = args[0];
					//if(type == "set")
					//{
					var weather = args[0];
					//int timeint;
					if (weather == "test")
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					else if (weather == "rain")
					{
						Main.raining = true;
					}
					else if (weather == "clear")
					{
						Main.raining = false;
					}
					else
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					//Main.time = timeint;
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
			{
				if (!GetInstance<ConfigClient>().DisableWeatherCommand)
				{
					/*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

					//var type = args[0];
					//if(type == "set")
					//{
					var weather = args[0];
					//int timeint;
					if (weather == "test")
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					else if (weather == "rain")
					{
						Main.raining = true;
					}
					else if (weather == "clear")
					{
						Main.raining = false;
					}
					else
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					//Main.time = timeint;
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
			{
				if (!GetInstance<ConfigClient>().DisableWeatherCommand)
				{
					/*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

					//var type = args[0];
					//if(type == "set")
					//{
					var weather = args[0];
					//int timeint;
					if (weather == "test")
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					else if (weather == "rain")
					{
						Main.raining = true;
					}
					else if (weather == "clear")
					{
						Main.raining = false;
					}
					else
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					//Main.time = timeint;
				}
			}
			else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
			{
				if (!GetInstance<ConfigClient>().DisableWeatherCommand)
				{
					/*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

					//var type = args[0];
					//if(type == "set")
					//{
					var weather = args[0];
					//int timeint;
					if (weather == "test")
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					else if (weather == "rain")
					{
						Main.raining = true;
					}
					else if (weather == "clear")
					{
						Main.raining = false;
					}
					else
					{
						throw new UsageException(args[0] + " is not rain or clear");
					}
					//Main.time = timeint;
				}
			}
		}
	}
}
