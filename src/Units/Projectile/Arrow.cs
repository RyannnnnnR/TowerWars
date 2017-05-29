using System;
namespace MyGame
{
	/// <summary>
	/// Creates an arrow projectile.
	/// </summary>
	public class Arrow : Projectile
	{
		public Arrow (Unit unit) : base("arrowBmp", 0.9f,unit)
		{
		}
	}
}
