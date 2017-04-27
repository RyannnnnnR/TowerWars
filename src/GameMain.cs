using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			//Open the game window
			SwinGame.SetIcon ("icon.png");
            SwinGame.OpenGraphicsWindow("TowerWars", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
			GamePainter painter = new GamePainter (null);
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
				//Paint all elements on to the screen
				if(SwinGame.MouseClicked(MouseButton.LeftButton))
					Console.WriteLine (SwinGame.MouseX() + " " + SwinGame.MouseY ());
				
				painter.paintStartSequence ();
                //SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}