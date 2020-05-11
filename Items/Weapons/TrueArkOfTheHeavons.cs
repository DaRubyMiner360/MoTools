using System.IO;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoTools.Projectiles.Melee;
using MoTools.Items.Weapons;

namespace MoTools.Items.Weapons
{
	public class TrueArkOfTheHeavons : ModItem
	{
		byte Uses = 0;

		public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Ark Of The Heavens"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("A blade forged from Heaven and the Ark Of The Heavens to vanquish all evil.");
		}

		public override void SetDefaults() 
		{
			item.damage = 160;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 3f;
			//item.shoot = ModContent.ProjectileType<HolyBlade>();
			item.shoot = mod.ProjectileType("TrueCelestialMagicCentral");
			item.shoot = 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			{
				int numberProjectiles = 2;
				type = mod.ProjectileType("HolyBlade");
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			return false;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddIngredient(ItemID.MythrilBar, 1);
			recipe.AddIngredient(ItemID.WormholePotion, 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddIngredient(mod, "ArkOfTheHeavons", 1);
			//recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
 
 