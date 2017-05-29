using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Defines warrior hero character
	/// </summary>
	public class Warrior : Unit
	{
		public Warrior () : base ("warriorBmp", "walkingScrpt", 0.4f, 15, false)
		{
		}

		public override string getName ()
		{
			return "warrior";
		}
	}
}
