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
			//Load images and animations
			SwinGame.LoadResourceBundle ("characterbundle.txt");
			//Initialise all game components
			GameManager manager = new GameManager ();
			Currency currency = new Currency (manager);
			TeamManager teamManager = new TeamManager ();
			ErrorManager errManager = new ErrorManager ();
			HomeTower home = new HomeTower ();
			EnemyTower enemy = new EnemyTower ();
			HealthManager healthManager = new HealthManager (teamManager, home, enemy);
			CollisionManager collisionManager = new CollisionManager (manager, teamManager, healthManager, home, enemy);
			DeploymentManager deployManager = new DeploymentManager (manager, currency, teamManager, errManager);
			GamePainter painter = new GamePainter (manager, currency);
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				//Paint all elements on to the screen
				painter.Paint ();

				//Handle game over
				if (manager.Running) {
					deployManager.handleInput (SwinGame.MousePosition ());
					deployManager.spawnUnits ();
					collisionManager.handleCollisions ();
					errManager.handleErrors ();
					currency.update ();
				} else {
					teamManager.clearTeams ();
					manager.drawWinLoseMessage ();
				}
				//Keep bases/health on screen, all the time.
				painter.paintHomeBase (Position.HOME_BASE_X, Position.HOME_BASE_Y);
				painter.paintEnemeyBase (Position.ENEMY_BASE_X, Position.ENEMY_BASE_Y);
				healthManager.updateHealth ();
				SwinGame.DrawFramerate (0, 0);

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
				}
			}
		}
}