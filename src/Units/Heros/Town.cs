using System;
namespace MyGame
{
	public class Town : Unit, PhysicalAttcker
	{
		public Town () : base("townBmp", "walkingScrpt")
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

		public override string getName ()
		{
			return "town";
		}
	}
}
