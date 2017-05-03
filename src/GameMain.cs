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
			DeploymentManager deployManager = new DeploymentManager ();
			GamePainter painter = new GamePainter (manager, currency);
			Warrior warrior = new Warrior ();
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				//Paint all elements on to the screen
				painter.Paint ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Console.WriteLine (SwinGame.MouseX () + " " + SwinGame.MouseY ());
					while (true) {
						SwinGame.ProcessEvents ();
						painter.Paint ();
						warrior.move (0.5f);
						SwinGame.RefreshScreen (60);
					}
				}
				//warrior.move (0.5f);
					currency.update ();
					SwinGame.DrawFramerate (0, 0);
					//SwinGame.ClearScreen ();

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
				manager.UnitCells.Clear ();
			}
		}
	}
}