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
	public class TimeSetCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "time-set";

		public override string Usage
			=> "/time-set time";

		public override string Description
			=> "Sets the time";

		public override void Action(CommandCaller caller, string input, string[] args) {
            if (!GetInstance<ConfigServer>().DisableTimeCommand)
            {
                if (!GetInstance<ConfigClient>().DisableTimeCommand)
                {
                    /*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

                    //var type = args[0];
                    //if(type == "set")
                    //{
                    var time = args[0];
                    int timeint;
                    if (time == "test")
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    else if (time == "noon")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "day")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "midnight")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "night")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "dusk")
                    {
                        Main.dayTime = false;
                        timeint = 32400;
                    }
                    else if (time == "dawn")
                    {
                        Main.dayTime = true;
                        timeint = 0;
                    }
                    else
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    Main.time = timeint;
                    /*//}
					//else if(type == "add")
					//{
						/*int time;
						Main.time = Main.time + time;*/
                    //throw new UsageException(args[0] + " is currently incomplete");
                    //}
                }
            }
            else if (Main.player[Main.myPlayer].name == "DaRubyMiner360")
            {
                if (!GetInstance<ConfigClient>().DisableTimeCommand)
                {
                    /*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

                    //var type = args[0];
                    //if(type == "set")
                    //{
                    var time = args[0];
                    int timeint;
                    if (time == "test")
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    else if (time == "noon")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "day")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "midnight")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "night")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "dusk")
                    {
                        Main.dayTime = false;
                        timeint = 32400;
                    }
                    else if (time == "dawn")
                    {
                        Main.dayTime = true;
                        timeint = 0;
                    }
                    else
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    Main.time = timeint;
                    /*//}
					//else if(type == "add")
					//{
						/*int time;
						Main.time = Main.time + time;*/
                    //throw new UsageException(args[0] + " is currently incomplete");
                    //}
                }
            }
            else if (Main.player[Main.myPlayer].name == "DaRubyDefault360")
            {
                if (!GetInstance<ConfigClient>().DisableTimeCommand)
                {
                    /*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

                    //var type = args[0];
                    //if(type == "set")
                    //{
                    var time = args[0];
                    int timeint;
                    if (time == "test")
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    else if (time == "noon")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "day")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "midnight")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "night")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "dusk")
                    {
                        Main.dayTime = false;
                        timeint = 32400;
                    }
                    else if (time == "dawn")
                    {
                        Main.dayTime = true;
                        timeint = 0;
                    }
                    else
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    Main.time = timeint;
                    /*//}
					//else if(type == "add")
					//{
						/*int time;
						Main.time = Main.time + time;*/
                    //throw new UsageException(args[0] + " is currently incomplete");
                    //}
                }
            }
            else if (Main.player[Main.myPlayer].name == "DaRubyMiner360 3.0")
            {
                if (!GetInstance<ConfigClient>().DisableTimeCommand)
                {
                    /*if (!int.TryParse(args[0], out int type))
					{
						throw new UsageException(args[0] + " is not an integer");
					}*/

                    //var type = args[0];
                    //if(type == "set")
                    //{
                    var time = args[0];
                    int timeint;
                    if (time == "test")
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    else if (time == "noon")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "day")
                    {
                        Main.dayTime = true;
                        timeint = 27000;
                    }
                    else if (time == "midnight")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "night")
                    {
                        Main.dayTime = false;
                        timeint = 27000;
                    }
                    else if (time == "dusk")
                    {
                        Main.dayTime = false;
                        timeint = 32400;
                    }
                    else if (time == "dawn")
                    {
                        Main.dayTime = true;
                        timeint = 0;
                    }
                    else
                    {
                        throw new UsageException(args[0] + " is not noon, midnight, dusk, dawn, day, or night");
                    }
                    Main.time = timeint;
                    /*//}
					//else if(type == "add")
					//{
						/*int time;
						Main.time = Main.time + time;*/
                    //throw new UsageException(args[0] + " is currently incomplete");
                    //}
                }
            }
        }
	}
}
