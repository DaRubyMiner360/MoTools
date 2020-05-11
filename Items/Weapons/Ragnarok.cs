using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MoTools.Projectiles.Melee;
using MoTools.Tiles;

namespace MoTools.Items.Weapons
{
	public class Ragnarok : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ragnarok"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The blade of Doomsday.");
		}

		public override void SetDefaults() 
		{
			item.damage = 195;
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
			item.shoot = mod.ProjectileType("RagnarokProjectile");
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			int numberProjectiles = Main.rand.Next(3,6);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 118, damage, knockBack, player.whoAmI);
			}


			return false; // return false because we don't want tmodloader to shoot projectile
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
			//recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(mod, "ExtremeForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}