using System;
namespace MyGame
{
	public class Fireball : Projectile
	{
		public Fireball (Unit unit,float x) : base("fireballBmp", "fireballScrpt", x, Position.HERO_SPAWN_Y, 0.9f, unit)
		{
		}
	}
}
