using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Keeps track of various game elements, such as the game ending and unit cells.
	/// </summary>
	public class GameManager
	{
		private List<UnitCell> unitcells;
		private bool running = true;
		private bool playerWon;
		private Random rand = new Random ();
		private Sprite firework = null;

		public GameManager ()
		{
			unitcells = new List<UnitCell> ();
		}
		/// <summary>
		/// Adds a unit cell to a list
		/// </summary>
		/// <param name="cell">A unit cell</param>
		public void AddUnitCell (UnitCell cell) {
			unitcells.Add (cell);
		}
		/// <summary>
		/// Gets a list of unit cells
		/// </summary>
		/// <value>The unit cells.</value>
		public List<UnitCell> UnitCells {
			get {
				return unitcells;
			}
		}
		/// <summary>
		/// Creates a firework sprite for the game ending.
		/// </summary>
		/// <returns>A sprite with the firework data</returns>
		public Sprite createFireWork () {
			Sprite sprite = SwinGame.CreateSprite (SwinGame.BitmapNamed ("fireworksBmp"), SwinGame.AnimationScriptNamed ("fireworksScrpt"));
			SwinGame.SpriteStartAnimation (sprite, "firework_start");
			SwinGame.SpriteSetX (sprite,rand.Next(10,790));
			SwinGame.SpriteSetY (sprite,rand.Next(10, 250));
			return sprite;
		}
		/// <summary>
		/// Prints outcome of game to player
		/// </summary>
		/// <remarks>
		/// Draws fireworks if player wins.
		/// </remarks>
		public void drawWinLoseMessage () {
				if (PlayerWon) {
				SwinGame.DrawText (Messages.WIN_MESSAGE, Color.White, 300, 130);
					if (firework == null) {
						firework = createFireWork ();
					}
					SwinGame.DrawSprite (firework);
					SwinGame.UpdateSprite (firework);
					if (firework.AnimationHasEnded) {
						SwinGame.FreeSprite (firework);
						firework = null;
					}
				} else {
					SwinGame.DrawText (Messages.LOSE_MESSAGE, Color.DarkRed, 300, 130);
				}
		}
		/// <summary>
		/// Returns the outcome of the game
		/// </summary>
		/// <value>A boolean value if the player won</value>
		public bool PlayerWon { 
			set { playerWon = value;}
			get { return playerWon; }
		}
		/// <summary>
		/// Keeps track of if the game is running.
		/// </summary>
		/// <value>A boolean value if the game is running.</value>
		public bool Running {
			set { running = value;}
			get {
				return running;
			}
		}
	}
}
