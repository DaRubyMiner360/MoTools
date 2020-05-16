using MoTools.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Weapons
{
	public class ERR0RYoyo : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("ERR0R");
			Tooltip.SetDefault("TH3 Y0YO 0F ERR0RS\n101011100000101010100011\nHACK1NG C0MPL3TE!");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 574;
			item.rare = 0;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 1);
			item.shoot = ProjectileType<ERR0RYoyoProjectile>();
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy};

		public override bool AllowPrefix(int pre) {
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1) {
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 30);
			recipe.AddIngredient(ItemID.CobaltBar, 30);
			recipe.AddIngredient(ItemID.MythrilBar, 30);
			recipe.AddIngredient(ItemID.LunarBar, 30);
			recipe.AddIngredient(mod, "The404Essence", 30);
			recipe.AddIngredient(mod, "The404Ore", 30);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.AddTile(mod, "The404Forge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
