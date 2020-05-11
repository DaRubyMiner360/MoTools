using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MoTools.Buffs
{
	public class CelestialPet : ModBuff
	{
		public override void SetDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			DisplayName.SetDefault("Baby Celestial");
			Description.SetDefault("\"A Baby Celestial is here to protect you!\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Projectiles.Pets.CelestialPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ProjectileType<Projectiles.Pets.CelestialPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}
