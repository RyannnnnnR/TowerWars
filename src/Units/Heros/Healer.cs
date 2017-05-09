using System;
namespace MyGame
{
	public class Healer : Unit, SpellCaster
	{
		public Healer () :base("healerBmp", "healerWalkingScrpt")
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

		public override string getName ()
		{
			throw new NotImplementedException ();
		}
	}
}
