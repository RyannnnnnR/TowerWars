using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Defines the cactus enemy
	/// </summary>
	public class Cactus : Unit
	{

		public Cactus () : base ("cactusBmp","walkingScrpt", -0.40f, 7, true)
		{
		}

		public override string getName ()
		{
			return "cactus";
		}
	}
}
