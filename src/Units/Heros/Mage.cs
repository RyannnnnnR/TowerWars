using System;
namespace MyGame
{
	/// <summary>
	/// Defines mage hero class
	/// </summary>
	/// <remarks>
	/// My personal favourite, so its a bit over powered
	/// </remarks>
	public class Mage : Unit
	{
		public Fireball fireball;
		private float spellDmg = 10;
		private int delay = 60;
		public Mage () : base ("mageBmp", "walkingScrpt", 0.4f, 0, false)
		{
		}
		/// <summary>
		/// Checks to see if mage is in range of enemy
		/// </summary>
		/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
		/// <param name="enemy">Enemy.</param>
		public bool inRange (Unit enemy) {
			float fieldOfView = getX () + 500;
			return fieldOfView >= enemy.getX ();
		}
		/// <summary>
		/// Checks to see if mage is in range of tower
		/// </summary>
		/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
		/// <param name="tower">Tower.</param>
		public bool inRange (Tower tower) { 
			float fieldOfView = getX () + 250;
			return fieldOfView >= tower.X;
		}
		/// <summary>
		/// Launches fireball
		/// </summary>
		public void Cast ()
		{
			delay--;	
				if (fireball == null && delay == 0) {
				fireball = new Fireball (this);
			}
			if (fireball != null) {
				fireball.draw ();
				delay = 30;//Shoot every half a second.
			}
				
		}
		/// <summary>
		/// Gets the spell dmg.
		/// </summary>
		/// <value>The spell dmg.</value>
		public float SpellDmg { 
			get { 
				return spellDmg; 
			}
		}
		public override string getName ()
		{
			return "mage";
		}
	}
}
