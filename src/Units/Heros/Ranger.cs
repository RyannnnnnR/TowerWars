using System;
namespace MyGame
{
	public class Ranger :Unit, RangedAttacker
	{
		public Ranger () : base("rangerBmp", "walkingScrpt")
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
