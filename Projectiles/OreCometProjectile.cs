using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace MoTools.Projectiles
{
	public class OreCometProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 0;
			projectile.scale = 1f;
			projectile.penetrate = 1;
			projectile.timeLeft = 10000;
			projectile.tileCollide = false;
            projectile.friendly = false;
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			MoToolsWorld.instance.OreComet(projectile.position);

			return base.OnTileCollide(oldVelocity);
        }
    }
}