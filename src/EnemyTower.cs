using System;
namespace MyGame
{
	/// <summary>
	/// Used to keep a physical instance of the Enemy Tower
	/// </summary>
	/// <remarks>
	/// Enemies and heroes need to have their own instance of a tower.
	/// </remarks>
	public class EnemyTower : Tower
	{
		public EnemyTower () : base (Position.ENEMY_BASE_X, Position.ENEMY_BASE_Y)
		{
		}
	}
}
