using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Used to print error messages to the player
	/// </summary>
	public class ErrorManager
	{	
		private int delay = 180;
		private string error = "";
		/// <summary>
		/// Draws the errors to the screen.
		/// </summary>
		public void handleErrors () {
			delay--;
			SwinGame.DrawText (Error, Color.Red, Position.ERROR_X, Position.ERROR_Y);
			if (delay == 0) {
				Error = "";
				delay = 180;
			}
		}
		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>The error message</value>
		public string Error { 
			get { return error;}
			set { error = value;}
		}
	}
}
