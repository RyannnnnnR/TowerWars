using System;
using SwinGameSDK;

namespace MyGame
{
	public class Cactus : Unit
	{
		private float dmg;

		public Cactus (int dmg) : base ("cactusBmp","walkingScrpt", -0.40f, 5, true)
		{
			this.dmg = dmg;
		}

		public override string getName ()
		{
			return "cactus";
		}
	}
}
