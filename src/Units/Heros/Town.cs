using System;
namespace MyGame
{
	public class Town : Unit
	{
		private int dmg;
		public Town (int dmg) : base("townBmp", "walkingScrpt", 0.40f)
		{
			this.dmg = dmg;
		}

		public override int Dmg {
			get {
				return dmg;
			}

			set {
				dmg = value;
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
