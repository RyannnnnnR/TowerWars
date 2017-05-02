using System;
namespace MyGame
{
	public class Mage : Unit, SpellCaster
	{
		public Mage () :base("mageBmp", "walkingScrpt")
		{
		}

		public int Mana {
			get {
				throw new NotImplementedException ();
			}

			set {
				throw new NotImplementedException ();
			}
		}

		public int spellDmg {
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
	}
}
