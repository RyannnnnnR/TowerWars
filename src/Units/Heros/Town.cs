using System;
namespace MyGame
{
	public class Town : Unit
	{
		private float dmg;
		public Town (int dmg) : base("townBmp", "walkingScrpt", 0.40f, 5)
		{
			this.dmg = dmg;
		}

		public override float Dmg {
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
