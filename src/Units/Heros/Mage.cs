using System;
namespace MyGame
{
	public class Mage : Unit, SpellCaster
	{
		public Fireball fireball;
		private float spellDmg = 10;
		public Mage () : base ("mageBmp", "walkingScrpt", 0.4f, 0, false)
		{
		}

		public bool inRange (Unit enemy) {
			float fieldOfView = getX () + 200;
			return fieldOfView >= enemy.getX ();
		}
		public bool inRange (Tower tower) { 
			float fieldOfView = getX () + 200;
			return fieldOfView >= tower.X;
		}

		public void Cast ()
		{
			if (fireball == null) {
				fireball = new Fireball (this);
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
