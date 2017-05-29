using System;
namespace MyGame
{
	/// <summary>
	/// Creates a fireball projectile.
	/// </summary>
	public class Fireball : Projectile
	{
		public Fireball (Unit unit) : base("fireballBmp", "fireballScrpt", 0.9f, unit)
		{
		}
	}
}
