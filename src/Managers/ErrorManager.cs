using System;
using SwinGameSDK;

namespace MyGame
{
	public class ErrorManager
	{	
		private int delay = 180;
		private string error = "";
		public ErrorManager ()
		{
		}
		public void handleErrors () {
			delay--;
			SwinGame.DrawText (Error, Color.Red, Position.ERROR_X, Position.ERROR_Y);
			if (delay == 0) {
				Error = "";
				delay = 180;
			}
		}
		public string Error { 
			get { return error;}
			set { error = value;}
		}
	}
}
