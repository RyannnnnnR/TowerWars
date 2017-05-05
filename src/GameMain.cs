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
			DeploymentManager deployManager = new DeploymentManager (manager, currency, teamManager);
			GamePainter painter = new GamePainter (manager, currency);

			Warrior warrior = new Warrior ();
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				painter.Paint ();
				//Paint all elements on to the screen

				deployManager.handleInput (SwinGame.MousePosition ());
				if (teamManager.heros.Count > 0) {

					foreach (Unit unit in teamManager.heros) {
						unit.move (0.5f);
					}
				}

					
					currency.update ();
					SwinGame.DrawFramerate (0, 0);
					//SwinGame.ClearScreen ();

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
			}
		}
	}
}