using System;
namespace MyGame
{
	/// <summary>
	/// Defines ranger hero character
	/// </summary>
	public class Ranger : Unit
	{
		private Arrow arrow;
		private int delay = 30;
		private float arrowDmg = 8;
		public Ranger () : base("rangerBmp", "walkingScrpt", 0.45f, 3, false)
		{
		}
		/// <summary>
		/// Checks if enemy is in range this character
		/// </summary>
		/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
		/// <param name="enemy">Enemy.</param>
		public bool inRange (Unit enemy)
		{
			float fieldOfView = getX () + 350;
			return fieldOfView >= enemy.getX ();
		}
		/// <summary>
		/// Checks if the tower is in range of this character
		/// </summary>
		/// <returns><c>true</c>, if range was ined, <c>false</c> otherwise.</returns>
		/// <param name="tower">Tower.</param>
		public bool inRange (Tower tower)
		{
			float fieldOfView = getX () + 250;
			return fieldOfView >= tower.X;
		}
		/// <summary>
		/// Launches arrows
		/// </summary>
		public void attack ()
		{
			delay--;
			if (arrow == null && delay == 0) {
				arrow = new Arrow (this);
			}
			if (arrow != null) {
				arrow.draw ();
				delay = 30;//Shoot every half a second.
			}
		}
		/// <summary>
		/// Gets the arrow dmg.
		/// </summary>
		/// <value>The arrow dmg.</value>
		public float ArrowDmg {
			get {
				return arrowDmg;
			}
		}
		/// <summary>
		/// Gets or sets the arrow object
		/// </summary>
		/// <value>The arrow.</value>
		public Arrow Arrow {
			set { arrow = value; }
			get {
				return arrow;
			}
		}
		public override string getName ()
		{
			return "ranger";
		}
	}
}
