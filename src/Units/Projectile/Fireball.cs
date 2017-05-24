using System;
namespace MyGame
{
	public class Fireball : Projectile
	{
		public Fireball (Unit unit) : base("fireballBmp", "fireballScrpt", Position.HERO_SPAWN_Y, 0.9f, unit)
		{
		}
	}
}
