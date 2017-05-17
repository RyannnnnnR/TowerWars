using System;
namespace MyGame
{
	public class Mage : Unit, SpellCaster
	{
		public Mage () : base ("mageBmp", "walkingScrpt", 0.4f)
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

		public int Mana {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}


		public void Cast ()
		{
			throw new NotImplementedException ();
		}

		public override string getName ()
		{
			return "mage";
		}
	}
}
