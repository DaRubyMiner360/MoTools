using Terraria.Graphics.Effects;
using Terraria.ID;
using System;
using System.IO;
using Terraria.UI;
using System.Collections.Generic;
using MoTools.Items.Consumables;
using MoTools.Items.Placeable;
using MoTools.Items;
//using MoTools.Items.Placeable.MusicBoxes;
//using MoTools.Tiles.MusicBoxes;
using MoTools.Projectiles.Accessories;
using MoTools.Projectiles;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MoTools.Items.MythicDamageClass
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
	public class MythicDamagePlayer : ModPlayer
	{
		public static MythicDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<MythicDamagePlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float mythicDamageAdd;
		public float mythicDamageMult = 1f;
		public float mythicKnockback;
		public int mythicCrit;

		// Here we include a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our mythic resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
		public int mythicResourceCurrent;
		public const int DefaultMythicResourceMax = 100;
		public int mythicResourceMax;
		public int mythicResourceMax2;
		public float mythicResourceRegenRate;
		internal int mythicResourceRegenTimer = 0;
		public static readonly Color HealMythicResource = new Color(187, 91, 201); // We can use this for CombatText, if you create an item that replenishes mythicResourceCurrent.

		/*
		In order to make the Mythic Resource mythic straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		Here are additional things you might need to implement if you intend to make a custom resource:
		- Multiplayer Syncing: The current mythic doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and clientClone will be necessary, as well as SyncPlayer if you allow the user to increase mythicResourceMax.
		- Save/Load and increased max resource: You'll need to implement Save/Load to remember increases to your mythicResourceMax cap.
		- Resouce replenishment item: Use GlobalNPC.NPCLoot to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.
		*/

		public override void Initialize() {
			mythicResourceMax = DefaultMythicResourceMax;
		}
		
		public override TagCompound Save()
        {
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
                {"mythicResourceCurrent", mythicResourceCurrent},
            };
            //note that C# 6.0 supports indexer initializers
            //return new TagCompound {
            //	["score"] = score
            //};
        }
		
		public override void Load(TagCompound tag)
        {
            mythicResourceCurrent = tag.GetInt("mythicResourceCurrent");
        }

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			mythicDamageAdd = 0f;
			mythicDamageMult = 1f;
			mythicKnockback = 0f;
			mythicCrit = 0;
			mythicResourceRegenRate = 1f;
			mythicResourceMax2 = mythicResourceMax;
		}

		public override void PostUpdateMiscEffects() {
			UpdateResource();
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource() {
			// For our resource lets make it regen slowly over time to keep it simple, let's use mythicResourceRegenTimer to count up to whatever value we want, then increase currentResource.
			mythicResourceRegenTimer++; //Increase it by 60 per second, or 1 per tick.

			// A simple timer that goes up to 3 seconds, increases the mythicResourceCurrent by 1 and then resets back to 0.
			if (mythicResourceRegenTimer > 180 * mythicResourceRegenRate) {
				mythicResourceCurrent += 2;
				mythicResourceRegenTimer = 0;
			}

			// Limit mythicResourceCurrent from going over the limit imposed by mythicResourceMax.
			mythicResourceCurrent = Utils.Clamp(mythicResourceCurrent, 0, mythicResourceMax2);
		}
	}
}
