using System;
namespace MyGame
{
	public class Lizard : Unit
	{
		public Lizard () : base("lizardBmp", "walkingScrpt", -0.4f, 5, true)
		{
		}

		public override string getName ()
		{
			return "lizard";
		}
	}
}
