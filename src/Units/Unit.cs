using System;
namespace MyGame
{
	public abstract class Unit
	{
		private int health;
		private int movementSpeed;
		public Unit ()
		{
		}
		public abstract void move ();
	}
}
