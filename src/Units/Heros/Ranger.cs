using System;
namespace MyGame
{
	public class Ranger : Unit
	{
		public Ranger () : base("rangerBmp", "walkingScrpt", 0.45f)
		{
		}

		public override int Dmg {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();

			}
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
