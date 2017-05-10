using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main ()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow ("TowerWars", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();
			SwinGame.LoadResourceBundle ("characterbundle.txt");
			GameManager manager = new GameManager ();
			Currency currency = new Currency (manager);
			TeamManager teamManager = new TeamManager ();
			ErrorManager errManager = new ErrorManager ();
			DeploymentManager deployManager = new DeploymentManager (manager, currency, teamManager, errManager);
			GamePainter painter = new GamePainter (manager, currency);

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				painter.Paint ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Console.WriteLine (SwinGame.MouseX () + " " + SwinGame.MouseY());
				}
				//Paint all elements on to the screen
				deployManager.handleInput (SwinGame.MousePosition ());
				//deployManager.SpawnRandomEnemy ();
				if (teamManager.heros.Count > 0) {

					foreach (Unit unit in teamManager.heros) {
						if (unit.getName () == "ninja") {							unit.move ();
							unit.SetLocation (SwinGame.SpriteX (unit.Spirte) + 0.6f, Position.SPAWN_Y);
						} else if (unit.getName () == "healer") {
							unit.move ();
							unit.SetLocation (SwinGame.SpriteX (unit.Spirte) + 0.3f, Position.SPAWN_Y);
						}
						unit.move ();
						unit.SetLocation (SwinGame.SpriteX (unit.Spirte) + 0.5f, Position.SPAWN_Y);
					}
				}
				if (teamManager.enemies.Count > 0) {

					foreach (Unit unit in teamManager.enemies) {
						unit.move ();
					}
				}

					errManager.handleError ();
					currency.update ();
					SwinGame.DrawFramerate (0, 0);
					//SwinGame.ClearScreen ();

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
			}
		}
	}
}