using MoTools.Dusts;
using MoTools.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Items.Tools
{
	public class QuasarPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The pickaxe for the ranged class, made of white celestial shards.");
		}

		public override void SetDefaults() {
			item.damage = 125;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.pick = 300;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VortexPickaxe, 1);
			recipe.AddIngredient(ItemType<WhiteCelestialShard>(), 10);
			//recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Sparkle>());
			}
		}
	}
}