using System;
namespace MyGame
{
	public class Ranger : Unit
	{
		public Ranger () : base("rangerBmp", "walkingScrpt", 0.45f, 10, false)
		{
		}

		public void attack ()
		{
			throw new NotImplementedException ();
		}

		public override string getName ()
		{
			return "ranger";
		}
	}
}
