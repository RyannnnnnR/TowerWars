using System;
namespace MyGame
{
	public class Mage : Unit, SpellCaster
	{
		public Fireball fireball;//List of fireballs
		private float spellDmg = 10;
		public Mage () : base ("mageBmp", "walkingScrpt", 0.4f, 0, false)
		{
		}

		public bool inRange (Unit enemy) {
			float fieldOfView = getX () + 430;
			return fieldOfView >= enemy.getX ();
		}

		public void Cast ()
		{
			if (fireball == null) {
				fireball = new Fireball (this, getX ());
			}
			fireball.draw ();

		}
		public float SpellDmg { 
			get { return spellDmg; }
			set { SpellDmg = value; }
		}
		public override string getName ()
		{
			return "mage";
		}
	}
}
