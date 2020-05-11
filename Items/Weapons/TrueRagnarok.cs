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
	public class TrueRagnarok : ModItem
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
			DisplayName.SetDefault("True Ragnarok"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The true form of the blade of Doomsday.");
		}

		public override void SetDefaults() 
		{
			item.damage = 230;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 1;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 1f;
			//item.shoot = ModContent.ProjectileType<HolyBlade>();
			//item.shoot = ModContent.ProjectileType<RagnarokProjectile>();
			//item.shoot = mod.ProjectileType("TrueRagnarokProjectile");
			item.shoot = mod.ProjectileType("TrueNightmareMagicCentral");
			item.shoot = 10;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			player.AddBuff(BuffID.Rage, 120);
			player.AddBuff(BuffID.Battle, 120);
			player.AddBuff(BuffID.Archery, 120);
			player.AddBuff(BuffID.Summoning, 120);
			player.AddBuff(BuffID.Dangersense, 120);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			{
				int numberProjectiles = 1;
				type = mod.ProjectileType("HolyBlade");
				for (int i = 0; i < numberProjectiles; i++)
				type = mod.ProjectileType("RagnarokProjectile");
				for (int i = 0; i < numberProjectiles; i++)
				type = mod.ProjectileType("TrueRagnarokProjectile");
				for (int i = 0; i < numberProjectiles; i++)
				{
					{
						Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
						Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					}
				}
				return false;
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Meowmere, 1);
			recipe.AddIngredient(ItemID.StarWrath, 1);
			recipe.AddIngredient(ItemID.PortalGun, 1);
			recipe.AddIngredient(ItemID.WormholePotion, 1);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.CelestialSigil, 1);
			recipe.AddIngredient(ItemID.MoonLordTrophy, 1);
			recipe.AddIngredient(ItemID.BossMaskMoonlord, 1);
			recipe.AddIngredient(ItemID.BossMaskCultist, 1);
			recipe.AddIngredient(ItemID.AncientCultistTrophy, 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 2);
			recipe.AddIngredient(mod, "Ragnarok", 1);
			//recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}