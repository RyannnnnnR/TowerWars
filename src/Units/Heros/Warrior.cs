using System;
using SwinGameSDK;

namespace MyGame
{
	public class Warrior : Unit
	{
		public Warrior () : base ("warriorBmp", "walkingScrpt", 0.4f, 15, false)
		{
		}

		public int attack ()
		{
			throw new NotImplementedException ();
		}

		public override string getName ()
		{
			return "warrior";
		}
	}
}
