using System;
using SwinGameSDK;

namespace MyGame
{
	public class Warrior : Unit, PhysicalAttcker
	{
		public Warrior () : base ("warriorBmp", "walkingScrpt")
		{
		}

		public int dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public int attack ()
		{
			throw new NotImplementedException ();
		}

	}
}
