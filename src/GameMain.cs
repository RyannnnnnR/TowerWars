using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			//Open the game window
            SwinGame.OpenGraphicsWindow("TowerWars", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
			GameManager manager = new GameManager ();
			GamePainter painter = new GamePainter (manager);
			Currency currency = new Currency (painter, manager);
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				//Paint all elements on to the screen
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
					Console.WriteLine (SwinGame.MouseX () + " " + SwinGame.MouseY ());
					}

				painter.Paint ();
				currency.update ();
                SwinGame.DrawFramerate(0,0);
				SwinGame.ClearScreen ();
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
			manager.UnitCells.Clear();
        }
    }
}