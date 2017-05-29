using System;
namespace MyGame
{
		/// <summary>
		/// Used to keep a physical instance of the Home Tower
		/// </summary>
		/// <remarks>
		/// Enemies and heroes need to have their own instance of a tower.
		/// </remarks>
	public class HomeTower : Tower
	{
		public HomeTower () : base(Position.HOME_BASE_X, Position.HOME_BASE_Y)
		{
		}
	}
}
