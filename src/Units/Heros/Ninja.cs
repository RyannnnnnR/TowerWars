using System;
namespace MyGame
{
	//Ranged or physical????
	public class Ninja : Unit
	{
public Ninja () :base("ninjaBmp", "ninjaRunninScrpt")
		{
		}

		public override string getName ()
		{
			return "ninja";
		}
	}
}
