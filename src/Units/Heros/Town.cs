using System;
using SwinGameSDK;

namespace MyGame
{
	public class Town : Unit
	{
		private float dmg;
		public Town (int dmg) : base ("townBmp", "walkingScrpt", 0.4f, 5, false)
		{
			this.dmg = dmg;
		}

		public int attack ()
		{
			throw new NotImplementedException ();
		}

		public override string getName ()
		{
			return "town";
		}
	}
}
