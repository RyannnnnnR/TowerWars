using System;
namespace MyGame
{
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
