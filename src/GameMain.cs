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

			HealthManager healthManager = new HealthManager (teamManager);
			CollisionManager collisionManager = new CollisionManager (teamManager, healthManager);
			Cactus cactus = new Cactus (0);
			Town town = new Town (10);
			teamManager.AddHero (town);
			teamManager.AddEnemy (cactus);
			town.SetLocation (100, 100);
			cactus.SetLocation (500, 100);
			DeploymentManager deployManager = new DeploymentManager (manager, currency, teamManager, errManager);
			GamePainter painter = new GamePainter (manager, currency);

			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				painter.Paint ();
				Console.WriteLine (teamManager.heros.Count);
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Console.WriteLine (SwinGame.MouseX () + " " + SwinGame.MouseY ());
				}
				//Paint all elements on to the screen
				deployManager.handleInput (SwinGame.MousePosition ());
				deployManager.spawnUnits ();
				collisionManager.handleCollisions ();
				healthManager.updateHealth ();
				errManager.handleErrors ();
				currency.update ();
				SwinGame.DrawFramerate (0, 0);

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
				}
			}
		}
}