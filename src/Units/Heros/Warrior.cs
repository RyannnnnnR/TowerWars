using System;
using SwinGameSDK;

namespace MyGame
{
	public class Warrior : Unit
	{
		public Warrior () : base ("warriorBmp", "walkingScrpt", 0.4f)
		{
		}

		public override float Dmg {
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

		public override string getName ()
		{
			return "warrior";
		}
	}
}
