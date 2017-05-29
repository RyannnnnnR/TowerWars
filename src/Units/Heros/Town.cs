using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Defines town hero character
	/// </summary>
	public class Town : Unit
	{
		public Town () : base ("townBmp", "walkingScrpt", 0.4f, 5, false)
		{
		}


		public override string getName ()
		{
			return "town";
		}
	}
}
