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
			HomeTower home = new HomeTower ();
			EnemyTower enemy = new EnemyTower ();
			HealthManager healthManager = new HealthManager (teamManager, home, enemy);
			CollisionManager collisionManager = new CollisionManager (manager, teamManager, healthManager, home, enemy);
			DeploymentManager deployManager = new DeploymentManager (manager, currency, teamManager, errManager);
			GamePainter painter = new GamePainter (manager, currency);
			Cactus cact = new Cactus (0);
			cact.Health = 10;
			//teamManager.AddEnemy (cact);
			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();
				painter.Paint ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Console.WriteLine ("HCount:" + teamManager.heros.Count + "Ecount:" + teamManager.enemies.Count);
				}
				//Paint all elements on to the screen
				deployManager.handleInput (SwinGame.MousePosition ());
				deployManager.spawnUnits ();
				collisionManager.handleCollisions ();
				healthManager.updateHealth ();
				painter.paintHomeBase (Position.HOME_BASE_X, Position.HOME_BASE_Y);
				painter.paintEnemeyBase (Position.ENEMY_BASE_X, Position.ENEMY_BASE_Y);
				errManager.handleErrors ();
				currency.update ();
				SwinGame.DrawFramerate (0, 0);

					//Draw onto the screen
					SwinGame.RefreshScreen (60);
				}
			}
		}
}