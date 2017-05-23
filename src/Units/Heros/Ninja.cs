using System;
namespace MyGame
{
	//Ranged or physical????
	public class Ninja : Unit
	{
	public Ninja () :base("ninjaBmp", "ninjaRunninScrpt", 0.5f, 20, false)
		{
		}

		public override string getName ()
		{
			return "ninja";
		}
	}
}
