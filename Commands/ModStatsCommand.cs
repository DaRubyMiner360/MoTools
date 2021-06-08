using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MoTools.Commands
{
	public class ModStatsCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "modstats";

		public override string Usage
			=> "/modstats";

		public override string Description
			=> "Gives the amount of different things in The Celestial Overtaking";

		public override void Action(CommandCaller caller, string input, string[] args) {
			int items       = 0;
			int npcs        = 0;
			int tiles       = 0;
			int walls       = 0;
			int buffs       = 0;
			int mounts      = 0;
			int projectiles = 0;
			int commands    = 0;

			typeof(ModNPC).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModNPC))).Select(t => npcs++);
			typeof(ModItem).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModItem))).Select(t => items++);
			typeof(ModTile).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModTile))).Select(t => tiles++);
			typeof(ModWall).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModWall))).Select(t => walls++);
			typeof(ModBuff).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModBuff))).Select(t => buffs++);
			typeof(ModMountData).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModMountData))).Select(t => mounts++);
			typeof(ModProjectile).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModProjectile))).Select(t => projectiles++);
			typeof(ModCommand).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ModCommand))).Select(t => commands++);

			Main.NewText(items);
			Main.NewText(npcs);
			Main.NewText(tiles);
			Main.NewText(walls);
			Main.NewText(buffs);
			Main.NewText(mounts);
			Main.NewText(projectiles);
			Main.NewText(commands);
		}
	}
}