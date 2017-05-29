using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Creates a skeleton for for units (i.e how they move, their health, how fast they move, etc.)
	/// </summary>
	public abstract class Unit
	{
		private float health = 100.00f;
		private Sprite sprite;
		private float movementSpeeed = 0.0f;
		private float dmg;
		/// <summary>
		/// Defines what units need to be units and sets up essential features for each unit(e.g animation)
		/// </summary>
		/// <param name="bitmap">An image of the character</param>
		/// <param name="animation">The name of the animation used</param>
		/// <param name="movementSpeed">How fast the unit moves</param>
		/// <param name="dmg">How much dmg units output</param>
		/// <param name="enemy">If the unit is an enemy</param>
		/// <remarks>
		/// The enemy flag makes the <seealso cref="MovementDirection"/> redundant as this flag can be checked to dictate movement.
		/// </remarks>
		public Unit (string bitmap, string animation, float movementSpeed, float dmg, bool enemy)
		{
			this.movementSpeeed = movementSpeed;
			sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed (bitmap), SwinGame.AnimationScriptNamed(animation));
			SwinGame.SpriteStartAnimation (sprite, "walking_loop");

			if (enemy) {
				SwinGame.SpriteSetX (sprite, Position.ENEMY_SPAWN_X);
				SwinGame.SpriteSetY (sprite, Position.ENEMY_SPAWN_Y);
			} else {
				SwinGame.SpriteSetX (sprite, Position.HERO_SPAWN_X);
				SwinGame.SpriteSetY (sprite, Position.HERO_SPAWN_Y);
			}

			SwinGame.SpriteSetDX (sprite, movementSpeed);
			this.dmg = dmg;
		}
		/// <summary>
		/// Sets the location of the character
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void SetLocation (float x, float y) {
			SwinGame.SpriteSetX (sprite, x);
			SwinGame.SpriteSetY (sprite, y);
		}
		/// <summary>
		/// Gets the x coordinate of the character
		/// </summary>
		/// <returns>The x value</returns>
		public float getX () {
			return SwinGame.SpriteX (sprite);
		}
		/// <summary>
		/// Gets the y coordinate of the character
		/// </summary>
		/// <returns>The y value</returns>
		public float getY ()
		{
			return SwinGame.SpriteY (sprite);
		}
		/// <summary>
		/// Gets or sets the dmg of a unit
		/// </summary>
		/// <value>The dmg value</value>
		public float Dmg { 
			get { 
				return dmg;
			} 
			set { 
				dmg = value;
			} 
		}
		/// <summary>
		/// Used to identify each type of unit.
		/// </summary>
		/// <returns>unit name</returns>
		public abstract string getName ();
		/// <summary>
		/// Draw the unit to the screen.
		/// </summary>
		public void draw () {
			SwinGame.DrawSprite (sprite);
			SwinGame.UpdateSprite (sprite);
		}
		/// <summary>
		/// Gets or sets the health of a unit
		/// </summary>
		/// <value>The health value</value>
		public float Health {
			get {
				return health;
			}
			set { health = value; }
		}
		/// <summary>
		/// Gets the character
		/// </summary>
		/// <value>The spirte.</value>
		public Sprite Spirte { 
			get { 
				return sprite; 
			}
		}

	}

}
