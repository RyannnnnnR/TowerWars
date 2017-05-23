using System;
namespace MyGame
{
	public class Mage : Unit, SpellCaster
	{
		public Fireball fireball;//List of fireballs
		public Mage () : base ("mageBmp", "walkingScrpt", 0.4f, 15, false)
		{
			//Field of view
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
			if (fireball == null) {//Make fireballs smaller
				fireball = new Fireball (this, getX ());
			}
				fireball.draw ();
		}

		public override string getName ()
		{
			return "mage";
		}
	}
}
