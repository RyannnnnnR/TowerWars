using System;
namespace MyGame
{
	/// <summary>
	/// Defines ninja hero character
	/// </summary>
	public class Ninja : Unit
	{
	public Ninja () :base("ninjaBmp", "ninjaRunningScrpt", 0.5f, 20, false)
		{
		}

		public override string getName ()
		{
			return "ninja";
		}
	}
}
