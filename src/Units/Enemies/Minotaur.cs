using System;
namespace MyGame
{
	/// <summary>
	/// Defines minotaur enemy character
	/// </summary>
	public class Minotaur : Unit
	{
		public Minotaur () : base ("minotaurBmp", "walkingScrpt", -0.4f, 5, true)
		{
		}


		public override string getName ()
		{
			return "minotaur";
		}
	}
}
