using System;
namespace MyGame
{
	public class HomeTower : Tower
	{
		public HomeTower () : base(Position.HEALTH_BAR_X, Position.HEALTH_BAR_Y)
		{
			drawHealthBar ();
		}
	}
}
