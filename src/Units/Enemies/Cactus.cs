using System;
namespace MyGame
{
	public class Cactus : Unit
	{
		private float dmg;
		public Cactus (int dmg) : base ("cactusBmp", "walkingScrpt", -0.40f)
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

		public override string getName ()
		{
			return "cactus";
		}
	}
}
